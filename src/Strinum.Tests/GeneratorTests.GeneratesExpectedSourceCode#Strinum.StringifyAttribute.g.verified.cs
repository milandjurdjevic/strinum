﻿//HintName: Strinum.StringifyAttribute.g.cs
// <auto-generated />
namespace Strinum
{
    [global::System.AttributeUsage(AttributeTargets.Field)]
    public sealed class StringifyAttribute : global::System.Attribute
    {
        public StringifyAttribute(string value)
        {
            Value = value;
        }
        
        public string Value { get; }
    }
}