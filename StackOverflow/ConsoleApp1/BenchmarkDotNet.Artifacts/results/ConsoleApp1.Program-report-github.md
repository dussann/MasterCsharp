``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1415 (21H1/May2021Update)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.404
  [Host]     : .NET 5.0.13 (5.0.1321.56516), X64 RyuJIT
  DefaultJob : .NET 5.0.13 (5.0.1321.56516), X64 RyuJIT


```
|         Method |     Mean |    Error |   StdDev |
|--------------- |---------:|---------:|---------:|
| CreateFunction | 78.04 ms | 1.547 ms | 2.905 ms |
