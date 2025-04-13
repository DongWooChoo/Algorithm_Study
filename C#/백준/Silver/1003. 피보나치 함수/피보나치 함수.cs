using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            int max_n = 41;
            int n = int.Parse(Console.ReadLine()); // 반복할 횟수
            int[] sample = new int[n];
            for (int i = 0; i < n; i++)
            {
                sample[i] = int.Parse(Console.ReadLine());
            }
            int[,] dp_fibo = new int[max_n, 2]; // 피보나치 DP 테이블
            dp_fibo[0, 0] = 1;
            dp_fibo[0, 1] = 0;
            dp_fibo[1, 0] = 0;
            dp_fibo[1, 1] = 1;

            // 테이블 값 세팅
            for (int i = 2; i < max_n; i++)
            {
                dp_fibo[i, 0] = dp_fibo[i - 1, 0] + dp_fibo[i - 2, 0];
                dp_fibo[i, 1] = dp_fibo[i - 1, 1] + dp_fibo[i - 2, 1];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(dp_fibo[sample[i], 0] + " " + dp_fibo[sample[i], 1]); // 결과 출력
            }
        }
    }
}