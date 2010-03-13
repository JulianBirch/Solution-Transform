using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SolutionTransform.Model;
using SolutionTransform.Solutions;

namespace SolutionTransform.Api10
{
	internal class BareNameFilter : IProjectFilter
	{
		private readonly IEnumerable<string> projects;

		public BareNameFilter(IEnumerable<string> patterns) 
		{
			var comparer = StringComparison.InvariantCultureIgnoreCase;
			this.projects = patterns.Select(p =>
					p.EndsWith(".csproj", comparer)
				? StandardRename.GetFileNameWithoutExtension(p)
				: p
				);
            
		}

		public bool ShouldApply(SolutionProject project)
		{
			if (project.IsFolder) {
				return false;  // Don't touch folders
			}
			foreach (var validProject in projects) {
				if (IsCorrectProject(project, validProject)) {
					return true;
				}
			}
			return false;
		}

		bool IsCorrectProject(SolutionProject project, string projectName) {
			return StringComparer.InvariantCultureIgnoreCase.Equals(
				StandardRename.GetFileNameWithoutExtension(project.Path.Path),
				projectName);
		}
	}

	
}