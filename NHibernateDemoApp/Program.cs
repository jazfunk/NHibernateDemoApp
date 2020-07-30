using NHibernate.Cfg;
using NHibernate.Dialect;
using System;
using System.Reflection;

namespace NHibernateDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new Configuration();

            config.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Host=localhost;Database=postgres;Username=postgres;Password=dbp@$$;";
                x.Dialect<PostgreSQLDialect>();
            });

            config.AddAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //var student1 = new Student
                    //{
                    //    ID = 1,
                    //    FirstName = "Allan",
                    //    LastName = "Boomer",
                    //};

                    //var student2 = new Student
                    //{
                    //    ID = 2,
                    //    FirstName = "Jerry",
                    //    LastName = "Lewis"
                    //};
                    //session.Save(student1);
                    //session.Save(student2);
                    var students = session.CreateCriteria<Student>().List<Student>();

                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.FirstName, student.LastName);
                    }

                    transaction.Commit();
                }
            }

            Console.ReadLine();
        }
    }
}
