using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using static System.Console;
public class Gradebook
{
	private int[,] grades;
	public string CourseName { get; }

	public Gradebook(string name,int[,] gradesArray)
	{
		CourseName = name;
		grades = gradesArray;
	}
	//display a welcome message to the Gradebook user
	public void DisplayMessage()
    {
		//get the name of the course
		WriteLine($"Welcome to the grade book for \n{CourseName}!\n");

    }
	//perform various operations on the data
	public void ProcessGrades()
    {
		//output grades array
		OutputGrades();
		//call methods GetMinimum and GetMaximum
		WriteLine($"\nLowest grade in the grade book is {GetMinimum()}" +
			$"\nHighest grade in the grade book is {GetMaximum()}");

		//output grade distribution chart of all grades on all test
		OutputBarChart();
    }
	//find the mimum grade
	public int GetMinimum()
    {
		//assume first element of grades array is smallest
		var lowGrade = grades[0, 0];
		foreach (var grade in grades)
        {
            //if grade less than lowGrade, asign it to lowGrade
            if (grade<lowGrade)
            {
				lowGrade = grade;
            }
        }
		//return lowest grade
		return lowGrade;
    }
	//find maximum grade
	public int GetMaximum()
    {
		//assume first element of grads array is largest
		var highGrade = grades[0, 0];
        foreach (var grade in grades)
        {
            //if grade greater than highGrade, assign it to highGrade
            if (grade>highGrade)
            {
				highGrade = grade;
            }
        }
		//highest grade
		return highGrade;
    }
	//determine average grade for particular student
	public double GetAverage(int student)
    {
		//get the number of grades per student
		var gradeCount = grades.GetLength(1);
		var total = 0.0; // initializ total

        //sum grades for one student
        for (int exam = 0; exam < gradeCount; ++exam)
        {
			total += grades[student, exam];
        }
		return total / gradeCount;
    }
	//outp bar chart displaying overall grade distribution
	public void OutputBarChart()
    {
		WriteLine("Overall grade distribution:");

		//store frequency of grades in each range of 10 grades
		var frequency = new int[11];

        //for each grade in GradeBook, increment the appropriate frequency
        foreach (var grade in grades)
        {
			++frequency[grade / 10];
        }
        //for each grade frequency, display bar in chart
        for (int count = 0; count < frequency.Length; ++count)
        {
            //output bar lable("00-09:",..., "90-99: ", "100: ")
            if (count ==10)
            {
				Write("   100: ");
            }
            else
            {
				Write($"{count * 10:D2}-{count * 10 + 9:D2}: ");
            }

            //display bar of asterisks
            for (int stars = 0; stars < frequency[count]; ++stars)
            {
				Console.Write("*");
            }
			WriteLine();
        }
    }
	//ouput the contents of the grads array
	public void OutputGrades()
    {
		WriteLine("The grades are:\n");
		Console.Write("        ");

        //create a column heading for each of the tests
        for (int test = 0; test < grades.GetLength(1); ++test)
        {
			Write($"Test{test + 1}   ");
        }
		WriteLine("Average");
        //create rows/colums of test representing array grades
        for (int student = 0; student < grades.GetLength(0); ++student)
        {
            Write($"Student {student + 1,2 }");
            //output student's grades
            for (int grade = 0; grade < grades.GetLength(1); ++grade)
            {
                Write($"{grades[student, grade],8}");
            }
            //call method GetAverage to calculate student's average grade
            //pass row number as the argument to GetAverage
            WriteLine($"{GetAverage(student),9:F}");
        }
    }
}
