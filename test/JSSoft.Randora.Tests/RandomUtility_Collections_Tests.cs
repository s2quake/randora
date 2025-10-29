// <copyright file="RandomUtility_Collections_Tests.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

namespace JSSoft.Randora.Tests;

public class RandomUtility_Collections_Tests
{
    private static Random NewSeeded(int seed = 123) => new(seed);

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Array_Generates_Length(int seed)
    {
        var r = NewSeeded(seed);
        var arr = R.Array(r, rr => R.Int32(rr, 0, 10), length: 5);
        Assert.Equal(5, arr.Length);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void List_Generates_Length(int seed)
    {
        var r = NewSeeded(seed);
        var list = R.List(r, rr => R.Int32(rr, 0, 10), length: 7);
        Assert.Equal(7, list.Count);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void HashSet_No_Duplicates(int seed)
    {
        var r = NewSeeded(seed);
        var set = R.HashSet(r, rr => R.Int32(rr, 0, 100), length: 20);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void SortedSet_Sorted(int seed)
    {
        var r = NewSeeded(seed);
        var set = R.SortedSet(r, rr => R.Int32(rr, 0, 100), length: 15);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void Dictionary_Unique_Keys(int seed)
    {
        var r = NewSeeded(seed);
        var dict = R.Dictionary(r, rr => R.Int32(rr, 0, 1000), R.String, length: 30);
        Assert.Equal(dict.Keys.Count, dict.Keys.Distinct().Count());
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void SortedDictionary_Sorted_By_Key(int seed)
    {
        var r = NewSeeded(seed);
        var sdict = R.SortedDictionary(r, rr => R.Int32(rr, 0, 1000), R.String, length: 20);
        Assert.True(sdict.Keys.SequenceEqual(sdict.Keys.OrderBy(k => k)));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableArray_Length(int seed)
    {
        var r = NewSeeded(seed);
        var arr = R.ImmutableArray(r, rr => R.Int32(rr, 0, 10), length: 4);
        Assert.Equal(4, arr.Length);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableList_Length(int seed)
    {
        var r = NewSeeded(seed);
        var list = R.ImmutableList(r, rr => R.Int32(rr, 0, 10), length: 6);
        Assert.Equal(6, list.Count);
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableHashSet_No_Duplicates(int seed)
    {
        var r = NewSeeded(seed);
        var set = R.ImmutableHashSet(r, rr => R.Int32(rr, 0, 20), length: 20);
        Assert.Equal(set.Count, set.Distinct().Count());
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableSortedSet_Sorted(int seed)
    {
        var r = NewSeeded(seed);
        var set = R.ImmutableSortedSet(r, rr => R.Int32(rr, 0, 20), length: 10);
        Assert.True(set.SequenceEqual(set.OrderBy(x => x)));
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableDictionary_Unique_Keys(int seed)
    {
        var r = NewSeeded(seed);
        var dict = R.ImmutableDictionary(r, rr => R.Int32(rr, 0, 1000), R.String, length: 25);
        Assert.Equal(dict.Keys.Count(), dict.Keys.Distinct().Count());
    }

    [Theory]
    [InlineData(0)]
    [ClassData(typeof(RandomSeedsData))]
    public void ImmutableSortedDictionary_Sorted_By_Key(int seed)
    {
        var r = NewSeeded(seed);
        var dict = R.ImmutableSortedDictionary(r, rr => R.Int32(rr, 0, 1000), R.String, length: 25);
        Assert.True(dict.Keys.SequenceEqual(dict.Keys.OrderBy(k => k)));
    }

    // ------------------------------
    // No-length overloads with a fixed seed ([Fact])
    // Verifies determinism and basic properties when length is driven by R.Length(random)
    // ------------------------------

    [Fact]
    public void Array_DefaultLength_WithSeed_IsDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var a1 = R.Array(r1, rr => R.Int32(rr, 0, 10));
        var a2 = R.Array(r2, rr => R.Int32(rr, 0, 10));
        Assert.Equal(a1, a2);
        Assert.InRange(a1.Length, 1, 9);
    }

    [Fact]
    public void List_DefaultLength_WithSeed_IsDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var l1 = R.List(r1, rr => R.Int32(rr, 0, 10));
        var l2 = R.List(r2, rr => R.Int32(rr, 0, 10));
        Assert.Equal(l1, l2);
        Assert.InRange(l1.Count, 1, 9);
    }

    [Fact]
    public void HashSet_DefaultLength_WithSeed_DeterministicContent()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var s1 = R.HashSet(r1, rr => R.Int32(rr, 0, 100));
        var s2 = R.HashSet(r2, rr => R.Int32(rr, 0, 100));
        Assert.True(s1.SetEquals(s2));
        Assert.Equal(s1.Count, s1.Distinct().Count());
    }

    [Fact]
    public void SortedSet_DefaultLength_WithSeed_SortedAndDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var s1 = R.SortedSet(r1, rr => R.Int32(rr, 0, 100));
        var s2 = R.SortedSet(r2, rr => R.Int32(rr, 0, 100));
        Assert.True(s1.SequenceEqual(s2));
        Assert.True(s1.SequenceEqual(s1.OrderBy(x => x)));
    }

    [Fact]
    public void Dictionary_DefaultLength_WithSeed_Deterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var d1 = R.Dictionary(r1, rr => R.Int32(rr, 0, 1000), R.String);
        var d2 = R.Dictionary(r2, rr => R.Int32(rr, 0, 1000), R.String);
        Assert.Equal(d1.OrderBy(kv => kv.Key), d2.OrderBy(kv => kv.Key));
        Assert.Equal(d1.Keys.Count, d1.Keys.Distinct().Count());
    }

    [Fact]
    public void SortedDictionary_DefaultLength_WithSeed_SortedAndDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var sd1 = R.SortedDictionary(r1, rr => R.Int32(rr, 0, 1000), R.String);
        var sd2 = R.SortedDictionary(r2, rr => R.Int32(rr, 0, 1000), R.String);
        Assert.True(sd1.SequenceEqual(sd2));
        Assert.True(sd1.Keys.SequenceEqual(sd1.Keys.OrderBy(k => k)));
    }

    [Fact]
    public void ImmutableArray_DefaultLength_WithSeed_IsDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var a1 = R.ImmutableArray(r1, rr => R.Int32(rr, 0, 10));
        var a2 = R.ImmutableArray(r2, rr => R.Int32(rr, 0, 10));
        Assert.Equal(a1, a2);
        Assert.InRange(a1.Length, 1, 9);
    }

    [Fact]
    public void ImmutableList_DefaultLength_WithSeed_IsDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var l1 = R.ImmutableList(r1, rr => R.Int32(rr, 0, 10));
        var l2 = R.ImmutableList(r2, rr => R.Int32(rr, 0, 10));
        Assert.Equal(l1, l2);
        Assert.InRange(l1.Count, 1, 9);
    }

    [Fact]
    public void ImmutableHashSet_DefaultLength_WithSeed_DeterministicContent()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var s1 = R.ImmutableHashSet(r1, rr => R.Int32(rr, 0, 100));
        var s2 = R.ImmutableHashSet(r2, rr => R.Int32(rr, 0, 100));
        Assert.Equal(s1.Count, s1.Distinct().Count());
        Assert.True(s1.SetEquals(s2));
    }

    [Fact]
    public void ImmutableSortedSet_DefaultLength_WithSeed_SortedAndDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var s1 = R.ImmutableSortedSet(r1, rr => R.Int32(rr, 0, 100));
        var s2 = R.ImmutableSortedSet(r2, rr => R.Int32(rr, 0, 100));
        Assert.True(s1.SequenceEqual(s2));
        Assert.True(s1.SequenceEqual(s1.OrderBy(x => x)));
    }

