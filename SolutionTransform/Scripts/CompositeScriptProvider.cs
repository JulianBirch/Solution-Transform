using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionTransform.Scripts
{
	internal class CompositeScriptProvider : IScriptProvider, IEqualityComparer<IScript>
	{
		private readonly IEnumerable<IScriptProvider> underlying;

		public CompositeScriptProvider(IEnumerable<IScriptProvider> underlying)
		{
			this.underlying = underlying;
		}

		public IEnumerable<IScript> AllScripts
		{
			get { return underlying.SelectMany(sp => sp.AllScripts).DistinctStreamed(this); }
		}

		bool IEqualityComparer<IScript>.Equals(IScript x, IScript y)
		{
			return StringComparer.InvariantCultureIgnoreCase.Equals(x.Name, y.Name);
		}

		int IEqualityComparer<IScript>.GetHashCode(IScript obj)
		{
			return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Name);
		}
	}

	internal static class DistinctHelper
	{
		/// <summary>
		/// Performs the same operation as Distinct
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="source"></param>
		/// <param name="comparer"></param>
		/// <returns></returns>
		public static IEnumerable<TValue> DistinctStreamed<TValue>(
			this IEnumerable<TValue> source, 
			IEqualityComparer<TValue> comparer)
		{
			HashSet<TValue> encountered = new HashSet<TValue>(comparer);
			foreach (var value in source)
			{
				if (encountered.Contains(value))
				{
					continue;
				}
				yield return value;
				encountered.Add(value);
			}
		}
	}
}