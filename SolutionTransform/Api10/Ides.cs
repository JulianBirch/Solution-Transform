using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionTransform.Model;
using SolutionTransform.Solutions.Commands;

namespace SolutionTransform.Api10 {
    static class Ides {
        static Dictionary<string, ISolutionCommand> ides = new Dictionary<string, ISolutionCommand>(StringComparer.InvariantCultureIgnoreCase) {
            { "", new NullCommand()},
            { "VS2008", ToVisualStudio2008() },
            { "VS2010", ToVisualStudio2010() }
        };

        public static ISolutionCommand Ide(string ide) {
            ISolutionCommand result;
            if (ides.TryGetValue(ide ?? "", out result)) {
                return result;
            }
            throw new ArgumentException(string.Format("Unrecognized IDE '{0}'.  Valid IDEs are:  {1}", ide,
                string.Join(", ", ides.Keys.ToArray())));
        }

        static ISolutionCommand ToVisualStudio2008() {
            return new ChangeVisualStudioVersionCommand(new[] { 
                "Microsoft Visual Studio Solution File, Format Version 10.00",
                "# Visual Studio 2008"
            }, "3.5", "9.0.30729");
        }

        static ISolutionCommand ToVisualStudio2010() {
            return new ChangeVisualStudioVersionCommand(new[] { 
                "Microsoft Visual Studio Solution File, Format Version 11.00",
                "# Visual Studio 2010"
            }, "4.0", "8.0.30703");  
            // Yes, the product version for VS2010 is /lower/ than that of VS2008.  Maybe Eric can explain this, I can't
            // This was correct as of VS2010 RC1
        }
    }

}
