using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 돌 개수
            int rock_count = int.Parse(Console.ReadLine());

            // 돌이 1개인 경우 SK(1) 승
            // 돌이 2개인 경우 SK(1) CY(1) 승
            // 돌이 3개인 경우 SK(3) 승
            // 돌이 4개인 경우 SK(3) CY(1) 승 or SK(1) CY(1) SK(1) CY(1) 승
            // 이와 같이 돌의 개수가 홀수인 경우 먼저 시작하는 사람이 이김
            if(rock_count%2 == 1){
                Console.WriteLine("SK");
            }
            else {
                Console.WriteLine("CY");
            }
            
        }
    }
}