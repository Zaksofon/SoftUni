using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int safeExitWindow = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();
            int carLength = 0;
            string carModel = "";
            int pastGreenLightTime = greenLightTime;
            int totalSafeExitTime = pastGreenLightTime + safeExitWindow;
            int carsCounter = 0;

            while (true)
            {
                string command = Console.ReadLine();
                
                if (command != "green" && command != "END")
                {
                    carModel = command;
                    carLength += carModel.Length;
                    carsQueue.Enqueue(carModel);
                }

                switch (command)
                {
                    case "green":
                        // string currentCar = carModel;
                        char currentCarHitSpot = '\0'; 

                        for (int i = 0; i <= carsQueue.Count; i++)
                        {
                            if (carsQueue.Peek().Length <= totalSafeExitTime)
                            {
                                carsQueue.Dequeue();
                                totalSafeExitTime -= carsQueue.Peek().Length;
                                pastGreenLightTime -= carsQueue.Peek().Length;
                                carsCounter++;
                            }
                            else
                            {
                                for (int j = 0; j < totalSafeExitTime; j++)
                                {
                                    currentCarHitSpot = carModel[j];
                                }
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carModel} was hit at {currentCarHitSpot}.");
                                return;
                            }
                        }

                        totalSafeExitTime = greenLightTime + safeExitWindow;
                        carLength = 0;
                        break;

                    case "END":
                        Console.WriteLine("Everyone is safe.");
                        Console.WriteLine($"{carsCounter} total cars passed the crossroads.");
                        return;
                }
            }
        }
    }
}