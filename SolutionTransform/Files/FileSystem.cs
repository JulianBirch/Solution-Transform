using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace SolutionTransform
{
    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> LoadAsLines(FilePath filePath)
        {
            string line;
            using (var reader = new StreamReader(filePath.Path))
            {
                while (null != (line = reader.ReadLine())) {
                    yield return line;
                }
            }
        }

        public XmlDocument LoadAsDocument(FilePath filePath)
        {
            var result = new XmlDocument();
            result.Load(filePath.Path);
            return result;
        }

        public void Save(FilePath filePath, IEnumerable<string> lines)
        {
            MakeWriteable(filePath.Path);
            using (var writer = new StreamWriter(filePath.Path, false, Encoding.Unicode)) {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
        void MakeWriteable(string path)
        {
            if (File.Exists(path)) {
                var info = new FileInfo(path);
                info.IsReadOnly = false;
            }
        }

        public void Save(FilePath filePath, XmlDocument document)
        {
            MakeWriteable(filePath.Path);
            document.Save(filePath.Path);
        }
    }
}