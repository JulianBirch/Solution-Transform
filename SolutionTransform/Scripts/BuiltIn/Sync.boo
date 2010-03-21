import SolutionTransform.Api10
import System.Collections.Generic

# Okay, this one's slightly complicated.  It takes the 

toSolution as object
fromSolution as object

with api10:
	_Parameters(
		_Solution("fromSolution", "The solution to synced from"),
		_Solution("toSolution", "The solution to be synced to.  It will only sync projects that are in both solutions.")
	)
	toSolution.Transform(
		_StandardRename(),
		_SyncFrom(fromSolution),
		_RebaseAssemblies(toSolution)
	)