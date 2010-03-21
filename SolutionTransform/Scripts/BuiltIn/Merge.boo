import SolutionTransform.Api10
import System.Collections.Generic

# Adds the projects from "from" to the solution "to"

# Example 
toSolution as object
fromSolutions as object

with api10:
	_Parameters(
		_SolutionList("fromSolutions", "The solution to merged from"),
		_Solution("toSolution", "The solution to be merged to.  It will only add projects that not in the toSolution.")
	)
	toSolution.Transform(
		_StandardRename(),
		_MergeFrom(fromSolutions),
		_RebaseAssemblies(toSolution)
	)