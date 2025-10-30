Commands changes
===================

1.0.0
-------------

### Initial Release

A lightweight random-value utility library providing comprehensive APIs for generating various types of random data.

**Core Features:**
- **Primitive Types**: Generate random values for all basic .NET types (sbyte, byte, int, long, float, double, decimal, bool, char, Guid, etc.)
- **Collections**: Create arrays, lists, sets, dictionaries with customizable generators and lengths
- **Immutable Collections**: Support for ImmutableArray, ImmutableList, ImmutableHashSet, ImmutableDictionary, etc.
- **Nullable Types**: Generate nullable value types and reference types with configurable null probability (default 66% non-null)
- **Tuples**: Create both System.Tuple and ValueTuple with 2-8 elements using custom generators
- **Text Generation**: Random words, sentences, and hexadecimal strings from built-in word dictionary
- **Date/Time**: Generate DateTimeOffset and TimeSpan values within configurable ranges
- **Enums**: Random enum values (excluding [Flags] enums)
- **BigInteger**: Generate arbitrary-precision integers with configurable byte lengths
- **Sign Helpers**: Utilities for positive, negative, non-negative, and non-positive values
- **Collection Extensions**: RandomOrDefault() and Random() extension methods for IEnumerable<T>
- **Conditional Generation**: Try() method for generating values that satisfy predicates
- **Probability Utilities**: Chance() method for percentage-based boolean results
- **Length Utilities**: Configurable length generation for collections (default 1-9 items)
- **Seeded Random**: All methods support explicit Random instances for reproducible results
- **Multi-Target Support**: Compatible with .NET 6.0, 7.0, 8.0, 9.0, and .NET Standard 2.1

