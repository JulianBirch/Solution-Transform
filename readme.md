Solution Transform is a tool for scripting modifications to solutions and csproj files in ways that don't break being able to use them in Visual Studio.  At the moment, it can do the following

- Add and remove projects
- Merge and Sync solutions
- Change the .NET version to Silverlight, .NET 3.5 or .NET 4.0
- Change the IDE from VS2008 to VS2010 and back again.

The intention is that you can include this in your build scripts to produce alternative versions of projects.  I'll be adding more standard conversions as required.  I've already got it integrated with 
the Castle Core Project building .NET 3.5, .NET 4.0 and Silverlight 3.0.

Its canonical home is http://github.com/JulianBirch/Solution-Transform

There is currently no binary distribution of the tool.

Command Parameters
==================
The tool is invoked as follows:

	SolutionTransform <<ScriptName>> <<parameters>>

If you're running from source, just put <<ScriptName>> <<parameters>> into the DEBUG page's command line parameters.  If you do so, I advise putting a breakpoint on the closing brace of Main as well, to ensure that you see all output.

	SolutionTransform <<ScriptName>> --help

will print the command line parameters for the script.  There are two other standard parameters

### Rename ###
By default, Solution Transform will produce a solution with the original name plus "-Modified" so "c:\Foo.sln" becomes "c:\Foo-Modified.sln".  
It will do the same thing to all of the projects within the solution.  
If you want a different "extension", the --rename parameter allows you to change it.  
So "rename -SL" would produce "c:\Foo-SL.sln".  Importantly "--rename """ will perform an in-place modification.  
Obviously I can't recommend that until you've tested out the -Modified output files first.

### AssemblyPaths ###
Pretty much every script will attempt to rebase the assemblies.  
Any assemblies referenced by any project will have their HintPaths changed.  
The --assemblyPaths parameter specifies where it will search for reference assemblies.  
So, for instance "-assemblyPaths lib/sl lib" will first search in the "lib/sl" folder and then in the "lib" folder for appropriate assemblies.

Targeting Commands
==================

Retarget 
--------

Retarget allows you to change your solution into a silverlight solution, a VS2010 solution or a .NET 4.0 solution. 

Here's some example command lines:

	SolutionTransform Retarget --solution "C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln" --ide vs2010 --target dotnet40 --rename -VS2010 
	SolutionTransform Retarget --solution "C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln" --target silverlight30 --rename -Silverlight --assemblyPaths ..\lib\silverlight-3.0  
It doesn't bother to check whether the command actually makes sense: you can create a VS2008 .NET 4.0 solution.  
It just won't work.  The Retarget command also does some basic manipulation of define constants.

N.B.  The Silverlight30 transform removes code signing from the project.

The parameters are as follows:

### Target ###
The version of .NET to use.  Valid values are: dotNet35, dotNet40 and Silverlight30.

### IDE ###
The version of the IDE to use.  Valid values are: VS2008 and VS2010. 

### OutputPaths ###
--outputPath "bin/silverlight" will change each project to output to "bin/silverlight/Release" and "bin/silverlight/debug" depending on which configuration you are using.

Define
------

The retarget command sets up some standard defines, but if your project is using different Defines, you need this command.  
It allows you to change a define in your solution globally. 

For example
	SolutionTransform Define --solution "C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln" --add MONO

It has two parameters, add and remove, both of which take multiple values.  The changes are made to every configuration on every project.  This command can also be used to patch up the default behaviour of Retarget if you want to use different defines.  If you're considering this, however, please contact me (Julian Birch) as I'd like to see if we can standardize on some #defines across open source projects.

Solution Modification Commands
==============================

There are now three scripts: Modify, Merge, and Sync.  For command line help, just put --help

Modify
------

This already has one happy user: me.  It allows you to add or remove projects from a solution.  This isn't quite the same as doing it in Visual Studio.  If you add a project, it automatically updates any assembly references to project references, which is a lot more convenient than Visual Studio's default behaviour.  If you remove a project, it looks up the assembly in the specified directories, rather than the project's output directory.  This is more useful for automated builds.

Example command line syntax:

	SolutionTransform  Modify --solution C:\Projects\Application.sln --add "C:\Projects\Library\ImportantLibrary.csproj"

However, in practice I doubt many people are going to want to add and remove projects on an individual basis.  Usually, you'll want to use Merge or Sync.

Merge
-----

This takes a list of projects and merges them together.  It seems like this is one of those things that excites some people and leaves others cold.  Here's how to revert Castle to the pre-division style:

	SolutionTransform Merge --toSolution C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-vs2008.sln --fromSolutions C:\OSS3\Castle Core\src\Core-vs2008.sln C:\OSS3\Castle DP\DynamicProxy\src\Castle.DynamicProxy2-vs2008.sln

This will create a solution C:\OSS3\Castle IoC\InversionOfControl\src\InversionOfControl-Modifed.sln which has all three solutions merged into one, with all of the references sorted out for you.  (A small note: when I try to run the project, I discover that it won't build until I build DynamicProxy individually.  After that it seems fine, though.)

Sync
----

This is for reflecting your changes back to the original solution.  This is effectively the inverse of Merge.  The following maps changes back to the original solution.

	SolutionTransform Sync --fromSolution %CD%\Application-Modified.sln --toSolution C:\Projects\Application.sln --rename ""  --assemblyPaths lib

Remember that --rename "" indicates an in-place modification, so the toSolution is overwritten.  The "lib" setting is relative to toSolution.

Project Modification Commands
=============================

ModifyProject
-------------

This allows you to modify a specific project, which you identify by specifying the solution and then the project name.  
This isn't just for consistency with the other commands: sometimes you need to know the containing solution to modify the project correctly.  
Currently all this command can do is remove an assembly, but I imagine it'll gain features over time.

Example:
	SolutionTransform ModifyProject --solution %CD%\Castle.Core-SL.sln --project Castle.DynamicProxy.Tests-SL --removeAssembly Rhino.Mocks.CPP.Interfaces --rename -SL

RoadMap
=======

It does most of the things I can think of as being useful at the moment.  I'm happy to hear suggestions, though.  

* It could do with more tests.
* I don't know if any Mono users would find it useful.  Get in touch if you're in this category.
* Obviously, check out the [issues list].

[issues list]: http://github.com/JulianBirch/Solution-Transform/issues