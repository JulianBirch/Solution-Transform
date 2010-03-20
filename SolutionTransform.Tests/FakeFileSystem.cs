using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NUnit.Framework;
using SolutionTransform.Files;

namespace SolutionTransform.Tests
{
	[TestFixture]
	public class Scripts
	{
		[Test]
		public void CorrectScriptsArePresent()
		{
			var provider = Program.ScriptProvider(new FileSystem());
			var scriptNames = provider.AllScripts.Select(x => x.Name);
			Assert.That(scriptNames, Contains.Item("Define"));
			Assert.That(scriptNames, Contains.Item("Merge"));
			Assert.That(scriptNames, Contains.Item("Modify"));
			Assert.That(scriptNames, Contains.Item("ModifyProject"));
			Assert.That(scriptNames, Contains.Item("Retarget"));
			Assert.That(scriptNames, Contains.Item("Sync"));
		}
	}

    class FakeFileSystem : IFileSystem
    {
        protected Dictionary<FilePath, IEnumerable<string>> solutions = new Dictionary<FilePath, IEnumerable<string>>();
        protected Dictionary<FilePath, XmlDocument> projects = new Dictionary<FilePath, XmlDocument>();
        
        public virtual void CheckFilePath(FilePath filePath)
        {
        	Assert.That(filePath, Is.Not.Null, "Missing file path!");
            Assert.That(!filePath.IsDirectory, "File path must point to a file.");
            Assert.That(filePath.IsAbsolute, "File path must be absolute.");
			
        }

        public virtual IEnumerable<string> LoadAsLines(FilePath filePath)
        {
            CheckFilePath(filePath);
			Assert.That(solutions.ContainsKey(filePath), string.Format("There wasn't a solution at {0}", filePath.Path));
            return solutions[filePath];
        }

        public virtual XmlDocument LoadAsDocument(FilePath filePath)
        {
            CheckFilePath(filePath);
			Assert.That(projects.ContainsKey(filePath), string.Format("There wasn't an XML file at {0}", filePath.Path));
            return projects[filePath];
        }

        public virtual void Save(FilePath filePath, IEnumerable<string> lines)
        {
            CheckFilePath(filePath);
            solutions[filePath] = lines;
        }

        public virtual void Save(FilePath filePath, XmlDocument document)
        {
            CheckFilePath(filePath);
            projects[filePath] = document;
        }

    	public IEnumerable<FilePath> Files(FilePath directory)
    	{
    		throw new System.NotImplementedException();
    	}

    	public IEnumerable<FilePath> Folders(FilePath directory)
    	{
    		throw new System.NotImplementedException();
    	}

    	public bool Exists(FilePath filePath)
    	{
    		throw new System.NotImplementedException();
    	}
    }
}