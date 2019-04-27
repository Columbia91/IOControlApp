using InAndOutControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InAndOutControl.DataAccess
{
    public class LogBooksTableDataService
    {
        private readonly ControlContext context;
        public LogBooksTableDataService()
        {
            context = new ControlContext();
        }
        public Guid InsertNewNote(Guid id, string purpose)
        {
            LogBook note = new LogBook
            {
                EntryTime = DateTime.Now,
                VisitorId = id,
                VisitPurpose = purpose
            };
            try
            {
                context.LogBooks.Add(note);
                context.SaveChanges();
                Console.WriteLine("\nДанные записаны!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.Write("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
            return note.Id;
        }

        public void UpdateRelevantNote(Guid id, double spentTime)
        {
            try
            {
                var note = context.LogBooks
                    .Where(l => l.Id == id).FirstOrDefault();

                note.ExitTime = note.EntryTime.AddMinutes(spentTime);
                context.SaveChanges();
                Console.WriteLine("\nДанные обновлены!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.Write("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
        }
    }
}
