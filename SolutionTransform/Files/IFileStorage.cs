using System.Collections.Generic;
using System.Xml;

namespace SolutionTransform.Files
{
	public interface IFileScanner
	{
		IEnumerable<FilePath> Files(FilePath directory);

		IEnumerable<FilePath> Folders(FilePath directory);

		bool Exists(FilePath filePath);
	}

	public interface IFileStorage
	{
		IEnumerable<string> LoadAsLines(FilePath filePath);
		XmlDocument LoadAsDocument(FilePath filePath);
		void Save(FilePath filePath, IEnumerable<string> lines);
		void Save(FilePath filePath, XmlDocument document);
	}

	public interface IFileSystem : IFileScanner, IFileStorage
	{
		
	}
}