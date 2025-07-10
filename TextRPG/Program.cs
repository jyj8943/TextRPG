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

        // 플레이어의 인벤토리를 아이템 클래스 리스트로 관리
        public List<Item> Inventory;

        public Player(string inputName)
        {
            Level = 1;
            PlayerName = inputName;
            Job = "전사";
            Atk = 10;
            Def = 5;
            Hp = 100;
            Gold = 1500;
            Inventory = new List<Item>();
        }
    }

    // 아이템 정보를 클래스로 구현
    public class Item
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        // 1일 경우 방어구, 2일 경우 무기
        public int ItemType { get; set; }
        public int Atk {  get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public bool isEquipe { get; set; }

        public Item(string ItemName, string ItemDescription, int ItemType, int Atk, int Def, int Gold, bool isEquipe)
        {
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemType = ItemType;
            this.Atk = Atk;
            this.Def = Def;
            this.Gold = Gold;
            this.isEquipe = isEquipe;
        }
    }

    internal class Program
    {
        const int FullI_Item_Size = 6;

        static Player player;
        // 전체 아이템 정보를 배열로 관리
        static Item[] items;

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
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("\n텍스트 RPG 스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("원하시는 이름을 설정해주세요. \n");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.Write(">>> ");
                string userInput = Console.ReadLine();
                isInput = false;

                // 1번 저장, 2번 다시 입력 => 그 외에는 다시 물어보는 함수 작성해야함
                Console.WriteLine("\n입력하신 이름은 {0}입니다.",  userInput);

                do
                {
                    Console.WriteLine("\n1. 저장\n2. 다시 입력\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                    Console.Write(">>> ");

                    try
                    {
                        var input = Console.ReadLine();

                        // 입력이 null이거나 공백일 경우 처리
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("\n입력이 비어 있습니다.");
                            continue;
                        }
                        else
                        {
                            saveInput = int.Parse(input);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n정수를 입력해 주세요.");
                        continue;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("\n입력한 숫자가 너무 큽니다.");
                        continue;
                    }

                    switch (saveInput)
                    {
                        case 1:
                            Console.WriteLine("\n캐릭터를 생성합니다.");
                            player = new Player(userInput);
                            isInput = true;
                            isSave = true;
                            break;
                        case 2:
                            Console.WriteLine("\n이름을 취소합니다.");
                            isInput = true;
                            break;
                        default:
                            Console.WriteLine("\n잘못된 숫자입니다.");
                            break;
                    }
                } while (!isInput);
            } while (!isSave);

            // 아이템 정보 초기화 함수
            InitItems();
            //player.Inventory.Add(items[1]);
        }

        static private void StartMenu()
        {
            int userInput = -1;
            bool isSelect = false;
            Console.Clear(); // 게임스타트 메소드 화면 정리

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 다양한 활동을 할 수 있습니다.");
            Console.WriteLine("\n■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("\n1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            do
            {
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>> ");

                try
                {
                    var input = Console.ReadLine();

                    // 입력이 null이거나 공백일 경우 처리
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\n입력이 비어 있습니다.");
                        continue;
                    }
                    else
                    {
                        userInput = int.Parse(input);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n정수를 입력해 주세요.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n입력한 숫자가 너무 큽니다.");
                    continue;
                }

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("\n상태 보기를 선택하셨습니다.");
                        isSelect = true;
                        ViewPlayerStatus();
                        break;
                    case 2:
                        Console.WriteLine("\n인벤토리를 선택하셨습니다.");
                        isSelect = true;
                        ViewPlayerInventory();
                        break;
                    case 3:
                        Console.WriteLine("\n상점을 선택하셨습니다.");
                        isSelect = true;
                        break;
                    default:
                        Console.WriteLine("\n잘못된 숫자를 입력하셨습니다.");
                        break;
                }
            } while (!isSelect);

        }

        static private void ViewPlayerStatus()
        {
            int userInput = -1;
            bool isInput = false;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();

            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.WriteLine("Lv. {0}", player.Level);
            Console.WriteLine("Chad ( " + player.PlayerName + " )");
            Console.WriteLine("공격력: " + player.Atk);
            Console.WriteLine("방어력: " + player.Def);
            Console.WriteLine("체력: " + player.Hp);
            Console.WriteLine("Gold: " + player.Gold + " G");
            Console.WriteLine("\n0. 나가기");

            do
            {
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>> ");

                try
                {
                    var input = Console.ReadLine();

                    // 입력이 null이거나 공백일 경우 처리
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\n입력이 비어 있습니다.");
                        continue;
                    }
                    else
                    {
                        userInput = int.Parse(input);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n정수를 입력해 주세요.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n입력한 숫자가 너무 큽니다.");
                    continue;
                }

                switch (userInput)
                {
                    case 0:
                        isInput = true;
                        StartMenu();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 숫자를 입력하셨습니다.");
                        break;
                }
            } while (!isInput); 
        }

        static private void ViewPlayerInventory()
        {
            int userInput = -1;
            bool isInput = false;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("인벤토리");
            Console.ResetColor();

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[ 아이템 목록 ]\n");

            // 보유중인 아이템 목록을 보여주는 함수
            ShowPlayerInventory();

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");

            do
            {
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>> ");

                try
                {
                    var input = Console.ReadLine();

                    // 입력이 null이거나 공백일 경우 처리
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\n입력이 비어 있습니다.");
                        continue;
                    }
                    else
                    {
                        userInput = int.Parse(input);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n정수를 입력해 주세요.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n입력한 숫자가 너무 큽니다.");
                    continue;
                }

                switch (userInput)
                {
                    case 0:
                        isInput = true;
                        StartMenu();
                        break;
                    case 1:
                        isInput = true;
                        Console.WriteLine("장착 관리");
                        // 장착 관리 메소드
                        break;
                    default:
                        Console.WriteLine("\n잘못된 숫자를 입력하셨습니다.");
                        break;
                }
            } while (!isInput);
        }

        static private void ShowPlayerInventory()
        {
            foreach (var item in player.Inventory)
            {
                int i = 0;

                if (item.isEquipe == false)
                {
                    Console.Write(" - " + i + " " + item.ItemName + "    " + " | ");

                    if (item.ItemType == 0)
                    {
                        Console.WriteLine("방어력 +" + item.Def + " | " + item.ItemDescription);
                    }
                    else if (item.ItemType == 1) 
                    {
                        Console.WriteLine("공격력 +" + item.Atk + " | " + item.ItemDescription);
                    }
                }
                else if (item.isEquipe == true)
                {
                    Console.Write(" - [E]" + i + " " + item.ItemName + "    " + " | ");

                    if (item.ItemType == 0)
                    {
                        Console.WriteLine("방어력 +" + item.Def + " | " + item.ItemDescription);
                    }
                    else if (item.ItemType == 1)
                    {
                        Console.WriteLine("공격력 +" + item.Atk + " | " + item.ItemDescription);
                    }
                }
                i++;
            }
        }

        static private void InitItems()
        {
            items = new Item[FullI_Item_Size];

            // 아이템 배열에 아이템 추가 ( 지금은 하드 코딩으로 집어넣는데 나중에는 동적으로 넣을 수 있을듯?
            items[0] = new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1, 0, 5, 1000, false);
            items[1] = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 1, 0, 9, 2500, false);
            items[2] = new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 1, 0, 15, 3500, false);
            items[3] = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 2, 0, 600, false);
            items[4] = new Item("청동 도끼", "어디선가 사용됐던 것 같은 도끼입니다.", 2, 5, 0, 1500, false);
            items[5] = new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2, 7, 0, 2500, false);
        }
    }
}