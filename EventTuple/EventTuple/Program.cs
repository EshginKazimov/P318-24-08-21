using System;

namespace EventTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Event

            Student s1 = new Student("Rail Jannatov", 90);
            Student s2 = new Student("Fagan Eyvazov", 90);

            s1.SendMessageEvent += Student1Print;
            s2.SendMessageEvent += (score) =>
            {
                if (score > 65)
                {
                    Console.WriteLine("Ela");
                    return;
                }

                Console.WriteLine("Teessuf");
            };

            s1.SendMessageEvent += (score) =>
            {
                if (score > 80)
                {
                    Console.WriteLine("chox ela");
                    return;
                }
            };

            //s1.SendMessage();
            //s2.SendMessage();

            //s1.NotifyEvent += SendEmail;
            //s1.NotifyEvent += SendSms;

            //s2.NotifyEvent += SendSms;

            //s1.Notify("Salam Rail");
            //s2.Notify("Salam Fagan");

            #endregion

            #region Tuple

            #region Reference type tuple

            //Tuple<int, string, string> person = new Tuple<int, string, string>(1, "Fagan", "Eyvazov"); 
            //Tuple<int, string, string> person = Tuple.Create(1, "Fagan", "Eyvazov"); 

            //Tuple<int, string, string> person = GetPerson();
            //var person = GetPerson();
            //Console.WriteLine(person.Item1);
            //Console.WriteLine(person.Item2);
            //Console.WriteLine(person.Item3);

            #endregion

            #region Value type tuple

            //ValueTuple<int, string, string> person = (1, "Fagan", "Eyvazov");
            //var person = (id: 1, name: "Fagan", surname: "Eyvazov");
            //Console.WriteLine(person.id);
            //Console.WriteLine(person.name);
            //Console.WriteLine(person.surname);

            //var person = GetPerson();
            //(int id, string name, string surname) person = GetPerson();
            //Console.WriteLine(person.id);
            //Console.WriteLine(person.name);
            //Console.WriteLine(person.surname);

            //(double perimetr, double area) rectangle = Calculate(10, 20);
            //Console.WriteLine(rectangle.perimetr);
            //Console.WriteLine(rectangle.area);

            #endregion

            #endregion
        }

        #region Tuple
        //IFigure interface olsun, Calculate method olsun
        //Rectangle, Square, Circle, Triangle classlari olsun
        //Calculate method-un implement edib
        //Return olaraq hem area hem perimetr qaytarsin

        static (double, double) Calculate(double length, double width)
        {
            double perimetr = 2 * (length + width);
            double area = length * width;

            return (perimetr, area);
        }

        static (int, string, string) GetPerson()
        {
            return (1, "Fagan", "Eyvazov");
        }

        //static ValueTuple<int, string, string> GetPerson()
        //{
        //    return (id: 1, name: "Fagan", surname: "Eyvazov");
        //}

        //static Tuple<int, string, string> GetPerson()
        //{
        //    //Tuple<int, string, string> person = new Tuple<int, string, string>(1, "Fagan", "Eyvazov"); 
        //    //Tuple<int, string, string> person = Tuple.Create(1, "Fagan", "Eyvazov");

        //    //return person;
        //    return Tuple.Create(1, "Fagan", "Eyvazov");
        //}

        #endregion

        #region Event

        static void SendEmail(string word)
        {
            Console.WriteLine("This word send by email: " + word);
        }

        static void SendSms(string word)
        {
            Console.WriteLine("This word send by sms: " + word);
        }

        static void Student1Print(int score)
        {
            if (score > 65)
            {
                Console.WriteLine("Aferin");
                return;
            }

            Console.WriteLine("Teessuf");
        }

        #endregion
    }

    #region Event

    class Student
    {
        public string FullName { get; }

        public int Score { get; }

        public event Action<int> SendMessageEvent;

        public event Action<string> NotifyEvent;

        public Student(string fullName, int score)
        {
            FullName = fullName;
            Score = score;
        }

        public void SendMessage()
        {
            SendMessageEvent(Score);
        }

        public void Notify(string word)
        {
            NotifyEvent(word);
        }
    }

    #endregion
}
