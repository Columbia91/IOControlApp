using InAndOutControl.DataAccess;
using InAndOutControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InAndOutControl
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ControlContext())
            {
                context.Visitors.Add(new Visitor
                {
                    FullName = "Мохаммед Салах",
                    PassportNumber = 111222333
                });
                context.SaveChanges();
            }

            while (true)
            {
                int passportNumber = 0;
                bool check = false;
                while (!check)
                {
                    Console.Clear();
                    Console.WriteLine("\tПрибыл посетитель\n" +
                    "Введите номер удостоверения личности:");
                    check = int.TryParse(Console.ReadLine(), out passportNumber);
                }
                var service = new VisitorsTableDataService();
                var visitor = service.FindInformationAboutThisVisitor(passportNumber);

                if (visitor != null)
                {
                    Console.Write($"Полное имя: {visitor.FullName}");
                }
                else
                {
                    Console.WriteLine("\nЭто первое посещение данного человека\n" +
                        "Введите его полное имя:");
                    string fullName = Console.ReadLine();
                    visitor = new Visitor
                    {
                        FullName = fullName,
                        PassportNumber = passportNumber
                    };
                    service.InsertNewVisitor(visitor);
                }
                Console.WriteLine("\nЦель прибытия:");
                string purpose = Console.ReadLine();

                LogBooksTableDataService logService = new LogBooksTableDataService();
                var noteId = logService.InsertNewNote(visitor.Id, purpose);

                Console.WriteLine("\nИмитировать выход посетителя через (мин):");
                double spentTime = 0;

                check = false;
                while (!check)
                {
                    check = double.TryParse(Console.ReadLine(), out spentTime);
                    if (spentTime <= 0)
                        check = false;
                }
                logService.UpdateRelevantNote(noteId, spentTime);
            }
        }
    }
}