    [Fact]
    public void ImmutableDictionary_DefaultLength_WithSeed_Deterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var d1 = R.ImmutableDictionary(r1, rr => R.Int32(rr, 0, 1000), R.String);
        var d2 = R.ImmutableDictionary(r2, rr => R.Int32(rr, 0, 1000), R.String);
        Assert.Equal(d1.OrderBy(kv => kv.Key), d2.OrderBy(kv => kv.Key));
        Assert.Equal(d1.Keys.Count(), d1.Keys.Distinct().Count());
    }

    [Fact]
    public void ImmutableSortedDictionary_DefaultLength_WithSeed_SortedAndDeterministic()
    {
        var r1 = NewSeeded(12345);
        var r2 = NewSeeded(12345);
        var d1 = R.ImmutableSortedDictionary(r1, rr => R.Int32(rr, 0, 1000), R.String);
        var d2 = R.ImmutableSortedDictionary(r2, rr => R.Int32(rr, 0, 1000), R.String);
        Assert.True(d1.SequenceEqual(d2));
        Assert.True(d1.Keys.SequenceEqual(d1.Keys.OrderBy(k => k)));
    }

    // ------------------------------
    // TryGetValue/TryGetKey failure path tests
    // Generator domain is a single value → after first insertion, uniqueness cannot be satisfied
    // Try(...) throws MaxAttemptsExceededException internally and is caught by TryGetValue/TryGetKey
    // The loop breaks early → resulting collection is smaller than requested length
    // ------------------------------

    [Fact]
    public void ImmutableHashSet_GeneratorDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var set = R.ImmutableHashSet(r, _ => 0, length: 10);
        Assert.Single(set);
        Assert.Contains(0, set);
    }

    [Fact]
    public void ImmutableSortedSet_GeneratorDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var set = R.ImmutableSortedSet(r, _ => 0, length: 10);
        Assert.Single(set);
        Assert.True(set.SequenceEqual(new[] { 0 }));
    }

    [Fact]
    public void HashSet_GeneratorDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var set = R.HashSet(r, _ => 0, length: 10);
        Assert.Single(set);
        Assert.Contains(0, set);
    }

    [Fact]
    public void SortedSet_GeneratorDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var set = R.SortedSet(r, _ => 0, length: 10);
        Assert.Single(set);
        Assert.True(set.SequenceEqual(new[] { 0 }));
    }

    [Fact]
    public void Dictionary_KeyDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var dict = R.Dictionary(r, _ => 0, _ => "v", length: 10);
        Assert.Single(dict);
        Assert.True(dict.ContainsKey(0));
    }

    [Fact]
    public void SortedDictionary_KeyDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var dict = R.SortedDictionary(r, _ => 0, _ => "v", length: 10);
        Assert.Single(dict);
        Assert.True(dict.ContainsKey(0));
        Assert.True(dict.Keys.SequenceEqual(new[] { 0 }));
    }

    [Fact]
    public void ImmutableDictionary_KeyDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var dict = R.ImmutableDictionary(r, _ => 0, _ => "v", length: 10);
        Assert.Single(dict);
        Assert.True(dict.ContainsKey(0));
    }

    [Fact]
    public void ImmutableSortedDictionary_KeyDomainExhausted_BreaksEarly()
    {
        var r = NewSeeded(1);
        var dict = R.ImmutableSortedDictionary(r, _ => 0, _ => "v", length: 10);
        Assert.Single(dict);
        Assert.True(dict.ContainsKey(0));
        Assert.True(dict.Keys.SequenceEqual(new[] { 0 }));
    }
}
