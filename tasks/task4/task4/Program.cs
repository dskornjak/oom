using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace task4
{
    [TestFixture]

    public class SuperMe : Person
    {
        public string m_MyName;
        private int m_MyAge;

        public int GetAge()
        {
           
            return m_MyAge;
        }
      
        
        public int Age
        {
            get
            {
                return m_MyAge;
            }
            set
            {
                m_MyAge = value;
            }
        }

        public string Name
        {
            get
            {
                return m_MyName;
            }
            set
            {
                m_MyName = value;
            }

        }

       
        public SuperMe()
        {
            m_MyName = "DEFAULT";
            m_MyAge = 99;
        }

        [JsonConstructor]
        public SuperMe(string newName, int newAge)
        {
            m_MyName = newName;
            m_MyAge = newAge;

        }

        [Test]
        public void UpdateAge(int NewAge)
        {
            try
            {
                if (NewAge < 1) throw new ArgumentException("Age equal or less 0");
                else
                {
                    Assert.NotZero(6);
                    m_MyAge = NewAge;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }

    [TestFixture]
    class Program
    {
        [Test]
        static void Main(string[] args)
        {
            var a = new SuperMe();
            var b = new SuperMe("Dinko", 29);
            Assert.AreEqual(a, b);

            Console.WriteLine(a.Age);
            a.Age = 45;
            Console.WriteLine(a.Age);
            Console.WriteLine(b.Age.ToString() + ", " + b.Name.ToString());
            b.UpdateAge(999);
            Console.WriteLine(b.Age.ToString() + ", " + b.Name.ToString());

            var c = new SecondMe();


            Console.WriteLine(b.GetAge());

            var e = new SuperMe("Skornjak", 33);
            Console.WriteLine(e.Name + " " + e.Age.ToString());

            string path = @"C:\TW\MyTest.txt";

            if (File.Exists(path)) File.Delete(path);

            string s = JsonConvert.SerializeObject(e);

            File.WriteAllText(path, s);

            Console.WriteLine("DESERIALIZED");

            s = File.ReadAllText(path);
            SuperMe f = JsonConvert.DeserializeObject<SuperMe>(s);

            Console.Write(f.Name + " " + f.Age.ToString() + "\n");
        }
    }
}
