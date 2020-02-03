![](https://github.com/ctufaro/GoogleHashCode2020/blob/master/logo.png?raw=true)
# Google Hashcode 2020
### Usage

Copy Program.cs into your .NET Core Console Application.

```sh
$ dotnet run [path to input file] -t
```

### Results
| Input Set | Generated Slices / Points | Maximum Slices / Points | Method |
| ------ | ------ | ------ | ------ |
| a_example.in | 16 | 16 | BackTrack() |
| b_small.in | 100 | 100 | BackTrack() |
| c_medium.in | 4,500 | 4,500 | BackTrack() |
| d_quite_big.in | 999,999,932 | 1,000,000,000 | GreedyLoop() |
| e_also_big.in | 505,000,000 | 505,000,000 | GreedyLoop() |

totals : **1,505,004,548** / **1,505,004,616**

