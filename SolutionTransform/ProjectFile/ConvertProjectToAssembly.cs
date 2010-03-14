using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using SolutionTransform.Solutions;

namespace SolutionTransform.ProjectFile
{
    public class ConvertProjectToAssembly : MSBuild2003Transform
    {
        private readonly SolutionProject project;

        public ConvertProjectToAssembly(SolutionProject project)
        {
            this.project = project;
        }

        public override void DoApplyTransform(XmlFile file) {
            foreach (var projectReference in RemovedProjectReferences(file))
            {
                ConvertToAssemblyReference(projectReference);
            }
        }

        public override void DoApplyTransform(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        IEnumerable<XmlElement> RemovedProjectReferences(XmlFile file)
        {
            foreach (XmlElement projectReference in file.Document.SelectNodes("//x:ProjectReference", namespaces)) {
                var include = new FilePath(projectReference.GetAttribute("Include"), false, false);
                var absolute = include.ToAbsolutePath(file.Path);
                if (project.Path.Equals(absolute)) {
                    yield return projectReference;
                }
            }
        }

        private void ConvertToAssemblyReference(XmlElement projectReference)
        {
            /*
    <Reference Include="nunit.framework, Version=2.5.3.9345, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\Lib\nunit.framework.dll</HintPath>
    </Reference>
             */
            var assemblyReference = projectReference.OwnerDocument.CreateElement("Reference", build2003);
            var specificVersion = AddElement(assemblyReference, "SpecificVersion");
            specificVersion.InnerText = "False";
            var hintPath = AddElement(projectReference, "HintPath");
            hintPath.InnerText = project.AssemblyFileName;
            projectReference.ParentNode.ReplaceChild(assemblyReference, projectReference);
        }
    }
}