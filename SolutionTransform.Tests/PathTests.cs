using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SolutionTransform.Tests {
	[TestFixture]
	public class PathTests {
		
		[Test]
		public void NoParentDirectories()
		{
			var result = PathCombine(@"a\b", @"c\d");
			Assert.That(result, Is.EqualTo(@"a\b\c\d"));
		}

		[Test]
		public void NoParentDirectoriesTrailingSlash() {
			var result = PathCombine(@"a\b\", @"c\d");
			Assert.That(result, Is.EqualTo(@"a\b\c\d"));
		}

		[Test]
		public void SingleParentDirectory() {
			var result = PathCombine(@"a\b\", @"..\c\d");
			Assert.That(result, Is.EqualTo(@"a\c\d"));
		}


		[Test]
		public void MultipleParentDirectories() {
			var result = PathCombine(@"a\b\c\d\..\..\e\f\..\g", @"h");
			Assert.That(result, Is.EqualTo(@"a\b\e\g\h"));
		}

		string PathCombine(string p1, string p2) {
			return FilePath.Normalize(FilePath.PathCombine(p1, p2));
		}
	}
}
