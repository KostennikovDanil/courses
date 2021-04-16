using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Collections
{
    class Program
    {

        static void Main(string[] args)
        {

            string path = Console.ReadLine();
            Dictionary<string, int> words = new Dictionary<string, int>();

            try
            {
                string text;
                using (StreamReader reader = new StreamReader(path))
                {
                    text = reader.ReadToEnd();
                }

                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray()).Split(" ");

                foreach (string word in noPunctuationText)
                {
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                    else
                    {
                        words.Add(word, 1);
                    }
                }

                string[] topWords = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    topWords[i] = words.Keys.ElementAt(i);
                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9 - i; j++)
                    {
                        if (words[topWords[j]] < words[topWords[j + 1]])
                        {
                            string tmp = topWords[j];
                            topWords[j] = topWords[j + 1];
                            topWords[j + 1] = tmp;
                        }
                    }
                            
                }


                for (int i = 10; i < words.Count; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if(words.Values.ElementAt(i)> words[topWords[j]])
                        {
                            for (int k = 9; k > j; k--)
                            {
                                topWords[k] = topWords[k - 1];
                            }
                            topWords[j] = words.Keys.ElementAt(i);
                            break;
                        }
                    }
                }

                foreach (var word in topWords)
                {
                    Console.WriteLine(words[word]);
                }

            }

            catch
            {

            }
        }
    }
}
