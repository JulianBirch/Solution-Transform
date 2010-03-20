using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SolutionTransform.Files;

namespace SolutionTransform.Solutions {
    public class SolutionFile {
        private readonly FilePath solutionPath;
        private readonly IFileStorage fileSystem;
        List<string> preamble;
        List<SolutionChapter> chapters;

        public SolutionFile(FilePath solutionPath, IFileStorage fileSystem, IEnumerable<string> preamble, IEnumerable<SolutionChapter> chapters) {
            if (solutionPath == null)
            {
                throw new ArgumentNullException("solutionPath");
            }
            this.solutionPath = solutionPath;
            this.fileSystem = fileSystem;
            this.preamble = preamble.ToList();
            this.chapters = chapters.ToList();
        }

        public IEnumerable<SolutionProject> Projects {
            get { return chapters.OfType<SolutionProject>(); }
        }

        public IEnumerable<string> Lines() {
            var result = new List<string>();
            result.AddRange(preamble);
            result.AddRange(Projects.SelectMany(c => c.Lines()));
            result.AddRange(from c in chapters
                            where !(c is SolutionProject)
                            from l in c.Lines()
                            select l);
            if (!string.IsNullOrEmpty(result[0]))
            {
                result.Insert(0, string.Empty);
            }
            return result;
        }

        internal GlobalChapter Globals {
            get {
                return chapters.OfType<GlobalChapter>().Single();
            }
        }

        public FilePath FullPath {
            get { return solutionPath; }
        }

        public IEnumerable<string> Preamble
        {
            get { return preamble; }
            set { preamble = value.ToList(); }
        }

        public void Remove(SolutionProject project) {
            chapters.Remove(project);
            Globals.ProjectConfigurationPlatforms.Remove(project);
        }

        public void Add(SolutionProject project) {
            chapters.Add(project);
            Globals.ProjectConfigurationPlatforms.Add(project);
        }

        internal void Save(FilePath destination) {
            fileSystem.Save(destination, Lines());
            
        }
    }
}
