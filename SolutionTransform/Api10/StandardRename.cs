using System.IO;
using System.Text.RegularExpressions;
using SolutionTransform.Model;

namespace SolutionTransform.Api10
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


        public string RenameCsproj(string csproj)
        {
            string name = Path.GetFileNameWithoutExtension(csproj);
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
            return RenameCsproj(name);
        }

        public string RenameProjectName(string name)
        {
            int index = name.IndexOf(delimiter);
            return string.Concat(
                index < 0 ? name : name.Substring(0, index)
                , string.IsNullOrEmpty(replacement) ? "" : delimiter
                , replacement);
        }
    }
}