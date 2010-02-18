Usage:

SolutionTransform <Script File Name> <Solution Full Path>

e.g.
SolutionTransform CastleSilverlight --solution "C:\OSS3\Castle Core\src\Core-vs2008.sln"

This creates a silverlight version of the original trunk project (at least on my machine)

BUGS
====

# 21 Dec 2009

The only known problem at the moment is the rewriting of DLLs e.g. NUnit to NUnitLite.  The underlying problem is that 
the Castle Projects don't have valid lib directories at the moment.  This will be fixed when it's possible to do so.

LICENSE
=======

Solution Transform is Copyright 2009-2010 Julian Birch

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this project except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


NDesk.Options is licensed under the MIT/X11 License 
http://www.opensource.org/licenses/mit-license.php