using System;
using System.Linq;
using SolutionTransform.Api10;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions
{
    internal class TransformCommand : ISolutionCommand
    {
        private readonly IProjectFilter filter;
        private readonly ITransform transform;

        public TransformCommand(ITransform transform) : this(new DontFilter(), transform)
        {
            
        }

        public TransformCommand(IProjectFilter filter, ITransform transform)
        {
            this.filter = filter;
            this.transform = transform;
        }

        public void Process(SolutionFile solutionFile)
        {
            foreach (var project in solutionFile.Projects.Where(filter.ShouldApply))
            {
                transform.ApplyTransform(project.XmlFile);
            }
        }
    }

}
