using System.ComponentModel;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Strinum.Tests;

[UsesVerify]
public class GeneratorTests
{
    [Fact]
    public Task GeneratesExpectedSourceCode()
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(
            """
            using System.ComponentModel;

            public enum GlobalEnumType
            {
                [Description("One global")] One,
                [Description("Two global")] Two,
                Three
            }

            namespace EnumNamespace
            {
                public enum EnumType
                {
                    [Description("One")] One,
                    [Description("Two")] Two,
                    Three,
                    [Description] Four
                }
            
                public class WrapperClass
                {
                    public enum NestedEnumType
                    {
                        [Description("One nested")] One,
                        [Description("Two nested")] Two,
                        Three
                    }
                    
                    private enum PrivateNestedEnumType
                    {
                        [Description("One private nested")] One,
                        [Description("Two private nested")] Two,
                        Three
                    }
                    
                    internal enum InternalNestedEnumType
                    {
                        [Description("One internal nested")] One,
                        [Description("Two internal nested")] Two,
                        Three
                    }
                }
            }
            """);


        CSharpCompilation compilation = CSharpCompilation.Create(nameof(GeneratorTests),
            new[] { syntaxTree },
            new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(DescriptionAttribute).Assembly.Location)
            });

        Generator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).RunGenerators(compilation);

        return Verify(driver);
    }
}