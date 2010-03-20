using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Boo.Lang.Compiler;
using SolutionTransform.Api10;
using SolutionTransform.Files;

namespace SolutionTransform.Scripts
{
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

		public int Execute(IEnumerable<string> args, IFileStorage fileSystem) {
			
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
}