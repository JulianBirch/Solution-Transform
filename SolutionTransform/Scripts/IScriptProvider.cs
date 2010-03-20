using System.Collections.Generic;
using System.Text;

namespace SolutionTransform.Scripts {
	interface IScriptProvider {
		IScript FindScript(string scriptName);

		IEnumerable<IScript> AllScripts { get; }
	}

	

	// This class is intentionally close to 
}
