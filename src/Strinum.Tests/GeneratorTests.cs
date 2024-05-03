using System.ComponentModel.DataAnnotations;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Strinum.Tests;

[UsesVerify]
public class GeneratorTests
{
    [Fact]
    public Task GeneratesExpectedSourceCode()
    {
        // lang=csharp
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(
            """
            using Strinum;

            public enum GlobalEnumType
            {
                One,
                Two,
                Three
            }

            namespace EnumNamespace
            {
                public enum EnumType
                {
                    One,
                    Two,
                    Three,
                    Four
                }
                
                public enum EnumTypeWithAttribute
                {
                    [StringEnum("NumberOne")] One,
                    [StringEnum("NumberTwo")] Two,
                    [StringEnum("NumberThree")] Three
                }
            
                public class WrapperClass
                {
                    public enum NestedEnumType
                    {
                        One,
                        Two,
                        Three
                    }
                    
                    private enum PrivateNestedEnumType
                    {
                        One,
                        Two,
                        Three
                    }
                    
                    internal enum InternalNestedEnumType
                    {
                        One,
                        Two,
                        Three
                    }
                }
                
                public class Program
                {
                    // Trigger the generator
                    public static void Main()
                    {
                        _ = StringEnum.ToString(GlobalEnumType.One);
                        _ = StringEnum.ToString(EnumType.One);
                        _ = StringEnum.ToString(EnumTypeWithAttribute.One);
                        _ = StringEnum.ToString(WrapperClass.NestedEnumType.One);
                        _ = StringEnum.ToString(WrapperClass.InternalNestedEnumType.One);
                        _ = StringEnum.ToString(System.DayOfWeek.Monday);
                    }
                }
            }
            """);

        CSharpCompilation compilation = CSharpCompilation.Create(nameof(GeneratorTests),
            new[] { syntaxTree },
            new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(DisplayAttribute).Assembly.Location)
            }
        );
        Generator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator).RunGenerators(compilation);
        return Verify(driver);
    }
}