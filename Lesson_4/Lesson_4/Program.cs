using System;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //  препятствия : (2;3); (4;5)
            // Зарание известны заблокированные поля:
           

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(Routes(i, j).ToString()+ " ");

                Console.WriteLine();
            }
        }
       public static int[] Yblock = { 2, 3 };// можно ещё задать random, если пользователь по коду не знает, какие поля заблокированы
       public static int[] Xblock = { 2, 1 };
        // ищем для каждой клетки кол-во маршрутов
        public static int Routes(int x, int y)
        {
            if (x == 0 || y == 0)
                return 1;
            else
            {
                for (int i = 0; i < Yblock.Length; i++)
                {
                    if (x == Xblock[i] && y == Yblock[i])
                        return 0;// поле заблокированно;\
                }
                return Routes(x, y - 1) + Routes(x - 1, y);
            }
       }
    }
}
