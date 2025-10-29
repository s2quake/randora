// <copyright file="RandomUtility_BasicTypes_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

using System.Reflection;
using System.Runtime.Versioning;

namespace JSSoft.Randora.Tests;

public class RandomUtility_BasicTypes_Tests
{
    private static Random NewSeeded(int seed = 42) => new(seed);

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void SByte_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        // expected via direct NextBytes
        var b = new byte[1];
        r1.NextBytes(b);
        var expected = (sbyte)b[0];

        var actual = R.SByte(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Byte_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var b = new byte[1];
        r1.NextBytes(b);
        var expected = b[0];

        var actual = R.Byte(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Int16_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var bytes = new byte[2];
        r1.NextBytes(bytes);
        var expected = BitConverter.ToInt16(bytes, 0);

        var actual = R.Int16(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void UInt16_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var bytes = new byte[2];
        r1.NextBytes(bytes);
        var expected = BitConverter.ToUInt16(bytes, 0);

        var actual = R.UInt16(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Int32_Range(int seed)
    {
        var r = NewSeeded(seed);
        var min = -1234;
        var max = 5678;
        var v = R.Int32(r, min, max);
        Assert.InRange(v, min, max - 1);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void UInt32_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var bytes = new byte[4];
        r1.NextBytes(bytes);
        var expected = BitConverter.ToUInt32(bytes, 0);

        var actual = R.UInt32(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Int64_Range(int seed)
    {
        var r = NewSeeded(seed);
        long min = -999_999_999_999;
        long max = 999_999_999_999;
        var v = R.Int64(r, min, max);
        Assert.True(v >= min && v < max);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void UInt64_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var bytes = new byte[8];
        r1.NextBytes(bytes);
        var expected = BitConverter.ToUInt64(bytes, 0);

        var actual = R.UInt64(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Single_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);

        var asm = typeof(R).Assembly;
        var attr = asm.GetCustomAttribute<TargetFrameworkAttribute>();

        var actual = R.Single(r2);
        if (attr?.FrameworkName == ".NETStandard,Version=v2.1")
        {
            var expected = (float)r1.NextDouble() * r1.Next();
            Assert.Equal(expected, actual);
        }
        else
        {
            var expected = r1.NextSingle();
            Assert.Equal(expected, actual);
        }
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Double_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = r1.NextDouble();
        var actual = R.Double(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Guid_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var expected = new Guid(R.Array(r1, R.Byte, 16));
        var actual = R.Guid(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Decimal_WithSeed_WithinRange01(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.Decimal(r);
        Assert.True(v >= 0m && v <= 1m);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void BigInteger_WithSeed_IsDeterministic(int seed)
    {
        var r1 = NewSeeded(seed);
        var r2 = NewSeeded(seed);
        var length = R.Length(r1, 1, 17);
        var bytes = R.Array(r1, R.Byte, length);
        var expected = new BigInteger(bytes);
        var actual = R.BigInteger(r2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Positive_IsPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.Positive(r);
        Assert.True(v > 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Negative_IsNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.Negative(r);
        Assert.True(v < 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonPositive_IsNonPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonPositive(r);
        Assert.True(v <= 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonNegative_IsNonNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonNegative(r);
        Assert.True(v >= 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void PositiveInt64_IsPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.PositiveInt64(r);
        Assert.True(v > 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NegativeInt64_IsNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NegativeInt64(r);
        Assert.True(v < 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonPositiveInt64_IsNonPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonPositiveInt64(r);
        Assert.True(v <= 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonNegativeInt64_IsNonNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonNegativeInt64(r);
        Assert.True(v >= 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void PositiveBigInteger_IsPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.PositiveBigInteger(r);
        Assert.True(v > 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NegativeBigInteger_IsNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NegativeBigInteger(r);
        Assert.True(v < 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonPositiveBigInteger_IsNonPositive(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonPositiveBigInteger(r);
        Assert.True(v <= 0);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void NonNegativeBigInteger_IsNonNegative(int seed)
    {
        var r = NewSeeded(seed);
        var v = R.NonNegativeBigInteger(r);
        Assert.True(v >= 0);
    }
}
