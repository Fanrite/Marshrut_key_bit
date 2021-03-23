using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marshrut_key_bit
{ 
    class CharNum
    {
            #region Fields
            private char _ch;
            private int _numberInWord;
            #endregion Fieds

            #region Properties          
            public char Ch
            {
                get { return _ch; }
                set
                {
                    if (_ch == value)
                        return;
                    _ch = value;
                }
            }
            
            public int NumberInWord
            {
                get { return _numberInWord; }
                set
                {
                    if (_numberInWord == value)
                        return;
                    _numberInWord = value;
                }
            }
            #endregion Properties
    }

    class Program
    {
            static void Main(string[] args)
            {
                string firstKey = "сканер";
                Console.Write("Введіть перший ключ:");
                firstKey = Console.ReadLine();
               
                string secondKey = "суп";
                Console.Write("Введіть другий ключ:");
                secondKey = Console.ReadLine();
           
                string stringUser = "заверншення роботи";
                Console.Write("Введіть повідомлення:");
                stringUser = Console.ReadLine();
                Console.Clear();
 
                char[,] matrix = new char[secondKey.Length, firstKey.Length];

                int countSymbols = 0;

                char[] charsFirstKey = firstKey.ToCharArray();
                char[] charsSecondKey = secondKey.ToCharArray();
                char[] charStringUser = stringUser.ToCharArray();

                List<CharNum> listCharNumFirst =
                    new List<CharNum>(firstKey.Length);

                List<CharNum> listCharNumSecond =
                    new List<CharNum>(secondKey.Length);

                listCharNumFirst = FillListKey(charsFirstKey);
                listCharNumSecond = FillListKey(charsSecondKey);

                listCharNumFirst = FillingSerialsNumber(listCharNumFirst);
                listCharNumSecond = FillingSerialsNumber(listCharNumSecond);

                ShowKey(listCharNumFirst, "Перший ключ: ");
                ShowKey(listCharNumSecond, "Другий ключ: ");

                for (int i = 0; i < listCharNumSecond.Count; i++)
                {
                    for (int j = 0; j < listCharNumFirst.Count; j++)
                    {
                        matrix[i, j] = charStringUser[countSymbols++];
                    }
                }

                Console.WriteLine($"Вхідне повідмлення: {stringUser}\n");
                countSymbols = 0;
                for (int i = 0; i < listCharNumSecond.Count; i++)
                {
                    for (int j = 0; j < listCharNumFirst.Count; j++)
                    {
                        matrix[listCharNumSecond[i].NumberInWord,
                           listCharNumFirst[j].NumberInWord] = charStringUser[countSymbols++];
                    }
                }

                ShowMatrix(matrix, "Зашифроване повідомлення: ");
                Console.ReadKey();
            }

            #region Methods
            public static int GetNumberInThealphabet(char s)
            {
                string str = @"АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";

                int number = str.IndexOf(s) / 2;

                return number;
            }

            public static List<CharNum> FillListKey(char[] chars)
            {
                List<CharNum> listKey = new List<CharNum>(chars.Length);

                for (int i = 0; i < chars.Length; i++)
                {
                    CharNum charNum = new CharNum()
                    {
                        Ch = chars[i],
                        NumberInWord = GetNumberInThealphabet(chars[i])
                    };

                    listKey.Add(charNum);
                }
                return listKey;
            }

            public static void ShowKey(List<CharNum> listCharNum, string message)
            {
                Console.WriteLine(message);

                foreach (var i in listCharNum)
                {
                    Console.Write(i.Ch + " ");
                }
                Console.WriteLine();

                foreach (var i in listCharNum)
                {
                    Console.Write(i.NumberInWord + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
 
            public static List<CharNum> FillingSerialsNumber(
                List<CharNum> listCharNum)
            {
                int count = 0;

                var result = listCharNum.OrderBy(a =>
                    a.NumberInWord);

                foreach (var i in result)
                {
                    i.NumberInWord = count++;
                }

                return listCharNum;
            }
 
            public static void ShowMatrix(char[,] matrix, string message)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        message += matrix[i, j];
                   Console.WriteLine(message);
            }
            #endregion Methods
    }

}