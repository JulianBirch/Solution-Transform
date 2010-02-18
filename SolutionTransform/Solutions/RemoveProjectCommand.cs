using System;
using System.IO;
using System.Linq;

namespace SolutionTransform.Solutions
{
    public class AddProjectCommand : ISolutionCommand {
        private string projectFileName;
        private readonly IFileSystem fileSystem;
        FilePath absolutePath;

        public AddProjectCommand(string projectFileName, IFileSystem fileSystem)
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
    }

    public class RemoveProjectCommand : ISolutionCommand {
        private readonly string projectFileName;
        private readonly string projectName;

        public RemoveProjectCommand(string projectFileName) {
            this.projectFileName = projectFileName;
            projectName = Path.GetFileNameWithoutExtension(projectFileName);
        }


        public void Process(SolutionFile solutionFile) {
            var project = solutionFile.Projects.FirstOrDefault(IsCorrectProject);
            if (project != null) {
                solutionFile.Remove(project);
            }
        }

        bool IsCorrectProject(SolutionProject project) {
            return StringComparer.InvariantCultureIgnoreCase.Equals(
                Path.GetFileNameWithoutExtension(project.Path.Path),
                projectName);
        }
    }
}