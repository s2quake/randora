// <copyright file="RandomSeedsData.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora.Tests;

public sealed class RandomSeedsData : TheoryData<int>
{
#if DEBUG
    private const long WindowSeconds = 600; // 10 minutes
#endif

    public RandomSeedsData()
    {
#if DEBUG
        Add(GetTenMinuteSeed(0));
#else
        Add(Random.Shared.Next());
        Add(Random.Shared.Next());
        Add(Random.Shared.Next());
        Add(Random.Shared.Next());
#endif
    }

#if DEBUG
    private static int GetTenMinuteSeed(int index = 0)
    {
        long nowSec = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long bucket = nowSec / WindowSeconds;

        unchecked
        {
            long x = (bucket * (long)0x9E3779B97F4A7C15L) + index;
            x ^= x >> 30;
            x *= (long)0xBF58476D1CE4E5B9L;
            x ^= x >> 27;
            x *= (long)0x94D049BB133111EBL;
            x ^= x >> 31;
            return (int)(x & 0x7fffffff);
        }
    }
#endif
}
