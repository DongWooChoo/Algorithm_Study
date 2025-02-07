using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace softeer
{
    class Program
    {
        // 사용할 지도
        static int[,] map;
        // 높이
        static int n;
        // 너비
        static int m;
        static int[,] distance;
        static bool[,] visited;
        static int[,] directions = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

        static void BFS(int x, int y){
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
            queue.Enqueue(new Tuple<int,int>(x,y));
            visited[x,y] = true;
            distance[x,y] = 0;

            while(queue.Count >= 1){
                Tuple<int,int> pos = queue.Dequeue();
                // 현재 위치
                int current_x = pos.Item1;
                int current_y = pos.Item2;

                for(int i = 0; i < 4; i++){
                    int next_x = current_x + directions[i,0];
                    int next_y = current_y + directions[i,1];
                    // 다음 위치가 지도 내에 위치해야함
                    if(next_x >= 0 && next_y >= 0 && next_x < n && next_y < m){
                        if(visited[next_x, next_y] == false && map[next_x, next_y] == 1){
                            queue.Enqueue(new Tuple<int, int>(next_x, next_y));
                            visited[next_x, next_y] = true;
                            // 현재 거리에서 + 1
                            distance[next_x, next_y] = distance[current_x, current_y] + 1;
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
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);

            map = new int[n,m];
            distance = new int[n,m];
            visited = new bool[n,m];
            
            // 시작점
            int x = -1;
            int y = -1;
            
            for(int i = 0; i < n; i++){
                int[] row = reader.ReadLine().Split().Select(int.Parse).ToArray();{
                    for(int j = 0; j < m; j++){
                        // 만약 값이 2라면 이는 시작지점
                        if(row[j] == 2){
                            x = i;
                            y = j;
                        }
                        // 갈 수 있는 길
                        else if (row[j] == 1) {
                            map[i, j] = row[j];
                            distance[i, j] = -1;
                        }
                        // 갈 수 없는 길
                        else {
                            map[i, j] = row[j];
                            distance[i, j] = 0;
                        }
                    }
                }
            }
            
            BFS(x,y);
            
            for(int i = 0; i < n; i++){
                for(int j = 0; j < m; j++){
                    writer.Write(distance[i,j] + " ");
                }
                writer.WriteLine();
            }
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}