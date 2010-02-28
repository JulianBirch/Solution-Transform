using System;

namespace SolutionTransform.Solutions
{
    public interface ISolutionCommand
    {
        void Process(SolutionFile solutionFile);
    }

    public class NullCommand : ISolutionCommand
    {
        public virtual void Process(SolutionFile solutionFile)
        {
            // Nothing
        }
    }
}
