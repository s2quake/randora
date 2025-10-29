// <copyright file="RandomUtility_Tuple_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora.Tests;

public class RandomUtility_Tuple_Tests
{
    private static Random NewSeeded(int seed = 2468) => new(seed);

    // ------------------------------
    // Tuple (System.Tuple<...>) seeded determinism
    // ------------------------------

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple2_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, rr => R.Int32(rr, -100, 100), R.String);
        var actual = R.Tuple(r2, rr => R.Int32(rr, -100, 100), R.String);
        Assert.Equal(expected, actual);
        Assert.InRange(expected.Item1, -100, 99);
        Assert.False(string.IsNullOrWhiteSpace(expected.Item2));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple3_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, R.Boolean, R.Guid, rr => R.Int32(rr, 0, 10));
        var actual = R.Tuple(r2, R.Boolean, R.Guid, rr => R.Int32(rr, 0, 10));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple4_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, R.String, R.Boolean, R.Guid, rr => R.Int32(rr, -50, 50));
        var actual = R.Tuple(r2, R.String, R.Boolean, R.Guid, rr => R.Int32(rr, -50, 50));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple5_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        var actual = R.Tuple(r2, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple6_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, R.Int64, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        var actual = R.Tuple(r2, R.Int64, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple7_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(r1, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        var actual = R.Tuple(r2, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Tuple8_WithTRest_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.Tuple(
            r1,
            R.Int32,
            R.String,
            R.Boolean,
            R.Guid,
            R.UInt32,
            R.Decimal,
            R.Double,
            rr => Tuple.Create(R.Int32(rr), R.Int32(rr)));
        var actual = R.Tuple(
            r2,
            R.Int32,
            R.String,
            R.Boolean,
            R.Guid,
            R.UInt32,
            R.Decimal,
            R.Double,
            rr => Tuple.Create(R.Int32(rr), R.Int32(rr)));
        Assert.Equal(expected, actual);
        Assert.IsType<Tuple<int, int>>(expected.Rest);
    }

    // ------------------------------
    // ValueTuple seeded determinism
    // ------------------------------

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple2_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Int64, R.String);
        var actual = R.ValueTuple(r2, R.Int64, R.String);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple4_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Boolean, R.Guid, R.UInt32, rr => R.Int32(rr, -10, 10));
        var actual = R.ValueTuple(r2, R.Boolean, R.Guid, R.UInt32, rr => R.Int32(rr, -10, 10));
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple3_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Int32, R.String, R.Guid);
        var actual = R.ValueTuple(r2, R.Int32, R.String, R.Guid);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple5_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        var actual = R.ValueTuple(r2, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple6_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Int64, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        var actual = R.ValueTuple(r2, R.Int64, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple7_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(r1, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        var actual = R.ValueTuple(r2, R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ValueTuple8_WithTRest_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = R.ValueTuple(
            r1,
            R.Int32,
            R.String,
            R.Boolean,
            R.Guid,
            R.UInt32,
            R.Decimal,
            R.Double,
            rr => DateTimeOffset.FromUnixTimeSeconds(R.Int32(rr, 0, int.MaxValue)));
        var actual = R.ValueTuple(
            r2,
            R.Int32,
            R.String,
            R.Boolean,
            R.Guid,
            R.UInt32,
            R.Decimal,
            R.Double,
            rr => DateTimeOffset.FromUnixTimeSeconds(R.Int32(rr, 0, int.MaxValue)));
        Assert.Equal(expected, actual);
    }

    // ------------------------------
    // Nullable Tuple / ValueTuple
    // ------------------------------

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NullableTuple2_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        Tuple<int, string>? expected = R.Chance(r1, 66) ? R.Tuple(r1, rr => R.Int32(rr, 0, 100), R.String) : null;
        var actual = R.NullableTuple(r2, rr => R.Int32(rr, 0, 100), R.String);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NullableValueTuple3_WithSeed_Deterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        (int, string, Guid)? expected = R.Chance(r1, 66)
            ? R.ValueTuple(r1, rr => R.Int32(rr, -5, 5), R.String, R.Guid)
            : null;
        var actual = R.NullableValueTuple(r2, rr => R.Int32(rr, -5, 5), R.String, R.Guid);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NullableTuple2_Parameterless_Returns_NullOrTuple()
    {
        var t = R.NullableTuple(R.Int32, R.String);
        if (t is not null)
        {
            Assert.False(string.IsNullOrWhiteSpace(t.Item2));
        }
    }

    [Fact]
    public void NullableValueTuple2_Parameterless_Returns_NullOrValueTuple()
    {
        var t = R.NullableValueTuple(R.Int32, R.String);
        if (t is (int a, string b))
        {
            Assert.IsType<int>(a);
            Assert.False(string.IsNullOrWhiteSpace(b));
        }
    }

    // ------------------------------
    // Parameterless generators (NO Random) for all arities up to 7 (+ TRest)
    // ------------------------------

    [Fact]
    public void Tuple2_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String);
        Assert.IsType<Tuple<int, string>>(t);
        Assert.IsType<int>(t.Item1);
        Assert.False(string.IsNullOrWhiteSpace(t.Item2));
    }

    [Fact]
    public void Tuple3_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean);
        Assert.IsType<Tuple<int, string, bool>>(t);
        Assert.IsType<int>(t.Item1);
        Assert.False(string.IsNullOrWhiteSpace(t.Item2));
        Assert.IsType<bool>(t.Item3);
    }

    [Fact]
    public void Tuple4_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean, R.Guid);
        Assert.IsType<Tuple<int, string, bool, Guid>>(t);
        Assert.IsType<Guid>(t.Item4);
    }

    [Fact]
    public void Tuple5_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        Assert.IsType<Tuple<int, string, bool, Guid, uint>>(t);
        Assert.IsType<uint>(t.Item5);
    }

    [Fact]
    public void Tuple6_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        Assert.IsType<Tuple<int, string, bool, Guid, uint, decimal>>(t);
        Assert.IsType<decimal>(t.Item6);
    }

    [Fact]
    public void Tuple7_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        Assert.IsType<Tuple<int, string, bool, Guid, uint, decimal, double>>(t);
        Assert.IsType<double>(t.Item7);
    }

    [Fact]
    public void Tuple8_WithTRest_NoRandom_Generates_Shape()
    {
        var t = R.Tuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double, () => Tuple.Create(1, 2));
        Assert.IsType<Tuple<int, string, bool, Guid, uint, decimal, double, Tuple<int, int>>>(t);
        Assert.Equal(1, t.Rest.Item1);
        Assert.Equal(2, t.Rest.Item2);
    }

    [Fact]
    public void ValueTuple2_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String);
        Assert.IsType<(int, string)>(t);
        Assert.IsType<int>(t.Item1);
        Assert.False(string.IsNullOrWhiteSpace(t.Item2));
    }

    [Fact]
    public void ValueTuple3_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean);
        Assert.IsType<(int, string, bool)>(t);
        Assert.IsType<bool>(t.Item3);
    }

    [Fact]
    public void ValueTuple4_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean, R.Guid);
        Assert.IsType<(int, string, bool, Guid)>(t);
        Assert.IsType<Guid>(t.Item4);
    }

    [Fact]
    public void ValueTuple5_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32);
        Assert.IsType<(int, string, bool, Guid, uint)>(t);
        Assert.IsType<uint>(t.Item5);
    }

    [Fact]
    public void ValueTuple6_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal);
        Assert.IsType<(int, string, bool, Guid, uint, decimal)>(t);
        Assert.IsType<decimal>(t.Item6);
    }

    [Fact]
    public void ValueTuple7_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double);
        Assert.IsType<(int, string, bool, Guid, uint, decimal, double)>(t);
        Assert.IsType<double>(t.Item7);
    }

    [Fact]
    public void ValueTuple8_WithTRest_NoRandom_Generates_Shape()
    {
        var t = R.ValueTuple(R.Int32, R.String, R.Boolean, R.Guid, R.UInt32, R.Decimal, R.Double, () => DateTime.UnixEpoch);
        Assert.IsType<int>(t.Item1);
        Assert.IsType<string>(t.Item2);
        Assert.IsType<bool>(t.Item3);
        Assert.IsType<Guid>(t.Item4);
        Assert.IsType<uint>(t.Item5);
        Assert.IsType<decimal>(t.Item6);
        Assert.IsType<double>(t.Item7);
        Assert.IsType<System.ValueTuple<DateTime>>(t.Rest);
        Assert.True(t.Rest.Item1 >= DateTime.UnixEpoch);
    }
}
