using System;
using System.Collections.Generic;

namespace SolutionTransform.Api10
{
    public enum OptionType
    {
        NoValues,
        OneValue,
        MultipleValues
    }

    public class Option<TContext> : Option, IOption<TContext>
    {
        private readonly Action<TContext, IEnumerable<string>> parse;

        public Option(string name, bool isRequired, OptionType optionType, string description, Action<TContext, IEnumerable<string>> parse2) : base(name, isRequired, optionType, description)
        {
            this.parse = parse2;
        }

        public void Parse(TContext context, IEnumerable<string> arguments) {
            parse(context, arguments);
        }
    }

    public class Option : IOption
    {
        private readonly string description;
        
        private readonly string name;
        private readonly bool isRequired;
        private readonly OptionType optionType;

        public Option(string name, bool isRequired, OptionType optionType, string description)
        {
            this.name = name;
            this.isRequired = isRequired;
            this.optionType = optionType;
            this.description = description;
        }

        public OptionType OptionType
        {
            get { return optionType; }
        }

        public string Name { get { return name;} }

        public string Description
        {
            get { return description; }
        }

        public bool IsRequired
        {
            get { return isRequired; }
        }
    }
}