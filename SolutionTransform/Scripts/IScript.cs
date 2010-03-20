using System.Collections.Generic;
using SolutionTransform.Files;

namespace SolutionTransform.Scripts
{
	interface IScript
	{
		string Name { get; }
		string Location { get; }
		int Execute(IEnumerable<string> arguments, IFileStorage fileSystem);
	}
}