import SolutionTransform.Api10
import System.Collections.Generic

# e.g. Modify --solution C:\Projects\Interfaces\Connectivity\FixJunction.sln --add "C:\Projects\IOM\JILIOM\JILIOMLib\JILiomLIB.csproj" 

solution as object
add as List of string
remove as List of string

with api10:
	_Parameters(
		_Solution("solution", "The solution to be modified"),
		_StringList("add", "Projects to be added to the solution.  As full paths."),
		_StringList("remove", "Projects to be removed to the solution.  As Names.")
	)
	solution.Transform(
		_StandardRename(),
		_Modify(add, remove),
		_RebaseAssemblies(solution)
	)