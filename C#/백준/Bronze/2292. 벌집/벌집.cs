using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 방 번호
            int room_number = int.Parse(Console.ReadLine());
            // 방 지나간 개수
            int room_through_count = 1;
            // 현재 위치에서 바로 나갈 수 있는 최소 방 번호
            int room_min = 2;
            // 현재 위치에서 바로 나갈 수 있는 최대 방 번호
            int room_max = 7;

            // 시작위치라면 바로 종료
            if(room_number == 1){
                Console.WriteLine(room_through_count);
                return;
            }
            
            while(true){
                room_through_count++;
                
                // 바로 나갈 수 있으면 나감
                if(room_min <= room_number && room_number <= room_max){
                    break;
                }
                // 최소 방 번호, 최대 방 번호 갱신
                // 규칙 : 최소 방 번호 (2, 8, 20와 같이 기존값에서 6의 배수가 증가), 최대 방 번호도 동일
                room_min = room_min + (room_through_count-1) * 6;
                room_max = room_max + (room_through_count) * 6;
            }
            Console.WriteLine(room_through_count);
            return;
        }
    }
}