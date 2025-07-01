using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]  // Adds memory usage statistics
public class ListIterationBenchmark
{
    private List<int> numbers;
    private int[] numbersArray;

    [GlobalSetup]
    public void Setup()
    {
        numbers = new List<int>();
        for (int i = 0; i < 10_000_000; i++)
        {
            numbers.Add(i);
        }
        numbersArray = numbers.ToArray(); // For Span test
    }

    [Benchmark]
    public void Iteration_WithDirectCountAccess()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            var x = numbers[i];
        }
    }

    [Benchmark]
    public void Iteration_WithCachedCount()
    {
        int count = numbers.Count;
        for (int i = 0; i < count; i++)
        {
            var x = numbers[i];
        }
    }

    [Benchmark]
    public void Iteration_WithForeach()
    {
        foreach (var x in numbers)
        {
            // Simulate processing
        }
    }

    [Benchmark]
    public void Iteration_WithSpan()
    {
        Span<int> span = numbersArray;
        for (int i = 0; i < span.Length; i++)
        {
            var x = span[i];
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<ListIterationBenchmark>();
    }
}
