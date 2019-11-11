using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Course_planning
{
    class Program
    {
        static void Main(string[] args)
        {
     
            string text = Console.ReadLine();
            string[] splittedWords = text.Split(", ");
            List<string> splittedLessons = new List<string>(splittedWords);
            Console.WriteLine(string.Join(" ", splittedLessons));

            //while
            bool isBreak = true;
            string lessonTitle = "";
            int lessonIdx = 0;

            while (isBreak)
            {
                string fullCommand = Console.ReadLine();

                List<string> splittedCommand = new List<string>(fullCommand.Split(':'));

                string command = splittedCommand[0];

                if (fullCommand != "course start")
                {
                    lessonTitle = splittedCommand[1];
                    lessonIdx = splittedCommand.IndexOf(lessonTitle);
                }

                if (command == "course start")
                {
                    isBreak = false;
                }
                else if (command == "Add")
                {
                    if (splittedLessons.Contains(lessonTitle) == false)
                    {
                        splittedLessons.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    if (splittedLessons.Contains(lessonTitle) == false)
                    {
                        int insertionIdx = int.Parse(splittedCommand[2]);

                        splittedLessons.Insert(insertionIdx, lessonTitle);
                    }
                }
                else if (command == "Remove")
                {
                    if (splittedLessons.Contains(lessonTitle) == true)
                    {
                        splittedLessons.Remove(lessonTitle);
                        if (splittedLessons.Contains(lessonTitle + "-Exercise") == true)
                        {
                            splittedLessons.Remove(lessonTitle + "-Exercise");
                        }
                    }
                }
                else if (command == "Swap")
                {
                    string swapLesson1 = lessonTitle;
                    string swapLesson2 = splittedCommand[2];

                    if (splittedLessons.Contains(swapLesson1) == true && splittedLessons.Contains(swapLesson2) == true)
                    {
                        int swapLesson1Idx = splittedLessons.IndexOf(swapLesson1);
                        int swapLesson2Idx = splittedLessons.IndexOf(swapLesson2);

                        string temp = splittedLessons[swapLesson1Idx];
                        splittedLessons[swapLesson1Idx] = splittedLessons[swapLesson2Idx];
                        splittedLessons[swapLesson2Idx] = temp;

                        if (splittedLessons.Contains(swapLesson1 + "-Exercise") == true)
                        {
                            splittedLessons.Remove(swapLesson1 + "-Exercise");
                            splittedLessons.Insert(swapLesson1Idx + 1, swapLesson1 + "-Exercise");
                        }

                        if (splittedLessons.Contains(swapLesson2 + "-Exercise") == true)
                        {
                            swapLesson2Idx = splittedLessons.IndexOf(swapLesson2);
                            splittedLessons.Remove(swapLesson2 + "-Exercise");
                            splittedLessons.Insert(swapLesson2Idx + 1, swapLesson2 + "-Exercise");
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    if (splittedLessons.Contains(lessonTitle) == false)
                    {
                        splittedLessons.Add(lessonTitle);
                        splittedLessons.Add(lessonTitle + "-Exercise");
                    }
                    if (splittedLessons.Contains(lessonTitle) == true && splittedLessons.Contains(lessonTitle + "-Exercise") == false)
                    {
                        int idxOfLesson = splittedLessons.IndexOf(lessonTitle);
                        int idxOfExercise = idxOfLesson + 1;

                        splittedLessons.Insert(idxOfExercise, lessonTitle + "- Exercise");
                    }
                }
            }
            foreach (var lesson in splittedLessons)
            {
                Console.WriteLine($"{splittedLessons.IndexOf(lesson) + 1}.{lesson}");
            }
        }
    }
}
