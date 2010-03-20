using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SolutionTransform.Files;
using SolutionTransform.Model;

namespace SolutionTransform.Scripts
{
	
	internal class ResourceScriptProvider : IScriptProvider
	{
		public IScript FindScript(string scriptName)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<IScript> AllScripts
		{
			get { throw new System.NotImplementedException(); }
		}
	}

	internal class FileSystemScriptProvider : IScriptProvider

	{
		private readonly IFileSystem fileSystem;
		private readonly FilePath currentDirectory;

		public FileSystemScriptProvider(IFileSystem fileSystem, FilePath currentDirectory)
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
			if (fullPath == null)
			{
				return null;  // Couldn't find a script
			}

			return GetScript(fullPath);
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

		private FilePath FindScript(FilePath path, string file) {
			var searchPath = path.File(file);
			
			if (fileSystem.Exists(searchPath)) {
				return searchPath;
			}
			searchPath = path.Directory("Scripts").File(file);
			if (fileSystem.Exists(searchPath)) {
				return searchPath;
			}
			var parent = path.Parent;
			if (parent == null) {
				return null; 
			}
			return FindScript(parent, file);
		}

		IEnumerable<IScript> AllScriptsRaw
		{
			get
			{
				return Parents(currentDirectory)
					.SelectMany(f => {
		                 	var scripts = f.Directory("Scripts");
		                 	return fileSystem.Exists(scripts)
		                 	       	? ScriptsForPath(f).Union(ScriptsForPath(scripts))
		                 	       	: ScriptsForPath(f);
						}
					);
			}
		}

		public IEnumerable<IScript> AllScripts
		{
			get {
				HashSet<string> encounteredNames = new HashSet<string>(new string[0], StringComparer.InvariantCultureIgnoreCase);
				foreach (var script in AllScriptsRaw)
				{
					if (encounteredNames.Contains(script.Name))
					{
						continue;
					}
					yield return script;
					encounteredNames.Add(script.Name);
				}
			}
		}

		public IEnumerable<IScript> ScriptsForPath(FilePath filePath)
		{
			return from f in fileSystem.Files(filePath)
			       where f.Path.EndsWith(".boo", StringComparison.InvariantCultureIgnoreCase)
			       select (IScript) GetScript(f);  // Bring on .NET 4
		}

		BooScript GetScript(FilePath filePath)
		{
			var fileContent = string.Join("\n", fileSystem.LoadAsLines(filePath).ToArray());
			return new BooScript(StandardRename.GetFileNameWithoutExtension(filePath.Path), filePath.Path, fileContent);
		}

		IEnumerable<FilePath> Parents(FilePath filePath)
		{
			yield return filePath;
			while (null != (filePath = filePath.Parent))
			{
				yield return filePath;
			}
		}
	}
}