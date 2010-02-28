import SolutionTransform.Api10

solution as object
target as string
ide as string
outputPaths as string
with api10:
	_Parameters(
		_Solution("solution", "The solution to be transformed"),
		_String("target", "The target, e.g. DotNet35, Silverlight30"),
		_String("ide", "The IDE, e.g. VS2008, VS2010"),
		_String("outputPaths", "The output paths e.g. 'build\\silverlight30'")
	)
	solution.Transform(
		_StandardRename(),
		_Target(target),
		_Ide(ide),
		_RebaseAssemblies(solution),
		_ChangeOutputPaths(outputPaths)
	)

# This script is the script for converting a castle solution to the corresponding castle silverlight solution

# RegexFilter(["Castle.Core", "Castle.DynamicProxy", "Castle.MicroKernel", "Castle.Windsor"])