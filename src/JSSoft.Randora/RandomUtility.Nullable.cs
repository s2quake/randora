// <copyright file="RandomUtility.Nullable.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora;

public static partial class RandomUtility
{
    /// <summary>
    /// Generates a random nullable sbyte value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static sbyte? NullableSByte() => Nullable(SByte);

    /// <summary>
    /// Generates a random nullable sbyte value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static sbyte? NullableSByte(Random random) => Nullable(random, SByte);

    /// <summary>
    /// Generates a random nullable byte value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static byte? NullableByte() => Nullable(Byte);

    /// <summary>
    /// Generates a random nullable byte value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static byte? NullableByte(Random random) => Nullable(random, Byte);

    /// <summary>
    /// Generates a random nullable 16-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static short? NullableInt16() => Nullable(Int16);

    /// <summary>
    /// Generates a random nullable 16-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static short? NullableInt16(Random random) => Nullable(random, Int16);

    /// <summary>
    /// Generates a random nullable unsigned 16-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static ushort? NullableUInt16() => Nullable(UInt16);

    /// <summary>
    /// Generates a random nullable unsigned 16-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static ushort? NullableUInt16(Random random) => Nullable(random, UInt16);

    /// <summary>
    /// Generates a random nullable 32-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static int? NullableInt32() => Nullable(Int32);

    /// <summary>
    /// Generates a random nullable 32-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static int? NullableInt32(Random random) => Nullable(random, Int32);

    /// <summary>
    /// Generates a random nullable unsigned 32-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static uint? NullableUInt32() => Nullable(UInt32);

    /// <summary>
    /// Generates a random nullable unsigned 32-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static uint? NullableUInt32(Random random) => Nullable(random, UInt32);

    /// <summary>
    /// Generates a random nullable 64-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static long? NullableInt64() => Nullable(Int64);

    /// <summary>
    /// Generates a random nullable 64-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static long? NullableInt64(Random random) => Nullable(random, Int64);

    /// <summary>
    /// Generates a random nullable unsigned 64-bit integer using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static ulong? NullableUInt64() => Nullable(UInt64);

    /// <summary>
    /// Generates a random nullable unsigned 64-bit integer using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static ulong? NullableUInt64(Random random) => Nullable(random, UInt64);

    /// <summary>
    /// Generates a random nullable single-precision floating-point value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static float? NullableSingle() => Nullable(Single);

    /// <summary>
    /// Generates a random nullable single-precision floating-point value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static float? NullableSingle(Random random) => Nullable(random, Single);

    /// <summary>
    /// Generates a random nullable double-precision floating-point value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static double? NullableDouble() => Nullable(Double);

    /// <summary>
    /// Generates a random nullable double-precision floating-point value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static double? NullableDouble(Random random) => Nullable(random, Double);

    /// <summary>
    /// Generates a random nullable decimal value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static decimal? NullableDecimal() => Nullable(Decimal);

    /// <summary>
    /// Generates a random nullable decimal value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static decimal? NullableDecimal(Random random) => Nullable(random, Decimal);

    /// <summary>
    /// Generates a random nullable BigInteger value using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static BigInteger? NullableBigInteger() => Nullable(BigInteger);

    /// <summary>
    /// Generates a random nullable BigInteger value using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static BigInteger? NullableBigInteger(Random random) => Nullable(random, BigInteger);

    /// <summary>
    /// Generates a random nullable string using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static string? NullableString() => NullableObject(String);

    /// <summary>
    /// Generates a random nullable string using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static string? NullableString(Random random) => NullableObject(random, String);

    /// <summary>
    /// Generates a random nullable character using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static char? NullableChar() => Nullable(Char);

    /// <summary>
    /// Generates a random nullable character using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static char? NullableChar(Random random) => Nullable(random, Char);

    /// <summary>
    /// Generates a random nullable DateTimeOffset using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static DateTimeOffset? NullableDateTimeOffset() => Nullable(DateTimeOffset);

