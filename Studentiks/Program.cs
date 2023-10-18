using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создатели гос услуг не представляют...Какая у меня программа!");
        //типо это кусок БД и айди идёт оттуда(вдруг у них ученик ушёл, а привязки по айди, тогда всё поплывёт).
        int[,] ozenochki = new int[,]
        {
           /*{1,5,3,4,5,3,2,4,5,4,2,3,4},
           {2,3,4,3,2,3,4,5,4,3,4,5,3 },
           {3,5,5,5,5,5,5,5,5,5,5,5,5 }*/
           {1,5,5,3,4 },
           {2,1,2,3,4 },
           {3,2,2,2,2 }
        };


        List<string> names = new List<string> { "Майнкрафтер", "Дотер", "Мирослав", "МаксимЗаброцкий", "ЕгоВеличествоМаслов" };
        int fornames = ozenochki.GetLength(0);
        Random random = new Random();

        List<string> names2 = new List<string> { };

        for (int i = 0; i < 3; i++)
        {
            int index = random.Next(names.Count); 
            names2.Add(names[index]); 
        }

        


        while (true)
        {
            int what = 0;
            
            Console.WriteLine("\n1 - Вывод всех оценок. \n2 - Вывод всех средних. \n3 - Вывод оценок ученика по предметам и среднего для ученика по его айди.");
            Console.Write("Ввод: ");
            what = int.Parse(Console.ReadLine());
            Console.Clear();
            PrintStudentData(what, ozenochki,names2);
        }
    }

    static void PrintStudentData(int what, int[,] ozenochki,List<string>names2)
    {
        if (what == 1)
        {
            for (int i = 0; i < ozenochki.GetLength(0); i++)
            {
                int studentId = ozenochki[i, 0];

                Console.Write($"{names2[i]} ID:{i+1} оценки: ");
                for (int j = 1; j < ozenochki.GetLength(1); j++)
                {
                    Console.Write($"{ozenochki[i, j]} ");
                }
                Console.WriteLine("\n");
            }
        }
        else if (what == 2)
        {
            for (int i = 0; i < ozenochki.GetLength(0); i++)
            {
                int studentId = ozenochki[i, 0]; // для айдишника
                float srznach = 0;

                for (int j = 1; j < ozenochki.GetLength(1); j++)
                {
                    srznach += ozenochki[i, j];
                }

                srznach /= ozenochki.GetLength(1) - 1; //убрал из расчёта айди
                Console.WriteLine($"Средняя оценка для ученика с ID {studentId}: {srznach:F2}");
            }
        }
        else if (what == 3)
        {
            Console.Write("Введите ID ученика: ");
            int searchId = int.Parse(Console.ReadLine());
            bool found = false;
            for (int i = 0; i < ozenochki.GetLength(0); i++)
            {
                int studentId = ozenochki[i, 0]; 
                if (studentId == searchId)
                {
                    Console.WriteLine($"Информация об ученике {names2[i]} с ID {studentId}:");
                    float srznach = 0;
                    for (int j = 1; j < ozenochki.GetLength(1); j++)
                    {
                        Console.WriteLine($"Предмет {j}: {ozenochki[i, j]}");
                        srznach += ozenochki[i, j];
                    }

                    srznach /= ozenochki.GetLength(1) - 1; 
                    Console.WriteLine($"Средняя оценка: {srznach:F2}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Ученик с ID {searchId} не найден.");
            }
        }
    }
}