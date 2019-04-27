namespace InAndOutControl.DataAccess
{
    using InAndOutControl.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ControlContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ControlContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "InAndOutControl.DataAccess.ControlContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ControlContext" 
        // в файле конфигурации приложения.
        public ControlContext()
            : base("name=ControlContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}