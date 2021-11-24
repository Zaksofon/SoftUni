using System;

namespace Mid_Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int lectures = int.Parse(Console.ReadLine());

            int bonus = int.Parse(Console.ReadLine());

            //{total bonus} = {student attendances} / {course lectures} * (5 + {additional bonus})
            double maxBonus = 0;
            int studentAttendances = 0;

            for (int i = 1; i <= students; i++)
            {
                int attend = int.Parse(Console.ReadLine());

                double currentBonus = (attend * 1.00/ lectures) * (5 + bonus);

                if (currentBonus >= maxBonus)
                {
                    maxBonus = currentBonus;
                    studentAttendances = attend;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendances} lectures.");
        }
    }
}
