﻿using Homework;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(3);
            list.Add(3);
         //   list.Add(3);
            //list[0] = 15;

            //list.Remove(5);

            //foreach (int x in list)
            //{
            //    Console.WriteLine(x);
            //}

        }
    }
}
