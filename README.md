![](https://github.com/ctufaro/GoogleHashCode2020/blob/master/logo.png?raw=true)
# Google Hashcode 2020
### Usage

Copy Program.cs into your dotnet core project.

```sh
$ dotnet run [path to input file] -t
```

### Results
| Input Set | Generated Slices / Points | Maximum Slices / Points | Method |
| ------ | ------ | ------ | ------ |
| a_example.in | 16 | 16 | BackTrack |
| b_small.in | 100 | 100 | BackTrack |
| c_medium.in | 4,500 | 4,500 | GreedyLoop |
| d_quite_big.in | 999,999,725 | 1,000,000,000 | GreedyLoop |
| e_also_big.in | 504,999,983 | 505,000,000 | GreedyLoop |
| **Total** | **1,505,004,324** | **1,505,004,616** ||

