# Strinum

Quick and easy conversion between enum and strings using source generator.

## Features

### Convert Enum To String
Convert an enum to a string representation, using the `StringEnum.ToString` method. The output can be customized
using the `StringEnumAttribute` class.

```csharp
enum MyEnum
{
    ValueOne,
    [StringEnum("Value 2")] ValueTwo
}


string value = StringEnum.ToString(MyEnum.Value);
```

### Convert String To Enum
Convert a string to an enum representation, using the `StringEnum.ToEnum` method. The method returns a null in case
that the string does not match any enum member.

```csharp
MyEnum? value = StringEnum.ToEnum<MyEnum>("Value");
```
