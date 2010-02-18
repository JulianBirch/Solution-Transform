using System.IO;
using System.Xml;

namespace SolutionTransform
{
    public class XmlFile
    {
        private readonly FilePath filePath;
        private readonly IFileSystem fileSystem;
        XmlDocument document;

        public XmlFile(FilePath filePath, IFileSystem fileSystem)
        {
            this.filePath = filePath;
            this.fileSystem = fileSystem;
        }

        internal XmlFile(XmlDocument document)
        {
            this.document = document;
        }

        internal XmlDocument Document {
            get {
                if (document == null) {
                    document = fileSystem.LoadAsDocument(filePath);
                }
                return document;
            }
        }

        public void Save(string to)
        {
            var newFilePath = filePath.Parent.File(to);
            fileSystem.Save(newFilePath, document);
        }

        public bool Exists
        {
            get
            {
                return File.Exists(filePath.Path);
            }
        }

        public FilePath Path
        {
            get { return filePath; }
        }
    }
}
