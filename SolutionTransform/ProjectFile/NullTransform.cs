using System.Xml;

namespace SolutionTransform.ProjectFile
{
    public class NullTransform : MSBuild2003Transform
    {
        public override void DoApplyTransform(XmlDocument document)
        {
            // Do nothing
        }
    }
}