using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //needs EntityFramework
using System.ComponentModel.DataAnnotations.Schema;

namespace preview
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase Db = new MyDatabase();
            foreach (var student in Db.Students)
            {
                Console.WriteLine($"{student.Name, -15} {student.Identity.Number}");
            }
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public virtual Identity Identity { get; set; }
    }
    public class Identity
    {
        [ForeignKey("Student")]
        public int IdentityID { get; set; }
        public string Number { get; set; }
        public virtual Student Student { get; set; }
    }
    public class MyDatabase : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Identity> Identities { get; set; }
    }
}
