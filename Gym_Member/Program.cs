using Gym_Member.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Member.Models;

namespace Gym_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t\tGym Member Information\n");
            Console.WriteLine("Enter Index Number..........\n");
            try
            {
                DisplayResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        public static void DisplayResult()
        {
            Console.WriteLine("1. Show All Member");
            Console.WriteLine("2. Insert New Member");
            Console.WriteLine("3. Update Member List");
            Console.WriteLine("4. Delete from Member List");

            var index = int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        {
            MemberRep memberRep = new MemberRep();
            if (index == 1)
            {
                var GymMemberList = memberRep.ShowAll();
                if (GymMemberList.Count() == 0)
                {
                    Console.WriteLine("_____________________________________________________________");
                    Console.WriteLine("No members have been inserted yet\n");
                    Console.WriteLine("\t\tEnter Member Information");
                    DisplayResult();
                    Console.WriteLine("_____________________________________________________________");
                }
                else
                {
                    foreach (var item in memberRep.ShowAll())
                    {
                        Console.WriteLine($"Member Id: {item.MemberId}, Name: {item.MemberName}, \nAge: {item.Age}, Phone Number: {item.PhoneNumber}, Package Duration: {item.PackageDuration}");
                    }
                    Console.WriteLine("_____________________________________________________________");
                    DisplayResult();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("_____________________________________________________________");
                Console.Write("Name :");
                string name = Console.ReadLine();

                Console.Write("Age :");
                int Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Phone Number :");
                string PhoneNumber = Console.ReadLine();

                Console.Write("Package Duration :");
                string PackageDuration = Console.ReadLine();

                int maxId = memberRep.ShowAll().Any() ? memberRep.ShowAll().Max(x => x.MemberId) : 0;

                GymMember GymMember = new GymMember
                {
                    MemberId = maxId + 1,
                    MemberName = name,
                    Age = Age,
                    PhoneNumber = PhoneNumber,
                    PackageDuration = PackageDuration
                };
                memberRep.Insert(GymMember);
                Console.WriteLine("\t\nMember Information Inserted successfully!!!");
                Console.WriteLine("___________________________________________________________________");
                DisplayResult();
            }
            else if (index == 3)
            {
                Console.WriteLine("___________________________________________________________________");
                Console.Write("Enter Member Id for  Update: ");
                int id = int.Parse(Console.ReadLine());
                var _GymMember = memberRep.FindMemberByID(id);

                if (_GymMember == null)
                {
                    Console.WriteLine("___________________________________________________________________");
                    Console.WriteLine("Member Id is invalid!!!");
                    Console.WriteLine("___________________________________________________________________");
                    DisplayResult();
                }
                else
                {
                    Console.WriteLine($"Update Info for Member Id : {id}");
                    Console.WriteLine("___________________________________________________________________");
                    Console.Write("Name :");
                    string name = Console.ReadLine();

                    Console.Write("Age :");
                    int Age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Phone Number :");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Package Duration :");
                    string PackageDuration = Console.ReadLine();

                    GymMember GymMember = new GymMember
                    {
                        MemberId = id,
                        MemberName = name,
                        Age = Age,
                        PhoneNumber = PhoneNumber,
                        PackageDuration = PackageDuration
                    };
                    memberRep.Update(GymMember);
                    Console.WriteLine("\t\nData Updated Successfully!!!");
                    Console.WriteLine("___________________________________________________________________");
                    DisplayResult();
                }
            }
            else if (index == 4)
            {
                Console.WriteLine("___________________________________________________________________");
                Console.Write("Enter Member Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var _GymMember = memberRep.FindMemberByID(id);

                if (_GymMember == null)
                {
                    Console.WriteLine("___________________________________________________________________");
                    Console.WriteLine("Member Id is invalid!!!");
                    Console.WriteLine("___________________________________________________________________");
                    DisplayResult();
                }
                else
                {
                    memberRep.Delete(id);
                    Console.WriteLine("\t\nMember Data Deleted Successfully!!!");
                    Console.WriteLine("\npress enter for exit");
                    

                    //DisplayResult();

                   
                }
            }
        }
    }
}
