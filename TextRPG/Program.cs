namespace TextRPG
{
    public class Player
    {
        public int Level { get; set; }
        public string PlayerName { get; set; }
        public string Job { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Player(string inputName)
        {
            Level = 1;
            PlayerName = inputName;
            Job = "전사";
            Atk = 10;
            Def = 5;
            Hp = 100;
            Gold = 1500;
        }
    }

    internal class Program
    {
        static Player player;

        static void Main(string[] args)
        {
            GameStart();
        }

        static private void GameStart()
        {
            int saveInput = -1;
            bool isSave = false;
            bool isInput = false;

            do
            {
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요. \n");
                string userInput = Console.ReadLine();

                // 1번 저장, 2번 다시 입력 => 그 외에는 다시 물어보는 함수 작성해야함
                Console.WriteLine("\n입력하신 이름은 {0}입니다.",  userInput);

                do
                {
                    Console.WriteLine("\n1. 저장\n2. 다시 입력\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n");

                    try
                    {
                        var input = Console.ReadLine();

                        // 입력이 null이거나 공백일 경우 처리
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("입력이 비어 있습니다.");
                        }
                        else
                        {
                            saveInput = int.Parse(input);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("정수를 입력해 주세요.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("입력한 숫자가 너무 큽니다.");
                    }

                    if (saveInput == 1)
                    {
                        Console.WriteLine("\n캐릭터를 생성합니다.\n");
                        player = new Player(userInput);
                        isInput = true;
                        isSave = true;
                    }
                    else if (saveInput == 2)
                    {
                        Console.WriteLine("\n이름을 취소합니다.");
                    }
                    else
                    {
                        Console.WriteLine("\n잘못된 숫자입니다.");
                    }
                } while (!isInput);
            } while (!isSave);
        }
    }
}