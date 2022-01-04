using System;

namespace Athens_chipher
{
    public class Program
    {
        //const string temp_ABC = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_,.?!";//м = 37
        const string temp_ABC = "абвгдежзийклмнопрстуфхцчшщъыьэюя_";//м=33
        //const string temp_ABC = "абвгдежзийклмнопрстуфхцчшщъыьэюя"; //м = 32
        //const string temp_ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";

        public static char[] rus_ABC = temp_ABC.ToCharArray();

        const string word = "шкьлнъйтбт_ш";


        static void Main(string[] args)
        {
            Dechipher();
        }
        static char[] in_letter(int[,] array, int length)
        {
            char[] word = new char[length];
            //char[] rus_ABC = temp_ABC.ToCharArray();
            int sch = 0;
            for (int j = 0; j < (length/2); j++)
            {
                for(int i = 0; i < 2; i++)
                {
                    word[sch] = rus_ABC[array[i, j]];
                    sch++;  
                }
                
            }
            return word;
        }
        static int[,] in_digit(char[] array, int length)
        {
            //кол-во данных зашифрованных букв /2
            int[,] word = new int[2, length];
            //char[] rus_ABC = temp_ABC.ToCharArray();
            int l = 0;
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < 2; i++)
                {

                    for (int k = 0; k < rus_ABC.Length; k++)
                    {
                        if (array[l] == rus_ABC[k])
                        {
                            word[i, j] = k;
                        }
                    }
                    l++;
                }
            }
            
            return word;
        }
        static void Dechipher()
        {
            char[] chipher_word = word.ToCharArray();
           // char[] ABC = temp_ABC.ToCharArray();
            int abc = rus_ABC.Length;
            // ввести S
            int[,] S = new int[,] { { 3 },  { 5 } };
            // ввести матрицу А
                int[,] A = new int[,] { { 4, 1 }, { 7, 2} };

                int modA = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
                Console.WriteLine("|A| = " + modA);
                Console.WriteLine("Введите A^(-1) по модулю " + abc + ":");
                int modA1 = Convert.ToInt32(Console.ReadLine());
                int[,] A1 = new int[2, 2]
                { {  ((modA1) * A[1, 1]),  modA1 * -(A[0, 1]) },
                { modA1 * (-A[1, 0]), modA1 * A[0, 0]}
                };
                int length = chipher_word.Length / 2;
                int[,] word_in_digit = in_digit(chipher_word, length);
                //Y-S

                for (int j = 0; j < length; j++)
                {
                    int x = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        word_in_digit[i, j] = word_in_digit[i, j] - S[x, 0];
                        x++;
                        while (word_in_digit[i, j] >= abc || word_in_digit[i, j] < 0)
                        {
                            if (word_in_digit[i, j] > abc)
                            {
                                word_in_digit[i, j] -= abc;
                            }
                            else
                            {
                                word_in_digit[i, j] += abc;
                            }
                        }
                    }

                }
                int[,] new_word = new int[2, length];
                //A1*(Y-S)
                for (int j = 0; j < length; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            new_word[i, j] = A1[0, 0] * word_in_digit[0, j] + A1[0, 1] * word_in_digit[1, j];
                        }
                        else
                        {
                            new_word[i, j] = A1[1, 0] * word_in_digit[0, j] + A1[1, 1] * word_in_digit[1, j];
                        }
                        while (new_word[i, j] >= abc || new_word[i, j] < 0)
                        {
                            if (new_word[i, j] >= abc)
                            {
                                new_word[i, j] -= abc;
                            }
                            else
                            {
                                new_word[i, j] += abc;
                            }
                        }
                    }
                }
                char[] answer = in_letter(new_word, chipher_word.Length);
                Console.WriteLine();
                for (int i = 0; i < answer.Length; i++)
                {
                    Console.Write(answer[i]);
                }
            
        }

    }
}
