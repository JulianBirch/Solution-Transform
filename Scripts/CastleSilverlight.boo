import SolutionTransform.Api10.Api

solution as object
with api10:
	_Parameters(
		_Solution("s|solution=", "solution", "The solution to be transformed to silverlight")
	)
	solution.Transform(
		_StandardRename(),
		_DontFilter(), 
		_Silverlight30Transform(),
		_RebaseAssemblies(solution),
		_ChangeOutputPaths("""build\silverlight30""")
		# ,StandardTransforms.CastleStandardsTransform()
	)

# This script is the script for converting a castle solution to the corresponding castle silverlight solution

# RegexFilter(["Castle.Core", "Castle.DynamicProxy", "Castle.MicroKernel", "Castle.Windsor"])