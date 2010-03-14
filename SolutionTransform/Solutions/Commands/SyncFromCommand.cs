using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolutionTransform.Model;

namespace SolutionTransform.Solutions.Commands
{
	class SyncFromCommand : BaseMergeCommand {
		public SyncFromCommand(SolutionFile fromSolution) : base(fromSolution.Projects)
		{
		}


		public override ISolutionCommand Restrict(IProjectFilter projectFilter)
		{
			throw new System.NotSupportedException("The SyncFrom command cannot be restricted.");
		}

		protected override void ProcessSolution(SolutionFile toSolution, Reconciliation<SolutionProject> reconciliation)
		{
			foreach (var projectPair in reconciliation.Matched) {
				toSolution.Remove(projectPair.Key);
				toSolution.Add(projectPair.Value);
			}
		}
	}

	public class Reconciliation<TValue>
	{
		readonly List<TValue> removed = new List<TValue>();

		public IEnumerable<TValue> Removed
		{
			get { return removed; }
		}

		public IEnumerable<TValue> Added
		{
			get { return added; }
		}

		public IEnumerable<KeyValuePair<TValue, TValue>> Matched
		{
			get { return matched; }
		}

		readonly List<TValue> added = new List<TValue>();
		readonly List<KeyValuePair<TValue, TValue>> matched = new List<KeyValuePair<TValue, TValue>>();

		// This is a vastly inefficient implementation, but good enough for solutions with < 50 projects
		public void Reconcile(IEnumerable<TValue> from, IEnumerable<TValue> to, Func<TValue, TValue, bool> isMatch)
		{   
			foreach (var fromProject in from)
			{
				foreach (var toProject in to)
				{
					if (isMatch(fromProject, toProject))
					{
						matched.Add(new KeyValuePair<TValue, TValue>(fromProject, toProject));
						goto NextFromProject;
					}
				}
				removed.Add(fromProject);
				NextFromProject:
				int x = 0;
			}
			var matchedTo = matched.Select(x => x.Value).ToList();
			added.AddRange(to.Except(matchedTo));
		}

        
	}
}