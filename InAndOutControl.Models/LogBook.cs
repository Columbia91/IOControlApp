using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InAndOutControl.Models
{
    public class LogBook
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; } = null;
        public Visitor Visitor { get; set; }
        public Guid VisitorId { get; set; }
        public string VisitPurpose { get; set; }
    }
}
/*Создайте консольное приложение, которое позволяет вести учёт посетителей в некоторое 
 * заведение (время, когда зашёл и вышел, имя, номер удостоверения, цель посещения). 
 * Сделайте приложение таким образом, чтобы им мог пользоваться охранник, который ничего 
 * не понимает в компьютерах.*/
