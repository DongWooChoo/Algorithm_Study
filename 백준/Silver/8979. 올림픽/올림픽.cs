using System;
using System.IO;
using System.Collections.Generic;

namespace softeer
{
    struct Medal {
        public int country_idx {get; set;}
        public int gold_medal {get; set;}
        public int silver_medal {get; set;}
        public int bronze_medal {get; set;}
        public int rank {get; set;}

        public Medal(int country_idx, int gold_medal, int silver_medal, int bronze_medal ,int rank){
            this.country_idx = country_idx;
            this.gold_medal = gold_medal;
            this.silver_medal = silver_medal;
            this.bronze_medal = bronze_medal;
            this.rank = rank;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            String[] input = reader.ReadLine().Split();
            // 월드컵 참가국의 수
            int n = int.Parse(input[0]);
            // 순위를 알고싶은 국가 번호
            int find_country_idx = int.Parse(input[1]);

            // 각 국가별 메달 정보를 저장하는 리스트
            List<Medal> medals = new List<Medal>(); 
            for(int i = 0; i < n; i++){
                input = reader.ReadLine().Split();
                int country_idx = int.Parse(input[0]);
                int gold_medal = int.Parse(input[1]);
                int silver_medal = int.Parse(input[2]);
                int bronze_medal = int.Parse(input[3]);
                medals.Add(new Medal(country_idx, gold_medal, silver_medal, bronze_medal, i + 1));
            }

            for(int i = 0; i < n; i++){
                for(int j = i + 1; j < n; j++){
                    // 현재 medal 객체
                    Medal i_medal = medals[i];
                    int i_gold_medal = i_medal.gold_medal;
                    int i_silver_medal = i_medal.silver_medal;
                    int i_bronze_medal = i_medal.bronze_medal;     
                    // 이후의 medal 객체
                    Medal j_medal = medals[j];
                    int j_gold_medal = j_medal.gold_medal;
                    int j_silver_medal = j_medal.silver_medal;
                    int j_bronze_medal = j_medal.bronze_medal;  

                    // 금메달 개수가 적다면 등수 교환
                    if(i_gold_medal < j_gold_medal){
                        medals = changeRank(medals, i, j);
                    }
                    // 금메달 개수가 같다면 은메달 비교
                    else if(i_gold_medal == j_gold_medal){
                        // 은메달 개수가 적다면 등수 교환
                        if(i_silver_medal < j_silver_medal){
                            medals = changeRank(medals, i, j);
                        }
                        // 은메달 개수가 같다면 동메달 비교
                        else if(i_silver_medal == j_silver_medal){
                            // 동메달 개수가 적다면 등수 교환
                            if(i_bronze_medal < j_bronze_medal){
                                medals = changeRank(medals, i, j);
                            }
                            // 동메달 개수가 같다면 동순위
                            else if(i_bronze_medal == j_bronze_medal){
                                int i_rank = i_medal.rank;   
                                int j_rank = j_medal.rank;
                                
                                // 순위 변경
                                i_medal.rank = i_rank;
                                j_medal.rank = i_rank;
                    
                                medals[j] = i_medal;
                                medals[i] = j_medal;
                            }
                        }
                    }
                }
            }
            
            for(int i = 0; i < n; i++){
                Medal medal = medals[i];
                //writer.WriteLine(medal.country_idx + " " + medal.gold_medal + " " + medal.silver_medal + " " + medal.bronze_medal + " " + medal.rank);
            }
            for(int i = 0; i < n; i++){
                Medal medal = medals[i];
                if(medal.country_idx == find_country_idx){
                    writer.WriteLine(medal.rank);
                }
            }
            
            reader.Close();
            writer.Flush();
            writer.Close();
        }

        static List<Medal> changeRank(List<Medal> medals, int i, int j){
            Medal i_medal = medals[i];
            int i_rank = i_medal.rank;    
            
            Medal j_medal = medals[j];
            int j_rank = j_medal.rank;

            // 순위 변경
            i_medal.rank = j_rank;
            j_medal.rank = i_rank;

            medals[i] = j_medal;
            medals[j] = i_medal;
            
            return medals;
        }
    }
}