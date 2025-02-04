using System;
using System.IO;
using System.Collections.Generic;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            string[] input = reader.ReadLine().Split(); 
            // 사람 수
            int n = int.Parse(input[0]);
            // 게임 유형
            char type = Convert.ToChar(input[1]);
            // 사용자 정보
            HashSet<string> user_list = new HashSet<string>();
            // List로 진행할 경우 시간 초과 발생 O(n)과 O(1)로 큰차이 
            // List<string> user_list = new List<string>();
            
            for(int i = 0; i < n; i++){
                // 사용자 명 입력
                string user_name = reader.ReadLine(); 
                // 사용자 정보에 해당 사용자가 없을 경우 데이터 추가
                if(!user_list.Contains(user_name)){
                    user_list.Add(user_name);
                }
            }

            // 윷놀이라면 최소 2명 필요
            if(type == 'Y'){
                writer.WriteLine(user_list.Count / 1); 
            }
            // 그림 찾기라면 최소 3명 필요
            else if(type == 'F'){
                writer.WriteLine(user_list.Count / 2); 
            }
            // 원카드라면 최소 4명 필요
            else if(type == 'O'){
                writer.WriteLine(user_list.Count / 3); 
            }
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}