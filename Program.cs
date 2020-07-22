using System;

namespace Gradebook2
{
    class Program
    {
        static void Main(string[] args)
        {
            //rectangular array of student grades
            int[,] gradesArray =
            {
                {87, 96, 70},
                {68, 87, 90},
                {94, 100, 90},
                {100, 81, 82},
                {83, 65, 85},
                {78, 87, 65},
                {85, 75, 83},
                {91, 94, 100},
                {76, 72, 84},
                {87, 93, 73},
            };

            Gradebook myGradeBook = new Gradebook("CS5 Introduction" +
            "to C++", gradesArray);
            myGradeBook.DisplayMessage();
            myGradeBook.ProcessGrades();
        }
    }
}
