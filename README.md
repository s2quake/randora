# Randora

A lightweight random-value utility. It provides simple APIs to generate a wide range of data: primitives, collections, enums, text, time values, shuffles, and more.

## Supported frameworks

This library is packaged as a multi-targeted NuGet.

- .NET 9.0 (default target for development)
- .NET 8.0
- .NET 7.0
- .NET 6.0
- .NET Standard 2.1

## Quick start: use with an alias

If `RandomUtility` feels too verbose, define a C# alias for concise code.

```csharp
using R = JSSoft.Randora.RandomUtility;

// Now you can call it succinctly:
int i = R.Int32();
Guid g = R.Guid();
```

To use it project-wide, add a using alias via GlobalUsings or your project file (e.g., Directory.Build.props).

```xml
<ItemGroup>
	<Using Include="JSSoft.Randora.RandomUtility" Alias="R" />
</ItemGroup>
```

## Basic usage

### Primitives

```csharp
using R = JSSoft.Randora.RandomUtility;

// Using the default (shared) Random
int i = R.Int32();                    // arbitrary int
int iInRange = R.Int32(-10, 10);      // [-10, 9]
long l = R.Int64();                   // arbitrary long
double d = R.Double();                // double in [0.0, 1.0)
decimal m = R.Decimal();              // decimal in [0m, 1m)
bool b = R.Boolean();                 // true/false
Guid g = R.Guid();                    // random Guid
string hex = R.Hex(8);                // 8 bytes → 16 hex characters
string word = R.Word();               // a single word
string sentence = R.String();         // 1–9 words joined by spaces

// Date/Time
DateTimeOffset dto = R.DateTimeOffset(); // roughly UnixEpoch ~ 2050-12-31
TimeSpan ts = R.TimeSpan();              // 0 to less than 365 days
TimeSpan tsMs = R.TimeSpan(10, 20);      // 10ms ~ 19ms

// BigInteger and sign helpers
BigInteger bi = R.BigInteger();          // internally based on 1–16 random bytes
int pos = R.Positive();                  // > 0
int nonNeg = R.NonNegative();            // >= 0
```

Every API also has an overload that accepts a `Random` instance. For reproducible outcomes, pass a seeded `Random`.

```csharp
var r = new Random(1234);
int v = R.Int32(r, -100, 100);
Guid gid = R.Guid(r);
```

### Collections

Provide only a generator delegate and get back many types of collections. If you omit the length, `R.Length()` (defaults to 1–9) is used internally.

```csharp
// Arrays/Lists
int[] arr = R.Array(R.Int32, length: 5);
List<string> list = R.List(R.String, length: 3);

// Sets (attempt to ensure uniqueness), sorted sets/dictionaries
HashSet<int> set = R.HashSet(R.Int32, length: 10);
SortedSet<int> sortedSet = R.SortedSet(R.Int32, length: 10);

// Dictionaries (keys must be unique)
var dict = R.Dictionary(() => R.Int32(0, 10_000), R.String, length: 20);
var sortedDict = R.SortedDictionary(() => R.Int32(0, 10_000), R.String, length: 20);

// Immutable collections
var ia = R.ImmutableArray(R.Int32, length: 4);
var il = R.ImmutableList(R.Int32, length: 6);
var ihs = R.ImmutableHashSet(R.Int32, length: 10);
var iss = R.ImmutableSortedSet(R.Int32, length: 10);
var id = R.ImmutableDictionary(() => R.Int32(0, 10_000), R.String, length: 10);
var isd = R.ImmutableSortedDictionary(() => R.Int32(0, 10_000), R.String, length: 10);

// With an explicit Random (useful for reproducible tests)
var r = new Random(7);
int[] seeded = R.Array(r, rr => R.Int32(rr, 0, 100), length: 5);
```

### Tuples and value tuples

Generate System.Tuple and C# value tuples by providing element generators. Two-element examples shown here; higher arities are also available.

```csharp
using R = JSSoft.Randora.RandomUtility;

// System.Tuple<T1, T2>
Tuple<int, string> t = R.Tuple(R.Int32, R.String);

// With an explicit Random (for reproducibility)
var r = new Random(123);
Tuple<int, string> tSeeded = R.Tuple(r, rr => R.Int32(rr, 0, 100), R.String);

// ValueTuple<T1, T2>
(int n, string s) vt = R.ValueTuple(R.Int32, R.String);

// Seeded value tuple
var r2 = new Random(123);
var vtSeeded = R.ValueTuple(r2, rr => R.Int32(rr, 0, 100), R.String);
```

### Nullable and NullableObject

Produce nullable value types via the `Nullable*` helpers (or the generic `Nullable<T>`), and nullable reference types via `NullableObject*` (or the generic `NullableObject<T>`). By default, there is a 66% chance of a non-null value.

```csharp
using R = JSSoft.Randora.RandomUtility;

// Value type (int?)
int? maybeInt = R.NullableInt32();                // ~66% non-null
int? maybeInt2 = R.Nullable(R.Int32);             // same behavior via generic helper

// Reference type (string?)
string? maybeString = R.NullableString();         // ~66% non-null
string? maybeString2 = R.NullableObject(R.String);

// Seeded variants
var r = new Random(2025);
int? seededInt = R.NullableInt32(r);
string? seededString = R.NullableString(r);
```

### Try, Chance, Random, RandomOrDefault

```csharp
// Try: generate until a predicate is satisfied → throws MaxAttemptsExceededException
// if the generator keeps failing to meet the predicate repeatedly
int even = R.Try(() => R.Int32(0, 10), x => x % 2 == 0);

// Chance: return true/false with a probability
bool p30 = R.Chance(30);     // 30%
bool pHalf = R.Chance(0.5);  // 50%

// Enumerable extensions: pick a random element
var nums = new[] { 1, 2, 3 };
int pick = nums.Random();                 // throws InvalidOperationException if empty
int pickOrDefault = nums.RandomOrDefault(); // returns default(int) == 0 if empty

// For classes/nullables
object? o = Array.Empty<object>().RandomOrDefault(); // returns null
```

### Length utility

```csharp
int any = R.Length();        // 1 ~ 9
int l1to6 = R.Length(7);     // 1 ~ 6 (exclusive upper bound)
int l3to6 = R.Length(3, 7);  // 3 ~ 6 (exclusive upper bound)
```

## Notes

- `Enum<T>()` does not support [Flags] enums and throws `InvalidOperationException`.
- The `Random()` / `RandomOrDefault()` extensions operate on `IEnumerable<T>`. `Random()` throws on empty sequences; `RandomOrDefault()` returns `default(T)`.
- When length is omitted for collection generators, the internal `R.Length()` result is used (defaults to 1–9). If key/value collisions occur repeatedly, you may end up with fewer items than requested.

```csharp
// Library namespace
// using JSSoft.Randora; // (RandomUtility resides in this namespace)
```

