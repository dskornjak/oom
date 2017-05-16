﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    interface getname
    {
        void Printname();
    }
    class SuperDinko : getname
    {
        private int age;

        public void Printname()
        {
            Console.WriteLine(MyName);
        }

        public string MyName
        {
            get;
            set;
        }

        public int MyAge
        {
            get => this.age;
            set => this.age = value;
        }

        public SuperDinko() /*Default Constructor*/
        {
            MyName = "DEFAULT";
            MyAge = 99;
        }

        public SuperDinko(string newName, int newAge) /*Second Constructor*/
        {
            try
            {
                if (newAge < 1) throw new ArgumentException("Age < 1");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            this.MyAge = newAge;
            this.MyName = newName;
        }

        public void UpdateAge(int newAge) /*Function updates age*/
        {
            this.MyAge = newAge;
        }

    }

    class Program
    {
        static int Main(string[] args)
        {
            var a = new SuperDinko();
            var b = new SuperDinko("Test", 1);

            Console.WriteLine(a.MyAge + " " + a.MyName);
            Console.WriteLine(b.MyAge + " " + b.MyName);
            Console.WriteLine("Update age on b to 45");
            b.UpdateAge(45);
            Console.WriteLine(b.MyAge);

            Console.WriteLine("\n\nStatic class");
            Console.WriteLine("INTERFACE");
            a.Printname();

            return 0;
        }
    }
}
