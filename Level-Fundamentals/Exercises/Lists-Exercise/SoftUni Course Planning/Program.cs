using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read list input from the Console
            List<string> courses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] cmdArgs = command.Split(":");

                string currentCommand = cmdArgs[0];

                //Add:{lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
                if (currentCommand == "Add")
                {
                    string courseToAdd = cmdArgs[1];

                    if (courses.Contains(courseToAdd))
                    {
                        continue;
                    }
                    else
                    {
                        courses.Add(courseToAdd);
                    }
                }
                //Insert:{lessonTitle}:{index} – insert the lesson to the given index, if it does not exist.
                else if (currentCommand == "Insert")
                {
                    string courseToInsert = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);

                    if (courses.Contains(courseToInsert))
                    {
                        continue;
                    }
                    else
                    {
                        courses.Insert(index, courseToInsert);
                    }
                }
                //Remove:{lessonTitle} – remove the lesson, if it exists.
                else if (currentCommand == "Remove")
                {
                    string courseToRemove = cmdArgs[1];
                    //Each time you Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons.
                    if (courses.Contains(courseToRemove))
                    {
                        courses.Remove(courseToRemove);
                    }
                    if (courses.Contains(courseToRemove + "-Exercise"))
                    {
                        courses.Remove(courseToRemove + "-Exercise");
                    }
                }
                //Swap:{lessonTitle}:{lessonTitle} – change the place of the two lessons, if they exist.
                else if (currentCommand == "Swap")
                {
                    string firstCourseToSwap = cmdArgs[1];
                    string secondCourseToSwap = cmdArgs[2];
                    int index1 = courses.IndexOf(firstCourseToSwap);
                    int index2 = courses.IndexOf(secondCourseToSwap);

                    if (courses.Contains(firstCourseToSwap) && courses.Contains(secondCourseToSwap))
                    {
                        for (int i = 0; i < courses.Count; i++)
                        {
                            if (courses[i] == firstCourseToSwap)
                            {
                                courses[i] = secondCourseToSwap;
                                continue;
                            }
                            if (courses[i] == secondCourseToSwap)
                            {
                                courses[i] = firstCourseToSwap;
                            }
                        }
                        //or
                        //string currentElement = courses.ElementAt(index1);
                        //courses[index1] = courses[index2];
                        //courses[index2] = currentElement;
                    }
                    if (courses.Contains(firstCourseToSwap + "-Exercise") && courses.Contains(firstCourseToSwap))
                    {
                        index1 = courses.IndexOf(firstCourseToSwap);
                        courses.Remove(firstCourseToSwap + "-Exercise");
                        courses.Insert(index1 + 1, firstCourseToSwap + "-Exercise");
                    }
                    else if (courses.Contains(secondCourseToSwap + "-Exercise") && courses.Contains(secondCourseToSwap))
                    {
                        index2 = courses.IndexOf(secondCourseToSwap);
                        courses.Remove(secondCourseToSwap + "-Exercise");
                        courses.Insert(index2 + 1, secondCourseToSwap + "-Exercise");
                    }

                }

                else if (currentCommand == "Exercise")
                {
                    string exercise = cmdArgs[1];
                    int index = courses.IndexOf(exercise);
                    if (courses.Contains(exercise) && !courses.Contains(exercise + "-Exercise"))
                    {
                        courses.Insert(index + 1, exercise + "-Exercise");
                    }
                    else if (!courses.Contains(exercise))
                    {
                        courses.Add(exercise);
                        courses.Add(exercise + "-Exercise");
                    }
                }
            }
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
