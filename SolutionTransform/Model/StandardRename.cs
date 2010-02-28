using System.IO;

namespace SolutionTransform.Model
{
    public class StandardRename : IRename {
        private readonly string delimiter;
        private readonly string replacement;

        public StandardRename(string replacement, string delimiter)
        {
            this.replacement = replacement;
            this.delimiter = delimiter;
        }

        public StandardRename(string replacement)
        {
            if (string.IsNullOrEmpty(replacement)) {
                this.replacement = null;
                this.delimiter = "-";
            } else
            {
                this.replacement = replacement.Substring(1);
                this.delimiter = replacement.Substring(0, 1);
            }
        }

        internal static string GetFileNameWithoutExtension(string name)
        {
            var file = Path.GetFileName(name);
            int index = file.LastIndexOf('.');
            return index < 0 ? file : file.Substring(0, index);
        }

        public string RenameCsproj(string csproj)
        {
            string name = GetFileNameWithoutExtension(csproj);
            string newFileName = string.Concat(
                RenameProjectName(name)
                ,Path.GetExtension(csproj))
                ;
            return Path.Combine(Path.GetDirectoryName(csproj), newFileName);
        }

        public string RenameSln(string solutionPath)
        {
            return RenameCsproj(solutionPath);
        }

        public string RenameSolutionProjectName(string name) {
            var csproj = RenameCsproj(name + ".x");
            return csproj.Substring(0, csproj.Length-2);
        }

        public string RenameProjectName(string name)
        {
            int index = name.LastIndexOf(delimiter);
            return string.Concat(
                index < 0 ? name : name.Substring(0, index)
                , string.IsNullOrEmpty(replacement) ? "" : delimiter
                , replacement);
        }
    }
}