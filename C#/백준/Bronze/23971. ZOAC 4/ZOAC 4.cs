using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]); // 한 줄에 의자 개수
            int w = int.Parse(input[1]); // 줄 개수
            int n = int.Parse(input[2]); // 세로 거리두기 칸 수
            int m = int.Parse(input[3]); // 가로 거리두기 칸 수
            int student_count = 0;
            /*for(int i = 1; i < h + 1; i++){ // 줄마다 반복
                if(n != 0 && i%(n+1)!=1){ //세로 거리두기 칸 수가 0이거나, 해당 줄은 건너뛰어야 하는 경우
                   continue;
                }
                else {
                    for(int j = 1; j < w + 1; j++){ // 가로 거리두기 칸 수가 0이거나, 해당 칸은 건너뛰어야 하는 경우
                        if(m != 0 && j%(m+1)!=1){
                           continue;
                        }
                        else {
                            student_count++;
                        }
                    }
                }
            } 해당 방식으로 진행할 경우 올바르게 답은 구할 수 있지만 시간 초과 발생 */
            
            // 1. (한 줄의 의자 개수 / 가로 거리두기 칸수(+1을 해야함)) 수행
            // 2. 결과를 반올림
            // 3. 세로도 동일하게 진행 후 곱셈을 함으로써 개수 파악
            student_count = (int)Math.Ceiling((double)h / (n+1)) * (int)Math.Ceiling((double)w / (m+1)); 
            
            Console.WriteLine(student_count);
        }
    }
}