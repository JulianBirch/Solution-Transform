using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions.Commands
{
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

		public abstract ISolutionCommand Restrict(IProjectFilter projectFilter);

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
			var name = StandardRename.GetFileNameWithoutExtension(project.Path.Path);
			var index = name.IndexOf('-');
			return index >= 0
			       	? name.Substring(0, index)
			       	: name;
		}

		
	}
}