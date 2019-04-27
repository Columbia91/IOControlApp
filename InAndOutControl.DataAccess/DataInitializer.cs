using InAndOutControl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InAndOutControl.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<ControlContext>
    {
        protected override void Seed(ControlContext context)
        {
            context.Visitors.AddRange(new List<Visitor>
            {
                new Visitor
                {
                    FullName = "Марат Башаров",
                    PassportNumber = 123456789
                },
                new Visitor
                {
                    FullName = "Илья Ильин",
                    PassportNumber = 987654321
                },
                new Visitor
                {
                    FullName = "Уилл Смит",
                    PassportNumber = 123654789
                }
            });
        }
    }
}
