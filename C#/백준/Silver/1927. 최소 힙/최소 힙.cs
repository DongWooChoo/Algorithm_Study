using System;
using System.IO;
using System.Collections.Generic;

namespace softeer
{
    class Program
    {
        class PriorityQueue : IComparable<PriorityQueue>
        {
            public int value {get; set;}
            public int counter {get; set;}
            // counter는 중복을 허용하기 위한 수단
            public PriorityQueue(int value, int counter){
                this.value = value;
                this.counter = counter;
            }

            public int CompareTo(PriorityQueue other){
                // 다른 값일 경우 value로 구분
                if(value!= other.value){
                    return value.CompareTo(other.value);
                }
                // 같은 값일 경우 counter로 구분
                else{
                    return counter.CompareTo(other.counter);
                }
            }
        }
        
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            // 우선순위 큐
            SortedSet<PriorityQueue> priority_queue = new SortedSet<PriorityQueue>();
            int counter = 0;
            // 수행 횟수
            int n = int.Parse(reader.ReadLine());
            
            for(int i = 0; i < n; i++){
                // 값
                int value = int.Parse(reader.ReadLine());
                // 값이 0이라면 우선순위 큐 값들 중 가장 작은 값을 출력
                if(value == 0){
                    // 현재 큐에 값이 없다면 0을 출력
                    if(priority_queue.Count == 0){
                        writer.WriteLine(0);
                    }
                    else {
                        // 큐에서 최대값을 찾아서 출력 후 제거
                        var min_value = priority_queue.Min;
                        writer.WriteLine(min_value.value);
                        priority_queue.Remove(min_value);
                    }
                }
                // 값이 0이 아니라면 값을 큐에 삽입
                else {
                    priority_queue.Add(new PriorityQueue(value,counter));
                    counter++;
                }
            }
            
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}