using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace SolutionTransform.Tests.Transforms {
	[TestFixture]
	public class SilverlightTransform {
		[Test]
		public void SilverlightRemovesSigning()
		{
			var document = new XmlDocument();
			document.LoadXml(ExampleCsprojFiles.castleCoreMar2010);
			var file = new XmlFile(document);
			var transform = Api10.Targets.Target("Silverlight30");
			transform.ApplyTransform(file);
			Assert.IsFalse(document.OuterXml.Contains("SignAssembly>true<"), "Silverlight transform should have removed signing.");
		}
	}
}
