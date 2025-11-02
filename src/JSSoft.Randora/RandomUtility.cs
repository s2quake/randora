// <copyright file="RandomUtility.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;

namespace JSSoft.Randora;

/// <summary>
/// Provides utility methods for generating random values of various types.
/// </summary>
public static partial class RandomUtility
{
    /// <summary>
    /// The maximum number of attempts the Try methods will perform to produce a value
    /// that satisfies the predicate before throwing an exception.
    /// </summary>
    public const int AttemptCount = 100;

    private static readonly char[] _hexCharacters =
    [
        '0', '1', '2', '3', '4', '5', '6', '7',
        '8', '9', 'a', 'b', 'c', 'd', 'e', 'f',
    ];

#if NETSTANDARD2_1
    private static readonly Random _shared = new(Seed: 0);
#else
    private static readonly Random _shared = System.Random.Shared;
#endif

    private static readonly string[] Words = GetWords();

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value.
    /// </summary>
    public static sbyte SByte() => SByte(_shared);

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static sbyte SByte(Random random)
    {
        var bytes = new byte[1];
        random.NextBytes(bytes);
        return (sbyte)bytes[0];
    }

    /// <summary>
    /// Generates a random <see cref="byte"/> value.
    /// </summary>
    public static byte Byte() => Byte(_shared);

    /// <summary>
    /// Generates a random <see cref="byte"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static byte Byte(Random random)
    {
        var bytes = new byte[1];
        random.NextBytes(bytes);
        return bytes[0];
    }

    /// <summary>
    /// Generates a byte array of a random length within the default range.
    /// </summary>
    public static byte[] Bytes() => Bytes(_shared);

    /// <summary>
    /// Generates a byte array with the specified length filled with random values.
    /// </summary>
    /// <param name="length">The number of bytes to generate.</param>
    public static byte[] Bytes(int length) => Bytes(_shared, length);

    /// <summary>
    /// Generates a byte array of a random length within the default range using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static byte[] Bytes(Random random) => Bytes(random, Length(random));

    /// <summary>
    /// Generates a byte array with the specified length using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="length">The number of bytes to generate.</param>
    public static byte[] Bytes(Random random, int length)
    {
        var bytes = new byte[length];
        random.NextBytes(bytes);
        return bytes;
    }

    /// <summary>
    /// Generates a random <see cref="short"/> value.
    /// </summary>
    public static short Int16() => Int16(_shared);

    /// <summary>
    /// Generates a random <see cref="short"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static short Int16(Random random)
    {
        var bytes = new byte[2];
        random.NextBytes(bytes);
        return BitConverter.ToInt16(bytes, 0);
    }

    /// <summary>
    /// Generates a random <see cref="ushort"/> value.
    /// </summary>
    public static ushort UInt16() => UInt16(_shared);

