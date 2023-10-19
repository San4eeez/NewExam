int[][,] jaggedArray3 = new int[3][,]
{
    new int[,]
    {
        {4, 5, 3, 4},
        {4, 5, 4, 3},
        {5, 5, 4, 4},
        {5, 5, 4, 5}
    },

    new int[,]
    {
        {4, 2, 3, 4},
        {2, 2, 3, 3},
        {5, 5, 4, 4},
        {3, 3, 3, 3}
    },

    new int[,]
    {
        {5, 5, 5, 4},
        {4, 5, 5, 3},
        {5, 5, 3, 4},
        {4, 2, 4, 5}
    }
};

while (true)
{
    Console.Write("Введите номер ученика: ");
    int studentNumber = int.Parse(Console.ReadLine()) - 1;
    rabota(studentNumber, jaggedArray3);


}
static void rabota(int studentNumber, int[][,] jaggedArray3)
{


    Console.Clear();
    Console.WriteLine($"Оценки для Ученика {studentNumber + 1}:");
    for (int subject = 0; subject < jaggedArray3.Length; subject++)
    {
        Console.Write($"Предмет {subject + 1} оценки: ");
        int sum = 0;
        for (int mark = 0; mark < jaggedArray3[subject].GetLength(1); mark++)
        {
            int markValue = jaggedArray3[subject][studentNumber, mark];
            sum += markValue;
            Console.Write($"{markValue} ");
        }
        double average = (double)sum / jaggedArray3[subject].GetLength(1);
        Console.WriteLine($"средняя оценка: {average:F2}");
    }

}