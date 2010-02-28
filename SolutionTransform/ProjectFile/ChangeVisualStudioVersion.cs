using System.Xml;

namespace SolutionTransform.ProjectFile
{
    public class ChangeVisualStudioVersion : MSBuild2003Transform
    {
        private readonly string toolsVersion;
        private readonly string productVersion;

        public ChangeVisualStudioVersion(string toolsVersion, string productVersion)
        {
            this.toolsVersion = toolsVersion;
            this.productVersion = productVersion;
        }

        
        public override void DoApplyTransform(XmlDocument document)
        {
            var root = document.DocumentElement;
            root.SetAttribute("ToolsVersion", toolsVersion);
            var rootPG = GetRootPropertyGroup(document);
            var productVersionElement = rootPG.SelectSingleNode("x:ProductVersion", namespaces);
            productVersionElement.InnerText = productVersion;
        }

        
    }
}