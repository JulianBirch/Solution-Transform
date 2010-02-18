using System.Collections.Generic;
using System.Xml;

namespace SolutionTransform
{
    public interface IFileSystem
    {
        IEnumerable<string> LoadAsLines(FilePath filePath);
        XmlDocument LoadAsDocument(FilePath filePath);
        void Save(FilePath filePath, IEnumerable<string> lines);
        void Save(FilePath filePath, XmlDocument document);
    }
}