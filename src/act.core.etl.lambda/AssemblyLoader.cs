﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

namespace act.core.etl.lambda
{
    public static class AssemblyLoader
    {
        public static Assembly LoadFromAssemblyPath(string assemblyFullPath)
        {
            var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(assemblyFullPath);
            var fileName = Path.GetFileName(assemblyFullPath);
            var directory = Path.GetDirectoryName(assemblyFullPath);

            var inCompileLibraries = DependencyContext.Default.CompileLibraries.Any(l => l.Name.Equals(fileNameWithOutExtension, StringComparison.OrdinalIgnoreCase));
            var inRuntimeLibraries = DependencyContext.Default.RuntimeLibraries.Any(l => l.Name.Equals(fileNameWithOutExtension, StringComparison.OrdinalIgnoreCase));

            var assembly = (inCompileLibraries || inRuntimeLibraries)
                ? Assembly.Load(new AssemblyName(fileNameWithOutExtension))
                : AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFullPath);

            if(assembly != null)
                LoadReferencedAssemblies(assembly,fileName, directory);

            return assembly;
        }

        private static void LoadReferencedAssemblies(Assembly assembly,string fileName,string directory)
        {
            var filesInDirectory = Directory.GetFiles(directory).Where(x=>x!= fileName).Select(Path.GetFileNameWithoutExtension).ToArray();
            var references = assembly.GetReferencedAssemblies();

            foreach(var reference in references)
            {
                if (filesInDirectory.Any(p => p == reference.Name))
                {
                    var loadFileName = $"{reference.Name}.dll";
                    var path = Path.Combine(directory, loadFileName);
                    var loadedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
                    if(loadedAssembly != null)
                        LoadReferencedAssemblies(loadedAssembly, loadFileName,directory);
                }
            }

        }

    }
}