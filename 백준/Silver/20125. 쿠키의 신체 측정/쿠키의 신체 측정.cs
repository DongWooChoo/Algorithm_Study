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

            // 길이
            int n = int.Parse(reader.ReadLine());
            
            // head 여부
            bool is_head = true;
            // 심장 위치
            int heart_x = 0;
            int heart_y = 0;
            // 팔 여부
            bool is_arm = true;
            // 팔 위치
            int arm_left = 0;
            int arm_right = 0;
            // 허리 여부
            bool is_body = true;
            // 허리 길이
            int body = 0;
            // 다리 여부
            bool is_leg = true;
            // 다리 길이
            int leg_left = 0;
            int leg_right = 0;
            
            for(int i = 0; i < n; i++){
                string data = reader.ReadLine();
                // 머리 위치 구하기
                if(is_head){
                    for(int j = 0; j < data.Length; j++){
                        // * 가 한곳 나오는데 이곳은 머리, 심장은 머리 바로 아래
                        if(data[j] == '*'){
                            is_head = false;
                            heart_x = j;
                            heart_y = i + 1; 
                        }
                    }
                }
                // 팔 길이 구하기
                else if(is_arm){
                    for(int j = 0; j < data.Length; j++){
                        if(data[j] == '*'){
                            if(j < heart_x){
                                arm_left++;
                            }
                            else if(j > heart_x){
                                arm_right++;
                            }
                        }
                    is_arm = false;
                    }
                }            
                // 허리 길이 구하기
                else if(is_body){
                    if(data[heart_x] == '*'){
                        body++;
                    }
                    else {
                        is_body = false;
                        // 다리 위치이므로 최소 다리 길이 1 추가
                        leg_left++;
                        leg_right++;
                    }
                }
                else if(is_leg){;
                    // 왼쪽 다리는 심장으로부터 한칸 왼쪽
                    if(data[heart_x - 1] == '*'){
                        leg_left++;
                    }                    
                    // 오른쪽 다리는 심장으로부터 한칸 오른쪽
                    if(data[heart_x + 1] == '*'){
                        leg_right++;
                    }
                }
            }

            heart_x++;
            heart_y++;
            writer.WriteLine(heart_y + " " + heart_x);
            writer.WriteLine(arm_left + " " + arm_right + " " + body + " " + leg_left + " " + leg_right);
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}