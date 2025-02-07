using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            // n의 개수
            int n = int.Parse(reader.ReadLine());
            // 등비수열만큼의 개수만 허용
            List<int> big_values = new List<int>(n*(n+1)/2);
            
            for(int i = 0; i < n; i++){
                // 입력한 값을 배열에다가 담음
                List<int> values = reader.ReadLine().Split().Select(int.Parse).ToList();
                // 정렬
                values.Sort();
                values.Reverse();
                // 1행에서는 최대 1개 값만이, 2행에서는 최대 2개 값만이 최대 값 후보에 들 수 있음
                for(int j = 0; j <= i; j++){
                    big_values.Add(values[j]);
                }
            }
            // 전체 정렬 후 n번째값 출력
            big_values.Sort();
            big_values.Reverse();
            writer.WriteLine(big_values[n-1]);
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}