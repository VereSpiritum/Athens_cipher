using System;

namespace Athens_cipher
{
    
    class Program
    {
        const string temp_rusABC = "абвгдежзийклмнопрстуфхцчшщъыьэюя_"; //m = 34
        //const string temp_rusABC = "абвгдежзийклмнопрстуфхцчшщъыьэюя_,.?!";//м = 37
        //const string temp_rusABC = "абвгдежзийклмнопрстуфхцчшщъыьэюя"; //м = 32
        
        const string chipher_word = "лвруияшащчыяэряшкга";
        const string word_for_chipher = "Дима, помой посуду";
        static int[] in_digit(char[] array)
        {
            int[] word = new int[array.Length];
            char[] rus_ABC = temp_rusABC.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < rus_ABC.Length; j++)
                {
                    if (array[i] == rus_ABC[j])
                    {
                        word[i] = j;
                    }
                }
            }
            return word;
        }
        static char[] in_letter(int[] array)
        {
            char[] word = new char[array.Length];
            char[] rus_ABC = temp_rusABC.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                word[i] = rus_ABC[array[i]];
            }
            return word;
        }
        static void Viviod(char [] array)
        {
            Console.WriteLine();
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
        static void Decipher2()
        {
            int S = 12;
            int ABC = 33;  //не забыть поменять размер алфавита
            int A1 = 26;

            char[] word = chipher_word.ToCharArray();
            int[] chipher_w;

            chipher_w = in_digit(word);
            
            int[] arr_word = new int[word.Length];
            for (int i = 0; i < arr_word.Length; i++)
            {
                int temp = A1 * (chipher_w[i] - S);
                while (temp >= ABC || temp < 0)
                {
                    if (temp >= ABC)
                    {
                        temp -= ABC;
                    }
                    else
                    {
                        temp += ABC;
                    }
                }
                arr_word[i] = temp;
            }

            Viviod(in_letter(arr_word));
            
        }
        static void Decipher1() //для расшифровки с неизвестной частью ключа С
        {
            int A = 13;
            int y = 32; //пробел 
            int ABC = 34;         
            int A1 = -13; //enter your A-1
            int x = 34;

            for (int k = 1; k <= x; k++)
            {
                int S = -A * k + y;
                
                while (S > ABC || S < 0)
                {
                    if (S > ABC)
                    {
                        S -= ABC;
                    }
                    else
                    {
                        S += ABC;
                    }
                }

                
                char[] word = chipher_word.ToCharArray();
                int[] chipher_w = in_digit(word);
                
                int[] arr_word = new int[word.Length];
                
                for (int i = 0; i < arr_word.Length; i++)
                {
                    int temp = A1 * (chipher_w[i] - S);
                    while (temp > ABC || temp < 0)
                    {
                        if (temp >= ABC)
                        {
                            temp -= ABC;
                        }
                        else
                        {
                            temp += ABC;
                        }
                    }
                    arr_word[i] = temp;
                }

                char[] answer = in_letter(arr_word);
                
                Console.WriteLine();
                for (int i = 0; i < answer.Length; i++)
                {
                   if(i == 0) Console.Write("["+ S + "]" + answer[i]);
                   else
                        Console.Write(answer[i]);
                }
            }
           
        }

        static void Main(string[] args)
        {
            // Decipher2();
        }
        
        static void Chipher_word()
        {
            int ABC = 34;
            int A = 5;
            int S = 25;

            char[] symb_for_chipher = word_for_chipher.ToCharArray();
            int[] word_in_digit = in_digit(symb_for_chipher);

            int[] chipher_w = new int[word_in_digit.Length];
            for (int i = 0; i < chipher_w.Length; i++)
            {
                int temp = A * word_in_digit[i] + S;
                while (temp >= ABC || temp < 0)
                {
                    if (temp > ABC)
                    {
                        temp -= ABC;
                    }
                    else
                    {
                        temp += ABC;
                    }
                }
                chipher_w[i] = temp;
            }

            Viviod(in_letter(chipher_w));



        }
    }
}
