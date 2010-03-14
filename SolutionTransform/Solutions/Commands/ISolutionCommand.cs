using System;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions.Commands
{
	public interface ISolutionCommand
	{
		void Process(SolutionFile solutionFile);

		ISolutionCommand Restrict(IProjectFilter projectFilter);
	}

	public class NullCommand : ISolutionCommand
	{
		public virtual void Process(SolutionFile solutionFile)
		{
			// Nothing
		}

		public ISolutionCommand Restrict(IProjectFilter projectFilter)
		{
			return this;  // Nothing needs doing, it's restricted enough
		}
	}
}