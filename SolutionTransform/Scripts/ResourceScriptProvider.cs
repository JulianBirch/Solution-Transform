using System.Collections.Generic;

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
}