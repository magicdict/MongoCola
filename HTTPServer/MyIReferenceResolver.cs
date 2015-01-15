using System.Collections.Generic;
using SystemUtility;
using SystemUtility.Config;
using MongoUtility.Core;
using RazorEngine.Compilation;
using RazorEngine.Compilation.ReferenceResolver;

namespace HTTPServer
{
    public class MyIReferenceResolver : IReferenceResolver
    {
        public IEnumerable<CompilerReference> GetReferences(TypeContext context,
            IEnumerable<CompilerReference> includeAssemblies)
        {
            // TypeContext gives you some context for the compilation (which templates, which namespaces and types)
            // My templates need some special reference to compile.
            return new[]
            {
                //CompilerReference.From("Path-to-my-custom-assembly"), // file path (string)
                CompilerReference.From(typeof (SystemConfig).Assembly),
                CompilerReference.From(typeof (Config).Assembly),
                CompilerReference.From(typeof (MongoConnectionConfig).Assembly) // Assembly
                //CompilerReference.From(assemblyInByteArray), // byte array (roslyn only)
                //CompilerReference.From(File.OpenRead(assembly)), // stream (roslyn only)
            };
        }
    }
}