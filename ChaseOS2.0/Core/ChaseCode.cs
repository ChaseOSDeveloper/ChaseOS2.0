﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
namespace ChaseOS2._0.Core
{
    
    public class Programming
    {
        public Programming()
        {

        }
        public string[] ParseProgram(string text)
        {
            string[] vs;
            if (text.StartsWith(" "))
            {

            } else
            {
                text = " " + text;
            }
            vs = text.Split(" ");
            return vs;
        }
    }
    public class InternalParse {
        
        public InternalParse()
        {
            
        }
        public void Program(string parseText)
        {
            Programming parser = new Programming();
            string[] commandsplit = parser.ParseProgram(parseText);
            Library libraries = new Library();
            try
            {

                libraries.Command(commandsplit);
            }
            catch
            {

            }
        }
        }
    public class Library
    {

        public bool uac = false;



        public Library()
        {
           
        }
        public void Command(string[] segment)
        {
            

            switch (segment[1])
            {
                case "uac":
                    Console.WriteLine("This script wants permissions to take control of your computer. Y/N");
                    string confirm = Console.ReadLine();
                    if (confirm == "Y")
                    {
                        uac = true;
                    }
                    break;
                case "waitforkey":
                    Console.ReadKey();
                    break;
                case "beep":
                    Console.Beep();
                    break;
                case "print":
                    if (segment[2] == "//GLOBALVAR//")
                    {
                        Console.WriteLine(Commands.globalVar);
                    } else
                    {
                        Console.WriteLine(segment[2]);
                    }
                    break;
                case "bsod":
                    if (uac)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Clear();
                        Console.WriteLine("Your computer ran into a problem, and the errorcode is");
                        Console.WriteLine(segment[2]);
                        Console.WriteLine("Restarting in 5 seconds...");
                        WaitSeconds(5);
                        Sys.Power.Reboot();
                    }
                    break;
                case "wait":
                    WaitSeconds(int.Parse(segment[2]));
                    break;
                case "addprint":
                    Console.WriteLine(Convert.ToInt32(segment[2]) + Convert.ToInt32(segment[3]));
                    break;
                case "subtractprint":
                    Console.WriteLine(Convert.ToInt32(segment[2]) - Convert.ToInt32(segment[3]));
                    break;
                case "multiplyprint":
                    Console.WriteLine(Convert.ToInt32(segment[2]) * Convert.ToInt32(segment[3]));
                    break;
                case "divideprint":
                    Console.WriteLine(Convert.ToInt32(segment[2]) / Convert.ToInt32(segment[3]));
                    break;
                case "input":
                    string bruh = Console.ReadLine();
                    Commands.globalVar = bruh;
                    break;
                case "nothing":
                    break;

            }
        }
        public static void WaitSeconds(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                // Loop round
            }
        }
    }
}
