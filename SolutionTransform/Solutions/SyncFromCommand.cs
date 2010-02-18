using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolutionTransform.Solutions {
    abstract class BaseMergeCommand : ISolutionCommand {
        protected readonly IEnumerable<SolutionProject> fromProjects;

        public BaseMergeCommand(IEnumerable<SolutionProject> fromProjects)
        {
            this.fromProjects = fromProjects.Distinct();
        }

        public void Process(SolutionFile toSolution) {
            foreach (var project in fromProjects) {
                project.Rebase(toSolution.FullPath);
            }
            var reconciliation = new Reconciliation<SolutionProject>();
            reconciliation.Reconcile(fromProjects, toSolution.Projects,
                new BareNameEqualityComparer().Equals);

            ProcessSolution(toSolution, reconciliation);
        }

        protected abstract void ProcessSolution(SolutionFile toSolution, Reconciliation<SolutionProject> reconciliation);

        public class BareNameEqualityComparer : IEqualityComparer<SolutionProject> {
            public bool Equals(SolutionProject x, SolutionProject y)
            {
                return StringComparer.InvariantCultureIgnoreCase.Equals(BareName(x), BareName(y));
            }

            public int GetHashCode(SolutionProject obj)
            {
                return BareName(obj).GetHashCode();
            }
        }


        static string BareName(SolutionProject project) {
            var name = Path.GetFileNameWithoutExtension(project.Path.Path);
            var index = name.IndexOf('-');
            return index >= 0
                ? name.Substring(0, index)
                : name;
        }
    }

    class SyncFromCommand : BaseMergeCommand {
        public SyncFromCommand(SolutionFile fromSolution) : base(fromSolution.Projects)
        {
        }

        

        protected override void ProcessSolution(SolutionFile toSolution, Reconciliation<SolutionProject> reconciliation)
        {
            foreach (var projectPair in reconciliation.Matched) {
                toSolution.Remove(projectPair.Key);
                toSolution.Add(projectPair.Value);
            }
        }
    }

    class MergeFromCommand : BaseMergeCommand {
        public MergeFromCommand(IEnumerable<SolutionFile> fromSolutions)
            : base(fromSolutions.SelectMany(s => s.Projects)) {
        }



        protected override void ProcessSolution(SolutionFile toSolution, Reconciliation<SolutionProject> reconciliation) {
            foreach (var project in reconciliation.Removed) {
                toSolution.Add(project);
            }
        }
    }

    public class Reconciliation<TValue>
    {
        readonly List<TValue> removed = new List<TValue>();

        public IEnumerable<TValue> Removed
        {
            get { return removed; }
        }

        public IEnumerable<TValue> Added
        {
            get { return added; }
        }

        public IEnumerable<KeyValuePair<TValue, TValue>> Matched
        {
            get { return matched; }
        }

        readonly List<TValue> added = new List<TValue>();
        readonly List<KeyValuePair<TValue, TValue>> matched = new List<KeyValuePair<TValue, TValue>>();

        // This is a vastly inefficient implementation, but good enough for solutions with < 50 projects
        public void Reconcile(IEnumerable<TValue> from, IEnumerable<TValue> to, Func<TValue, TValue, bool> isMatch)
        {   
            foreach (var fromProject in from)
            {
                foreach (var toProject in to)
                {
                    if (isMatch(fromProject, toProject))
                    {
                        matched.Add(new KeyValuePair<TValue, TValue>(fromProject, toProject));
                        goto NextFromProject;
                    }
                }
                removed.Add(fromProject);
            NextFromProject:
                int x = 0;
            }
            var matchedTo = matched.Select(x => x.Value).ToList();
            added.AddRange(to.Except(matchedTo));
        }

        
    }
}
