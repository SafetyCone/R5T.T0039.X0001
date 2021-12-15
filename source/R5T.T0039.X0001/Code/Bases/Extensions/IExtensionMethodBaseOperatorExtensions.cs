using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0039;
using R5T.T0058;

using Instances = R5T.T0039.X0001.Instances;


namespace System
{
    public static class IExtensionMethodBaseOperatorExtensions
    {
        public static async Task<NamespacedTypeNameCSharpCodeFilePath[]> GetExtensionMethodBaseExtensionMethods(this IExtensionMethodBaseOperator _,
            string projectDirectoryPath)
        {
            var output = new List<NamespacedTypeNameCSharpCodeFilePath>();

            var extensionMethodBasesExtensionsCodeFilePaths = Instances.CodeDirectoryOperator.GetBasesExtensionsDirectoryFilePaths(projectDirectoryPath);
            foreach (var filePath in extensionMethodBasesExtensionsCodeFilePaths)
            {
                var compilationUnit = await Instances.CompilationUnitOperator.Load(filePath);

                var namespacedTypedParameterizedMethodNames = Instances.CompilationUnitOperator.GetExtensionMethodNamespacedTypedParameterizedMethodNames_StringlyTyped(compilationUnit);
                foreach (var namespacedTypedParameterizedMethodName in namespacedTypedParameterizedMethodNames)
                {
                    var namespacedCodeFilePath = new NamespacedTypeNameCSharpCodeFilePath
                    {
                        CodeFilePath = Instances.CodeFileOperator.ToStronglyTypedCSharpCodeFilePath(filePath),
                        NamespacedTypeName = Instances.NamespacedTypeName.ToStronglyTypedNamespacedTypeName(namespacedTypedParameterizedMethodName) // Note, misuse of the strongly-typed namespaced type name class, but ok.
                    };

                    output.Add(namespacedCodeFilePath);
                }
            }

            return output.ToArray();
        }

        public static async Task<NamespacedTypeNameCSharpCodeFilePath[]> GetExtensionMethodBases(this IExtensionMethodBaseOperator _,
            string projectDirectoryPath)
        {
            var output = await Instances.CodeFileOperator.GetNamespacedTypeNameCSharpCodeFilePaths(
                projectDirectoryPath,
                Instances.CodeDirectoryOperator.GetBasesIntefacesDirectoryFilePathsGenerator(),
                _.GetHasExtensionMethodBaseMarkerAttributePredicate());

            return output;
        }

        public static async Task<NamespacedTypeNameCSharpCodeFilePath[]> GetAllExtensionMethodBases(this IExtensionMethodBaseOperator _,
               string projectDirectoryPath)
        {
            // Actual only (not including possible), but there is no possible at the momment.
            var output = await _.GetExtensionMethodBases(projectDirectoryPath);
            return output;
        }

        public static bool HasExtensionMethodBaseMarkerAttribute(this IExtensionMethodBaseOperator _,
            InterfaceDeclarationSyntax @interface)
        {
            var output = @interface.HasAttributeOfType(
                Instances.AttributeTypeName.ExtensionMethodBaseMarkerAttribute());

            return output;
        }

        public static Func<InterfaceDeclarationSyntax, bool> GetHasExtensionMethodBaseMarkerAttributePredicate(this IExtensionMethodBaseOperator _)
        {
            bool Output(InterfaceDeclarationSyntax @interface) => _.HasExtensionMethodBaseMarkerAttribute(@interface);
            return Output;
        }
    }
}