    /// <summary>
    /// Generates a random nullable DateTimeOffset using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static DateTimeOffset? NullableDateTimeOffset(Random random) => Nullable(random, DateTimeOffset);

    /// <summary>
    /// Generates a random nullable TimeSpan using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static TimeSpan? NullableTimeSpan() => Nullable(TimeSpan);

    /// <summary>
    /// Generates a random nullable TimeSpan using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static TimeSpan? NullableTimeSpan(Random random) => Nullable(random, TimeSpan);

    /// <summary>
    /// Generates a random nullable boolean using the shared random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    public static bool? NullableBoolean() => Nullable(Boolean);

    /// <summary>
    /// Generates a random nullable boolean using the specified random source.
    /// Approximately 66% of calls return a non-null value; otherwise, null.
    /// </summary>
    /// <param name="random">The random source to use.</param>
    public static bool? NullableBoolean(Random random) => Nullable(random, Boolean);

    /// <summary>
    /// Generates a nullable array using the shared random source. Returns null or an array whose elements are produced by <paramref name="generator"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated array.</returns>
    public static T[]? NullableArray<T>(Func<T> generator) => NullableObject(() => Array(generator));

    /// <summary>
    /// Generates a nullable array using the specified random source. Returns null or an array whose elements are produced by <paramref name="generator"/> with <paramref name="random"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated array.</returns>
    public static T[]? NullableArray<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => Array(random, generator));

    /// <summary>
    /// Generates a nullable List using the shared random source. Returns null or a list whose elements are produced by <paramref name="generator"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated list.</returns>
    public static List<T>? NullableList<T>(Func<T> generator) => NullableObject(() => List(generator));

    /// <summary>
    /// Generates a nullable List using the shared random source with a fixed length. Returns null or a list of the specified <paramref name="length"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired list length.</param>
    /// <returns>Null or a generated list.</returns>
    public static List<T>? NullableList<T>(Func<T> generator, int length)
        => NullableObject(() => List(generator, length));

    /// <summary>
    /// Generates a nullable List using the specified random source. Returns null or a list whose elements are produced by <paramref name="generator"/> with <paramref name="random"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated list.</returns>
    public static List<T>? NullableList<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => List(random, generator));

    /// <summary>
    /// Generates a nullable List using the specified random source and fixed length. Returns null or a list of the specified <paramref name="length"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired list length.</param>
    /// <returns>Null or a generated list.</returns>
    public static List<T>? NullableList<T>(Random random, Func<Random, T> generator, int length)
        => NullableObject(random, random => List(random, generator, length));

    /// <summary>
    /// Generates a nullable HashSet using the shared random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated set.</returns>
    public static HashSet<T>? NullableHashSet<T>(Func<T> generator)
        => NullableObject(() => HashSet(generator));

    /// <summary>
    /// Generates a nullable HashSet using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated set.</returns>
    public static HashSet<T>? NullableHashSet<T>(Func<T> generator, int length)
        => NullableObject(() => HashSet(generator, length));

    /// <summary>
    /// Generates a nullable HashSet using the specified random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated set.</returns>
    public static HashSet<T>? NullableHashSet<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => HashSet(random, generator));

    /// <summary>
    /// Generates a nullable HashSet using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated set.</returns>
    public static HashSet<T>? NullableHashSet<T>(Random random, Func<Random, T> generator, int length)
        => NullableObject(random, random => HashSet(random, generator, length));

    /// <summary>
    /// Generates a nullable Dictionary using the shared random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <returns>Null or a generated dictionary.</returns>
    public static Dictionary<TKey, TValue>? NullableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(() => Dictionary(keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable Dictionary using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated dictionary.</returns>
    public static Dictionary<TKey, TValue>? NullableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(() => Dictionary(keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable Dictionary using the specified random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <returns>Null or a generated dictionary.</returns>
    public static Dictionary<TKey, TValue>? NullableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(random, random => Dictionary(random, keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable Dictionary using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated dictionary.</returns>
    public static Dictionary<TKey, TValue>? NullableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(random, random => Dictionary(random, keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable ImmutableArray using the shared random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated immutable array.</returns>
    public static ImmutableArray<T>? NullableImmutableArray<T>(Func<T> generator)
        => Nullable(() => ImmutableArray(generator));

    /// <summary>
    /// Generates a nullable ImmutableArray using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired item count.</param>
    /// <returns>Null or a generated immutable array.</returns>
    public static ImmutableArray<T>? NullableImmutableArray<T>(Func<T> generator, int length)
        => Nullable(() => ImmutableArray(generator, length));

    /// <summary>
    /// Generates a nullable ImmutableArray using the specified random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable array.</returns>
    public static ImmutableArray<T>? NullableImmutableArray<T>(Random random, Func<Random, T> generator)
        => Nullable(random, random => ImmutableArray(random, generator));

    /// <summary>
    /// Generates a nullable ImmutableArray using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired item count.</param>
    /// <returns>Null or a generated immutable array.</returns>
    public static ImmutableArray<T>? NullableImmutableArray<T>(Random random, Func<Random, T> generator, int length)
        => Nullable(random, random => ImmutableArray(random, generator, length));

    /// <summary>
    /// Generates a nullable ImmutableList using the shared random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated immutable list.</returns>
    public static ImmutableList<T>? NullableImmutableList<T>(Func<T> generator)
        => NullableObject(() => ImmutableList(generator));

    /// <summary>
    /// Generates a nullable ImmutableList using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired item count.</param>
    /// <returns>Null or a generated immutable list.</returns>
    public static ImmutableList<T>? NullableImmutableList<T>(Func<T> generator, int length)
        => NullableObject(() => ImmutableList(generator, length));

    /// <summary>
    /// Generates a nullable ImmutableList using the specified random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable list.</returns>
    public static ImmutableList<T>? NullableImmutableList<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => ImmutableList(random, generator));

    /// <summary>
    /// Generates a nullable ImmutableList using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired item count.</param>
    /// <returns>Null or a generated immutable list.</returns>
    public static ImmutableList<T>? NullableImmutableList<T>(Random random, Func<Random, T> generator, int length)
        => NullableObject(random, random => ImmutableList(random, generator, length));

    /// <summary>
    /// Generates a nullable ImmutableHashSet using the shared random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated immutable set.</returns>
    public static ImmutableHashSet<T>? NullableImmutableHashSet<T>(Func<T> generator)
        => NullableObject(() => ImmutableHashSet(generator));

    /// <summary>
    /// Generates a nullable ImmutableHashSet using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated immutable set.</returns>
    public static ImmutableHashSet<T>? NullableImmutableHashSet<T>(Func<T> generator, int length)
        => NullableObject(() => ImmutableHashSet(generator, length));

    /// <summary>
    /// Generates a nullable ImmutableHashSet using the specified random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable set.</returns>
    public static ImmutableHashSet<T>? NullableImmutableHashSet<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => ImmutableHashSet(random, generator));

    /// <summary>
    /// Generates a nullable ImmutableHashSet using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated immutable set.</returns>
    public static ImmutableHashSet<T>? NullableImmutableHashSet<T>(Random random, Func<Random, T> generator, int length)
        => NullableObject(random, random => ImmutableHashSet(random, generator, length));

    /// <summary>
    /// Generates a nullable ImmutableSortedSet using the shared random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <returns>Null or a generated immutable sorted set.</returns>
    public static ImmutableSortedSet<T>? NullableImmutableSortedSet<T>(Func<T> generator)
        => NullableObject(() => ImmutableSortedSet(generator));

    /// <summary>
    /// Generates a nullable ImmutableSortedSet using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="generator">The element generator.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated immutable sorted set.</returns>
    public static ImmutableSortedSet<T>? NullableImmutableSortedSet<T>(Func<T> generator, int length)
        => NullableObject(() => ImmutableSortedSet(generator, length));

    /// <summary>
    /// Generates a nullable ImmutableSortedSet using the specified random source.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable sorted set.</returns>
    public static ImmutableSortedSet<T>? NullableImmutableSortedSet<T>(Random random, Func<Random, T> generator)
        => NullableObject(random, random => ImmutableSortedSet(random, generator));

    /// <summary>
    /// Generates a nullable ImmutableSortedSet using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The element generator that accepts a random source.</param>
    /// <param name="length">The desired item count upper bound.</param>
    /// <returns>Null or a generated immutable sorted set.</returns>
    public static ImmutableSortedSet<T>? NullableImmutableSortedSet<T>(Random random, Func<Random, T> generator, int length)
        => NullableObject(random, random => ImmutableSortedSet(random, generator, length));

    /// <summary>
    /// Generates a nullable ImmutableDictionary using the shared random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <returns>Null or a generated immutable dictionary.</returns>
    public static ImmutableDictionary<TKey, TValue>? NullableImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(() => ImmutableDictionary(keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable ImmutableDictionary using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated immutable dictionary.</returns>
    public static ImmutableDictionary<TKey, TValue>? NullableImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(() => ImmutableDictionary(keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable ImmutableDictionary using the specified random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable dictionary.</returns>
    public static ImmutableDictionary<TKey, TValue>? NullableImmutableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(random, random => ImmutableDictionary(random, keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable ImmutableDictionary using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated immutable dictionary.</returns>
    public static ImmutableDictionary<TKey, TValue>? NullableImmutableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(random, random => ImmutableDictionary(random, keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable ImmutableSortedDictionary using the shared random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <returns>Null or a generated immutable sorted dictionary.</returns>
    public static ImmutableSortedDictionary<TKey, TValue>? NullableImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(() => ImmutableSortedDictionary(keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable ImmutableSortedDictionary using the shared random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="keyGenerator">The key generator.</param>
    /// <param name="valueGenerator">The value generator.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated immutable sorted dictionary.</returns>
    public static ImmutableSortedDictionary<TKey, TValue>? NullableImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(() => ImmutableSortedDictionary(keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable ImmutableSortedDictionary using the specified random source.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <returns>Null or a generated immutable sorted dictionary.</returns>
    public static ImmutableSortedDictionary<TKey, TValue>? NullableImmutableSortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => NullableObject(random, random => ImmutableSortedDictionary(random, keyGenerator, valueGenerator));

    /// <summary>
    /// Generates a nullable ImmutableSortedDictionary using the specified random source with a fixed length.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="keyGenerator">The key generator that accepts a random source.</param>
    /// <param name="valueGenerator">The value generator that accepts a random source.</param>
    /// <param name="length">The desired number of entries.</param>
    /// <returns>Null or a generated immutable sorted dictionary.</returns>
    public static ImmutableSortedDictionary<TKey, TValue>? NullableImmutableSortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator, int length)
        where TKey : notnull
        => NullableObject(random, random => ImmutableSortedDictionary(random, keyGenerator, valueGenerator, length));

    /// <summary>
    /// Generates a nullable Tuple of two elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2>? NullableTuple<T1, T2>(Func<T1> generator1, Func<T2> generator2)
        => NullableObject(() => Tuple(generator1, generator2));

    /// <summary>
    /// Generates a nullable Tuple of two elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2>? NullableTuple<T1, T2>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2)
        => NullableObject(random, random => Tuple(random, generator1, generator2));

    /// <summary>
    /// Generates a nullable Tuple of three elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3>? NullableTuple<T1, T2, T3>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3)
        => NullableObject(() => Tuple(generator1, generator2, generator3));

    /// <summary>
    /// Generates a nullable Tuple of three elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3>? NullableTuple<T1, T2, T3>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3)
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3));

    /// <summary>
    /// Generates a nullable Tuple of four elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4>? NullableTuple<T1, T2, T3, T4>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4)
        => NullableObject(() => Tuple(generator1, generator2, generator3, generator4));

    /// <summary>
    /// Generates a nullable Tuple of four elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4>? NullableTuple<T1, T2, T3, T4>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4)
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3, generator4));

    /// <summary>
    /// Generates a nullable Tuple of five elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5>? NullableTuple<T1, T2, T3, T4, T5>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5)
        => NullableObject(() => Tuple(generator1, generator2, generator3, generator4, generator5));

    /// <summary>
    /// Generates a nullable Tuple of five elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5>? NullableTuple<T1, T2, T3, T4, T5>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5)
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3, generator4, generator5));

    /// <summary>
    /// Generates a nullable Tuple of six elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6>? NullableTuple<T1, T2, T3, T4, T5, T6>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6)
        => NullableObject(() => Tuple(generator1, generator2, generator3, generator4, generator5, generator6));

    /// <summary>
    /// Generates a nullable Tuple of six elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6>? NullableTuple<T1, T2, T3, T4, T5, T6>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6)
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3, generator4, generator5, generator6));

    /// <summary>
    /// Generates a nullable Tuple of seven elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7>? NullableTuple<T1, T2, T3, T4, T5, T6, T7>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7)
        => NullableObject(() => Tuple(generator1, generator2, generator3, generator4, generator5, generator6, generator7));

    /// <summary>
    /// Generates a nullable Tuple of seven elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7>? NullableTuple<T1, T2, T3, T4, T5, T6, T7>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7)
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3, generator4, generator5, generator6, generator7));

    /// <summary>
    /// Generates a nullable Tuple of eight elements (the eighth is TRest) using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <typeparam name="TRest">The type of the eighth element (TRest).</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <param name="generator8">The eighth element generator.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>? NullableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7, Func<TRest> generator8)
        where TRest : notnull
        => NullableObject(() => Tuple(generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8));

    /// <summary>
    /// Generates a nullable Tuple of eight elements (the eighth is TRest) using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <typeparam name="TRest">The type of the eighth element (TRest).</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <param name="generator8">The eighth element generator that accepts a random source.</param>
    /// <returns>Null or a generated Tuple.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>? NullableTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7, Func<Random, TRest> generator8)
        where TRest : notnull
        => NullableObject(random, random => Tuple(random, generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8));

    /// <summary>
    /// Generates a nullable value tuple of two elements using element generators with the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2)? NullableValueTuple<T1, T2>(Func<T1> generator1, Func<T2> generator2)
        => Nullable(() => ValueTuple(generator1, generator2));

    /// <summary>
    /// Generates a nullable value tuple of two elements using element generators with the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2)? NullableValueTuple<T1, T2>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2)
        => Nullable(random, random => ValueTuple(random, generator1, generator2));

    /// <summary>
    /// Generates a nullable value tuple of three elements using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3)? NullableValueTuple<T1, T2, T3>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3)
        => Nullable(() => ValueTuple(generator1, generator2, generator3));

    /// <summary>
    /// Generates a nullable value tuple of three elements using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3)? NullableValueTuple<T1, T2, T3>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3)
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3));

    /// <summary>
    /// Generates a nullable value tuple of four elements using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4)? NullableValueTuple<T1, T2, T3, T4>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4)
        => Nullable(() => ValueTuple(generator1, generator2, generator3, generator4));

    /// <summary>
    /// Generates a nullable value tuple of four elements using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4)? NullableValueTuple<T1, T2, T3, T4>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4)
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3, generator4));

    /// <summary>
    /// Generates a nullable value tuple of five elements using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5)? NullableValueTuple<T1, T2, T3, T4, T5>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5)
        => Nullable(() => ValueTuple(generator1, generator2, generator3, generator4, generator5));

    /// <summary>
    /// Generates a nullable value tuple of five elements using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5)? NullableValueTuple<T1, T2, T3, T4, T5>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5)
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3, generator4, generator5));

    /// <summary>
    /// Generates a nullable value tuple of six elements using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6)? NullableValueTuple<T1, T2, T3, T4, T5, T6>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6)
        => Nullable(() => ValueTuple(generator1, generator2, generator3, generator4, generator5, generator6));

    /// <summary>
    /// Generates a nullable value tuple of six elements using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6)? NullableValueTuple<T1, T2, T3, T4, T5, T6>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6)
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3, generator4, generator5, generator6));

    /// <summary>
    /// Generates a nullable value tuple of seven elements using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7)? NullableValueTuple<T1, T2, T3, T4, T5, T6, T7>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7)
        => Nullable(() => ValueTuple(generator1, generator2, generator3, generator4, generator5, generator6, generator7));

    /// <summary>
    /// Generates a nullable value tuple of seven elements using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7)? NullableValueTuple<T1, T2, T3, T4, T5, T6, T7>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7)
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3, generator4, generator5, generator6, generator7));

    /// <summary>
    /// Generates a nullable value tuple of eight elements (the eighth is TRest) using the shared random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <typeparam name="TRest">The type of the eighth element (TRest).</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <param name="generator8">The eighth element generator.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7, TRest)? NullableValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7, Func<TRest> generator8)
        where TRest : struct
        => Nullable(() => ValueTuple(generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8));

    /// <summary>
    /// Generates a nullable value tuple of eight elements (the eighth is TRest) using the specified random source.
    /// </summary>
    /// <typeparam name="T1">The type of the first element.</typeparam>
    /// <typeparam name="T2">The type of the second element.</typeparam>
    /// <typeparam name="T3">The type of the third element.</typeparam>
    /// <typeparam name="T4">The type of the fourth element.</typeparam>
    /// <typeparam name="T5">The type of the fifth element.</typeparam>
    /// <typeparam name="T6">The type of the sixth element.</typeparam>
    /// <typeparam name="T7">The type of the seventh element.</typeparam>
    /// <typeparam name="TRest">The type of the eighth element (TRest).</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <param name="generator8">The eighth element generator that accepts a random source.</param>
    /// <returns>Null or a generated value tuple.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7, TRest)? NullableValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7, Func<Random, TRest> generator8)
        where TRest : struct
        => Nullable(random, random => ValueTuple(random, generator1, generator2, generator3, generator4, generator5, generator6, generator7, generator8));

    /// <summary>
    /// Returns a nullable value generated by <paramref name="generator"/> or null with approximately 34% probability.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="generator">The value generator.</param>
    /// <returns>A value or null.</returns>
    public static T? Nullable<T>(Func<T> generator)
        where T : struct
        => Chance(66) ? generator() : null;

    /// <summary>
    /// Returns a nullable value generated by <paramref name="generator"/> using <paramref name="random"/>, or null with approximately 34% probability.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The value generator that accepts a random source.</param>
    /// <returns>A value or null.</returns>
    public static T? Nullable<T>(Random random, Func<Random, T> generator)
        where T : struct
        => Chance(random, 66) ? generator(random) : null;

    /// <summary>
    /// Returns a nullable reference type generated by <paramref name="generator"/> or null (default) with approximately 34% probability.
    /// </summary>
    /// <typeparam name="T">The reference type.</typeparam>
    /// <param name="generator">The value generator.</param>
    /// <returns>A reference value or null.</returns>
    public static T? NullableObject<T>(Func<T> generator)
        where T : notnull
        => Chance(66) ? generator() : default;

    /// <summary>
    /// Returns a nullable reference type generated by <paramref name="generator"/> using <paramref name="random"/>, or null (default) with approximately 34% probability.
    /// </summary>
    /// <typeparam name="T">The reference type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator">The value generator that accepts a random source.</param>
    /// <returns>A reference value or null.</returns>
    public static T? NullableObject<T>(Random random, Func<Random, T> generator)
        where T : notnull
        => Chance(random, 66) ? generator(random) : default;
}
