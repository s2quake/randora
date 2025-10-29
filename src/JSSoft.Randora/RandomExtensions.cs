// <copyright file="RandomExtensions.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora;

internal static class RandomExtensions
{
#if NETSTANDARD2_1
    public static long NextInt64(this Random @this)
    {
        Span<byte> buffer = stackalloc byte[8];
        @this.NextBytes(buffer);
        return BitConverter.ToInt64(buffer);
    }

    public static long NextInt64(this Random @this, long maxValue)
    {
        if (maxValue <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue), "maxValue must be greater than zero.");
        }

        var v = NextInt64(@this);
        return Math.Abs(v % maxValue);
    }

    public static long NextInt64(this Random @this, long minValue, long maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue), "minValue must be less than or equal to maxValue.");
        }

        var v = NextInt64(@this);
        return Math.Abs(v % (maxValue - minValue)) + minValue;
    }
#endif
}
