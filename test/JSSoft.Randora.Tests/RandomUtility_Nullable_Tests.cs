// <copyright file="RandomUtility_Nullable_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora.Tests;

public class RandomUtility_Nullable_Tests
{
    private static Random NewSeeded(int seed = 4242) => new(seed);

    // Scalars --------------------------------------------------------------

    [Fact]
    public void NullableSByte_Basic()
    {
        var v = R.NullableSByte();
        if (v is not null)
        {
            Assert.InRange(v.Value, sbyte.MinValue, sbyte.MaxValue);
        }
    }

    [Fact]
    public void NullableByte_Basic()
    {
        var v = R.NullableByte();
        if (v is not null)
        {
            Assert.InRange(v.Value, byte.MinValue, byte.MaxValue);
        }
    }

    [Fact]
    public void NullableInt16_Basic()
    {
        var v = R.NullableInt16();
        if (v is not null)
        {
            Assert.InRange(v.Value, short.MinValue, short.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt16_Basic()
    {
        var v = R.NullableUInt16();
        if (v is not null)
        {
            Assert.InRange(v.Value, ushort.MinValue, ushort.MaxValue);
        }
    }

    [Fact]
    public void NullableInt32_Basic()
    {
        var v = R.NullableInt32();
        if (v is not null)
        {
            Assert.InRange(v.Value, int.MinValue, int.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt32_Basic()
    {
        var v = R.NullableUInt32();
        if (v is not null)
        {
            Assert.InRange(v.Value, uint.MinValue, uint.MaxValue);
        }
    }

    [Fact]
    public void NullableInt64_Basic()
    {
        var v = R.NullableInt64();
        if (v is not null)
        {
            Assert.InRange(v.Value, long.MinValue, long.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt64_Basic()
    {
        var v = R.NullableUInt64();
        if (v is not null)
        {
            Assert.InRange(v.Value, ulong.MinValue, ulong.MaxValue);
        }
    }

    [Fact]
    public void NullableSingle_Basic()
    {
        var v = R.NullableSingle();
        if (v is not null)
        {
            Assert.False(float.IsNaN(v.Value));
        }
    }

    [Fact]
    public void NullableDouble_Basic()
    {
        var v = R.NullableDouble();
        if (v is not null)
        {
            Assert.False(double.IsNaN(v.Value));
        }
    }

    [Fact]
    public void NullableDecimal_Basic()
    {
        var v = R.NullableDecimal();
        if (v is not null)
        {
            Assert.IsType<decimal>(v.Value);
        }
    }

    [Fact]
    public void NullableBigInteger_Basic()
    {
        var v = R.NullableBigInteger();
        if (v is not null)
        {
            var min = -(BigInteger.One << 127);
            var max = (BigInteger.One << 127) - BigInteger.One;
            Assert.True(v.Value >= min && v.Value <= max);
        }
    }

    [Fact]
    public void NullableString_Basic()
    {
        var v = R.NullableString();
        if (v is not null)
        {
            Assert.IsType<string>(v);
        }
    }

    [Fact]
    public void NullableChar_Basic()
    {
        var v = R.NullableChar();
        if (v is not null)
        {
            Assert.InRange(v.Value, char.MinValue, char.MaxValue);
        }
    }

    [Fact]
    public void NullableDateTimeOffset_Basic()
    {
        var v = R.NullableDateTimeOffset();
        if (v is not null)
        {
            Assert.IsType<DateTimeOffset>(v.Value);
        }
    }

    [Fact]
    public void NullableTimeSpan_Basic()
    {
        var v = R.NullableTimeSpan();
        if (v is not null)
        {
            Assert.IsType<TimeSpan>(v.Value);
        }
    }

    [Fact]
    public void NullableBoolean_Basic()
    {
        var v = R.NullableBoolean();
        if (v is not null)
        {
            Assert.IsType<bool>(v.Value);
        }
    }

    // Collections ----------------------------------------------------------

    [Fact]
    public void NullableArray_Int_Basic()
    {
        var v = R.NullableArray(R.Int32);
        if (v is not null)
        {
            Assert.IsType<int[]>(v);
        }
    }

    [Fact]
    public void NullableList_Int_Basic()
    {
        // no length
        var v1 = R.NullableList(R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<List<int>>(v1);
        }

        // with length
        const int length = 5;
        var v2 = R.NullableList(R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Count);
        }
    }

    [Fact]
    public void NullableHashSet_Int_Basic()
    {
        // no length
        var v1 = R.NullableHashSet(R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<HashSet<int>>(v1);
        }

        // with length
        const int length = 7;
        var v2 = R.NullableHashSet(R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableDictionary_IntInt_Basic()
    {
        // no length
        var d1 = R.NullableDictionary(R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.Equal(d1.Keys.Distinct().Count(), d1.Count);
        }

        // with length
        const int length = 6;
        var d2 = R.NullableDictionary(R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
        }
    }

    // Immutable collections ------------------------------------------------

    [Fact]
    public void NullableImmutableArray_Int_Basic()
    {
        // no length
        var v1 = R.NullableImmutableArray(R.Int32);
        if (v1 is not null)
        {
            Assert.True(v1.Value.Length >= 0);
        }

        // with length
        const int length = 4;
        var v2 = R.NullableImmutableArray(R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Value.Length);
        }
    }

    [Fact]
    public void NullableImmutableList_Int_Basic()
    {
        var v1 = R.NullableImmutableList(R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<ImmutableList<int>>(v1);
        }

        const int length = 5;
        var v2 = R.NullableImmutableList(R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Count);
        }
    }

    [Fact]
    public void NullableImmutableHashSet_Int_Basic()
    {
        var v1 = R.NullableImmutableHashSet(R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<ImmutableHashSet<int>>(v1);
        }

        const int length = 8;
        var v2 = R.NullableImmutableHashSet(R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableImmutableSortedSet_Int_Basic()
    {
        var v1 = R.NullableImmutableSortedSet(R.Int32);
        if (v1 is not null)
        {
            Assert.True(IsNonDecreasing(v1));
        }

        const int length = 9;
        var v2 = R.NullableImmutableSortedSet(R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
            Assert.True(IsNonDecreasing(v2));
        }
    }

    [Fact]
    public void NullableImmutableDictionary_IntInt_Basic()
    {
        var d1 = R.NullableImmutableDictionary(R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.Equal(d1.Keys.Distinct().Count(), d1.Count);
        }

        const int length = 5;
        var d2 = R.NullableImmutableDictionary(R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableImmutableSortedDictionary_IntInt_Basic()
    {
        var d1 = R.NullableImmutableSortedDictionary(R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.True(IsNonDecreasing(d1.Keys));
        }

        const int length = 6;
        var d2 = R.NullableImmutableSortedDictionary(R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
            Assert.True(IsNonDecreasing(d2.Keys));
        }
    }

    // Tuples ---------------------------------------------------------------

    [Fact]
    public void NullableTuple_Ints_Basic()
    {
        // 2 .. 7
        var t2 = R.NullableTuple(R.Int32, R.Int32);
        if (t2 is not null)
        {
            Assert.IsType<int>(t2.Item1);
            Assert.IsType<int>(t2.Item2);
        }

        var t3 = R.NullableTuple(R.Int32, R.Int32, R.Int32);
        if (t3 is not null)
        {
            Assert.IsType<int>(t3.Item1);
            Assert.IsType<int>(t3.Item2);
            Assert.IsType<int>(t3.Item3);
        }

        var t4 = R.NullableTuple(R.Int32, R.Int32, R.Int32, R.Int32);
        if (t4 is not null)
        {
            Assert.Equal(4, new object[] { t4.Item1, t4.Item2, t4.Item3, t4.Item4 }.Count(x => x is int));
        }

        var t5 = R.NullableTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t5 is not null)
        {
            Assert.Equal(5, new object[] { t5.Item1, t5.Item2, t5.Item3, t5.Item4, t5.Item5 }.Count(x => x is int));
        }

        var t6 = R.NullableTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t6 is not null)
        {
            Assert.Equal(6, new object[] { t6.Item1, t6.Item2, t6.Item3, t6.Item4, t6.Item5, t6.Item6 }.Count(x => x is int));
        }

        var t7 = R.NullableTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t7 is not null)
        {
            Assert.Equal(7, new object[] { t7.Item1, t7.Item2, t7.Item3, t7.Item4, t7.Item5, t7.Item6, t7.Item7 }.Count(x => x is int));
        }

        // 8th with TRest (must be Tuple<...>)
        var t8 = R.NullableTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, () => Tuple.Create(1, 2));
        if (t8 is not null)
        {
            Assert.IsType<Tuple<int, int>>(t8.Rest);
            var rest = t8.Rest;
            Assert.IsType<int>(rest.Item1);
            Assert.IsType<int>(rest.Item2);
        }
    }

    [Fact]
    public void NullableValueTuple_Ints_Basic()
    {
        // 2 .. 7
        var t2 = R.NullableValueTuple(R.Int32, R.Int32);
        if (t2.HasValue)
        {
            Assert.IsType<int>(t2.Value.Item1);
            Assert.IsType<int>(t2.Value.Item2);
        }

        var t3 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32);
        if (t3.HasValue)
        {
            Assert.Equal(3, new object[] { t3.Value.Item1, t3.Value.Item2, t3.Value.Item3 }.Count(x => x is int));
        }

        var t4 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32, R.Int32);
        if (t4.HasValue)
        {
            Assert.Equal(4, new object[] { t4.Value.Item1, t4.Value.Item2, t4.Value.Item3, t4.Value.Item4 }.Count(x => x is int));
        }

        var t5 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t5.HasValue)
        {
            Assert.Equal(5, new object[] { t5.Value.Item1, t5.Value.Item2, t5.Value.Item3, t5.Value.Item4, t5.Value.Item5 }.Count(x => x is int));
        }

        var t6 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t6.HasValue)
        {
            Assert.Equal(6, new object[] { t6.Value.Item1, t6.Value.Item2, t6.Value.Item3, t6.Value.Item4, t6.Value.Item5, t6.Value.Item6 }.Count(x => x is int));
        }

        var t7 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t7.HasValue)
        {
            Assert.Equal(7, new object[] { t7.Value.Item1, t7.Value.Item2, t7.Value.Item3, t7.Value.Item4, t7.Value.Item5, t7.Value.Item6, t7.Value.Item7 }.Count(x => x is int));
        }

        // 8th with TRest (struct)
        var t8 = R.NullableValueTuple(R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, () => DateTime.UnixEpoch);
        if (t8.HasValue)
        {
            Assert.IsType<ValueTuple<DateTime>>(t8.Value.Rest);
            Assert.IsType<DateTime>(t8.Value.Rest.Item1);
        }
    }

    // Helpers --------------------------------------------------------------

    private static bool IsNonDecreasing<T>(IEnumerable<T> items)
        where T : IComparable<T>
    {
        using var e = items.GetEnumerator();
        if (!e.MoveNext())
        {
            return true;
        }

        var prev = e.Current;
        while (e.MoveNext())
        {
            if (prev.CompareTo(e.Current) > 0)
            {
                return false;
            }

            prev = e.Current;
        }

        return true;
    }

    // =====================================================================
    // With Random overloads
    // =====================================================================

    // Scalars with Random --------------------------------------------------

    [Fact]
    public void NullableSByte_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableSByte(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, sbyte.MinValue, sbyte.MaxValue);
        }
    }

    [Fact]
    public void NullableByte_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableByte(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, byte.MinValue, byte.MaxValue);
        }
    }

    [Fact]
    public void NullableInt16_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableInt16(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, short.MinValue, short.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt16_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableUInt16(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, ushort.MinValue, ushort.MaxValue);
        }
    }

    [Fact]
    public void NullableInt32_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableInt32(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, int.MinValue, int.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt32_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableUInt32(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, uint.MinValue, uint.MaxValue);
        }
    }

    [Fact]
    public void NullableInt64_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableInt64(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, long.MinValue, long.MaxValue);
        }
    }

    [Fact]
    public void NullableUInt64_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableUInt64(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, ulong.MinValue, ulong.MaxValue);
        }
    }

    [Fact]
    public void NullableSingle_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableSingle(r);
        if (v is not null)
        {
            Assert.False(float.IsNaN(v.Value));
        }
    }

    [Fact]
    public void NullableDouble_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableDouble(r);
        if (v is not null)
        {
            Assert.False(double.IsNaN(v.Value));
        }
    }

    [Fact]
    public void NullableDecimal_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableDecimal(r);
        if (v is not null)
        {
            Assert.IsType<decimal>(v.Value);
        }
    }

    [Fact]
    public void NullableBigInteger_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableBigInteger(r);
        if (v is not null)
        {
            var min = -(BigInteger.One << 127);
            var max = (BigInteger.One << 127) - BigInteger.One;
            Assert.True(v.Value >= min && v.Value <= max);
        }
    }

    [Fact]
    public void NullableString_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableString(r);
        if (v is not null)
        {
            Assert.IsType<string>(v);
        }
    }

    [Fact]
    public void NullableChar_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableChar(r);
        if (v is not null)
        {
            Assert.InRange(v.Value, char.MinValue, char.MaxValue);
        }
    }

    [Fact]
    public void NullableDateTimeOffset_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableDateTimeOffset(r);
        if (v is not null)
        {
            Assert.IsType<DateTimeOffset>(v.Value);
        }
    }

    [Fact]
    public void NullableTimeSpan_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableTimeSpan(r);
        if (v is not null)
        {
            Assert.IsType<TimeSpan>(v.Value);
        }
    }

    [Fact]
    public void NullableBoolean_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableBoolean(r);
        if (v is not null)
        {
            Assert.IsType<bool>(v.Value);
        }
    }

    // Collections with Random ---------------------------------------------

    [Fact]
    public void NullableArray_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v = R.NullableArray(r, R.Int32);
        if (v is not null)
        {
            Assert.IsType<int[]>(v);
        }
    }

    [Fact]
    public void NullableList_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableList(r, R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<List<int>>(v1);
        }

        const int length = 5;
        var v2 = R.NullableList(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Count);
        }
    }

    [Fact]
    public void NullableHashSet_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableHashSet(r, R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<HashSet<int>>(v1);
        }

        const int length = 7;
        var v2 = R.NullableHashSet(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableDictionary_IntInt_WithRandom_Basic()
    {
        var r = NewSeeded();
        var d1 = R.NullableDictionary(r, R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.Equal(d1.Keys.Distinct().Count(), d1.Count);
        }

        const int length = 6;
        var d2 = R.NullableDictionary(r, R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
        }
    }

    // Immutable with Random ------------------------------------------------

    [Fact]
    public void NullableImmutableArray_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableImmutableArray(r, R.Int32);
        if (v1 is not null)
        {
            Assert.True(v1.Value.Length >= 0);
        }

        const int length = 4;
        var v2 = R.NullableImmutableArray(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Value.Length);
        }
    }

    [Fact]
    public void NullableImmutableList_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableImmutableList(r, R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<List<int>>(v1);
        }

        const int length = 5;
        var v2 = R.NullableImmutableList(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.Equal(length, v2.Count);
        }
    }

    [Fact]
    public void NullableImmutableHashSet_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableImmutableHashSet(r, R.Int32);
        if (v1 is not null)
        {
            Assert.IsType<ImmutableHashSet<int>>(v1);
        }

        const int length = 8;
        var v2 = R.NullableImmutableHashSet(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableImmutableSortedSet_Int_WithRandom_Basic()
    {
        var r = NewSeeded();
        var v1 = R.NullableImmutableSortedSet(r, R.Int32);
        if (v1 is not null)
        {
            Assert.True(IsNonDecreasing(v1));
        }

        const int length = 9;
        var v2 = R.NullableImmutableSortedSet(r, R.Int32, length);
        if (v2 is not null)
        {
            Assert.InRange(v2.Count, 0, length);
            Assert.True(IsNonDecreasing(v2));
        }
    }

    [Fact]
    public void NullableImmutableDictionary_IntInt_WithRandom_Basic()
    {
        var r = NewSeeded();
        var d1 = R.NullableImmutableDictionary(r, R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.Equal(d1.Keys.Distinct().Count(), d1.Count);
        }

        const int length = 5;
        var d2 = R.NullableImmutableDictionary(r, R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
        }
    }

    [Fact]
    public void NullableImmutableSortedDictionary_IntInt_WithRandom_Basic()
    {
        var r = NewSeeded();
        var d1 = R.NullableImmutableSortedDictionary(r, R.Int32, R.Int32);
        if (d1 is not null)
        {
            Assert.True(IsNonDecreasing(d1.Keys));
        }

        const int length = 6;
        var d2 = R.NullableImmutableSortedDictionary(r, R.Int32, R.Int32, length);
        if (d2 is not null)
        {
            Assert.InRange(d2.Count, 0, length);
            Assert.True(IsNonDecreasing(d2.Keys));
        }
    }

    // Tuples with Random ---------------------------------------------------

    [Fact]
    public void NullableTuple_Ints_WithRandom_Basic()
    {
        var r = NewSeeded();

        var t2 = R.NullableTuple(r, R.Int32, R.Int32);
        if (t2 is not null)
        {
            Assert.IsType<int>(t2.Item1);
            Assert.IsType<int>(t2.Item2);
        }

        var t3 = R.NullableTuple(r, R.Int32, R.Int32, R.Int32);
        if (t3 is not null)
        {
            Assert.IsType<int>(t3.Item1);
            Assert.IsType<int>(t3.Item2);
            Assert.IsType<int>(t3.Item3);
        }

        var t4 = R.NullableTuple(r, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t4 is not null)
        {
            Assert.Equal(4, new object[] { t4.Item1, t4.Item2, t4.Item3, t4.Item4 }.Count(x => x is int));
        }

        var t5 = R.NullableTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t5 is not null)
        {
            Assert.Equal(5, new object[] { t5.Item1, t5.Item2, t5.Item3, t5.Item4, t5.Item5 }.Count(x => x is int));
        }

        var t6 = R.NullableTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t6 is not null)
        {
            Assert.Equal(6, new object[] { t6.Item1, t6.Item2, t6.Item3, t6.Item4, t6.Item5, t6.Item6 }.Count(x => x is int));
        }

        var t7 = R.NullableTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t7 is not null)
        {
            Assert.Equal(7, new object[] { t7.Item1, t7.Item2, t7.Item3, t7.Item4, t7.Item5, t7.Item6, t7.Item7 }.Count(x => x is int));
        }

        var t8 = R.NullableTuple(
            r,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            rr => Tuple.Create(R.Int32(rr), R.Int32(rr)));
        if (t8 is not null)
        {
            Assert.IsType<Tuple<int, int>>(t8.Rest);
            var rest = t8.Rest;
            Assert.IsType<int>(rest.Item1);
            Assert.IsType<int>(rest.Item2);
        }
    }

    [Fact]
    public void NullableValueTuple_Ints_WithRandom_Basic()
    {
        var r = NewSeeded();

        var t2 = R.NullableValueTuple(r, R.Int32, R.Int32);
        if (t2.HasValue)
        {
            Assert.IsType<int>(t2.Value.Item1);
            Assert.IsType<int>(t2.Value.Item2);
        }

        var t3 = R.NullableValueTuple(r, R.Int32, R.Int32, R.Int32);
        if (t3.HasValue)
        {
            Assert.Equal(3, new object[] { t3.Value.Item1, t3.Value.Item2, t3.Value.Item3 }.Count(x => x is int));
        }

        var t4 = R.NullableValueTuple(r, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t4.HasValue)
        {
            Assert.Equal(4, new object[] { t4.Value.Item1, t4.Value.Item2, t4.Value.Item3, t4.Value.Item4 }.Count(x => x is int));
        }

        var t5 = R.NullableValueTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t5.HasValue)
        {
            Assert.Equal(5, new object[] { t5.Value.Item1, t5.Value.Item2, t5.Value.Item3, t5.Value.Item4, t5.Value.Item5 }.Count(x => x is int));
        }

        var t6 = R.NullableValueTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t6.HasValue)
        {
            Assert.Equal(6, new object[] { t6.Value.Item1, t6.Value.Item2, t6.Value.Item3, t6.Value.Item4, t6.Value.Item5, t6.Value.Item6 }.Count(x => x is int));
        }

        var t7 = R.NullableValueTuple(r, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32, R.Int32);
        if (t7.HasValue)
        {
            Assert.Equal(7, new object[] { t7.Value.Item1, t7.Value.Item2, t7.Value.Item3, t7.Value.Item4, t7.Value.Item5, t7.Value.Item6, t7.Value.Item7 }.Count(x => x is int));
        }

        var t8 = R.NullableValueTuple(
            r,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            R.Int32,
            rr => DateTime.UnixEpoch.AddSeconds(R.Int32(rr, 0, 1000)));
        if (t8.HasValue)
        {
            Assert.IsType<ValueTuple<DateTime>>(t8.Value.Rest);
            Assert.IsType<DateTime>(t8.Value.Rest.Item1);
        }
    }

    // Generic helpers ----------------------------------------------------

    [Fact]
    public void Nullable_Int_WithRandom_ShouldContainNullAndValue()
    {
        var r = NewSeeded();
        const int iterations = 128; // 66% 값 생성 확률을 고려한 충분한 반복
        var results = new List<int?>(capacity: iterations);

        for (int i = 0; i < iterations; i++)
        {
            results.Add(R.Nullable(r, R.Int32));
        }

        Assert.Contains(results, v => v.HasValue);
        Assert.Contains(results, v => v is null);
    }

    [Fact]
    public void NullableObject_String_WithRandom_ShouldContainNullAndValue()
    {
        var r = NewSeeded();
        const int iterations = 128;
        var results = new List<string?>(capacity: iterations);

        for (int i = 0; i < iterations; i++)
        {
            results.Add(R.NullableObject(r, R.String));
        }

        Assert.Contains(results, v => v is not null);
        Assert.Contains(results, v => v is null);
    }
}
