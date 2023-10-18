using System;

class Program
{
    static void Main()
    {
        int numStudents = 5;    // Количество студентов
        int numSubjects = 3;    // Количество предметов
        int numGrades = 4;      // Количество оценок для каждого предмета

        int[,,] gradeBook = new int[numStudents, numSubjects, numGrades];

        // Задаем оценки
        gradeBook = new int[,,]
        {
            { { 4, 5, 3, 4 }, { 3, 4, 5, 4 }, { 5, 4, 3, 3 } },
            { { 4, 5, 4, 3 }, { 3, 3, 4, 4 }, { 5, 4, 5, 3 } },
            { { 5, 5, 4, 4 }, { 3, 4, 4, 4 }, { 4, 5, 5, 5 } },
            { { 3, 4, 3, 2 }, { 2, 3, 3, 4 }, { 3, 4, 2, 2 } },
            { { 5, 5, 4, 5 }, { 4, 5, 5, 5 }, { 5, 5, 5, 5 } }
        };

        while (true)
        {
            Console.Write("Введите ID ученика (или 0 для выхода): ");
            int studentId = int.Parse(Console.ReadLine());

            if (studentId == 0)
            {
                break;
            }

            bool found = false;
            for (int student = 0; student < numStudents; student++)
            {
                if (studentId == student + 1)
                {
                    Console.WriteLine($"Информация об ученике с ID {studentId}:");

                    for (int subject = 0; subject < numSubjects; subject++)
                    {
                        Console.WriteLine($"Предмет {subject + 1}:");

                        for (int grade = 0; grade < numGrades; grade++)
                        {
                            int currentGrade = gradeBook[student, subject, grade];
                            Console.WriteLine($"Оценка {grade + 1}: {currentGrade}");
                        }

                        float average = CalculateAverage(gradeBook, student, subject, numGrades);
                        Console.WriteLine($"Средняя оценка по предмету: {average:F2}");
                    }

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Ученик с ID {studentId} не найден.");
            }
        }
    }

    static float CalculateAverage(int[,,] gradeBook, int student, int subject, int numGrades)
    {
        float sum = 0;
        for (int grade = 0; grade < numGrades; grade++)
        {
            sum += gradeBook[student, subject, grade];
        }
        return sum / numGrades;
    }
}
