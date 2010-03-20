using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Boo.Lang.Compiler;
using SolutionTransform.Api10;

namespace SolutionTransform.Scripts {
	interface IScriptProvider {
		IScript FindScript(string scriptName);

		IEnumerable<IScript> AllScripts { get; }
	}



	interface IScript
	{
		string Name { get; }
		string Location { get; }
		int Execute(IEnumerable<string> arguments, IFileSystem fileSystem);
	}

	class BooScript : IScript
	{
		private readonly string name;
		private readonly string location;
		private readonly string content;

		public BooScript(string name, string location, string content)
		{
			this.name = name;
			this.location = location;
			this.content = content;
		}

		public int Execute(IEnumerable<string> args, IFileSystem fileSystem) {
			
			try {
				var interpreter = new Boo.Lang.Interpreter.InteractiveInterpreter2();

				var parser = new BooCommandLineParser(interpreter, args.ToArray());
				var api10 = new Api(parser, fileSystem);
				// api10.Parameters();

				interpreter.SetValue("api10", api10);

				
				CompilerContext context;
				try {
					context = interpreter.Eval(content);
				} catch (TargetInvocationException ex) {
					if (ex.InnerException == null) {
						throw ex.InnerException;
					}
					throw;
				}
				foreach (var e in context.Errors) {
					Console.WriteLine(e.ToString());
				}
				if (context.Errors.Count != 0) {
					return 2;
				}
			} catch (NonErrorTerminationException) {
				return 0;
			} catch (Exception ex) {
				WriteException(Console.Out, ex);
				return 1;
			}
			return 0;
		}

		static void WriteException(TextWriter writer, Exception ex) {
			writer.WriteLine(ex.Message);
			writer.WriteLine();
			writer.WriteLine(ex.StackTrace);
			var inner = ex.InnerException;
			if (inner != null) {
				writer.WriteLine("======");
				WriteException(writer, inner);
			}
		}

		public string Name
		{
			get { return name; }
		}

		public string Location
		{
			get { return location; }
		}
	}

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
