// <copyright file="RandomUtility.Tuple.cs" company="JSSoft">
//   Copyright (c) 2025 Jeesu Choi. All Rights Reserved.
//   Licensed under the MIT License. See LICENSE.md in the project root for license information.
// </copyright>

#pragma warning disable SA1414 // Tuple types in signatures should have element names
namespace JSSoft.Randora;

public static partial class RandomUtility
{
    /// <summary>
    /// Creates a Tuple of two elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <returns>A Tuple of two generated elements.</returns>
    public static Tuple<T1, T2> Tuple<T1, T2>(Func<T1> generator1, Func<T2> generator2)
        => new(generator1(), generator2());

    /// <summary>
    /// Creates a Tuple of two elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <returns>A Tuple of two generated elements.</returns>
    public static Tuple<T1, T2> Tuple<T1, T2>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2)
        => new(generator1(random), generator2(random));

    /// <summary>
    /// Creates a Tuple of three elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <returns>A Tuple of three generated elements.</returns>
    public static Tuple<T1, T2, T3> Tuple<T1, T2, T3>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3)
        => new(generator1(), generator2(), generator3());

    /// <summary>
    /// Creates a Tuple of three elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <returns>A Tuple of three generated elements.</returns>
    public static Tuple<T1, T2, T3> Tuple<T1, T2, T3>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3)
        => new(generator1(random), generator2(random), generator3(random));

    /// <summary>
    /// Creates a Tuple of four elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <returns>A Tuple of four generated elements.</returns>
    public static Tuple<T1, T2, T3, T4> Tuple<T1, T2, T3, T4>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4)
        => new(generator1(), generator2(), generator3(), generator4());

    /// <summary>
    /// Creates a Tuple of four elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <returns>A Tuple of four generated elements.</returns>
    public static Tuple<T1, T2, T3, T4> Tuple<T1, T2, T3, T4>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4)
        => new(generator1(random), generator2(random), generator3(random), generator4(random));

    /// <summary>
    /// Creates a Tuple of five elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <returns>A Tuple of five generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5> Tuple<T1, T2, T3, T4, T5>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5)
        => new(generator1(), generator2(), generator3(), generator4(), generator5());

    /// <summary>
    /// Creates a Tuple of five elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <returns>A Tuple of five generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5> Tuple<T1, T2, T3, T4, T5>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5)
        => new(generator1(random), generator2(random), generator3(random), generator4(random), generator5(random));

    /// <summary>
    /// Creates a Tuple of six elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <returns>A Tuple of six generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6> Tuple<T1, T2, T3, T4, T5, T6>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6)
        => new(generator1(), generator2(), generator3(), generator4(), generator5(), generator6());

    /// <summary>
    /// Creates a Tuple of six elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <returns>A Tuple of six generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6> Tuple<T1, T2, T3, T4, T5, T6>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6)
        => new(generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random));

    /// <summary>
    /// Creates a Tuple of seven elements using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <returns>A Tuple of seven generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7> Tuple<T1, T2, T3, T4, T5, T6, T7>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7)
        => new(generator1(), generator2(), generator3(), generator4(), generator5(), generator6(), generator7());

    /// <summary>
    /// Creates a Tuple of seven elements using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <returns>A Tuple of seven generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7> Tuple<T1, T2, T3, T4, T5, T6, T7>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7)
        => new(generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random), generator7(random));

    /// <summary>
    /// Creates a Tuple of eight elements (eighth is TRest) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <typeparam name="TRest">The eighth element type (TRest).</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <param name="generator8">The eighth element generator.</param>
    /// <returns>A Tuple of eight generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7, Func<TRest> generator8)
        where TRest : notnull
        => new(generator1(), generator2(), generator3(), generator4(), generator5(), generator6(), generator7(), generator8());

    /// <summary>
    /// Creates a Tuple of eight elements (eighth is TRest) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <typeparam name="TRest">The eighth element type (TRest).</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <param name="generator8">The eighth element generator that accepts a random source.</param>
    /// <returns>A Tuple of eight generated elements.</returns>
    public static Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7, Func<Random, TRest> generator8)
        where TRest : notnull
        => new(generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random), generator7(random), generator8(random));

    /// <summary>
    /// Creates a value tuple (T1,T2) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <returns>A value tuple of two generated elements.</returns>
    public static (T1, T2) ValueTuple<T1, T2>(Func<T1> generator1, Func<T2> generator2)
        => (generator1(), generator2());

    /// <summary>
    /// Creates a value tuple (T1,T2) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <returns>A value tuple of two generated elements.</returns>
    public static (T1, T2) ValueTuple<T1, T2>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2)
        => (generator1(random), generator2(random));

    /// <summary>
    /// Creates a value tuple (T1,T2,T3) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <returns>A value tuple of three generated elements.</returns>
    public static (T1, T2, T3) ValueTuple<T1, T2, T3>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3)
        => (generator1(), generator2(), generator3());

    /// <summary>
    /// Creates a value tuple (T1,T2,T3) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <returns>A value tuple of three generated elements.</returns>
    public static (T1, T2, T3) ValueTuple<T1, T2, T3>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3)
        => (generator1(random), generator2(random), generator3(random));

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <returns>A value tuple of four generated elements.</returns>
    public static (T1, T2, T3, T4) ValueTuple<T1, T2, T3, T4>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4)
        => (generator1(), generator2(), generator3(), generator4());

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <returns>A value tuple of four generated elements.</returns>
    public static (T1, T2, T3, T4) ValueTuple<T1, T2, T3, T4>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4)
        => (generator1(random), generator2(random), generator3(random), generator4(random));

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <returns>A value tuple of five generated elements.</returns>
    public static (T1, T2, T3, T4, T5) ValueTuple<T1, T2, T3, T4, T5>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5)
        => (generator1(), generator2(), generator3(), generator4(), generator5());

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <returns>A value tuple of five generated elements.</returns>
    public static (T1, T2, T3, T4, T5) ValueTuple<T1, T2, T3, T4, T5>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5)
        => (generator1(random), generator2(random), generator3(random), generator4(random), generator5(random));

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5,T6) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <returns>A value tuple of six generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6) ValueTuple<T1, T2, T3, T4, T5, T6>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6)
        => (generator1(), generator2(), generator3(), generator4(), generator5(), generator6());

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5,T6) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <returns>A value tuple of six generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6) ValueTuple<T1, T2, T3, T4, T5, T6>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6)
        => (generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random));

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5,T6,T7) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <returns>A value tuple of seven generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7) ValueTuple<T1, T2, T3, T4, T5, T6, T7>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7)
        => (generator1(), generator2(), generator3(), generator4(), generator5(), generator6(), generator7());

    /// <summary>
    /// Creates a value tuple (T1,T2,T3,T4,T5,T6,T7) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <returns>A value tuple of seven generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7) ValueTuple<T1, T2, T3, T4, T5, T6, T7>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7)
        => (generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random), generator7(random));

    /// <summary>
    /// Creates a value tuple of eight elements (eighth is TRest) using the provided element generators and the shared random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <typeparam name="TRest">The eighth element type (TRest).</typeparam>
    /// <param name="generator1">The first element generator.</param>
    /// <param name="generator2">The second element generator.</param>
    /// <param name="generator3">The third element generator.</param>
    /// <param name="generator4">The fourth element generator.</param>
    /// <param name="generator5">The fifth element generator.</param>
    /// <param name="generator6">The sixth element generator.</param>
    /// <param name="generator7">The seventh element generator.</param>
    /// <param name="generator8">The eighth element generator.</param>
    /// <returns>A value tuple of eight generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7, TRest) ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Func<T1> generator1, Func<T2> generator2, Func<T3> generator3, Func<T4> generator4, Func<T5> generator5, Func<T6> generator6, Func<T7> generator7, Func<TRest> generator8)
        where TRest : struct
        => (generator1(), generator2(), generator3(), generator4(), generator5(), generator6(), generator7(), generator8());

    /// <summary>
    /// Creates a value tuple of eight elements (eighth is TRest) using the provided element generators and the specified random source.
    /// </summary>
    /// <typeparam name="T1">The first element type.</typeparam>
    /// <typeparam name="T2">The second element type.</typeparam>
    /// <typeparam name="T3">The third element type.</typeparam>
    /// <typeparam name="T4">The fourth element type.</typeparam>
    /// <typeparam name="T5">The fifth element type.</typeparam>
    /// <typeparam name="T6">The sixth element type.</typeparam>
    /// <typeparam name="T7">The seventh element type.</typeparam>
    /// <typeparam name="TRest">The eighth element type (TRest).</typeparam>
    /// <param name="random">The random source to use.</param>
    /// <param name="generator1">The first element generator that accepts a random source.</param>
    /// <param name="generator2">The second element generator that accepts a random source.</param>
    /// <param name="generator3">The third element generator that accepts a random source.</param>
    /// <param name="generator4">The fourth element generator that accepts a random source.</param>
    /// <param name="generator5">The fifth element generator that accepts a random source.</param>
    /// <param name="generator6">The sixth element generator that accepts a random source.</param>
    /// <param name="generator7">The seventh element generator that accepts a random source.</param>
    /// <param name="generator8">The eighth element generator that accepts a random source.</param>
    /// <returns>A value tuple of eight generated elements.</returns>
    public static (T1, T2, T3, T4, T5, T6, T7, TRest) ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(Random random, Func<Random, T1> generator1, Func<Random, T2> generator2, Func<Random, T3> generator3, Func<Random, T4> generator4, Func<Random, T5> generator5, Func<Random, T6> generator6, Func<Random, T7> generator7, Func<Random, TRest> generator8)
        where TRest : struct
        => (generator1(random), generator2(random), generator3(random), generator4(random), generator5(random), generator6(random), generator7(random), generator8(random));
}
