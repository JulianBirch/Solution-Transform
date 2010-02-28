using System;
using System.Linq;
using System.Xml;

namespace SolutionTransform.ProjectFile
{
    /// <summary>
    /// Can be used to change a project from version 3.5 to 4.0 and back again.
    /// Please note:  ChangeTo40Framework is better for conversion to 4.0
    /// </summary>
    public class ChangeFrameworkVersion : MSBuild2003Transform
    {
        private readonly string newVersion;

        public ChangeFrameworkVersion(string newVersion)
        {
            this.newVersion = newVersion;
        }

        public override void DoApplyTransform(XmlDocument document)
        {
            foreach (XmlElement element in document.SelectNodes("/*/*/x:Reference/x:RequiredTargetFramework", namespaces))
            {
                element.InnerText = newVersion;
            }
            foreach (XmlElement element in document.SelectNodes("/*/*/x:TargetFrameworkVersion", namespaces))
            {
                element.InnerText = newVersion;
            }
        }
    }

    public class ChangeTo40Framework : ChangeFrameworkVersion
    {
        public ChangeTo40Framework() : base("v4.0")
        {
            
        }

        public override void DoApplyTransform(XmlDocument document) {
            base.DoApplyTransform(document);
            var references = GetAssemblyReferences(document);
            var first = references.Cast<XmlElement>().First();
            ReferenceMapTransform.AddReference(first, "Microsoft.CSharp");

        }
    }

}