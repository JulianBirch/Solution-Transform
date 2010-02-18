using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem;

namespace SolutionTransform.Api10 {
    public class WithMacro : AbstractAstMacro {
        public override void Initialize(CompilerContext context) {
            
        }
        public override Statement Expand(MacroStatement macro)
        {
            var instance = macro.Arguments[0] as ReferenceExpression;
            var transformer = new WithExpander(instance);
            transformer.Visit(macro.Body);
            return macro.Body;
        }

        class WithExpander : DepthFirstTransformer
        {
            private readonly ReferenceExpression instance;

            public WithExpander(ReferenceExpression instance)
            {
                this.instance = instance;
                /*
                foreach (var method in members.Where(m => m.EntityType == EntityType.Method))
                {
                    keywords.Add(method.Name);
                }*/
            }

            public override void OnReferenceExpression(ReferenceExpression node) {
                if (node.Name[0] == '_')
                {
                    var result = new MemberReferenceExpression(node.LexicalInfo);
                    result.Name = node.Name.Substring(1);
                    result.Target = instance.CloneNode();
                    ReplaceCurrentNode(result);
                }
            }
        }
    }
}
