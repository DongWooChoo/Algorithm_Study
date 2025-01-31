using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace softeer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            {
                StringBuilder output = new StringBuilder();
                HashSet<int> s = new HashSet<int>(); // 중복 제거 & 빠른 검색

                int n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] input = reader.ReadLine().Split();
                    string command = input[0];
                    int value = 0;

                    if (input.Length > 1)
                    {
                        value = int.Parse(input[1]);
                    }

                    RunCommand(s, command, value, output);
                }

                Console.Write(output.ToString());
            }
        }

        static void RunCommand(HashSet<int> s, string command, int value, StringBuilder output)
        {
            if (command == "add")
            {
                s.Add(value); // 중복 없이 추가
            }
            else if (command == "check")
            {
                output.AppendLine(s.Contains(value) ? "1" : "0");
            }
            else if (command == "remove")
            {
                s.Remove(value);
            }
            else if (command == "toggle")
            {
                if (s.Contains(value))
                    s.Remove(value);
                else
                    s.Add(value);
            }
            else if (command == "all")
            {
                s.Clear();
                for (int i = 1; i <= 20; i++) // 1~20까지 저장
                {
                    s.Add(i);
                }
            }
            else if (command == "empty")
            {
                s.Clear();
            }
        }
    }
}
