using System.Collections.Generic;
using System.Text;

namespace SolutionTransform.Scripts {
	interface IScriptProvider {
		IEnumerable<IScript> AllScripts { get; }
	}
}
