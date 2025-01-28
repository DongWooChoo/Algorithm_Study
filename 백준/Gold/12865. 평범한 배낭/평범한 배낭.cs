using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            // 첫 줄 입력 : 아이템 개수, 최대 무게
            int n = int.Parse(input[0]); // 아이템 개수
            int max_weight = int.Parse(input[1]); // 최대 무게
            int[,] item = new int[n+1,2];
            for (int i=1; i < n+1; i++)
            {
                input = Console.ReadLine().Split(" ");
                item[i,0] = int.Parse(input[0]); // 아이템 무게
                item[i,1] = int.Parse(input[1]); // 아이템 가치
            }

            // dp tabe 세팅
            int[,] dp_table = new int[n+1,max_weight + 1];
            
            for(int i=0;i<max_weight+1;i++)
            {
                dp_table[0,i] = 0;
            }
            
            for(int i=0;i<n+1;i++)
            {
                dp_table[i,0] = 0;
            }

            // 연산
            for(int i = 1; i < n+1; i++)
            {
                for(int j = 1; j < max_weight+1; j++)
                {
                    if(j >= item[i,0]) 
                    {
                        dp_table[i,j] = Math.Max(dp_table[i-1,j], dp_table[i-1,j-item[i,0]] + item[i,1]);
                    }
                    else
                    {
                        dp_table[i,j] = dp_table[i-1,j];
                    }
                }
            }
            Console.WriteLine(dp_table[n,max_weight]);
        }
    }
}