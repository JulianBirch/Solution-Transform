import SolutionTransform.Api10
import System.Collections.Generic

# e.g. Modify --solution C:\Projects\Interfaces\Connectivity\FixJunction.sln --add "C:\Projects\IOM\JILIOM\JILIOMLib\JILiomLIB.csproj" 

solution as object
add as List of string
remove as List of string

with api10:
	_Parameters(
		_Solution("solution", "The solution which lists the projects to be modified.  Note that, unusually, this script doesn't rebase assemblies."),
		_StringList("add", "Defines to be added to every project."),
		_StringList("remove", "Defines to be removed to every project.")
	)
	solution.Transform(
		_StandardRename(),
		_Define(add, remove)
	)