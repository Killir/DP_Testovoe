using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileReader
{
    const string path = "Assets/alice30.txt";

    static char[] splitChars = { ' ', '-', '\'', '\"', '`', ',', '.', '!', '?', ':', ';', '(', ')'};
    static StreamReader sr;

    public static Queue<string> GetWords(int minLettersCount)
    {
        Queue<string> words = new Queue<string>();
        sr = new StreamReader(path);

        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            string[] splitedLine = line.Split(splitChars, System.StringSplitOptions.RemoveEmptyEntries);
            foreach(string nextWord in splitedLine) {
                string word = nextWord.ToUpper();
                if (word.Length >= minLettersCount && !words.Contains(word)) {
                    words.Enqueue(word);
                }
            }
        }

        sr.Close();

        return words;        
    }

}
