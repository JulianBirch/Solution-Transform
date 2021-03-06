using System;
using System.IO;
using System.Linq;
using SolutionTransform.Files;
using SolutionTransform.Model;
using SolutionTransform.Solutions.Commands;

namespace SolutionTransform.Solutions.Commands
{
	public class AddProjectCommand : ISolutionCommand {
		private string projectFileName;
		private readonly IFileStorage fileSystem;
		FilePath absolutePath;

		public AddProjectCommand(string projectFileName, IFileStorage fileSystem)
		{
			this.projectFileName = projectFileName;
			this.fileSystem = fileSystem;
			absolutePath = new FilePath(projectFileName, false, true);
		}

		public void Process(SolutionFile solutionFile)
		{
			var basePath = solutionFile.FullPath.Parent;
			var relativePath = absolutePath.PathFrom(basePath);
			var project = new SolutionProject(relativePath, basePath, SolutionProject.CsProjProject, fileSystem);
			// It would be nicer if we could figure out the type by reading the destination file.
			solutionFile.Add(project);
		}

		public ISolutionCommand Restrict(IProjectFilter projectFilter)
		{
			throw new System.NotSupportedException("The add project command cannot be restricted.");
		}
	}
}