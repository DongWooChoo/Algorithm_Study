using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace softeer
{
    class Program
    {
        // 사용할 그래프
        static Dictionary<int,List<int>> graph = new Dictionary<int,List<int>>();

        static void insertLine(int start, int end){
            // 기존에 해당 정점이 들어 있을 경우
            if(!graph.ContainsKey(start)){
                graph.Add(start, new List<int>{end});
            }
            else {
                graph[start].Add(end);
            }
            // 양방향이니 반대도 진행
            if(!graph.ContainsKey(end)){
                graph.Add(end, new List<int>{start});
            }
            else {
                graph[end].Add(start);
            }
        }
        
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            
            string[] input = reader.ReadLine().Split();
            // 정점 개수
            int n = int.Parse(input[0]);
            // 간선 개수
            int m = int.Parse(input[1]);
            // 시작 정점
            int v = int.Parse(input[2]);

            for(int i = 0; i < m; i++){
                // 간선을 그래프에 추가
                input = reader.ReadLine().Split();
                int start = int.Parse(input[0]);
                int end = int.Parse(input[1]);
                insertLine(start, end);
            }

            printDFS(v, writer);
            writer.WriteLine();
            printBFS(v, writer);
            
            /* 출력 테스트
            foreach (KeyValuePair<int, List<int>> kvp in graph ){
                for(int i = 0; i < kvp.Value.Count; i++){
                    writer.WriteLine(kvp.Key + " : " + kvp.Value[i]);
                }
            }*/
            reader.Close();
            writer.Flush();
            writer.Close();
        }

        // DFS 출력
        static void printDFS(int start_v, StreamWriter writer){
            Stack<int> dfs_stack = new Stack<int>();
            HashSet<int> is_visited = new HashSet<int>(); //HashSet 사용시 조회에 빠름
            dfs_stack.Push(start_v);
            // 스택이 빌 때까지 반복
            while(dfs_stack.Count >= 1){
                // 값 출력
                int v = dfs_stack.Pop();
                if(!is_visited.Contains(v)){
                    writer.Write(v + " ");
                    is_visited.Add(v);
                    // 내림차순으로 정렬 해야 작은 값부터 방문(4, 3, 2 순으로 들어가야지 2가 먼저 나옴)
                    if(graph.ContainsKey(v)){
                        foreach(int i in graph[v].OrderByDescending(num => num))
                        {
                            if(!is_visited.Contains(i)){
                                dfs_stack.Push(i);
                            }
                        }
                    }
                }
            }
        }

        // BFS 출력
        static void printBFS(int start_v, StreamWriter writer){
            Queue<int> bfs_queue = new Queue<int>();
            HashSet<int> is_visited = new HashSet<int>();
            bfs_queue.Enqueue(start_v);
            // 큐가 빌 때까지 반복
            while(bfs_queue.Count >= 1){
                // 출력
                int v = bfs_queue.Dequeue();
                if(!is_visited.Contains(v)){
                     is_visited.Add(v);
                }
                writer.Write(v + " ");
                // 오름차순으로 방문
                if(graph.ContainsKey(v)){
                    foreach(int i in graph[v].OrderBy(num => num))
                    {
                        if(!is_visited.Contains(i)){
                            bfs_queue.Enqueue(i);
                            is_visited.Add(i);
                        }
                    }
                }
            }
        }
    }
}