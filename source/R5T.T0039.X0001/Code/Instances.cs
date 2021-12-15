using System;

using R5T.T0034;
using R5T.T0045;


namespace R5T.T0039.X0001
{
    public static class Instances
    {
        public static IAttributeTypeName AttributeTypeName { get; } = T0034.AttributeTypeName.Instance;
        public static ICodeDirectoryOperator CodeDirectoryOperator { get; } = T0045.CodeDirectoryOperator.Instance;
        public static ICodeFileOperator CodeFileOperator { get; } = T0045.CodeFileOperator.Instance;
        public static ICompilationUnitOperator CompilationUnitOperator { get; } = T0045.CompilationUnitOperator.Instance;
        public static INamespacedTypeName NamespacedTypeName { get; } = T0034.NamespacedTypeName.Instance;
    }
}
