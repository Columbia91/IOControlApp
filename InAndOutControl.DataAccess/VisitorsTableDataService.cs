using InAndOutControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InAndOutControl.DataAccess
{
    public class VisitorsTableDataService
    {
        private readonly ControlContext context;
        public VisitorsTableDataService()
        {
            context = new ControlContext();
        }
        public Visitor FindInformationAboutThisVisitor(int number)
        {
            Visitor visitor = null;
            try
            {
                visitor = context.Visitors
                    .Where(v => v.PassportNumber == number).SingleOrDefault();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return visitor;
        }

        public void InsertNewVisitor(Visitor visitor)
        {
            try
            {
                context.Visitors.Add(visitor);
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
