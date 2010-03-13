using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using SolutionTransform.Api10;

namespace SolutionTransform.Tests {
    [TestFixture]
    public class TargetTests {
        

        public void CanRemoveTargets()
        {
            var document = new XmlDocument();
            document.LoadXml(ExampleCsprojFiles.iocTests);
            var remove = Targets.RemoveFlavourTargetsAndDefines();
            remove.ApplyTransform(new XmlFile(document));
            Assert.IsFalse(document.OuterXml.Contains(".targets"), "Targets were not removed.");
        }
    }
}