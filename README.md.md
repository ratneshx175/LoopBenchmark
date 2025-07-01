# C# List Iteration Benchmark - .NET 8

This project benchmarks different techniques for iterating over large lists in C# using **.NET 8** and **BenchmarkDotNet**.

The focus is on performance and memory efficiency when processing large datasets.

---

## 📦 Project Information

- **Framework:** .NET 8
- **NuGet Package:**
  ```xml
  <PackageReference Include="BenchmarkDotNet" Version="0.14.0" />
  ```
- **BenchmarkDotNet Version:** 0.14.0

---

## 🛠 Technologies Used

- C# 12 (.NET 8)
- BenchmarkDotNet for benchmarking
- Span for low-overhead array access

---

## 🚀 How to Run

**Prerequisites:**

- .NET 8 SDK installed

**Steps:**

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
dotnet restore
dotnet run -c Release
```

BenchmarkDotNet will execute all test methods and output detailed performance statistics.

---

## 🔬 Benchmark Methods Explained

| Method Name                       | Description                                                  |
| --------------------------------- | ------------------------------------------------------------ |
| `Iteration_WithDirectCountAccess` | Uses `for (int i = 0; i < numbers.Count; i++)` for iteration |
| `Iteration_WithCachedCount`       | Caches `.Count` in a local variable before the loop          |
| `Iteration_WithForeach`           | Iterates using `foreach (var x in numbers)`                  |
| `Iteration_WithSpan`              | Converts list to array and iterates using `Span<int>`        |

List contains **10 million integers**.

---

## 📊 Benchmark Results

**Device Details:**

- **CPU:** AMD Ryzen 5 5625U with Radeon Graphics, 6 Cores / 12 Threads
- **RAM:** System Dependent
- **OS:** Windows 11 (10.0.26100.4351)
- **.NET Version:** .NET 8.0.11
- **BenchmarkDotNet:** 0.14.0

**Note:** Benchmark executed with attached debugger.

### Performance Comparison

```
| Method                          | Mean     | Error     | StdDev    | Median   | Allocated |
|---------------------------------|----------|-----------|-----------|----------|-----------|
| Iteration_WithDirectCountAccess | 3.948 ms | 0.0777 ms | 0.1551 ms | 3.878 ms | 26 B      |
| Iteration_WithCachedCount       | 4.101 ms | 0.0812 ms | 0.2331 ms | 4.041 ms | 26 B      |
| Iteration_WithForeach           | 3.509 ms | 0.0678 ms | 0.1762 ms | 3.454 ms | 52 B      |
| Iteration_WithSpan              | 2.503 ms | 0.0290 ms | 0.0242 ms | 2.503 ms | 26 B      |
```

**Observations:**

- `Span<T>` offers the fastest iteration.
- `foreach` is faster than both direct and cached `.Count` access in this scenario.
- Caching `.Count` doesn't significantly outperform direct `.Count` access for `List<int>`.
- `foreach` results in slightly more memory allocation compared to other methods.

**Warnings:**

- Benchmark was executed with an attached debugger, results may vary slightly in production conditions.
- Outliers removed during analysis to maintain result accuracy.

---

## 📚 References

- [BenchmarkDotNet Documentation](https://benchmarkdotnet.org/articles/guides/quick-start.html)
- [Span](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)[ - Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)
- [.NET 8 Official Site](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

## ⭐️ Star this project if you found it useful!

---

**Feel free to contribute with additional iteration techniques or improvements.**

