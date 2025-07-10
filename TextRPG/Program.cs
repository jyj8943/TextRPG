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

            StartMenu();
        }

        static private void GameStart()
        {
            int saveInput = -1;
            bool isSave = false;
            bool isInput = false;

            do
            {
                Console.WriteLine("텍스트 RPG 스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요. \n");
                string userInput = Console.ReadLine();
                isInput = false;

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
                        isInput = true;
                    }
                    else
                    {
                        Console.WriteLine("\n잘못된 숫자입니다.");
                    }
                } while (!isInput);
            } while (!isSave);
        }

        static private void StartMenu()
        {
            int userInput = -1;
            bool isSelect = false;
            Console.Clear(); // 게임스타트 메소드 화면 정리


            do
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 다양한 활동을 할 수 있습니다.");
                Console.WriteLine("\n■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("\n1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("\n■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>> ");

                try
                {
                    var input = Console.ReadLine();

                    // 입력이 null이거나 공백일 경우 처리
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\n입력이 비어 있습니다.");
                    }
                    else
                    {
                        userInput = int.Parse(input);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n정수를 입력해 주세요.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n입력한 숫자가 너무 큽니다.");
                }

                if (userInput == 1)
                {
                    Console.WriteLine("\n상태 보기를 선택하셨습니다.");
                    isSelect = true;
                }
                else if (userInput == 2)
                {
                    Console.WriteLine("\n인벤토리를 선택하셨습니다.");
                    isSelect = true;
                }
                else if (userInput == 3)
                {
                    Console.WriteLine("\n상점을 선택하셨습니다.");
                    isSelect = true;
                }
                else
                {
                    Console.WriteLine("\n잘못된 숫자를 입력하셨습니다.\n");
                }
            } while (!isSelect);

        }
    }
}