    /// <summary>
    /// Generates a random <see cref="ushort"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static ushort UInt16(Random random)
    {
        var bytes = new byte[2];
        random.NextBytes(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }

    /// <summary>
    /// Generates a random <see cref="int"/> value.
    /// </summary>
    public static int Int32() => Int32(_shared);

    /// <summary>
    /// Generates a random <see cref="int"/> within the specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound.</param>
    /// <param name="maxValue">The exclusive upper bound.</param>
    public static int Int32(int minValue, int maxValue) => _shared.Next(minValue, maxValue);

    /// <summary>
    /// Generates a random <see cref="int"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int Int32(Random random) => Int32(random, int.MinValue, int.MaxValue);

    /// <summary>
    /// Generates a random <see cref="int"/> within the specified range using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="minValue">The inclusive lower bound.</param>
    /// <param name="maxValue">The exclusive upper bound.</param>
    public static int Int32(Random random, int minValue, int maxValue) => random.Next(minValue, maxValue);

    /// <summary>
    /// Generates a random <see cref="uint"/> value.
    /// </summary>
    public static uint UInt32() => UInt32(_shared);

    /// <summary>
    /// Generates a random <see cref="uint"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static uint UInt32(Random random)
    {
        var bytes = new byte[4];
        random.NextBytes(bytes);
        return BitConverter.ToUInt32(bytes, 0);
    }

    /// <summary>
    /// Generates a random <see cref="long"/> value.
    /// </summary>
    public static long Int64() => Int64(_shared);

    /// <summary>
    /// Generates a random <see cref="long"/> within the specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound.</param>
    /// <param name="maxValue">The exclusive upper bound.</param>
    public static long Int64(long minValue, long maxValue) => _shared.NextInt64(minValue, maxValue);

    /// <summary>
    /// Generates a random <see cref="long"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static long Int64(Random random) => Int64(random, long.MinValue, long.MaxValue);

    /// <summary>
    /// Generates a random <see cref="long"/> within the specified range using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="minValue">The inclusive lower bound.</param>
    /// <param name="maxValue">The exclusive upper bound.</param>
    public static long Int64(Random random, long minValue, long maxValue) => random.NextInt64(minValue, maxValue);

    /// <summary>
    /// Generates a random <see cref="ulong"/> value.
    /// </summary>
    public static ulong UInt64() => UInt64(_shared);

    /// <summary>
    /// Generates a random <see cref="ulong"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static ulong UInt64(Random random)
    {
        var bytes = new byte[8];
        random.NextBytes(bytes);
        return BitConverter.ToUInt64(bytes, 0);
    }

    /// <summary>
    /// Generates a random <see cref="float"/> value.
    /// </summary>
    public static float Single() => Single(_shared);

    /// <summary>
    /// Generates a random <see cref="float"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static float Single(Random random)
    {
#if NET6_0_OR_GREATER
        return random.NextSingle();
#else
        return (float)random.NextDouble() * random.Next();
#endif
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value.
    /// </summary>
    public static double Double() => Double(_shared);

    /// <summary>
    /// Generates a random <see cref="double"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static double Double(Random random) => random.NextDouble();

    /// <summary>
    /// Generates a random <see cref="decimal"/> value.
    /// </summary>
    public static decimal Decimal() => Decimal(_shared);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static decimal Decimal(Random random) => (decimal)random.NextDouble();

    /// <summary>
    /// Generates a random <see cref="System.Numerics.BigInteger"/> value.
    /// </summary>
    public static BigInteger BigInteger() => BigInteger(_shared);

    /// <summary>
    /// Generates a random <see cref="System.Numerics.BigInteger"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static BigInteger BigInteger(Random random)
    {
        var length = Length(random, 1, 17);
        var bytes = Array(random, Byte, length);
        return new BigInteger(bytes);
    }

    /// <summary>
    /// Generates a positive <see cref="int"/> value (> 0).
    /// </summary>
    public static int Positive() => Positive(_shared);

    /// <summary>
    /// Generates a positive <see cref="int"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int Positive(Random random) => Int32(random, 0, int.MaxValue) + 1;

    /// <summary>
    /// Generates a negative <see cref="int"/> value (&lt; 0).
    /// </summary>
    public static int Negative() => Negative(_shared);

    /// <summary>
    /// Generates a negative <see cref="int"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int Negative(Random random) => Int32(random, int.MinValue, 0);

    /// <summary>
    /// Generates a non-positive <see cref="int"/> value (&lt;= 0).
    /// </summary>
    public static int NonPositive() => NonPositive(_shared);

    /// <summary>
    /// Generates a non-positive <see cref="int"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int NonPositive(Random random) => Int32(random, int.MinValue, 1);

    /// <summary>
    /// Generates a non-negative <see cref="int"/> value (>= 0).
    /// </summary>
    public static int NonNegative() => NonNegative(_shared);

    /// <summary>
    /// Generates a non-negative <see cref="int"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int NonNegative(Random random) => Int32(random, -1, int.MaxValue) + 1;

    /// <summary>
    /// Generates a positive <see cref="long"/> value (> 0).
    /// </summary>
    public static long PositiveInt64() => PositiveInt64(_shared);

    /// <summary>
    /// Generates a positive <see cref="long"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static long PositiveInt64(Random random) => Int64(random, 0, long.MaxValue) + 1;

    /// <summary>
    /// Generates a negative <see cref="long"/> value (&lt; 0).
    /// </summary>
    public static long NegativeInt64() => NegativeInt64(_shared);

    /// <summary>
    /// Generates a negative <see cref="long"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static long NegativeInt64(Random random) => Int64(random, long.MinValue, 0);

    /// <summary>
    /// Generates a non-positive <see cref="long"/> value (&lt;= 0).
    /// </summary>
    public static long NonPositiveInt64() => NonPositiveInt64(_shared);

    /// <summary>
    /// Generates a non-positive <see cref="long"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static long NonPositiveInt64(Random random) => Int64(random, long.MinValue, 1);

    /// <summary>
    /// Generates a non-negative <see cref="long"/> value (>= 0).
    /// </summary>
    public static long NonNegativeInt64() => NonNegativeInt64(_shared);

    /// <summary>
    /// Generates a non-negative <see cref="long"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static long NonNegativeInt64(Random random) => Int64(random, -1, long.MaxValue) + 1;

    /// <summary>
    /// Generates a positive <see cref="System.Numerics.BigInteger"/> value (> 0).
    /// </summary>
    public static BigInteger PositiveBigInteger() => PositiveBigInteger(_shared);

    /// <summary>
    /// Generates a positive <see cref="System.Numerics.BigInteger"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static BigInteger PositiveBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign > 0 ? v : -v;
    }

    /// <summary>
    /// Generates a negative <see cref="System.Numerics.BigInteger"/> value (&lt; 0).
    /// </summary>
    public static BigInteger NegativeBigInteger() => NegativeBigInteger(_shared);

    /// <summary>
    /// Generates a negative <see cref="System.Numerics.BigInteger"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static BigInteger NegativeBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign < 0 ? v : -v;
    }

