using System.Collections.Generic;

namespace SolutionTransform.Api10
{
    public interface IOption
    {
        string Name { get; }
        string Description { get; }
        bool IsRequired { get;  }
        OptionType OptionType { get; }
    }

    public interface IOption<TContext> : IOption
    {
        void Parse(TContext context, IEnumerable<string> arguments);
    }
}