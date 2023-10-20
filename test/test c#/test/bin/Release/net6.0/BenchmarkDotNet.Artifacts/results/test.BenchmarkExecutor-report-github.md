```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 10 (10.0.19045.3208/22H2/2022Update)
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]   : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  ShortRun : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method             | Mean      | Error     | StdDev    | Ratio | RatioSD | Rank | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------:|----------:|----------:|------:|--------:|-----:|-------:|----------:|------------:|
| BenchMarkExecutor2 |  9.298 ns | 11.136 ns | 0.6104 ns |  0.94 |    0.11 |    1 | 0.0127 |      40 B |        1.00 |
| BenchMarkExecutor  | 10.050 ns | 33.856 ns | 1.8558 ns |  1.00 |    0.00 |    2 | 0.0127 |      40 B |        1.00 |
| BenchMarkExecutor3 | 10.053 ns | 18.289 ns | 1.0025 ns |  1.01 |    0.11 |    2 | 0.0127 |      40 B |        1.00 |
