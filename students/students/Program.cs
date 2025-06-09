using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using StudentStorage;

namespace StudentsInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.Load();
            while (true) {
                int choice = 0;
                Console.WriteLine("chose one/t1.adding student/t2.searching/t3.exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Student student1 = new Student();
                        Console.WriteLine("enter the id");
                        student1.id = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the name");
                        student1.name = Console.ReadLine();
                        Console.WriteLine("enter score");
                        student1.score = int.Parse(Console.ReadLine());
                        storage.studentsInfo.Add(student1.id, student1);
                        storage.save();
                        break;
                    case 2:
                        Console.WriteLine("enter the id for searching");
                        int enteredId = int.Parse(Console.ReadLine());
                        if (storage.studentsInfo.ContainsKey(enteredId)) {
                            //index = GetTheIndex(enteredId, storage.studentsInfo);
                            //Student enteredStudent = storage.studentsInfo[index];
                            Console.WriteLine($"NAME:{storage.studentsInfo[enteredId].name }/tID: {storage.studentsInfo[enteredId].id}/tSCORE: {storage.studentsInfo[enteredId].score}");
                        }
                        else { Console.WriteLine("The student doesnt exist"); }
                        break;
                    case 3:
                        Console.WriteLine("thanks for using our service. Goodby!");
                        Environment.Exit(0);
                        break;

                }


            }
        }

    } }