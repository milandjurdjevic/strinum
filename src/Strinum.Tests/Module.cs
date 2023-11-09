using System.Runtime.CompilerServices;

namespace Strinum.Tests;

public static class Module
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifySourceGenerators.Initialize();
    }
}