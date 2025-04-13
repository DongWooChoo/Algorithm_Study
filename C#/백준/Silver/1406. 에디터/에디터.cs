using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            // 테스트 개수, 테스트 맨앞에 문자를 추가하기 위해서 맨 왼쪽에 공백 추가
            string init_text = " " + reader.ReadLine();
            // 명령 수행 개수
            int n = int.Parse(reader.ReadLine());

            LinkedList<char> sentence = new LinkedList<char>(init_text);
            // 커서 위치
            LinkedListNode<char> pointer = sentence.Last; 
            
            for(int i = 0; i < n; i++){
                string[] input = reader.ReadLine().Split();
                // 명령 수행
                Tuple<LinkedList<char>, LinkedListNode<char>> result = RunCommand(sentence, pointer, input);
                sentence = result.Item1;
                pointer = result.Item2;
            }
            string str_sentence = new string(sentence.ToArray());
            // 이전에 문자열 앞에 넣은 공백 제거
            str_sentence =  str_sentence.Length > 1 ? str_sentence.Substring(1) : "";
            writer.WriteLine(str_sentence);
            reader.Close();
            writer.Flush();
            writer.Close();
        }

        // 명령 수행 후 결과를 반환하는 메서드
        static Tuple<LinkedList<char>,LinkedListNode<char>> RunCommand(LinkedList<char> sentence, LinkedListNode<char> pointer, string[] input){
            char command = char.Parse(input[0]);
            char value = ' ';
            // input[1]은 P 명령을 제외하고는 없음
            if(input.Length > 1){
                value = char.Parse(input[1]);
            }
            if(command == 'L'){
                // 커서 위치 왼쪽으로
                if(pointer.Previous != null){
                    pointer = pointer.Previous;
                }
            }
            else if(command == 'D'){
                // 커서 위치 오른쪽으로
                if(pointer.Next != null){
                    pointer = pointer.Next;
                }
            }            
            else if(command == 'B'){
                // 값이 공백이 아닐 경우 제거(공백일 경우 가장 왼쪽값임)
                if(pointer.Value != ' '){
                    LinkedListNode<char> temp_pointer = pointer.Previous;
                    sentence.Remove(pointer);
                    pointer = temp_pointer;
                }
            }           
            else if(command == 'P'){
                // 현재 위치에 값을 넣고 이동
                sentence.AddAfter(pointer, value);
                if(pointer.Next != null){
                    pointer = pointer.Next;
                }
            }
            
            return new Tuple<LinkedList<char>,LinkedListNode<char>>(sentence, pointer);
            
        }
    }
}