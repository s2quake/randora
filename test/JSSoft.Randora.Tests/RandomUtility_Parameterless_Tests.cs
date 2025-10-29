// <copyright file="RandomUtility_Parameterless_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora.Tests;

public class RandomUtility_Parameterless_Tests
{
    // Basic numeric generators

    [Fact]
    public void SByte_Parameterless_WithinRange()
    {
        var v = R.SByte();
        Assert.InRange(v, sbyte.MinValue, sbyte.MaxValue);
    }

    [Fact]
    public void Byte_Parameterless_WithinRange()
    {
        var v = R.Byte();
        Assert.InRange(v, byte.MinValue, byte.MaxValue);
    }

    [Fact]
    public void Bytes_DefaultLength_And_Content()
    {
        var bytes = R.Bytes();
        Assert.NotNull(bytes);
        Assert.InRange(bytes.Length, 1, 9); // Length() default range [1,9]
    }

    [Fact]
    public void Bytes_WithLength_Matches_Length()
    {
        var bytes = R.Bytes(8);
        Assert.Equal(8, bytes.Length);
    }

    [Fact]
    public void Int16_WithinRange()
    {
        var v = R.Int16();
        Assert.InRange(v, short.MinValue, short.MaxValue);
    }

    [Fact]
    public void UInt16_WithinRange()
    {
        var v = R.UInt16();
        Assert.InRange(v, ushort.MinValue, ushort.MaxValue);
    }

    [Fact]
    public void Int32_WithinRange()
    {
        var v = R.Int32();

        // any int is valid; just ensure no exception
        Assert.InRange(v, int.MinValue, int.MaxValue);
    }

    [Fact]
    public void Int32_WithRange_RespectsBounds()
    {
        var v = R.Int32(-10, 10);
        Assert.InRange(v, -10, 9);
    }

    [Fact]
    public void UInt32_WithinRange()
    {
        var v = R.UInt32();
        Assert.InRange(v, uint.MinValue, uint.MaxValue);
    }

    [Fact]
    public void Int64_WithinRange()
    {
        var v = R.Int64();
        Assert.InRange(v, long.MinValue, long.MaxValue);
    }

    [Fact]
    public void Int64_WithRange_RespectsBounds()
    {
        var v = R.Int64(-1000L, 1000L);
        Assert.True(v >= -1000L && v < 1000L);
    }

    [Fact]
    public void UInt64_WithinRange()
    {
        var v = R.UInt64();
        Assert.InRange(v, ulong.MinValue, ulong.MaxValue);
    }

    [Fact]
    public void Single_WithinFiniteRange()
    {
        var v = R.Single();
        Assert.True(float.IsFinite(v));
    }

    [Fact]
    public void Double_WithinFiniteRange()
    {
        var v = R.Double();
        Assert.True(double.IsFinite(v));
    }

    [Fact]
    public void Decimal_Within01()
    {
        var v = R.Decimal();
        Assert.True(v >= 0m && v <= 1m);
    }

    [Fact]
    public void BigInteger_Basic()
    {
        // RandomUtility.BigInteger() builds from 1..16 bytes (two's complement, little-endian).
        // Therefore the overall possible range is [-2^127, 2^127 - 1].
        var min = -(BigInteger.One << 127);
        var max = (BigInteger.One << 127) - BigInteger.One;

        var v = R.BigInteger();
        Assert.True(v >= min && v <= max);
    }

    // Sign helpers

    [Fact]
    public void Positive_Is_Positive()
    {
        var v = R.Positive();
        Assert.True(v > 0);
    }

    [Fact]
    public void Negative_Is_Negative()
    {
        var v = R.Negative();
        Assert.True(v < 0);
    }

    [Fact]
    public void NonPositive_Is_NonPositive()
    {
        var v = R.NonPositive();
        Assert.True(v <= 0);
    }

    [Fact]
    public void NonNegative_Is_NonNegative()
    {
        var v = R.NonNegative();
        Assert.True(v >= 0);
    }

    [Fact]
    public void PositiveInt64_Is_Positive()
    {
        var v = R.PositiveInt64();
        Assert.True(v > 0);
    }

