using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int nOperations = int.Parse(Console.ReadLine());

            Queue<string> text = new Queue<string>();
            Dictionary<int, string[]> sequenceArchive = new Dictionary<int, string[]>();
            sequenceArchive.Add(0, new []{string.Empty});

            for (int i = 1; i <= nOperations; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                switch (command)
                {
                    case "1":
                        string[] add = parts[1]
                            .Select(x => new string(x, 1))
                            .ToArray();
                        foreach (var element in add)
                        {
                            text.Enqueue(element);
                        }
                        sequenceArchive.Add(i, new []{string.Join(", ", text.ToArray())});
                        break;

                    case "2":
                        int nElementsToErase = Convert.ToInt32(parts[1]);
                        for (int j = 0; j < nElementsToErase; j++)
                        {
                            text.Dequeue();
                        }
                        sequenceArchive.Add(i, new[] { string.Join(", ", text.ToArray()) });
                        break;
                    
                    case "3":
                        int index = int.Parse(parts[1]);
                        List<string> newText = new List<string>(text);
                        char currentLetter = Convert.ToChar(newText[index - 1]);
                        Console.WriteLine(currentLetter);
                        break;

                    case "4":
                        int caseCounter = 0;
                        if (caseCounter == 0)
                        {
                            int curIndex = sequenceArchive.Count - 1;
                            string newState = Convert.ToString(sequenceArchive[curIndex]);
                            text.Clear();
                            text.Enqueue(newState);
                        }
                        else if (caseCounter > 0)
                        {
                            int curIndex = sequenceArchive.Count;
                            string newState = Convert.ToString(sequenceArchive[curIndex]);
                            text.Clear();
                            text.Enqueue(newState);
                        }
                        caseCounter++;
                        break;
                }
            }
        }
    }
}
