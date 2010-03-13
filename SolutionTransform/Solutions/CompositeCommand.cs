using System.Collections.Generic;
using System.Linq;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions
{
    public class CompositeCommand : ISolutionCommand
    {
        private readonly IEnumerable<ISolutionCommand> underlying;

        public CompositeCommand(IEnumerable<ISolutionCommand> underlying)
        {
            this.underlying = underlying;
        }

        public void Process(SolutionFile solutionFile)
        {
            foreach (var command in underlying)
            {
                command.Process(solutionFile);
            }
        }

    	public ISolutionCommand Restrict(IProjectFilter projectFilter)
    	{
    		return new CompositeCommand(underlying.Select(c => c.Restrict(projectFilter)));
    	}
    }
}