    [Fact]
    public void NegativeInt64_Is_Negative()
    {
        var v = R.NegativeInt64();
        Assert.True(v < 0);
    }

    [Fact]
    public void NonPositiveInt64_Is_NonPositive()
    {
        var v = R.NonPositiveInt64();
        Assert.True(v <= 0);
    }

    [Fact]
    public void NonNegativeInt64_Is_NonNegative()
    {
        var v = R.NonNegativeInt64();
        Assert.True(v >= 0);
    }

    [Fact]
    public void PositiveBigInteger_Is_Positive()
    {
        var v = R.PositiveBigInteger();
        Assert.True(v > 0);
    }

    [Fact]
    public void NegativeBigInteger_Is_Negative()
    {
        var v = R.NegativeBigInteger();
        Assert.True(v < 0);
    }

    [Fact]
    public void NonPositiveBigInteger_Is_NonPositive()
    {
        var v = R.NonPositiveBigInteger();
        Assert.True(v <= 0);
    }

    [Fact]
    public void NonNegativeBigInteger_Is_NonNegative()
    {
        var v = R.NonNegativeBigInteger();
        Assert.True(v >= 0);
    }

    // Text / hex / char

    [Fact]
    public void Word_NotEmpty()
    {
        var w = R.Word();
        Assert.False(string.IsNullOrWhiteSpace(w));
    }

    [Fact]
    public void Hex_DefaultLength_Format()
    {
        var h = R.Hex();
        Assert.Matches("^[0-9a-f]*$", h);
        Assert.True(h.Length % 2 == 0);
    }

    [Fact]
    public void Hex_WithLength_Format()
    {
        var h = R.Hex(8);
        Assert.Equal(16, h.Length);
        Assert.Matches("^[0-9a-f]+$", h);
    }

    [Fact]
    public void Char_AnyChar()
    {
        var c = R.Char();
        Assert.InRange((int)c, char.MinValue, char.MaxValue);
    }

    // Date / time / guid

    [Fact]
    public void DateTimeOffset_InExpectedRange()
    {
        var d = R.DateTimeOffset();
        Assert.True(d >= DateTimeOffset.UnixEpoch);
        Assert.True(d <= new DateTimeOffset(new DateTime(2050, 12, 31, 0, 0, 0, DateTimeKind.Utc)));
        Assert.Equal(0, d.Ticks % 10_000_000); // seconds precision
    }

    [Fact]
    public void TimeSpan_Basic()
    {
        var ts = R.TimeSpan();
        Assert.True(ts >= TimeSpan.Zero);
        Assert.True(ts < new TimeSpan(365, 0, 0, 0));
    }

    [Fact]
    public void TimeSpan_WithRange_Ms()
    {
        var ts = R.TimeSpan(10, 20);
        Assert.True(ts >= TimeSpan.FromMilliseconds(10));
        Assert.True(ts < TimeSpan.FromMilliseconds(20));
    }

    [Fact]
    public void Guid_Has16Bytes()
    {
        var g = R.Guid();
        Assert.Equal(16, g.ToByteArray().Length);
    }

    // Length helpers

    [Fact]
    public void Length_Default_Range()
    {
        var v = R.Length();
        Assert.InRange(v, 1, 9);
    }

    [Fact]
    public void Length_WithMax_Range()
    {
        var v = R.Length(7);
        Assert.InRange(v, 1, 6);
    }

    [Fact]
    public void Length_WithMinMax_Range()
    {
        var v = R.Length(3, 7);
        Assert.InRange(v, 3, 6);
    }

    // Boolean / enum / string

    [Fact]
    public void Boolean_ReturnsBool()
    {
        var b = R.Boolean();
        Assert.IsType<bool>(b);
    }

    [Fact]
    public void Enum_ReturnsValidValue()
    {
        var e = R.Enum<DateTimeKind>();
        Assert.Contains(e, Enum.GetValues<DateTimeKind>());
    }

    [Fact]
    public void Enum_WithFlagsEnum_Throws()
    {
        // AttributeTargets is a [Flags] enum in System namespace
        Assert.Throws<InvalidOperationException>(() => R.Enum<AttributeTargets>());
    }

