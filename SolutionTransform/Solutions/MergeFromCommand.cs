using System;
using System.Collections.Generic;
using System.Linq;
using SolutionTransform.ProjectFile;

namespace SolutionTransform.Solutions
{
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

    class ChangeVisualStudioVersionCommand : ISolutionCommand
    {
        private readonly string[] preamble;

        ChangeVisualStudioVersion transform;

        public ChangeVisualStudioVersionCommand(string[] preamble, string toolsVersion, string productVersion)
        {
            this.preamble = preamble;
            transform = new ChangeVisualStudioVersion(toolsVersion, productVersion);
        }

        public void Process(SolutionFile solutionFile)
        {
            solutionFile.Preamble = preamble;
            new TransformCommand(transform).Process(solutionFile);
        }
    }
}