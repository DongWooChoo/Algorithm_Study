using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace softeer
{
    class Program
    {
        class Person
        {
            public int idx { get; set; }
            public int height { get; set; }
            public int weight { get; set; }
            public int rank { get; set; }

            public Person(int idx, int height, int weight)
            {
                this.idx = idx;
                this.height = height;
                this.weight = weight;
                this.rank = 1; // 초기값 설정
            }

        }

        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Console.OpenStandardInput());
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());

            int n = int.Parse(reader.ReadLine());
            List<Person> persons = new List<Person>(n);

            // 입력 데이터 저장
            for (int i = 0; i < n; i++)
            {
                string[] input = reader.ReadLine().Split();
                int weight = int.Parse(input[0]);
                int height = int.Parse(input[1]);
                persons.Add(new Person(i, height, weight));
            }
            
            persons = persons.OrderBy(item => item.height).ToList();
            persons.Reverse();
            for(int i = 0; i < n; i++){
                int gap = 1;
                for(int j = 0; j < i; j++){
                    Person i_person = persons[i]; // 현재 사람
                    Person j_person = persons[j]; // 비교 대상
                    
                    // 만약 앞선 사람보다 키와 덩치가 작다면, 이전 사람의 rank보다 + gap
                    if((i_person.height < j_person.height) && (i_person.weight < j_person.weight)){
                        i_person.rank = i_person.rank + gap;
                    }

                    persons[i] = i_person;
                    persons[j] = j_person;
                }
            }     
            persons = persons.OrderBy(item => item.idx).ToList();
            // 결과 출력
            foreach (Person person in persons)
            {
                writer.Write(person.rank + " ");
            }

            reader.Close();
            writer.Flush();
            writer.Close();
        }
    }
}
