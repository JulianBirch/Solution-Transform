using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SolutionTransform.Model;

namespace SolutionTransform.Scripts
{
	internal class ResourceScriptProvider : IScriptProvider
	{
		private readonly Assembly assembly;

		public ResourceScriptProvider(Assembly assembly)
		{
			this.assembly = assembly;
		}

		public IEnumerable<IScript> AllScripts
		{
			get {
				return from resourceName in assembly.GetManifestResourceNames()
				       where resourceName.EndsWith(".boo", StringComparison.InvariantCultureIgnoreCase)
				       select (IScript) new BooScript(
						   NameFromResource(resourceName), 
						   resourceName,
						   ReadAll(assembly.GetManifestResourceStream(resourceName))
				       	);
			}
		}

		string NameFromResource(string resourceName)
		{
			var withoutExtension = StandardRename.GetFileNameWithoutExtension(resourceName);
			return Regex.Match(withoutExtension, "[^.]+$").Value;
		}

		string ReadAll(Stream stream)
		{
			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}