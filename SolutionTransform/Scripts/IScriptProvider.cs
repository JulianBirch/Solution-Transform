using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SolutionTransform.Files;

namespace SolutionTransform.Scripts {
	interface IScriptProvider {
		IScript FindScript(string scriptName);

		IEnumerable<IScript> AllScripts { get; }
	}

	

	// This class is intentionally close to 
	internal class FileSystemScriptProvider : IScriptProvider

	{
		private readonly IFileStorage fileSystem;
		private readonly FilePath currentDirectory;

		public FileSystemScriptProvider(IFileStorage fileSystem, FilePath currentDirectory)
		{
			this.fileSystem = fileSystem;
			this.currentDirectory = currentDirectory;
		}

		public IScript FindScript(string scriptName)
		{
			if (scriptName == null) {
				throw new ArgumentNullException(@"Script Name should not be null.", "scriptName");
			}
			var scriptFile = scriptName.Contains(".") ? scriptName : scriptName + ".boo";
			var fullPath = FullPath(scriptFile);
			var fileContent = string.Join("\n", fileSystem.LoadAsLines(fullPath).ToArray());
			return new BooScript(scriptName, scriptFile, fileContent);
		}

		public FilePath FullPath(string file) {
			if (file.Contains("\\")) {
				if (file.Contains(":")) {
					return new FilePath(file, false);
				}
				return currentDirectory.File(file);
			}
			return FindScript(currentDirectory, file);
		}

		private static FilePath FindScript(FilePath path, string file) {
			var searchPath = path.File(file);
			if (File.Exists(searchPath.Path)) {
				return searchPath;
			}
			searchPath = path.Directory("Scripts").File(file);
			if (File.Exists(searchPath.Path)) {
				return searchPath;
			}
			var parent = path.Parent;
			if (parent == null) {
				return null; 
			}
			return FindScript(parent, file);
		}

		public IEnumerable<IScript> AllScripts
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
