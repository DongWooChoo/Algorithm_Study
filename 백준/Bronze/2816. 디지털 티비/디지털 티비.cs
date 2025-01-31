using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 채널 수
            int n = int.Parse(Console.ReadLine());
            // 채널 리스트
            string[] channel_list = new String[n];

            // KBS1 채널 IDX;
            int kbs1_idx = -1;
            // KBS2 채널 IDX
            int kbs2_idx = -1;
            // 현재 채널 IDX
            int current_channel_idx = 0;
            for(int i = 0; i < n; i++){
                string channel_name = Console.ReadLine();
                channel_list[i] = channel_name;
                if(channel_name == "KBS1"){
                    kbs1_idx = i;
                }
                else if(channel_name == "KBS2"){
                    kbs2_idx = i;
                }
            }

            // KBS1 채널보다 KBS2 채널이 위에 존재할 경우, KBS1 채널을 위로 옮김으로써 KBS2 채널의 순서가 한 단계 내려감
            if(kbs1_idx > kbs2_idx){
                kbs2_idx += 1;
            }

            
            // 현재 채널을 KBS1 채널로 이동
            while(current_channel_idx != kbs1_idx){
                current_channel_idx += 1;
                Console.Write("1");
            }

            // KBS1 채널을 위로 이동
            while(kbs1_idx != 0){
                kbs1_idx -= 1;
                current_channel_idx -= 1;
                Console.Write("4");
            }

            
            // 현재 채널을 KBS2 채널로 이동
            while(current_channel_idx != kbs2_idx){
                current_channel_idx += 1;
                Console.Write("1");
            }

            // KBS2 채널을 위로 이동
            while(kbs2_idx != 1){
                kbs2_idx -= 1;
                current_channel_idx -= 1;
                Console.Write("4");
            }
        }
    }
}