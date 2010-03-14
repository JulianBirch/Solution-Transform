namespace SolutionTransform.ProjectFile
{
	using System.Xml;

	public class MainSilverlight30Transform : AltDotNetTransform
	{
		public override void DoApplyTransform(XmlDocument document) {
			base.DoApplyTransform(document);
			foreach (var propertyGroup in GetPropertyGroups(document))
			{
				Delete(propertyGroup, "x:FileAlignment");
				SetElementIfPresent(propertyGroup, "SilverlightApplication", false);
				SetElementIfPresent(propertyGroup, "ValidateXaml", true);
				SetElementIfPresent(propertyGroup, "ThrowErrorsInValidation", true);
				SetElementIfPresent(propertyGroup, "ProjectTypeGuids", "{A1591282-1198-4647-A2B1-27E5FF5F6F3B};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}");
				SetElementIfPresent(propertyGroup, "SignAssembly", "false");  // Silverlight doesn't support signed assemblies
			}
		    
			
			Delete(document, "/*/*/x:Reference/x:RequiredTargetFramework");
			var extensions = AddElement(document.DocumentElement, "ProjectExtensions");
			var vs = AddElement(extensions, "VisualStudio");
			var flavour = AddElement(vs, "FlavorProperties");
			flavour.SetAttribute("GUID", "{A1591282-1198-4647-A2B1-27E5FF5F6F3B}");
			var spp = AddElement(flavour, "SilverlightProjectProperties");

            Delete(document.DocumentElement, "//x:RequiredTargetFramework");
		}
	}
}
