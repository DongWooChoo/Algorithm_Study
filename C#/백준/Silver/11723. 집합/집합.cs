using System;
using System.IO;
using System.Text;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StringBuilder output = new StringBuilder();
            int bit_set = 0;
            // 연산의 수
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++){
                string[] input = reader.ReadLine().Split();
                // 명령어
                string command = input[0];
                // 값
                int value = 0;
                if(input.Length > 1) {
                    value = int.Parse(input[1]) - 1;
                }
                bit_set = RunCommand(bit_set, command, value, output);
            }
            Console.Write(output.ToString());
        }
        
        static int RunCommand(int bit_set, string command, int value, StringBuilder output){
            // 비트셋에 값 추가
            if(command == "add"){
                bit_set |= (1 << value);
            }
            // 비트셋에 해당 값이 존재하는지 검사
            else if(command == "check"){
                output.AppendLine(((bit_set & (1 << value)) != 0) ? "1" : "0");
            }
            // 비트셋에 존재하는 해당 값 삭제
            else if(command == "remove"){
                bit_set &= ~(1 << value);
            }
            // 비트셋에 해당 값이 0이면 1, 1이면 0으로 변환
            else if(command == "toggle"){
                bit_set ^= (1 << value);
            }
            // 전체 값 추가
            else if(command == "all"){
                bit_set = (1 << 20) - 1;
            }
            // 전체 값 삭제
            else if(command == "empty"){
                 bit_set = 0;
            }
            return bit_set;
        }
        
        /* 해당 코드로 진행시 시간 초과 문제가 발생 -> 비트마스킹으로 해결 -> StringBuilder로 구현시 성공
        static List<int> RunCommand(List<int> s, string command, int value,  StringBuilder output){
            // 리스트에 값 추가
            if(command == "add"){
                s.Add(value);
            }
            // 리스트에 해당 값이 존재하는지 검사
            else if(command == "check"){
                output.AppendLine(s.Contains(value) ? "1" : "0");
            }
            // 리스트에 존재하는 해당 값 삭제
            else if(command == "remove"){
                s.Remove(value);
            }
            // 리스트에 해당 값이 0이면 1, 1이면 0으로 변환
            else if(command == "toggle"){
                if(s.Contains(value) == true){
                    s.Remove(value); 
                }
                else {
                    s.Add(value);
                }
            }
            // 전체 값 추가
            else if(command == "all"){
                s.Clear();
                for(int i = 0; i <= 20; i++){
                    s.Add(value);
                }
            }
            // 전체 값 삭제
            else if(command == "empty"){
                s.Clear();
            }
            return s;
        }
        */
    }
}