    [Fact]
    public void String_ComposedOfWords()
    {
        var s = R.String();
        Assert.False(string.IsNullOrWhiteSpace(s));
        Assert.DoesNotContain("  ", s);
    }

    // Collections (parameterless Random overloads)

    [Fact]
    public void Array_Generator_DefaultLength()
    {
        var arr = R.Array(() => 1);
        Assert.InRange(arr.Length, 1, 9);
    }

    [Fact]
    public void Array_Generator_WithLength()
    {
        var arr = R.Array(() => 1, 5);
        Assert.Equal(5, arr.Length);
    }

    [Fact]
    public void List_Generator_DefaultLength()
    {
        var list = R.List(() => 1);
        Assert.InRange(list.Count, 1, 9);
    }

    [Fact]
    public void List_Generator_WithLength()
    {
        var list = R.List(() => 1, 6);
        Assert.Equal(6, list.Count);
    }

    [Fact]
    public void HashSet_Generator_DefaultLength()
    {
        var set = R.HashSet(R.Int32);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Fact]
    public void HashSet_Generator_WithLength()
    {
        var set = R.HashSet(R.Int32, 10);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Fact]
    public void SortedSet_Generator_DefaultLength()
    {
        var set = R.SortedSet(R.Int32);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Fact]
    public void SortedSet_Generator_WithLength()
    {
        var set = R.SortedSet(R.Int32, 7);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Fact]
    public void Dictionary_Generator_Default()
    {
        var dict = R.Dictionary(() => R.Int32(0, 10_000), R.String);
        Assert.Equal(dict.Keys.Count, dict.Keys.Distinct().Count());
    }

    [Fact]
    public void Dictionary_Generator_WithLength()
    {
        var dict = R.Dictionary(() => R.Int32(0, 10_000), R.String, 10);
        Assert.Equal(dict.Keys.Count, dict.Keys.Distinct().Count());
    }

    [Fact]
    public void SortedDictionary_Generator_Default()
    {
        var dict = R.SortedDictionary(() => R.Int32(0, 10_000), R.String);
        Assert.True(dict.Keys.SequenceEqual(dict.Keys.OrderBy(k => k)));
    }

    [Fact]
    public void SortedDictionary_Generator_WithLength()
    {
        var dict = R.SortedDictionary(() => R.Int32(0, 10_000), R.String, 10);
        Assert.True(dict.Keys.SequenceEqual(dict.Keys.OrderBy(k => k)));
    }

    [Fact]
    public void ImmutableArray_Generator_Default()
    {
        var arr = R.ImmutableArray(() => 1);
        Assert.InRange(arr.Length, 1, 9);
    }

    [Fact]
    public void ImmutableArray_Generator_WithLength()
    {
        var arr = R.ImmutableArray(() => 1, 4);
        Assert.Equal(4, arr.Length);
    }

    [Fact]
    public void ImmutableList_Generator_Default()
    {
        var list = R.ImmutableList(() => 1);
        Assert.InRange(list.Count, 1, 9);
    }

