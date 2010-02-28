// Copyright 2004-2009 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Xml;
using SolutionTransform.ProjectFile;

namespace SolutionTransform.Solutions
{
	using System;

    public class SolutionProject : SolutionChapter, IEquatable<SolutionProject> {
		private Guid type;
		private string name;
        private FilePath path;
        private XmlFile xmlFile;
		private Guid id;

        public SolutionProject(string start, string end, FilePath basePath, IFileSystem fileSystem) : base(start, end) {
			var components = start.Split('"');
			type = new Guid(components[1]);
			name = components[3];
            path = new FilePath(components[5], false);
            xmlFile = new XmlFile(path.ToAbsolutePath(basePath), fileSystem);
			id = new Guid(components[7]);
		}

        public SolutionProject(FilePath relativePath, FilePath basePath, Guid projectType, IFileSystem fileSystem)
            : base("", "EndProject")
        {
            this.type = projectType;
            name = System.IO.Path.GetFileNameWithoutExtension(relativePath.Path);
            path = relativePath;
            xmlFile = new XmlFile(path.ToAbsolutePath(basePath), fileSystem);
            id = ProjectGuid(xmlFile.Document);
            WriteLineBack();
        }

        public void Rebase(FilePath newSolutionPath)
        {
            path = xmlFile.Path.PathFrom(newSolutionPath);
        }

        static Guid ProjectGuid(XmlDocument xmlFile)
        {
            var element = (XmlElement)xmlFile.SelectSingleNode("/*/*/x:ProjectGuid", MSBuild2003Transform.MsBuild2003Namespace(xmlFile));
            if (element == null)
            {
                throw new InvalidDataException("Project file doesn't seem to have a project GUID.");
            }
            return new Guid(element.InnerText);
        }

	    public XmlFile XmlFile
	    {
	        get { return xmlFile; }
	    }

	    public bool IsFolder { get
		{
				return type == FolderProject;
		}}

		public readonly static Guid FolderProject = new Guid("{2150E333-8FDC-42A3-9474-1A3956D46DE8}");
        public readonly static Guid CsProjProject = new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}");

		public Guid Id {
			get { return id; }
		}

		public FilePath Path {
			get { return path; }
			set { path = value; WriteLineBack(); }
		}

		public string Name {
			get { return name; }
			set { name = value; WriteLineBack(); }
		}

		public Guid Type {
			get { return type; }
		}

	    string BeginProject
	    {
	        get
	        {
                return string.Format(@"Project(""{{{0}}}"") = ""{1}"", ""{2}"", ""{{{3}}}""",
                                     Type.ToString().ToUpperInvariant(), 
                                     Name, 
                                     Path.Path, 
                                     Id.ToString().ToUpperInvariant()
                );
	        }
	    }

        public string AssemblyFileName
        {
            get {
                return AssemblyName + ".dll"; // TODO: Support links to exes
                
            }
        }

        public string AssemblyName
        {
            get {
                var document = xmlFile.Document;
                var element = (XmlElement)document.SelectSingleNode("/*/*/x:AssemblyName", MSBuild2003Transform.MsBuild2003Namespace(document));
                if (element == null) {
                    throw new Exception("Couldn't find assembly name!");
                }
                return element.InnerText;
            }
        }

        void WriteLineBack() {
			Start = BeginProject;
		}

        public bool Equals(SolutionProject other)
        {
            return other.Id == Id;
        }

        public override bool Equals(object obj) {
            return Equals(obj as SolutionProject);
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}
