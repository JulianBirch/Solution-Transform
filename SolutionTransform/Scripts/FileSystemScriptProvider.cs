using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SolutionTransform.Files;
using SolutionTransform.Model;

namespace SolutionTransform.Scripts
{
	internal class FileSystemScriptProvider : IScriptProvider
	{
		private readonly IFileSystem fileSystem;
		private readonly FilePath currentDirectory;

		public FileSystemScriptProvider(IFileSystem fileSystem, FilePath currentDirectory)
		{
			this.fileSystem = fileSystem;
			this.currentDirectory = currentDirectory;
		}

		public IEnumerable<IScript> AllScripts
		{
			get {
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