using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> scheduleList = Console.ReadLine().Split(", ").ToList();
            string input;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] inputArray = input.Split(":");

                switch (inputArray[0])
                {
                    case "Add":
                        string lessontTitleAdd = inputArray[1];
                        scheduleList = ListAddLesonTitle(scheduleList, lessontTitleAdd);
                        break;

                    case "Insert":
                        string lessontTitleInsert = inputArray[1];
                        int indexInsert = int.Parse(inputArray[2]);
                        scheduleList = InsertLessonTitleAtIndex(scheduleList, lessontTitleInsert, indexInsert);
                        break;

                    case "Remove":
                        string lessonTitleRemove = inputArray[1];
                        scheduleList = RemoveLessonTitle(scheduleList, lessonTitleRemove);
                        break;

                    case "Swap":
                        string lessonTitleSwapOne = inputArray[1];
                        string lessonTitleSwapTwo = inputArray[2];
                        scheduleList = SwapLessonTitle(scheduleList, lessonTitleSwapOne, lessonTitleSwapTwo);
                        break;

                    case "Exercise":
                        string exerciseAdd = inputArray[1];
                        scheduleList = ExerciseAddToList(scheduleList, exerciseAdd);
                        break;
                }


            }

            if(input=="course start")
            {
                for (int i = 0; i < scheduleList.Count; i++)
                {
                    Console.WriteLine($"{i+1}.{scheduleList[i]}");
                }
            }
//            •	Print the whole course schedule, each lesson on a new line with its number(index) in the schedule: 
//"{lesson index}.{lessonTitle}"


        }

        static List<string> ExerciseAddToList(List<string> scheduleList, string exerciseAdd)
        {
            //Exercise: { lessonTitle} – add Exercise in the schedule right after the lesson index,
            //        if the lesson exists and there is no exercise already, in the following format "{lessonTitle}-Exercise".
            //        If the lesson doesn`t exist, add the lesson at the end of the course schedule, followed by the Exercise.

            string ifExistExercuse = $"{exerciseAdd}-Exercise";

        

            if(!scheduleList.Contains(exerciseAdd))
            {
                scheduleList.Add(exerciseAdd);
                scheduleList.Add(ifExistExercuse);
            }
            else if (scheduleList.Contains(exerciseAdd) && !scheduleList.Contains(ifExistExercuse))
            {
                int indexOfExercise = scheduleList.IndexOf(exerciseAdd);
                scheduleList.Insert(indexOfExercise + 1, ifExistExercuse);

            }

            return scheduleList;
        }

        static List<string> SwapLessonTitle(List<string> scheduleList, string lessonTitleSwapOne, string lessonTitleSwapTwo)
        {
            bool swapComplete = false;

            //	Swap: { lessonTitle}:{ lessonTitle} – swap the position of the two lessons, if they exist.
            if (scheduleList.Contains(lessonTitleSwapOne) && scheduleList.Contains(lessonTitleSwapTwo))
            {
                int indexOfOne = scheduleList.IndexOf(lessonTitleSwapOne);
                int indexOfTwo = scheduleList.IndexOf(lessonTitleSwapTwo);

                string tempLessonTitle = scheduleList[indexOfOne];
                scheduleList[indexOfOne] = scheduleList[indexOfTwo];
                scheduleList[indexOfTwo] = tempLessonTitle;
                swapComplete = true;
            }

            string tempExerciseSwapOne = $"{lessonTitleSwapTwo}-Exercise";
            string tempExerciseSwapTwo = $"{lessonTitleSwapOne}-Exercise";

            if (swapComplete)
            {
                if (scheduleList.Contains(tempExerciseSwapOne))
                {
                    int indexOfOne = scheduleList.IndexOf(lessonTitleSwapTwo);
                    int indexOfExercise = scheduleList.IndexOf(tempExerciseSwapOne);
                    string tempExercise = scheduleList[indexOfExercise];
                  

                    scheduleList.Insert(indexOfOne+1, tempExercise);
                    scheduleList.RemoveAt(indexOfExercise+1);


                }
                if (scheduleList.Contains(tempExerciseSwapTwo))
                {
                
                    int indexOfTwo = scheduleList.IndexOf(lessonTitleSwapOne);
                    int indexOfExercise = scheduleList.IndexOf(tempExerciseSwapTwo);
                    string tempExercise = scheduleList[indexOfExercise];

                    scheduleList.Insert(indexOfTwo + 1, tempExercise);
                    scheduleList.RemoveAt(indexOfExercise+1);

                }
            }


            return scheduleList;
        }

        static List<string> RemoveLessonTitle(List<string> scheduleList, string lessonTitleRemove)
        {
            //	Remove: { lessonTitle}  – remove the lesson, if it exists.
            string tempExercise = $"{lessonTitleRemove}-Exercise";

            if (scheduleList.Contains(lessonTitleRemove))
            {
                int indexAt = scheduleList.IndexOf(lessonTitleRemove);
                if (indexAt != -1)
                {
                    scheduleList.Remove(lessonTitleRemove);
                }
            }    
            
            if (scheduleList.Contains(tempExercise))
            {
                int indexAt = scheduleList.IndexOf(tempExercise);
                if (indexAt != -1)
                {
                    scheduleList.Remove(tempExercise);
                }
            }

            return scheduleList;
        }

        static List<string> InsertLessonTitleAtIndex(List<string> scheduleList, string lessontTitleInsert, int indexInsert)
        {
            //	Insert: { lessonTitle}:{ index} – insert the lesson to the given index, if it does not exist.
            if (!scheduleList.Contains(lessontTitleInsert))
            {
                scheduleList.Insert(indexInsert, lessontTitleInsert);
            }
            return scheduleList;
        }

        static List<string> ListAddLesonTitle(List<string> scheduleList, string lessontTitleAdd)
        {
            if (!scheduleList.Contains(lessontTitleAdd))
            {
                scheduleList.Add(lessontTitleAdd);
            }
            //•	Add:{lessonTitle} – add the lesson to the end of the schedule, if it does not exist.

            return scheduleList;
        }
    }
}
