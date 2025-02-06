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

            String[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]);  // 점수 개수
            int taesu_score = int.Parse(input[1]);  // 태수의 점수
            int p = int.Parse(input[2]);  // 랭킹 리스트 크기

            // 랭킹 리스트가 비어있다면 태수는 1등
            if (n == 0) {
                writer.WriteLine("1");
                reader.Close();
                writer.Flush();
                writer.Close();
                return;
            }

            List<int> score_list = new List<int>();
            input = reader.ReadLine().Split();

            for (int i = 0; i < n; i++) {
                score_list.Add(int.Parse(input[i]));
            }

            int rank = 1;
            bool canBeRanked = false;

            // 태수 점수가 현재 랭킹에서 몇 번째에 위치할지 확인
            for (int i = 0; i < n; i++) {
                if (score_list[i] > taesu_score) {
                    rank++;
                } else if (score_list[i] == taesu_score) {
                    if (i + 1 >= p) {  // 동점일 경우에도 랭킹 제한 확인
                        rank = -1;
                        break;
                    }
                } else {
                    canBeRanked = true;
                    break;
                }
            }

            // 랭킹 리스트가 꽉 차 있고, 태수 점수가 가장 낮은 점수보다 낮거나 같다면 랭크 불가능
            if (n >= p && taesu_score <= score_list[n - 1]) {
                rank = -1;
            }

            writer.WriteLine(rank);
            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}
