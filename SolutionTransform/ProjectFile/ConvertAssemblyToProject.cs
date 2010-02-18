using System;
using System.Collections.Generic;
using System.Xml;
using SolutionTransform.Solutions;

namespace SolutionTransform.ProjectFile
{
    public class ConvertAssemblyToProject : MSBuild2003Transform
    {
        private readonly SolutionProject project;

        public ConvertAssemblyToProject(SolutionProject project)
        {
            this.project = project;
        }

        public override void DoApplyTransform(XmlFile file) {
            foreach (var assemblyReference in AddedProjectReferences(file.Document)) {
                ConvertToProjectReference(assemblyReference, file.Path);
            }
        }

        public override void DoApplyTransform(XmlDocument document) {
            throw new NotImplementedException();
        }

        IEnumerable<XmlElement> AddedProjectReferences(XmlDocument document) {
            var assemblyName = project.AssemblyName;
            foreach (XmlElement reference in document.SelectNodes("//x:Reference", namespaces)) {
                var include = reference.GetAttribute("Include");
                int commaIndex = include.IndexOf(',');
                var bareInclude = commaIndex < 0
                    ? include
                    : include.Substring(0, commaIndex);
                if (StringComparer.InvariantCulture.Equals(bareInclude, assemblyName))
                {
                    yield return reference;
                }
            }
        }

        private void ConvertToProjectReference(XmlElement assemblyReference, FilePath currentPath) {
            /*
    <ProjectReference Include="..\SolutionTransform\SolutionTransform.csproj">
      <Project>{F37F9843-2A33-48A4-8D90-81277E0FBAC8}</Project>
      <Name>SolutionTransform</Name>
    </ProjectReference>
             */
            var projectReference = assemblyReference.OwnerDocument.CreateElement("ProjectReference", build2003);
            var projectElement = AddElement(projectReference, "Project");
            projectElement.InnerText = string.Concat("{", project.Id, "}");// You try writing a format string for that...
            var name = AddElement(projectReference, "Name");
            projectReference.SetAttribute("Include", project.Path.PathFrom(currentPath).Path);
            name.InnerText = project.AssemblyName;
            assemblyReference.ParentNode.ReplaceChild(projectReference, assemblyReference);
        }
    }
}