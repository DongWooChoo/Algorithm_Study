using System;
using System.IO;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            // 테스트 케이스 개수
            int testcase_count = int.Parse(reader.ReadLine());

            for(int i = 0; i < testcase_count; i++){
                // 학생들의 키 정보들을 담는 배열
                int[] students = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                int walk_count = GetWalkCount(students);
                writer.WriteLine(students[0] + " " + walk_count);
            }
            reader.Close();
            writer.Close();
        }

        // 학생들의 키 순서대로 오름차순 정렬 및 이동 걸음 수 반환
        static int GetWalkCount(int[] students){
            int walk_count = 0;
            int[] lines = new int[20];
            for(int i = 0; i < 20; i++){
                lines[i] = students[i+1];
                int find_i = i;
                for(int j = i - 1; j >= 0; j--){
                    // 현재 학생보다 앞에 있는 학생의 키가 큰 경우 위치 바꾸기
                    if(lines[find_i] < lines[j]){
                        int temp = lines[find_i];
                        lines[find_i] = lines[j];
                        lines[j] = temp;
                        walk_count++;
                        find_i--;
                    }
                }
            }
            return walk_count;
        }
    }
}