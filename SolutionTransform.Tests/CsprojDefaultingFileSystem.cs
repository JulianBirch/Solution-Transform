using System.Xml;

namespace SolutionTransform.Tests
{
    class CsprojDefaultingFileSystem : FakeFileSystem {
        public override XmlDocument LoadAsDocument(FilePath filePath) {
            if (projects.ContainsKey(filePath)) {
                return base.LoadAsDocument(filePath);
            }
            return ExampleCsprojFiles.ToDocument(ExampleCsprojFiles.microKernel);
        }
    }
}