    /// <summary>
    /// Generates a non-positive <see cref="System.Numerics.BigInteger"/> value (&lt;= 0).
    /// </summary>
    public static BigInteger NonPositiveBigInteger() => NonPositiveBigInteger(_shared);

    /// <summary>
    /// Generates a non-positive <see cref="System.Numerics.BigInteger"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static BigInteger NonPositiveBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign <= 0 ? v : -v;
    }

    /// <summary>
    /// Generates a non-negative <see cref="System.Numerics.BigInteger"/> value (>= 0).
    /// </summary>
    public static BigInteger NonNegativeBigInteger() => NonNegativeBigInteger(_shared);

    /// <summary>
    /// Generates a non-negative <see cref="System.Numerics.BigInteger"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static BigInteger NonNegativeBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign >= 0 ? v : -v;
    }

    /// <summary>
    /// Returns a random word from the embedded dictionary.
    /// </summary>
    public static string Word() => Word(_shared);

    /// <summary>
    /// Returns a random word using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static string Word(Random random) => Words[Int32(random, 0, Words.Length)];

    /// <summary>
    /// Generates a hexadecimal string of random length within the default range.
    /// </summary>
    public static string Hex() => Hex(_shared);

    /// <summary>
    /// Generates a hexadecimal string with the specified length.
    /// </summary>
    /// <param name="length">The number of hex characters to produce.</param>
    public static string Hex(int length) => Hex(_shared, length);

    /// <summary>
    /// Generates a hexadecimal string of random length using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static string Hex(Random random) => Hex(random, Length(random));

    /// <summary>
    /// Generates a hexadecimal string with the specified length using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="length">The number of hex characters to produce.</param>
    public static string Hex(Random random, int length) => Hex(Bytes(random, length));

    /// <summary>
    /// Generates a random <see cref="char"/> value.
    /// </summary>
    public static char Char() => Char(_shared);

    /// <summary>
    /// Generates a random <see cref="char"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static char Char(Random random) => (char)UInt16(random);

    /// <summary>
    /// Generates a random <see cref="System.DateTimeOffset"/> value.
    /// </summary>
    public static DateTimeOffset DateTimeOffset() => DateTimeOffset(_shared);

    /// <summary>
    /// Generates a random <see cref="System.DateTimeOffset"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static DateTimeOffset DateTimeOffset(Random random)
    {
        var minValue = DateTime.UnixEpoch.Ticks;
        var maxValue = new DateTime(2050, 12, 31, 0, 0, 0, DateTimeKind.Utc).Ticks;
        var value = random.NextInt64(minValue, maxValue) / 10000000L * 10000000L;
        return new DateTimeOffset(value, System.TimeSpan.Zero);
    }

    /// <summary>
    /// Generates a random <see cref="System.TimeSpan"/> value.
    /// </summary>
    public static TimeSpan TimeSpan() => TimeSpan(_shared);

    /// <summary>
    /// Generates a random <see cref="System.TimeSpan"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static TimeSpan TimeSpan(Random random) => new(random.NextInt64(new TimeSpan(365, 0, 0, 0).Ticks));

    /// <summary>
    /// Generates a <see cref="System.TimeSpan"/> within the specified milliseconds range.
    /// </summary>
    /// <param name="minMilliseconds">The inclusive lower bound in milliseconds.</param>
    /// <param name="maxMilliseconds">The exclusive upper bound in milliseconds.</param>
    public static TimeSpan TimeSpan(int minMilliseconds, int maxMilliseconds)
        => TimeSpan(_shared, minMilliseconds, maxMilliseconds);

    /// <summary>
    /// Generates a <see cref="System.TimeSpan"/> within the specified milliseconds range using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="minMilliseconds">The inclusive lower bound in milliseconds.</param>
    /// <param name="maxMilliseconds">The exclusive upper bound in milliseconds.</param>
    public static TimeSpan TimeSpan(Random random, int minMilliseconds, int maxMilliseconds)
    {
        var milliseconds = random.Next(minMilliseconds, maxMilliseconds);
        return System.TimeSpan.FromMilliseconds(milliseconds);
    }

    /// <summary>
    /// Generates a random <see cref="System.Guid"/> value.
    /// </summary>
    public static Guid Guid() => Guid(_shared);

    /// <summary>
    /// Generates a random <see cref="System.Guid"/> value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static Guid Guid(Random random) => new(Array(random, Byte, 16));

    /// <summary>
    /// Returns a random length within the default range.
    /// </summary>
    public static int Length() => Length(_shared);

    /// <summary>
    /// Returns a random length between 1 (inclusive) and the specified maximum (exclusive).
    /// </summary>
    /// <param name="maxLength">The exclusive upper bound.</param>
    public static int Length(int maxLength) => Length(1, maxLength);

    /// <summary>
    /// Returns a random length within the specified range.
    /// </summary>
    /// <param name="minLength">The inclusive lower bound.</param>
    /// <param name="maxLength">The exclusive upper bound.</param>
    public static int Length(int minLength, int maxLength) => Length(_shared, minLength, maxLength);

    /// <summary>
    /// Returns a random length within the default range using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static int Length(Random random) => Length(random, 1, 10);

    /// <summary>
    /// Returns a random length between 1 (inclusive) and the specified maximum (exclusive) using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="maxLength">The exclusive upper bound.</param>
    public static int Length(Random random, int maxLength) => Length(random, 1, maxLength);

    /// <summary>
    /// Returns a random length within the specified range using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="minLength">The inclusive lower bound.</param>
    /// <param name="maxLength">The exclusive upper bound.</param>
    public static int Length(Random random, int minLength, int maxLength) => random.Next(minLength, maxLength);

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    public static bool Boolean() => Boolean(_shared);

    /// <summary>
    /// Generates a random boolean value using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static bool Boolean(Random random) => Int32(random, 0, 2) is 0;

    /// <summary>
    /// Returns a random enum value. Flags enums are not supported.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    public static T Enum<T>()
        where T : Enum
        => Enum<T>(_shared);

    /// <summary>
    /// Returns a random enum value using the specified PRNG. Flags enums are not supported.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static T Enum<T>(Random random)
        where T : Enum
    {
        if (Attribute.GetCustomAttribute(typeof(T), typeof(FlagsAttribute)) is FlagsAttribute)
        {
            throw new InvalidOperationException("flags enum is not supported.");
        }

        var values = System.Enum.GetValues(typeof(T));
        var index = Int32(random, 0, values.Length);
        return (T)values.GetValue(index)!;
    }

    /// <summary>
    /// Generates a random whitespace-separated string of words.
    /// </summary>
    public static string String() => String(_shared);

    /// <summary>
    /// Generates a random whitespace-separated string of words using the specified PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static string String(Random random)
    {
        var sb = new StringBuilder();
        var count = Int32(random, 1, 10);
        for (var i = 0; i < count; i++)
        {
            if (sb.Length != 0)
            {
                sb.Append(' ');
            }

            sb.Append(Word(random));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Creates an array of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static T[] Array<T>(Func<T> generator) => Array(generator, Length());

    /// <summary>
    /// Creates an array using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The number of elements.</param>
    public static T[] Array<T>(Func<T> generator, int length) => Array(_shared, _ => generator(), length);

    /// <summary>
    /// Creates an array of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static T[] Array<T>(Random random, Func<Random, T> generator) => Array(random, generator, Length(random));

    /// <summary>
    /// Creates an array using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The number of elements.</param>
    public static T[] Array<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return items;
    }

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.List{T}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static List<T> List<T>(Func<T> generator) => List(generator, Length());

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.List{T}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The number of elements.</param>
    public static List<T> List<T>(Func<T> generator, int length)
        => List(_shared, _ => generator(), length);

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.List{T}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static List<T> List<T>(Random random, Func<Random, T> generator)
        => List(random, generator, Length(random));

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.List{T}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The number of elements.</param>
    public static List<T> List<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return [.. items];
    }

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.HashSet{TValue}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static HashSet<TValue> HashSet<TValue>(Func<TValue> generator) => HashSet(generator, Length());

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.HashSet{TValue}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static HashSet<TValue> HashSet<TValue>(Func<TValue> generator, int length)
        => HashSet(_shared, _ => generator(), length);

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.HashSet{TValue}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static HashSet<TValue> HashSet<TValue>(Random random, Func<Random, TValue> generator)
        => HashSet(random, generator, Length(random));

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.HashSet{TValue}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static HashSet<TValue> HashSet<TValue>(Random random, Func<Random, TValue> generator, int length)
    {
        var itemList = new List<TValue>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetValue(random, generator, item => !itemList.Contains(item), out var item))
            {
                break;
            }

            itemList.Add(item);
        }

        return [.. itemList];
    }

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedSet{TValue}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static SortedSet<TValue> SortedSet<TValue>(Func<TValue> generator) => SortedSet(generator, Length());

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedSet{TValue}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static SortedSet<TValue> SortedSet<TValue>(Func<TValue> generator, int length)
        => SortedSet(_shared, _ => generator(), length);

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedSet{TValue}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static SortedSet<TValue> SortedSet<TValue>(Random random, Func<Random, TValue> generator)
        => SortedSet(random, generator, Length(random));

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedSet{TValue}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="TValue">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static SortedSet<TValue> SortedSet<TValue>(Random random, Func<Random, TValue> generator, int length)
    {
        var itemList = new List<TValue>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetValue(random, generator, item => !itemList.Contains(item), out var item))
            {
                break;
            }

            itemList.Add(item);
        }

        return [.. itemList];
    }

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/> of random length using the specified key and value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => Dictionary(keyGenerator, valueGenerator, Length());

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/> using the specified key/value generators and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => Dictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/> of random length using the specified PRNG and key/value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => Dictionary(random, keyGenerator, valueGenerator, Length(random));

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.Dictionary{TKey, TValue}"/> using the specified PRNG, key/value generators, and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
    {
        var keySet = new HashSet<TKey>(length);
        var itemList = new List<KeyValuePair<TKey, TValue>>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetKey(random, keyGenerator, item => !keySet.Contains(item), out var key))
            {
                break;
            }

            var value = valueGenerator(random);
            itemList.Add(new(key, value));
            keySet.Add(key);
        }

        return new Dictionary<TKey, TValue>(itemList);
    }

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedDictionary{TKey, TValue}"/> of random length using the specified key and value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => SortedDictionary(keyGenerator, valueGenerator, Length());

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedDictionary{TKey, TValue}"/> using the specified key/value generators and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => SortedDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedDictionary{TKey, TValue}"/> of random length using the specified PRNG and key/value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => SortedDictionary(random, keyGenerator, valueGenerator, Length(random));

    /// <summary>
    /// Creates a <see cref="System.Collections.Generic.SortedDictionary{TKey, TValue}"/> using the specified PRNG, key/value generators, and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
    {
        var dictionary = new Dictionary<TKey, TValue>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetKey(random, keyGenerator, item => !dictionary.ContainsKey(item), out var key))
            {
                break;
            }

            var value = valueGenerator(random);
            dictionary.Add(key, value);
        }

        return new SortedDictionary<TKey, TValue>(dictionary);
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableArray{T}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static ImmutableArray<T> ImmutableArray<T>(Func<T> generator)
        => ImmutableArray(generator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableArray{T}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The number of elements.</param>
    public static ImmutableArray<T> ImmutableArray<T>(Func<T> generator, int length)
        => ImmutableArray(_shared, _ => generator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableArray{T}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static ImmutableArray<T> ImmutableArray<T>(Random random, Func<Random, T> generator)
        => ImmutableArray(random, generator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableArray{T}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The number of elements.</param>
    public static ImmutableArray<T> ImmutableArray<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return System.Collections.Immutable.ImmutableArray.Create(items);
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableList{T}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static ImmutableList<T> ImmutableList<T>(Func<T> generator)
        => ImmutableList(generator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableList{T}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The number of elements.</param>
    public static ImmutableList<T> ImmutableList<T>(Func<T> generator, int length)
        => ImmutableList(_shared, _ => generator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableList{T}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static ImmutableList<T> ImmutableList<T>(Random random, Func<Random, T> generator)
        => ImmutableList(random, generator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableList{T}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The number of elements.</param>
    public static ImmutableList<T> ImmutableList<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return System.Collections.Immutable.ImmutableList.Create(items);
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableHashSet{T}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static ImmutableHashSet<T> ImmutableHashSet<T>(Func<T> generator)
        => ImmutableHashSet(generator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableHashSet{T}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static ImmutableHashSet<T> ImmutableHashSet<T>(Func<T> generator, int length)
        => ImmutableHashSet(_shared, _ => generator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableHashSet{T}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static ImmutableHashSet<T> ImmutableHashSet<T>(Random random, Func<Random, T> generator)
        => ImmutableHashSet(random, generator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableHashSet{T}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static ImmutableHashSet<T> ImmutableHashSet<T>(Random random, Func<Random, T> generator, int length)
    {
        var itemList = new List<T>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetValue(random, generator, item => !itemList.Contains(item), out var item))
            {
                break;
            }

            itemList.Add(item);
        }

        return [.. itemList];
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedSet{T}"/> of random length using the specified value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Func<T> generator)
        => ImmutableSortedSet(generator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedSet{T}"/> using the specified value generator and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">A function that generates element values.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Func<T> generator, int length)
        => ImmutableSortedSet(_shared, _ => generator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedSet{T}"/> of random length using the specified PRNG and value generator.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Random random, Func<Random, T> generator)
        => ImmutableSortedSet(random, generator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedSet{T}"/> using the specified PRNG, value generator, and length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">A function that generates element values given a PRNG.</param>
    /// <param name="length">The maximum number of unique elements to attempt to add.</param>
    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Random random, Func<Random, T> generator, int length)
    {
        var itemList = new List<T>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetValue(random, generator, item => !itemList.Contains(item), out var item))
            {
                break;
            }

            itemList.Add(item);
        }

        return [.. itemList];
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableDictionary{TKey, TValue}"/> of random length using the specified key and value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => ImmutableDictionary(keyGenerator, valueGenerator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableDictionary{TKey, TValue}"/> using the specified key/value generators and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => ImmutableDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableDictionary{TKey, TValue}"/> of random length using the specified PRNG and key/value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => ImmutableDictionary(random, keyGenerator, valueGenerator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableDictionary{TKey, TValue}"/> using the specified PRNG, key/value generators, and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
    {
        var keySet = new HashSet<TKey>(length);
        var itemList = new List<KeyValuePair<TKey, TValue>>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetKey(random, keyGenerator, item => !keySet.Contains(item), out var key))
            {
                break;
            }

            var value = valueGenerator(random);
            itemList.Add(new(key, value));
            keySet.Add(key);
        }

        return System.Collections.Immutable.ImmutableDictionary.CreateRange(itemList);
    }

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedDictionary{TKey, TValue}"/> of random length using the specified key and value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => ImmutableSortedDictionary(keyGenerator, valueGenerator, Length());

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedDictionary{TKey, TValue}"/> using the specified key/value generators and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">A function that generates keys.</param>
    /// <param name="valueGenerator">A function that generates values.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => ImmutableSortedDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedDictionary{TKey, TValue}"/> of random length using the specified PRNG and key/value generators.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => ImmutableSortedDictionary(random, keyGenerator, valueGenerator, Length(random));

    /// <summary>
    /// Creates an <see cref="System.Collections.Immutable.ImmutableSortedDictionary{TKey, TValue}"/> using the specified PRNG, key/value generators, and length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="keyGenerator">A function that generates keys given a PRNG.</param>
    /// <param name="valueGenerator">A function that generates values given a PRNG.</param>
    /// <param name="length">The maximum number of unique keys to attempt to add.</param>
    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
    {
        var keySet = new HashSet<TKey>(length);
        var itemList = new List<KeyValuePair<TKey, TValue>>(length);
        for (var i = 0; i < length; i++)
        {
            if (!TryGetKey(random, keyGenerator, item => !keySet.Contains(item), out var key))
            {
                break;
            }

            var value = valueGenerator(random);
            itemList.Add(new(key, value));
            keySet.Add(key);
        }

        return System.Collections.Immutable.ImmutableSortedDictionary.CreateRange(itemList);
    }

    /// <summary>
    /// Returns a random element from the sequence, or the default value if the sequence is empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="enumerable">The source sequence.</param>
    public static T? RandomOrDefault<T>(this IEnumerable<T> enumerable)
        => RandomOrDefault(enumerable, _shared);

    /// <summary>
    /// Returns a random element from the sequence using the specified PRNG, or the default value if the sequence is empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="enumerable">The source sequence.</param>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static T? RandomOrDefault<T>(this IEnumerable<T> enumerable, Random random)
    {
        var count = 0;
        using (var enumerator1 = enumerable.GetEnumerator())
        {
            while (enumerator1.MoveNext())
            {
                count++;
            }
        }

        using var enumerator2 = enumerable.GetEnumerator();
        var index = Int32(random, 0, count);
        var i = 0;
        while (enumerator2.MoveNext())
        {
            if (i == index)
            {
                return enumerator2.Current;
            }

            i++;
        }

        return default;
    }

    /// <summary>
    /// Returns a random element from the sequence. Throws if the sequence is empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="enumerable">The source sequence.</param>
    public static T Random<T>(this IEnumerable<T> enumerable)
        => Random(enumerable, _shared);

    /// <summary>
    /// Returns a random element from the sequence using the specified PRNG. Throws if the sequence is empty.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="enumerable">The source sequence.</param>
    /// <param name="random">The pseudo-random number generator to use.</param>
    public static T Random<T>(this IEnumerable<T> enumerable, Random random)
    {
        var count = 0;
        using (var enumerator1 = enumerable.GetEnumerator())
        {
            while (enumerator1.MoveNext())
            {
                count++;
            }
        }

        using var enumerator2 = enumerable.GetEnumerator();
        var index = Int32(random, 0, count);
        var i = 0;
        while (enumerator2.MoveNext())
        {
            if (i == index)
            {
                return enumerator2.Current;
            }

            i++;
        }

        throw new InvalidOperationException("Sequence contains no elements.");
    }

    /// <summary>
    /// Repeatedly executes the generator until the predicate is satisfied and returns the value. Throws if the maximum attempts are exceeded.
    /// </summary>
    /// <typeparam name="T">The generated value type.</typeparam>
    /// <param name="generator">The value generator.</param>
    /// <param name="predicate">The predicate to test generated values.</param>
    public static T Try<T>(Func<T> generator, Func<T, bool> predicate)
        => Try(_shared, _ => generator(), predicate);

    /// <summary>
    /// Repeatedly executes the generator with the specified PRNG until the predicate is satisfied. Throws if the maximum attempts are exceeded.
    /// </summary>
    /// <typeparam name="T">The generated value type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="generator">The value generator that accepts a PRNG.</param>
    /// <param name="predicate">The predicate to test generated values.</param>
    public static T Try<T>(Random random, Func<Random, T> generator, Func<T, bool> predicate)
    {
        var countByValue = new Dictionary<object, int>();
        while (true)
        {
            var item = generator(random);
            if (predicate(item))
            {
                return item;
            }

            var key = item is null ? (object)DBNull.Value : item;
            if (!countByValue.TryGetValue(key, out var count))
            {
                countByValue[key] = count = 0;
            }

            count++;
            if (count >= AttemptCount)
            {
                throw new MaxAttemptsExceededException(AttemptCount);
            }

            countByValue[key] = count;
        }
    }

    /// <summary>
    /// Returns true with the specified probability (0–100%).
    /// </summary>
    /// <param name="probability">The probability in percent (0–100).</param>
    public static bool Chance(int probability) => Chance(_shared, probability);

    /// <summary>
    /// Returns true with the specified probability (0–100%) using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="probability">The probability in percent (0–100).</param>
    public static bool Chance(Random random, int probability)
    {
        if (probability < 0 || probability > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0 and 100.");
        }

        return random.Next(0, 100) < probability;
    }

    /// <summary>
    /// Returns true with the specified probability (0.0–1.0).
    /// </summary>
    /// <param name="probability">The probability between 0.0 and 1.0.</param>
    public static bool Chance(double probability) => Chance(_shared, probability);

    /// <summary>
    /// Returns true with the specified probability (0.0–1.0) using the provided PRNG.
    /// </summary>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="probability">The probability between 0.0 and 1.0.</param>
    public static bool Chance(Random random, double probability)
    {
        if (probability < 0.0 || probability > 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0 and 1.");
        }

        return random.NextDouble() < probability;
    }

    /// <summary>
    /// Returns the sequence ordered in a random order.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The source sequence.</param>
    public static IOrderedEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        => Shuffle(_shared, source);

    /// <summary>
    /// Returns the sequence ordered in a random order using the specified PRNG.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The pseudo-random number generator to use.</param>
    /// <param name="source">The source sequence.</param>
    public static IOrderedEnumerable<T> Shuffle<T>(Random random, IEnumerable<T> source)
        => source.OrderBy(_ => random.Next());

    private static string[] GetWords()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = string.Join(
            ".", typeof(RandomUtility).Namespace, "Resources", "words.txt");
        var resourceStream = assembly.GetManifestResourceStream(resourceName)!;
        using var stream = new StreamReader(resourceStream);
        var text = stream.ReadToEnd();
        var i = 0;
        using var sr1 = new StringReader(text);
        while (sr1.ReadLine() is not null)
        {
            i++;
        }

        var words = new string[i];
        i = 0;
        using var sr2 = new StringReader(text);
        while (sr2.ReadLine() is string line2)
        {
            words[i++] = line2;
        }

        return words;
    }

    private static bool TryGetKey<TKey>(
        Random random, Func<Random, TKey> keyGenerator, Func<TKey, bool> predicate, [MaybeNullWhen(false)] out TKey key)
        where TKey : notnull
    {
        try
        {
            key = Try(random, keyGenerator, predicate);
            return true;
        }
        catch (MaxAttemptsExceededException)
        {
            key = default;
            return false;
        }
    }

    private static bool TryGetValue<TValue>(
        Random random,
        Func<Random, TValue> valueGenerator,
        Func<TValue, bool> predicate,
        [MaybeNullWhen(false)] out TValue value)
    {
        try
        {
            value = Try(random, valueGenerator, predicate);
            return true;
        }
        catch (MaxAttemptsExceededException)
        {
            value = default;
            return false;
        }
    }

    private static string Hex(ReadOnlySpan<byte> bytes)
    {
#if NETSTANDARD2_1_OR_GREATER
        char[] chars = new char[bytes.Length * 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            chars[i * 2] = _hexCharacters[bytes[i] >> 4];
            chars[(i * 2) + 1] = _hexCharacters[bytes[i] & 0xf];
        }

        return new string(chars);
#else
        var length = bytes.Length * 2;
        var chars = ArrayPool<char>.Shared.Rent(length);
        for (int i = 0; i < bytes.Length; i++)
        {
            chars[i * 2] = _hexCharacters[bytes[i] >> 4];
            chars[(i * 2) + 1] = _hexCharacters[bytes[i] & 0xf];
        }

        var result = new string(chars, 0, length);
        ArrayPool<char>.Shared.Return(chars);
        return result;
#endif
    }

    /// <summary>
    /// The exception thrown when the maximum number of attempts to find a value matching the predicate is exceeded.
    /// </summary>
    public sealed class MaxAttemptsExceededException(int maxAttempts)
        : InvalidOperationException($"No value was found that matches the condition after {maxAttempts} attempts.")
    {
    }
}
