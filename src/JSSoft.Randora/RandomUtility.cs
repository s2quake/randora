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

public static partial class RandomUtility
{
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

    public static sbyte SByte() => SByte(_shared);

    public static sbyte SByte(Random random)
    {
        var bytes = new byte[1];
        random.NextBytes(bytes);
        return (sbyte)bytes[0];
    }

    public static byte Byte() => Byte(_shared);

    public static byte Byte(Random random)
    {
        var bytes = new byte[1];
        random.NextBytes(bytes);
        return bytes[0];
    }

    public static byte[] Bytes() => Bytes(_shared);

    public static byte[] Bytes(int length) => Bytes(_shared, length);

    public static byte[] Bytes(Random random) => Bytes(random, Length(random));

    public static byte[] Bytes(Random random, int length)
    {
        var bytes = new byte[length];
        random.NextBytes(bytes);
        return bytes;
    }

    public static short Int16() => Int16(_shared);

    public static short Int16(Random random)
    {
        var bytes = new byte[2];
        random.NextBytes(bytes);
        return BitConverter.ToInt16(bytes, 0);
    }

    public static ushort UInt16() => UInt16(_shared);

    public static ushort UInt16(Random random)
    {
        var bytes = new byte[2];
        random.NextBytes(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }

    public static int Int32() => Int32(_shared);

    public static int Int32(int minValue, int maxValue) => _shared.Next(minValue, maxValue);

    public static int Int32(Random random) => Int32(random, int.MinValue, int.MaxValue);

    public static int Int32(Random random, int minValue, int maxValue) => random.Next(minValue, maxValue);

    public static uint UInt32() => UInt32(_shared);

    public static uint UInt32(Random random)
    {
        var bytes = new byte[4];
        random.NextBytes(bytes);
        return BitConverter.ToUInt32(bytes, 0);
    }

    public static long Int64() => Int64(_shared);

    public static long Int64(long minValue, long maxValue) => _shared.NextInt64(minValue, maxValue);

    public static long Int64(Random random) => Int64(random, long.MinValue, long.MaxValue);

    public static long Int64(Random random, long minValue, long maxValue) => random.NextInt64(minValue, maxValue);

    public static ulong UInt64() => UInt64(_shared);

    public static ulong UInt64(Random random)
    {
        var bytes = new byte[8];
        random.NextBytes(bytes);
        return BitConverter.ToUInt64(bytes, 0);
    }

    public static float Single() => Single(_shared);

    public static float Single(Random random)
    {
#if NET6_0_OR_GREATER
        return random.NextSingle();
#else
        return (float)random.NextDouble() * random.Next();
#endif
    }

    public static double Double() => Double(_shared);

    public static double Double(Random random) => random.NextDouble();

    public static decimal Decimal() => Decimal(_shared);

    public static decimal Decimal(Random random) => (decimal)random.NextDouble();

    public static BigInteger BigInteger() => BigInteger(_shared);

    public static BigInteger BigInteger(Random random)
    {
        var length = Length(random, 1, 17);
        var bytes = Array(random, Byte, length);
        return new BigInteger(bytes);
    }

    public static int Positive() => Positive(_shared);

    public static int Positive(Random random) => Int32(random, 0, int.MaxValue) + 1;

    public static int Negative() => Negative(_shared);

    public static int Negative(Random random) => Int32(random, int.MinValue, 0);

    public static int NonPositive() => NonPositive(_shared);

    public static int NonPositive(Random random) => Int32(random, int.MinValue, 1);

    public static int NonNegative() => NonNegative(_shared);

    public static int NonNegative(Random random) => Int32(random, -1, int.MaxValue) + 1;

    public static long PositiveInt64() => PositiveInt64(_shared);

    public static long PositiveInt64(Random random) => Int64(random, 0, long.MaxValue) + 1;

    public static long NegativeInt64() => NegativeInt64(_shared);

    public static long NegativeInt64(Random random) => Int64(random, long.MinValue, 0);

    public static long NonPositiveInt64() => NonPositiveInt64(_shared);

    public static long NonPositiveInt64(Random random) => Int64(random, long.MinValue, 1);

    public static long NonNegativeInt64() => NonNegativeInt64(_shared);

    public static long NonNegativeInt64(Random random) => Int64(random, -1, long.MaxValue) + 1;

    public static BigInteger PositiveBigInteger() => PositiveBigInteger(_shared);

    public static BigInteger PositiveBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign > 0 ? v : -v;
    }

    public static BigInteger NegativeBigInteger() => NegativeBigInteger(_shared);

