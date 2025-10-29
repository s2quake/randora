// <copyright file="RandomUtility_Other_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

using System.Numerics;

namespace JSSoft.Randora.Tests;

public class RandomUtility_Other_Tests
{
    private static Random NewSeeded(int seed = 999) => new(seed);

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Word_Returns_NonEmpty(int seed)
    {
        var r = NewSeeded(seed);
        var w = R.Word(r);
        Assert.False(string.IsNullOrWhiteSpace(w));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Hex_Length_Matches(int seed)
    {
        var r = NewSeeded(seed);
        var s = R.Hex(r, 8);
        Assert.Equal(16, s.Length); // 2 chars per byte
        Assert.Matches("^[0-9a-f]+$", s);
    }

    // ------------------------------
    // NewSeeded + Theory based tests for Random / RandomOrDefault
    // class(object) / struct(int) and their nullable forms
    // ------------------------------

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Random_Object_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => (object)R.Int32(r, -1000, 1000))
            .ToArray();
        var selected = R.Random(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Random_ObjectNullable_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Boolean(r) ? null : (object?)R.String(r))
            .ToArray();
        var selected = R.Random(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Random_Int_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Int32(r, -5000, 5000))
            .ToArray();
        var selected = R.Random(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Random_NullableInt_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Boolean(r) ? (int?)null : R.Int32(r, -100, 100))
            .ToArray();
        var selected = R.Random(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void RandomOrDefault_Object_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => (object)R.Int32(r, 0, 1000))
            .ToArray();
        var selected = R.RandomOrDefault(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void RandomOrDefault_ObjectNullable_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Boolean(r) ? null : (object?)R.String(r))
            .ToArray();
        var selected = R.RandomOrDefault(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void RandomOrDefault_Int_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Int32(r, 0, 10000))
            .ToArray();
        var selected = R.RandomOrDefault(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void RandomOrDefault_NullableInt_Selects_Element(int seed)
    {
        var r = NewSeeded(seed);
        var items = Enumerable.Range(0, 8)
            .Select(_ => R.Boolean(r) ? (int?)null : R.Int32(r, 0, 100))
            .ToArray();
        var selected = R.RandomOrDefault(items);
        Assert.Contains(selected, items);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Char_Is_Any_Char(int seed)
    {
        var r = NewSeeded(seed);
        var c = R.Char(r);
        Assert.InRange((int)c, char.MinValue, char.MaxValue);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void DateTimeOffset_InExpectedRange(int seed)
    {
        var r = NewSeeded(seed);
        var d = R.DateTimeOffset(r);
        Assert.True(d >= DateTimeOffset.UnixEpoch);
        Assert.True(d <= new DateTimeOffset(new DateTime(2050, 12, 31, 0, 0, 0, DateTimeKind.Utc)));
        Assert.Equal(0, d.Ticks % 10_000_000); // seconds precision
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void TimeSpan_Basic(int seed)
    {
        var r = NewSeeded(seed);
        var ts = R.TimeSpan(r);
        Assert.True(ts >= TimeSpan.Zero);
        Assert.True(ts < new TimeSpan(365, 0, 0, 0));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void TimeSpan_Range_Ms(int seed)
    {
        var r = NewSeeded(seed);
        var ts = R.TimeSpan(r, 10, 20);
        Assert.True(ts >= TimeSpan.FromMilliseconds(10));
        Assert.True(ts < TimeSpan.FromMilliseconds(20));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Guid_Has_16Bytes(int seed)
    {
        var r = NewSeeded(seed);
        var g = R.Guid(r);
        Assert.Equal(16, g.ToByteArray().Length);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Length_Range(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.Length(r, 3, 7);
        Assert.True(v >= 3 && v < 7);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Length_WithMax_Range_Seeded(int seed)
    {
        var r = NewSeeded(seed);
        const int max = 7;
        var v = R.Length(r, max);
        Assert.True(v >= 1 && v < max);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Boolean_Returns_Bool(int seed)
    {
        var r = NewSeeded(seed);
        var b = R.Boolean(r);
        Assert.IsType<bool>(b);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Enum_Returns_One_Of_Values(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.Enum<DateTimeKind>(r);
        Assert.Contains(v, Enum.GetValues<DateTimeKind>());
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void String_Composed_Of_Words(int seed)
    {
        var r = NewSeeded(seed);
        var s = R.String(r);
        Assert.DoesNotContain("  ", s);
        Assert.False(string.IsNullOrWhiteSpace(s));
    }

    [Fact]
    public void RandomOrDefault_Returns_Default_On_Empty()
    {
        var arr = Array.Empty<int>();
        var v = R.RandomOrDefault(arr);
        Assert.Equal(0, v);
    }

    [Fact]
    public void Random_Selects_Element()
    {
        var arr = new[] { 1, 2, 3 };
        var v = R.Random(arr);
        Assert.Contains(v, arr);
    }

    [Fact]
    public void Try_Succeeds_With_Predicate()
    {
        var r = NewSeeded();
        var v = R.Try(r, rr => R.Int32(rr, 0, 10), x => x % 2 == 0);
        Assert.True(v % 2 == 0);
    }

    [Fact]
    public void Try_Throws_MaxAttemptsExceeded_When_NoMatch_ValueType()
    {
        // Generator always yields 1, predicate is always false → exceeds AttemptCount per-value
        var ex = Assert.Throws<R.MaxAttemptsExceededException>(() => R.Try(() => 1, _ => false));
        Assert.Contains(R.AttemptCount.ToString(), ex.Message);
    }

    [Fact]
    public void Try_Throws_MaxAttemptsExceeded_When_NoMatch_NullReference()
    {
        // Generator always yields null for reference type, predicate always false → exceeds AttemptCount for DBNull.Value key
        var ex = Assert.Throws<R.MaxAttemptsExceededException>(() => R.Try<string>(() => null!, _ => false));
        Assert.Contains(R.AttemptCount.ToString(), ex.Message);
    }

    [Fact]
    public void Chance_Int_Validates_Range()
    {
        var r = NewSeeded();
        Assert.Throws<ArgumentOutOfRangeException>(() => R.Chance(r, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => R.Chance(r, 101));
    }

    [Fact]
    public void Chance_Double_Validates_Range()
    {
        var r = NewSeeded();
        Assert.Throws<ArgumentOutOfRangeException>(() => R.Chance(r, -0.1));
        Assert.Throws<ArgumentOutOfRangeException>(() => R.Chance(r, 1.1));
    }

    [Fact]
    public void Shuffle_Reorders_Deterministically_WithSeed()
    {
        var r = NewSeeded();
        var source = Enumerable.Range(0, 10).ToArray();
        var shuffled1 = R.Shuffle(r, source).ToArray();
        var r2 = NewSeeded();
        var shuffled2 = R.Shuffle(r2, source).ToArray();
        Assert.Equal(shuffled1, shuffled2);

        // not guaranteed to change order, but with this seed and range most likely
        // so we allow equality as long as deterministic.
    }
}
