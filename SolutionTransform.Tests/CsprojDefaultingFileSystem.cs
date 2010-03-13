using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace SolutionTransform.Tests
{
    class CsprojDefaultingFileSystem : FakeFileSystem {
    	private readonly string defaultCsproj;

		public CsprojDefaultingFileSystem()
			: this(ExampleCsprojFiles.microKernel)
		{
    		
		}

		public CsprojDefaultingFileSystem(string defaultCsproj)
		{
			this.defaultCsproj = defaultCsproj;
		}

    	public override XmlDocument LoadAsDocument(FilePath filePath) {
            if (!projects.ContainsKey(filePath)) {
				Save(filePath, ExampleCsprojFiles.ToDocument(defaultCsproj));
            }
			return base.LoadAsDocument(filePath);
        }

		public XmlDocument LoadAsDocument(string filePath)
		{
			return LoadAsDocument(new FilePath(filePath, false, true));
		}

		internal IEnumerable<string> SetSolutionText(string solutionFileName, string solutionText) {
			var filePath = new FilePath(solutionFileName, false);
			var originalLines = solutionText.AsLines();
			Save(filePath, originalLines);
			return originalLines;
		}
    }
}