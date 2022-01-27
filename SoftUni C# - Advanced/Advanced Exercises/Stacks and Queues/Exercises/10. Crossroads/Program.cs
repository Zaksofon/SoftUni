using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _10.Crossroads_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int safeExitWindow = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int carsCounter = 0;

            while (true)
            {
                string command = Console.ReadLine();
                int greenLight = greenLightTime;
                int safeTime = safeExitWindow;

                switch (command)
                {
                    case "END":
                        Console.WriteLine("Everyone is safe.");
                        Console.WriteLine($"{carsCounter} total cars passed the crossroads.");
                        return;

                    case "green":
                        while(greenLight > 0 && carsQueue.Count > 0)
                        {
                            string firstCarInQueue = carsQueue.Dequeue();
                            greenLight -= firstCarInQueue.Length;

                            if (greenLight > 0)
                            {
                                carsCounter++;
                            }

                            else
                            {
                                safeTime += greenLight;
                                carsCounter++;

                                if (safeTime < 0)
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{firstCarInQueue} was hit at {firstCarInQueue.Substring(firstCarInQueue.Length + safeTime, 1)}.");
                                    return;
                                }
                            }
                        }
                        break;

                    default:
                        carsQueue.Enqueue(command);
                        break;

                }
            }
        }
    }
}
