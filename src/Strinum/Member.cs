using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Strinum;

public class Member
{
    private readonly AttributeData _marker;
    private readonly ISymbol _symbol;

    public Member(ISymbol symbol, AttributeData marker)
    {
        _symbol = symbol;
        _marker = marker;
    }

    public ITypeSymbol Type => _symbol.ContainingType;
    public string Key => $"global::{_symbol.ToDisplayString()}";

    public string Value
    {
        get
        {
            AttributeSyntax? markerSyntax = _marker.ApplicationSyntaxReference?.GetSyntax() as AttributeSyntax;
            AttributeArgumentSyntax? markerArgumentSyntax = markerSyntax?.ArgumentList?.Arguments.FirstOrDefault();
            string? markerArgumentValue = markerArgumentSyntax?.ToString().Trim('"');
            return String.IsNullOrWhiteSpace(markerArgumentValue)
                ? "global::System.String.Empty"
                : $"\"{markerArgumentValue}\"";
        }
    }
}