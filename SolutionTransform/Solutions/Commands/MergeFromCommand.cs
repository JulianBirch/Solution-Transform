using System;
using System.Collections.Generic;
using System.Linq;
using SolutionTransform.Model;
using SolutionTransform.ProjectFile;
using SolutionTransform.Solutions.Commands;

namespace SolutionTransform.Solutions.Commands
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

		public override ISolutionCommand Restrict(IProjectFilter projectFilter) {
			throw new System.NotSupportedException("The MergeFrom command cannot be restricted.");
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
			new PerProjectCommand((s, p) => transform.ApplyTransform(p.XmlFile));
		}

		public ISolutionCommand Restrict(IProjectFilter projectFilter)
		{
			throw new System.NotSupportedException("You can't convert only part of a solution to a different version of Visual Studio.");
		}
	}
}