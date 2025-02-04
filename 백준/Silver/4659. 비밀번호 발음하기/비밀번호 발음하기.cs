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
            while(true){
                String input = reader.ReadLine();
                // 입력 값이 end일 경우 종료
                if(input == "end"){
                    break;
                }

                // 모음 존재 여부
                bool is_exist_mo = false;
                // 현재 글자
                char current_char = ' ';
                // 전 글자
                char before_char = ' ';
                // 전전 글자
                char before_before_char = ' ';
                // 비밀번호 모음, 자임 연속 여부
                bool is_duplicated = false;
                for (int i = 0; i < input.Length; i++){
                    // 전 글자 모음 여부
                    if(i > 0){
                        char before_word = input[i-1];
                        if(before_word == 'a' || before_word == 'e' || before_word == 'i' || before_word == 'o' || before_word == 'u'){
                            before_char = 'm';
                        }
                        else{
                            before_char = 'j';
                        }
                    }
                    // 전전 글자 모음 여부
                    if(i > 1){
                        char before_before_word = input[i-2];
                        if(before_before_word == 'a' || before_before_word == 'e' || before_before_word == 'i' || before_before_word == 'o' || before_before_word == 'u'){
                            before_before_char = 'm';
                        }
                        else{
                            before_before_char = 'j';
                        }
                    }
                    // 모음 존재 여부 검사
                    if(input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u'){
                        is_exist_mo = true;
                        current_char = 'm';
                    }
                    else{
                        current_char = 'j';
                    }
                    // 이전 글자와 중복되면 안됨 단, ee와 oo는 예외
                    if(i > 0 && input[i] == input[i-1] && !((input[i] == 'e' && input[i-1] == 'e') || (input[i] == 'o' && input[i-1] == 'o'))){
                        is_duplicated = true;
                    }
                    // 모음 3번 연속, 자음 3번 연속이면 안됨
                    if(i > 1 && ((current_char == before_char) && (current_char == before_before_char) && (before_char == before_before_char))){
                        is_duplicated = true;
                    }
                    
                }
                // 최소 하나의 모음과 연속된 문자가 사용되지 않았을 경우
                if(is_exist_mo && !is_duplicated){
                    writer.WriteLine("<" + input + ">" + " is acceptable.");
                }
                else {
                    writer.WriteLine("<" + input + ">" + " is not acceptable.");
                }
            }
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}