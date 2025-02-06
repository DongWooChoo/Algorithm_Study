using System;
using System.IO;
using System.Linq;
namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            // 테스트 개수
            int n = int.Parse(reader.ReadLine());

            for(int i = 0; i < n; i++){
                // 날짜 수
                int day = int.Parse(reader.ReadLine());
                // 날짜별 주식 변화
                int[] money = reader.ReadLine().Split().Select(int.Parse).ToArray();
                long max_money = GetMaxMoney(day, money);
                writer.WriteLine(max_money);
            }
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }

        static long GetMaxMoney(int day, int[] money){
            long earn_money = 0;
            int max_money = 0;
            for(int i = money.Length - 1; i >= 0; i--){
                // 더 큰 금액이 나올 경우 가장 큰 금액으로 설정
                if(max_money < money[i]){
                    max_money = money[i];
                }
                // 차액 만큼 플러스
                else {
                    earn_money += max_money - money[i];                    
                }
            }
            return earn_money;
        }
    }
}