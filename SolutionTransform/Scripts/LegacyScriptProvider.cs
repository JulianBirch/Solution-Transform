using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SolutionTransform.Scripts
{
	[System.Obsolete("Should be using the file system provider rather than the legacy one", false)]
	class LegacyScriptProvider : IScriptProvider
	{
		// TODO: Abstract out file location and resource location
		public IScript FindScript(string scriptName)
		{
			if (scriptName == null) {
				throw new ArgumentNullException(@"Script Name should not be null.", "scriptName");
			}
			var scriptFile = scriptName.Contains(".") ? scriptName : scriptName + ".boo";
			var fullPath = FullPath(scriptFile);
			return new BooScript(scriptName, scriptFile, fullPath.FileContent());
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
				throw new FileNotFoundException(string.Format("Couldn't find a script called {0}.", file));
			}
			return FindScript(parent, file);
		}

		public static FilePath GetCurrentPath() {
			var executablePath = Assembly.GetExecutingAssembly().CodeBase;
			return ToLocal(Path.GetDirectoryName(executablePath));
		}

		static FilePath ToLocal(string uriStyle) {
			string result = uriStyle.Replace("/", "\\");
			return new FilePath(result.Substring(6), true);
		}

		public static FilePath FullPath(string file) {
			if (file.Contains("\\")) {
				if (file.Contains(":")) {
					return new FilePath(file, false);
				}
				return GetCurrentPath().File(file);
			}
			return FindScript(GetCurrentPath(), file);
		}

		public IEnumerable<IScript> AllScripts
		{
			get { return Enumerable.Empty<IScript>(); }
		}
	}
}