using System;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true) {
                string[] input = Console.ReadLine().Split(' ');
                int line1 = int.Parse(input[0]);
                int line2 = int.Parse(input[1]);
                int line3 = int.Parse(input[2]);
                // 마지막 값은 0, 0, 0이며 이 경우 수행하지 않고 종료
                if (line1 == 0 && line2 == 0 && line3 == 0){
                    break;
                }
                string result = getTriangleType(line1, line2, line3);
                Console.WriteLine(result);
            }
        }

        // 삼각형의 유형을 반환하는 메서드
        static string getTriangleType(int line1, int line2, int line3){

            string result = "";
            
            // 삼각형 여부 파악
            bool isTriangle = checkIsTriangle(line1, line2, line3);
            if(isTriangle == false){
                result = "Invalid";
            }
            
            // 정삼각형의 경우
            else if(line1 == line2 && line1 == line3 && line2 == line3){
                result = "Equilateral";
            }
            
            // 이등변 삼각형의 경우
            else if(line1 == line2 || line1 == line3 || line2 == line3){
                result = "Isosceles";
            }
            
            // 이외의 삼각형의 경우
            else {
                result = "Scalene";
            }

            return result;
        }

        // 삼각형 여부를 검사하는 메서드
        static bool checkIsTriangle(int line1, int line2, int line3){
            
            int []lines = { line1, line2, line3};
            // 정렬 수행
            Array.Sort(lines);

            // 가장 긴변의 길이보다 나머지 두 변의 합이 더 커야함
            if(lines[2] < lines[1] + lines[0]) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}