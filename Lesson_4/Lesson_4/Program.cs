using System;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // задача про короля
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(Routes(i, j).ToString() + " ");

                Console.WriteLine();
            }

            Console.WriteLine();
            
            // БИНАРНЫЙ ПОИСК
            int Length = 10;
            int[] array = new int[Length];
            for (int i = 0; i < Length; i++)
                array[i] = i;

            Console.WriteLine(BinarySearch(array,8,0,array.Length-1));
            
            
            //ЗАДАЧА С РАСПОЛОЖЕНИЕМ КОНЯ
            annull();
            hourse(1);
            printBoard();

        }
        // ЗАДАЧА ПРО МАРШРУТЫ КОРОЛЯ
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
                        return 0;// поле заблокированно;
                }
                return Routes(x, y - 1) + Routes(x - 1, y);
            }
        }

        ///БИНАРНЫЙ ПОИСК
        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }
            var middle = (first + last) / 2;
            var middleValue = array[middle];

            if (middleValue == searchedValue)
                return middle;
            else
            {
                if (middleValue > searchedValue)
                {
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }


        // ЗАДАЧА С КОНЁМ
        public static int boardLength = 8;
        public static int[,] board = new int[boardLength, boardLength];
       
        public static void annull()
        {
            for (int i = 0; i < boardLength; i++)
                for (int j = 0; j < boardLength; j++)
                {
                    board[i, j] = 0;
                }

        }

        public static void printBoard()
        {
            for (int i = 0; i < boardLength; i++)
            {
                for (int j = 0; j < boardLength; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        // проверяет наличие фигуры в клетке
        public static int CheckBoard()
        {
            for (int i = 0; i < boardLength; i++)
                for (int j = 0; j < boardLength; j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (checkHourse(i, j) == 1)
                        {
                            return 1;
                        }
                    }
                }
            return 0;
        }

        public static int checkHourse(int x, int y) // координаты коня
        {
            for (int i = 0; i < boardLength; i++)
                for (int j = 0; j < boardLength; j++)
                {
                    if (board[i, j] != 0)
                    {
                        // не уверен, но вроде как долженен быть хотя бы один маршрут  с конём
                        // проверка, на наличие следующего места для коня
                        if (board[x + 2, y + 1] != 0 || board[x + 2, y - 1] != 0 || board[x - 2, y - 1] != 0 || board[x - 2, y + 1] != 0 || board[x + 1, y + 2] != 0 || board[x + 1, y - 2] != 0 || board[x - 1, y - 2] != 0 || board[x - 1, y + 2] != 0)
                        {
                            return 1;
                        }
                    }
                }
            return 0;
        }
        //поставили коня в клетку
        //нашли клетку для следующего, поняли, что она пустая
        //и так ходим конём, пока не поймём, что все клетки заняты конями
        //если будет хоть одна пустая, то возвращаемся на шаг назад

        public static bool checkIfAllFilled()
        {
            for (int i = 0; i < boardLength; i++)
                for (int j = 0; j < boardLength; j++)
                {
                    if (board[i, j] == 0) return false;
                }

            return true;
        }

        public static bool  hourse(int n)
        {
            // проверили, что клетка пустая
            if (CheckBoard() == 0) return false;
            // проверили, что все клетки заполнены
            if (checkIfAllFilled()) return true;

            for (int i = 0; i < boardLength; i++)
                for (int j = 0; j < boardLength; j++)
                {
                    // поставили коня в первую клетку
                    if (board[i, j] == 0)
                    {
                        board[i, j] = n;
                        if (hourse(n + 1)) return true;
                        board[i, j] = 0;
                    }
                }
            return false;
        }


    }
}
