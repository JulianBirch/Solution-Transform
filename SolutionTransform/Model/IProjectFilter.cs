using SolutionTransform.Solutions;

namespace SolutionTransform.Model
{
    public interface IProjectFilter
    {
        bool ShouldApply(SolutionProject project);
    }
}