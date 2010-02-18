using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Boo.Lang.Interpreter;

namespace SolutionTransform.Api10
{
    public class BooCommandLineParser
    {
        private readonly InteractiveInterpreter2 interpreter;
        private readonly CommandLineParser commandLineParser;

        public BooCommandLineParser(InteractiveInterpreter2 interpreter, string[] arguments)
            : this(interpreter, new CommandLineParser(arguments, Console.Out))
        {
            
        }

        public BooCommandLineParser(InteractiveInterpreter2 interpreter, CommandLineParser commandLineParser)
        {
            this.interpreter = interpreter;
            this.commandLineParser = commandLineParser;
        }

        public void Parameters(IEnumerable<IOption> options)
        {
            var result = commandLineParser.Parameters(options);
            Dictionary<string, object> variables = new Dictionary<string, object> ();
            var processableOptions = result.Keys.OfType<IOption<IDictionary<string, object>>>();
            foreach (var option in processableOptions)
            {
                option.Parse(variables, result[option]);
            }
            foreach (var item in variables)
            {
                interpreter.SetValue(item.Key, item.Value);
            }
        }
    }

    public class CommandLineParser {
        private readonly string[] arguments;
        private readonly TextWriter output;

        public CommandLineParser(string[] arguments, TextWriter output)
        {
            this.arguments = arguments;
            this.output = output;
        }

        void ShowHelp(IEnumerable<IOption> options)
        {
            output.WriteLine("Argument help:");
            foreach (var option in options)
            {
                output.WriteLine("\t--{0,-20}{1}\t{2}", 
                    option.Name, 
                    option.OptionType == OptionType.NoValues ? "" : "<Values>", 
                    option.Description
                    );
            }
            throw new NonErrorTerminationException();
        }

        IDictionary<IOption, List<string>> ParseParameters(IEnumerable<IOption> options)
        {
            var lookup = options.ToDictionary(o => o.Name);
            IOption currentOption = null;
            List<string> unparsed = new List<string>();
            List<string> currentList = unparsed;
            Dictionary<IOption, List<string>> values = new Dictionary<IOption, List<string>>();
            foreach (var argument in arguments) {
                if (argument.StartsWith("--")) {
                    if (argument.Length == 2)
                    {
                        return values;
                    }
                    var name = argument.Substring(2);
                    if (!lookup.TryGetValue(name, out currentOption))
                    {
                        output.WriteLine("Unknown option {0}", argument);
                        ShowHelp(options);
                    }
                    if (currentOption.OptionType == OptionType.NoValues)
                    {
                        values[currentOption] = new List<string>();  // empty list
                        currentOption = null; 
                    } else {
                        values[currentOption] = currentList = new List<string>();
                    }
                } else if (currentOption != null)
                {
                    currentList.Add(argument);
                }
            }
            return values;
        }

        void ValidateParameters(IDictionary<IOption, List<string>> values, IEnumerable<IOption> options)
        {
            var missing = from o in options
                          where o.IsRequired && !values.ContainsKey(o)
                          select o;
            var invalid = from o in options
                          where o.OptionType == OptionType.NoValues && values.ContainsKey(o)
                          select o;
            if (missing.Any() || invalid.Any())
            {
                foreach (var option in missing) {
                    output.WriteLine("Missing parameter {0}", option.Name);
                }
                foreach (var option in invalid) {
                    output.WriteLine("Values provided to null parameter {0}", option.Name);
                }
                ShowHelp(options);
            }
        }

        public IDictionary<IOption, List<string>> Parameters(IEnumerable<IOption> options)
        {
            bool showHelp = false;
            var help = new Option("help", false, OptionType.NoValues, "Shows argument help");
            var extendedOptions = options.Union(new [] { help });
            var result = ParseParameters(extendedOptions);
            if (result.ContainsKey(help)) {
                ShowHelp(options);
            }
            ValidateParameters(result, options);
            return result;
        }
    }
}