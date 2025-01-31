using System;
using System.Collections.Generic;
namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char,int> alphabet_count = new Dictionary<char,int>();
            for (int i = 0; i < input.Length; i++){
                
                char alphabet = Char.ToUpper(input[i]);
                // 기존에 해당 언어가 있었을 경우
                if(alphabet_count.ContainsKey(alphabet)){
                    alphabet_count[alphabet] += 1;
                }
                else {
                    alphabet_count.Add(alphabet, 1);
                }
            }

            // 최다 사용값 찾기
            int max_used_count = 0;
            foreach(var alphabet in alphabet_count){
                if(max_used_count < alphabet.Value){
                    max_used_count = alphabet.Value;
                }
            }

            // 최다 사용 알파벳 찾기
            char max_used_alphabet = ' ';
            int check_duplicated = 0;
            foreach(var alphabet in alphabet_count){
                if(max_used_count == alphabet.Value){
                    max_used_alphabet = alphabet.Key;
                    check_duplicated++;
                }
            }

            // 결과 출력
            if(check_duplicated != 1){
                Console.WriteLine("?");
            }
            else {
                Console.WriteLine(max_used_alphabet);
            }
        }
    }
}