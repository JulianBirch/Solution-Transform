using System;
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace SolutionTransform.Tests
{
    class FakeFileSystem : IFileSystem
    {
        protected Dictionary<FilePath, IEnumerable<string>> solutions = new Dictionary<FilePath, IEnumerable<string>>();
        protected Dictionary<FilePath, XmlDocument> projects = new Dictionary<FilePath, XmlDocument>();
        
        public virtual void CheckFilePath(FilePath filePath)
        {
            Assert.That(!filePath.IsDirectory, "File path must point to a file.");
            Assert.That(filePath.IsAbsolute, "File path must be absolute.");
        }

        public virtual IEnumerable<string> LoadAsLines(FilePath filePath)
        {
            CheckFilePath(filePath);
            return solutions[filePath];
        }

        public virtual XmlDocument LoadAsDocument(FilePath filePath)
        {
            CheckFilePath(filePath);
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
    }
}