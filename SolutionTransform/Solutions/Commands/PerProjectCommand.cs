using System;
using System.Collections.Generic;
using System.Linq;
using SolutionTransform.Api10;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions.Commands
{
	internal class PerProjectCommand : ISolutionCommand
	{
		private readonly IProjectFilter filter;
		private readonly Action<SolutionFile, SolutionProject> processProject;


		public PerProjectCommand(Action<SolutionFile, SolutionProject> processProject)
			: this(new DontFilter(), processProject)
		{
			
		}

		public PerProjectCommand(IProjectFilter filter, Action<SolutionFile, SolutionProject> processProject)
		{
			this.filter = filter;
			this.processProject = processProject;
		}

		public void Process(SolutionFile solutionFile)
		{
			foreach (var project in solutionFile.Projects.ToList().Where(filter.ShouldApply)) {
				processProject(solutionFile, project);
			}
		}

		public ISolutionCommand Restrict(IProjectFilter projectFilter)
		{
			var newFilter = new AndFilter(new IProjectFilter[] {this.filter, projectFilter});
			return new PerProjectCommand(newFilter, processProject);
		}

		class AndFilter : IProjectFilter
		{
			private readonly IEnumerable<IProjectFilter> projectFilters;

			public AndFilter(IEnumerable<IProjectFilter> projectFilters)
			{
				this.projectFilters = projectFilters;
			}

			public bool ShouldApply(SolutionProject project)
			{
				return projectFilters.Select(pf => pf.ShouldApply(project)).Aggregate(true, (x, y) => x && y);
			}
		}
	}
}