using System;
using System.Collections.Generic;
using System.IO;

namespace Task03
{
    class CountingWordsInTextFile
    {
        static void Main(string[] args)
        {
            string text = String.Empty;
            string[] result;
            string[] remover = {",","!",".","?","(",")",";",":","#","@"};
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            StreamReader textReader = new StreamReader("D:\\Epam\\EPAM.Summer.Kozlov.09\\Task03\\textfile.txt");

            while (textReader.EndOfStream != true)
            {
                text += textReader.ReadLine();
            }
                       
            textReader.Close();

            foreach (string value  in remover)
            {
                text = text.Replace(value, "");
            }

            result = text.Split(' ');

            foreach (string word in result)
            {
                if (wordsDictionary.ContainsKey(word))
                {
                    wordsDictionary[word] += 1;
                }
                else
                {
                    wordsDictionary.Add(word, 1);
                }
            }
            Console.WriteLine("The frequency of words in the text:");
            foreach (KeyValuePair<string, int> word in wordsDictionary)
            {
                Console.WriteLine($"The word '{word.Key}' found in text {word.Value} times.");
            }


            Console.ReadLine();
        }
    }
}
