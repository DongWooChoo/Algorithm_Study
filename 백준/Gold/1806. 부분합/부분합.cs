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
            
            string[] input = reader.ReadLine().Split();
            // 수열 개수
            int n = int.Parse(input[0]);
            // 최소 합
            int s = int.Parse(input[1]);

            // 최소 합이 0이라면 바로 1반환
            if(s == 0){
                writer.WriteLine(1);
                reader.Close();
                writer.Flush();
                writer.Close();
                return;
            }
            List<int> number_list = reader.ReadLine().Split().Select(int.Parse).ToList();

            int start = 0;
            int end = 0;
            int min_length = n + 1;
            int sum = 0;

            while(end < n){
                // 최소 합보다 클때까지 반복
                sum += number_list[end];
                end++;
                while(sum >= s){
                    if(min_length >= end - start) {
                        min_length = end - start;
                    }
                    // 최소 합보다 크면 앞부분을 하나씩 없애봄
                    sum -= number_list[start];
                    start++;
                }
            }
            writer.WriteLine(min_length == n + 1 ? 0 : min_length);
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}