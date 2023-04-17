namespace ChessLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new();
            InputCoordinates();
            void InputCoordinates()
            {
                Console.WriteLine("Введите координаты, сначала начальные x1, y1, а потом желаемые для перемещения x2, y2");
                bool validation1 = int.TryParse(Console.ReadLine(), out int x1);
                bool validation2 = int.TryParse(Console.ReadLine(), out int y1);
                bool validation3 = int.TryParse(Console.ReadLine(), out int x2);
                bool validation4 = int.TryParse(Console.ReadLine(), out int y2);
                if (validation1 && validation2 && validation3 && validation4 && (x1 >= 1 && x1 <= 8) && (y1 >= 1 && y1 <= 8) && (x2 >= 1 && x2 <= 8) && (y2 >= 1 && y2 <= 8))
                {
                    FigureSelector(x1, y1, x2, y2);
                }
                else
                {
                    Console.WriteLine("Координаты имеют некорректное значение");
                    InputCoordinates();
                }
            }
            void FigureSelector(int x1, int y1, int x2, int y2)
            {

                Console.WriteLine("Выберите фигуру для проверки возможности хода");
                Console.WriteLine("Нажмите 1, чтобы выбрать короля");
                Console.WriteLine("Нажмите 2, чтобы выбрать королеву");
                Console.WriteLine("Нажмите 3, чтобы выбрать ладью");
                Console.WriteLine("Нажмите 4, чтобы выбрать слона");
                Console.WriteLine("Нажмите 5, чтобы выбрать коня");
                Console.WriteLine("Нажмите 6, чтобы выбрать пешку");
                var figureSelector = Console.ReadKey().Key;
                Console.WriteLine();
                switch (figureSelector)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.King(x1, y1, x2, y2)}");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.Queen(x1, y1, x2, y2)}");
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.Rook(x1, y1, x2, y2)}");
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.Bishop(x1, y1, x2, y2)}");
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.Knight(x1, y1, x2, y2)}");
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine($"Возможно ли такое перемещение?: {chess.Pawn(x1, y1, x2, y2)}");
                        break;
                    default:
                        Console.WriteLine("Фигуры с таким номером не существует");
                        FigureSelector(x1, y1, x2, y2);
                        break;
                }
            }
 
        }
    }
    public class Chess
    {
        // Король
        public bool King(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == 1 || Math.Abs(y2 - y1) == 1)
                return true;
            else
                return false;
        }

        // Королева
        public bool Queen(int x1, int y1, int x2, int y2)
        {
            if ((Math.Abs(x2 - x1) == Math.Abs(y2 - y1)) ^ ((x1 == x2 && y1 != y2) || (y1 == y2 && x1 != x2)))
                return true;
            else
                return false;
        }

        // Ладья
        public bool Rook(int x1, int y1, int x2, int y2)
        {
            if ((x1 == x2 && y1 != y2) || (y1 == y2 && x1 != x2))
                return true;
            else
                return false;
        }

        // Слон
        public bool Bishop(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
                return true;
            else
                return false;
        }

        // Конь
        public bool Knight(int x1, int y1, int x2, int y2)
        {
            if ((y2 == y1 + 2 && x2 == x1 + 1) || (y2 == y1 + 2 && x2 == x1 - 1) || (y2 == y1 - 2 && x2 == x1 + 1) || (y2 == y1 - 2 && x2 == x1 - 1) || (y2 == y1 + 1 && x2 == x1 + 2) || (y2 == y1 - 1 && x2 == x1 + 2) || (y2 == y1 + 1 && x2 == x1 - 2) || (y2 == y1 - 1 && x2 == x1 - 2))
                return true;
            else
                return false;               
        }

        // Пешка
        public bool Pawn(int x1, int y1, int x2, int y2)
        {
            if ((y2 == y1 + 1)) 
                return true;        
            else
               return false;
        }
    }
}
