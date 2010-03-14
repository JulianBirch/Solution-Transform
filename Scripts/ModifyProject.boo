import SolutionTransform.Api10
import System.Collections.Generic

# e.g. Modify --solution C:\Projects\Interfaces\Connectivity\FixJunction.sln --add "C:\Projects\IOM\JILIOM\JILIOMLib\JILiomLIB.csproj" 

solution as object
project as List of string
removeAssembly as List of string

with api10:
	_Parameters(
		_Solution("solution", "The solution to be modified"),
		_StringList("project", "Project(s) in the solution affected.  As Names."),
		_StringList("removeAssembly", "Assembly/Assemblies to be removed.  As Names.")
	)
	solution.Transform(
		_StandardRename(),
		_Restrict(_RemoveAssemblies(removeAssembly), project)
	)