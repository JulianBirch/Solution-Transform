using System;
using System.Collections.Generic;
using System.Linq;
using SolutionTransform.Model;
using SolutionTransform.ProjectFile;
using SolutionTransform.Solutions;

namespace SolutionTransform.Api10
{
    public class SolutionTransformer
    {
        private readonly SolutionFile solutionFile;

        public SolutionTransformer(SolutionFile solutionFile)
        {
            this.solutionFile = solutionFile;
        }

        public void Transform(IRename rename, params ISolutionCommand[] solutionCommands) {
            var originalProjects = solutionFile.Projects.ToList();
            var solutionCommand = solutionCommands.Length == 1
                ? solutionCommands[0]
                : new CompositeCommand(solutionCommands);
            solutionCommand.Process(solutionFile);

            SynchronizeProjectReferences(solutionFile.Projects, originalProjects);

            ApplyTransform(new NameTransform(rename));  // Rename the projects and solution

            SaveProjectsAndSolution(rename);
        }

        private void SynchronizeProjectReferences(IEnumerable<SolutionProject> currentProjects, IEnumerable<SolutionProject> originalProjects)
        {
            var addedProjects = currentProjects.Except(originalProjects);
            var removedProjects = originalProjects.Except(currentProjects);
            foreach (var project in addedProjects) {
                ApplyTransform(new ConvertAssemblyToProject(project));
            }
            foreach (var project in removedProjects) {
                ApplyTransform(new ConvertProjectToAssembly(project));
            }
        }

        void ApplyTransform(ITransform transform)
        {
            var command = new TransformCommand(new DontFilter(), transform);
            command.Process(solutionFile);
        }

        private void SaveProjectsAndSolution(IRename rename)
        {
            foreach (var project in solutionFile.Projects.Where(p => !p.IsFolder)) {
                project.Name = rename.RenameSolutionProjectName(project.Name);
                project.Path = new FilePath (rename.RenameCsproj(project.Path.Path), false);
                // Note that project.Path and project.XmlFile.Path have different values....
                var from = project.XmlFile.Path.Path;
                var to = rename.RenameCsproj(from);
                project.XmlFile.Save(to);
                Duplicate(from, to, ".cspscc");
                Duplicate(from, to, ".user");
                
            }
            var destination = rename.RenameSln(solutionFile.FullPath.Path);
            var filePath = new FilePath(destination, false, true);
            solutionFile.Save(filePath);
        }

        private void Duplicate(string from, string to, string extension)
        {

            string fromWithExtension = from + extension;
            var toWithExtension = to + extension;
            if (StringComparer.InvariantCultureIgnoreCase.Equals(fromWithExtension, toWithExtension))
            {
                return;
            }
            if (System.IO.File.Exists(fromWithExtension)) {
                System.IO.File.Copy(fromWithExtension, toWithExtension, true);
            }
        }

        internal FilePath BasePath
        {
            get
            {
                return solutionFile.FullPath.Parent;
            }
        }

        internal SolutionFile Solution
        {
            get { return solutionFile; }
        }
    }
}