    public static BigInteger NegativeBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign < 0 ? v : -v;
    }

    public static BigInteger NonPositiveBigInteger() => NonPositiveBigInteger(_shared);

    public static BigInteger NonPositiveBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign <= 0 ? v : -v;
    }

    public static BigInteger NonNegativeBigInteger() => NonNegativeBigInteger(_shared);

    public static BigInteger NonNegativeBigInteger(Random random)
    {
        var v = BigInteger(random);
        return v.Sign >= 0 ? v : -v;
    }

    public static string Word() => Word(_shared);

    public static string Word(Random random) => Words[Int32(random, 0, Words.Length)];

    public static string Hex() => Hex(_shared);

    public static string Hex(int length) => Hex(_shared, length);

    public static string Hex(Random random) => Hex(random, Length(random));

    public static string Hex(Random random, int length) => Hex(Bytes(random, length));

    public static char Char() => Char(_shared);

    public static char Char(Random random) => (char)UInt16(random);

    public static DateTimeOffset DateTimeOffset() => DateTimeOffset(_shared);

    public static DateTimeOffset DateTimeOffset(Random random)
    {
        var minValue = DateTime.UnixEpoch.Ticks;
        var maxValue = new DateTime(2050, 12, 31, 0, 0, 0, DateTimeKind.Utc).Ticks;
        var value = random.NextInt64(minValue, maxValue) / 10000000L * 10000000L;
        return new DateTimeOffset(value, System.TimeSpan.Zero);
    }

    public static TimeSpan TimeSpan() => TimeSpan(_shared);

    public static TimeSpan TimeSpan(Random random) => new(random.NextInt64(new TimeSpan(365, 0, 0, 0).Ticks));

    public static TimeSpan TimeSpan(int minMilliseconds, int maxMilliseconds)
        => TimeSpan(_shared, minMilliseconds, maxMilliseconds);

    public static TimeSpan TimeSpan(Random random, int minMilliseconds, int maxMilliseconds)
    {
        var milliseconds = random.Next(minMilliseconds, maxMilliseconds);
        return System.TimeSpan.FromMilliseconds(milliseconds);
    }

    public static Guid Guid() => Guid(_shared);

    public static Guid Guid(Random random) => new(Array(random, Byte, 16));

    public static int Length() => Length(_shared);

    public static int Length(int maxLength) => Length(1, maxLength);

    public static int Length(int minLength, int maxLength) => Length(_shared, minLength, maxLength);

    public static int Length(Random random) => Length(random, 1, 10);

    public static int Length(Random random, int maxLength) => Length(random, 1, maxLength);

    public static int Length(Random random, int minLength, int maxLength) => random.Next(minLength, maxLength);

    public static bool Boolean() => Boolean(_shared);

    public static bool Boolean(Random random) => Int32(random, 0, 2) is 0;

    public static T Enum<T>()
        where T : Enum
        => Enum<T>(_shared);

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

    public static string String() => String(_shared);

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

    public static T[] Array<T>(Func<T> generator) => Array(generator, Length());

    public static T[] Array<T>(Func<T> generator, int length) => Array(_shared, _ => generator(), length);

    public static T[] Array<T>(Random random, Func<Random, T> generator) => Array(random, generator, Length(random));

    public static T[] Array<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return items;
    }

    public static List<T> List<T>(Func<T> generator) => List(generator, Length());

    public static List<T> List<T>(Func<T> generator, int length)
        => List(_shared, _ => generator(), length);

    public static List<T> List<T>(Random random, Func<Random, T> generator)
        => List(random, generator, Length(random));

    public static List<T> List<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return [.. items];
    }

    public static HashSet<TValue> HashSet<TValue>(Func<TValue> generator) => HashSet(generator, Length());

    public static HashSet<TValue> HashSet<TValue>(Func<TValue> generator, int length)
        => HashSet(_shared, _ => generator(), length);

    public static HashSet<TValue> HashSet<TValue>(Random random, Func<Random, TValue> generator)
        => HashSet(random, generator, Length(random));

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

    public static SortedSet<TValue> SortedSet<TValue>(Func<TValue> generator) => SortedSet(generator, Length());

    public static SortedSet<TValue> SortedSet<TValue>(Func<TValue> generator, int length)
        => SortedSet(_shared, _ => generator(), length);

    public static SortedSet<TValue> SortedSet<TValue>(Random random, Func<Random, TValue> generator)
        => SortedSet(random, generator, Length(random));

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

    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => Dictionary(keyGenerator, valueGenerator, Length());

    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => Dictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => Dictionary(random, keyGenerator, valueGenerator, Length(random));

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

    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => SortedDictionary(keyGenerator, valueGenerator, Length());

    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => SortedDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    public static SortedDictionary<TKey, TValue> SortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => SortedDictionary(random, keyGenerator, valueGenerator, Length(random));

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

    public static ImmutableArray<T> ImmutableArray<T>(Func<T> generator)
        => ImmutableArray(generator, Length());

    public static ImmutableArray<T> ImmutableArray<T>(Func<T> generator, int length)
        => ImmutableArray(_shared, _ => generator(), length);

    public static ImmutableArray<T> ImmutableArray<T>(Random random, Func<Random, T> generator)
        => ImmutableArray(random, generator, Length(random));

    public static ImmutableArray<T> ImmutableArray<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return System.Collections.Immutable.ImmutableArray.Create(items);
    }

    public static ImmutableList<T> ImmutableList<T>(Func<T> generator)
        => ImmutableList(generator, Length());

    public static ImmutableList<T> ImmutableList<T>(Func<T> generator, int length)
        => ImmutableList(_shared, _ => generator(), length);

    public static ImmutableList<T> ImmutableList<T>(Random random, Func<Random, T> generator)
        => ImmutableList(random, generator, Length(random));

    public static ImmutableList<T> ImmutableList<T>(Random random, Func<Random, T> generator, int length)
    {
        var items = new T[length];
        for (var i = 0; i < length; i++)
        {
            items[i] = generator(random);
        }

        return System.Collections.Immutable.ImmutableList.Create(items);
    }

    public static ImmutableHashSet<T> ImmutableHashSet<T>(Func<T> generator)
        => ImmutableHashSet(generator, Length());

    public static ImmutableHashSet<T> ImmutableHashSet<T>(Func<T> generator, int length)
        => ImmutableHashSet(_shared, _ => generator(), length);

    public static ImmutableHashSet<T> ImmutableHashSet<T>(Random random, Func<Random, T> generator)
        => ImmutableHashSet(random, generator, Length(random));

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

    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Func<T> generator)
        => ImmutableSortedSet(generator, Length());

    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Func<T> generator, int length)
        => ImmutableSortedSet(_shared, _ => generator(), length);

    public static ImmutableSortedSet<T> ImmutableSortedSet<T>(Random random, Func<Random, T> generator)
        => ImmutableSortedSet(random, generator, Length(random));

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

    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => ImmutableDictionary(keyGenerator, valueGenerator, Length());

    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => ImmutableDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    public static ImmutableDictionary<TKey, TValue> ImmutableDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => ImmutableDictionary(random, keyGenerator, valueGenerator, Length(random));

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

    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator)
        where TKey : notnull
        => ImmutableSortedDictionary(keyGenerator, valueGenerator, Length());

    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Func<TKey> keyGenerator, Func<TValue> valueGenerator, int length)
        where TKey : notnull
        => ImmutableSortedDictionary(_shared, _ => keyGenerator(), _ => valueGenerator(), length);

    public static ImmutableSortedDictionary<TKey, TValue> ImmutableSortedDictionary<TKey, TValue>(
        Random random, Func<Random, TKey> keyGenerator, Func<Random, TValue> valueGenerator)
        where TKey : notnull
        => ImmutableSortedDictionary(random, keyGenerator, valueGenerator, Length(random));

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

    public static T? RandomOrDefault<T>(this IEnumerable<T> enumerable)
        => RandomOrDefault(enumerable, _shared);

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

    public static T Random<T>(this IEnumerable<T> enumerable)
        => Random(enumerable, _shared);

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

    public static T Try<T>(Func<T> generator, Func<T, bool> predicate)
        => Try(_shared, _ => generator(), predicate);

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

    public static bool Chance(int probability) => Chance(_shared, probability);

    public static bool Chance(Random random, int probability)
    {
        if (probability < 0 || probability > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0 and 100.");
        }

        return random.Next(0, 100) < probability;
    }

    public static bool Chance(double probability) => Chance(_shared, probability);

    public static bool Chance(Random random, double probability)
    {
        if (probability < 0.0 || probability > 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(probability), "Probability must be between 0 and 1.");
        }

        return random.NextDouble() < probability;
    }

    public static IOrderedEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        => Shuffle(_shared, source);

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

    public sealed class MaxAttemptsExceededException(int maxAttempts)
        : InvalidOperationException($"No value was found that matches the condition after {maxAttempts} attempts.")
    {
    }
}
