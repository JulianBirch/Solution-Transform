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
			get { return underlying.SelectMany(sp => sp.AllScripts).Distinct(this); }
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
}