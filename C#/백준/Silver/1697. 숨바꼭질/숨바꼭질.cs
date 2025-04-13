using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace softeer
{
    
    class Program
    {
        static int n;
        static int k;
        static int[] distance = new int[100001];
        static bool[] visited = new bool[100001];

        static void BFS(){
            Queue<int> queue = new Queue<int>();
            // 초기위치 = 수빈의 위치
            queue.Enqueue(n);
            distance[n] = 0;
            visited[n] = true;
            while(queue.Count >= 1){
                int current_pos = queue.Dequeue();
                // 동생을 찾았으면 중단
                if(current_pos == k){
                    return;
                }
                int next_pos = -1;
                for(int i = 0; i < 3; i++){
                    if(i==0){
                        // 앞으로 한칸 이동
                        next_pos = current_pos + 1;
                    }
                    else if(i==1){
                        // 뒤로 한칸 이동
                        next_pos = current_pos - 1;  
                    }
                    else {
                        // 순간 이동
                        next_pos = 2 * current_pos;                         
                    }
                    // 범위를 벗어나지 않을 경우
                    if(next_pos >= 0 && next_pos <= 100000) {
                        if(visited[next_pos] == false){
                            distance[next_pos] = distance[current_pos] + 1;
                            visited[next_pos] = true;
                            queue.Enqueue(next_pos);
                        }
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            string[] input = reader.ReadLine().Split();
            // 수빈이의 위치
            n = int.Parse(input[0]);
            // 동생의 위치
            k = int.Parse(input[1]);
            
            BFS();
            
            /* 출력
            for(int i = 0; i < 30; i++){
                writer.WriteLine(i + " " + distance[i]);
            }
            */
            writer.WriteLine(distance[k]);
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}