    [Fact]
    public void ImmutableList_Generator_WithLength()
    {
        var list = R.ImmutableList(() => 1, 3);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void ImmutableHashSet_Generator_Default()
    {
        var set = R.ImmutableHashSet(R.Int32);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Fact]
    public void ImmutableHashSet_Generator_WithLength()
    {
        var set = R.ImmutableHashSet(R.Int32, 10);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Fact]
    public void ImmutableSortedSet_Generator_Default()
    {
        var set = R.ImmutableSortedSet(R.Int32);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Fact]
    public void ImmutableSortedSet_Generator_WithLength()
    {
        var set = R.ImmutableSortedSet(R.Int32, 10);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Fact]
    public void ImmutableDictionary_Generator_Default()
    {
        var dict = R.ImmutableDictionary(() => R.Int32(0, 10_000), R.String);
        Assert.Equal(dict.Keys.Count(), dict.Keys.Distinct().Count());
    }

    [Fact]
    public void ImmutableDictionary_Generator_WithLength()
    {
        var dict = R.ImmutableDictionary(() => R.Int32(0, 10_000), R.String, 10);
        Assert.Equal(dict.Keys.Count(), dict.Keys.Distinct().Count());
    }

    [Fact]
    public void ImmutableSortedDictionary_Generator_Default()
    {
        var dict = R.ImmutableSortedDictionary(() => R.Int32(0, 10_000), R.String);
        Assert.True(dict.Keys.SequenceEqual(dict.Keys.OrderBy(k => k)));
    }

    [Fact]
    public void ImmutableSortedDictionary_Generator_WithLength()
    {
        var dict = R.ImmutableSortedDictionary(() => R.Int32(0, 10_000), R.String, 10);
        Assert.True(dict.Keys.SequenceEqual(dict.Keys.OrderBy(k => k)));
    }

    // Enumerable helpers (parameterless Random)

    [Fact]
    public void Random_Empty_Object_Throws_InvalidOperationException()
    {
        object[] empty = Array.Empty<object>();
        Assert.Throws<InvalidOperationException>(() => R.Random(empty));
    }

    [Fact]
    public void Random_Empty_ObjectNullable_Throws_InvalidOperationException()
    {
        object?[] empty = Array.Empty<object?>();
        Assert.Throws<InvalidOperationException>(() => R.Random(empty));
    }

    [Fact]
    public void Random_Empty_Int_Throws_InvalidOperationException()
    {
        int[] empty = Array.Empty<int>();
        Assert.Throws<InvalidOperationException>(() => R.Random(empty));
    }

    [Fact]
    public void Random_Empty_NullableInt_Throws_InvalidOperationException()
    {
        int?[] empty = Array.Empty<int?>();
        Assert.Throws<InvalidOperationException>(() => R.Random(empty));
    }

    [Fact]
    public void RandomOrDefault_Empty_Object_Returns_Null()
    {
        object[] empty = Array.Empty<object>();
        var v = R.RandomOrDefault(empty);
        Assert.Null(v);
    }

    [Fact]
    public void RandomOrDefault_Empty_ObjectNullable_Returns_Null()
    {
        object?[] empty = Array.Empty<object?>();
        var v = R.RandomOrDefault(empty);
        Assert.Null(v);
    }

    [Fact]
    public void RandomOrDefault_Empty_Int_Returns_Default()
    {
        int[] empty = Array.Empty<int>();
        var v = R.RandomOrDefault(empty);
        Assert.Equal(default, v);
    }

    [Fact]
    public void RandomOrDefault_Empty_NullableInt_Returns_Null()
    {
        int?[] empty = Array.Empty<int?>();
        var v = R.RandomOrDefault(empty);
        Assert.Null(v);
    }

    [Fact]
    public void RandomOrDefault_OnEmpty_ReturnsDefault()
    {
        var v = R.RandomOrDefault(Array.Empty<int>());
        Assert.Equal(0, v);
    }

    [Fact]
    public void Random_OnNonEmpty_ReturnsElement()
    {
        var arr = new[] { 1, 2, 3 };
        var v = R.Random(arr);
        Assert.Contains(v, arr);
    }

    [Fact]
    public void Try_Generates_Value_Satisfying_Predicate()
    {
        var v = R.Try(() => R.Int32(0, 10), x => x % 2 == 0);
        Assert.True(v % 2 == 0);
    }

    // Chance / Shuffle (parameterless Random)

    [Fact]
    public void Chance_Int_ReturnsBool()
    {
        var b = R.Chance(50);
        Assert.IsType<bool>(b);
    }

    [Fact]
    public void Chance_Double_ReturnsBool()
    {
        var b = R.Chance(0.5);
        Assert.IsType<bool>(b);
    }

    [Fact]
    public void Shuffle_Preserves_Multiset()
    {
        var source = Enumerable.Range(0, 20).ToArray();
        var shuffled = R.Shuffle(source).ToArray();
        Assert.Equal(source.Length, shuffled.Length);
        Assert.Equal(source.OrderBy(x => x), shuffled.OrderBy(x => x));
    }
}
