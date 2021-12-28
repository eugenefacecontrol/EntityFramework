// See https://aka.ms/new-console-template for more information

namespace HelloApp
{
    public class Program
    {
        public static void CheckCrud()
        {
            using (var db = new ApplicationContext())
            {
                var user1 = new User { Name = "Tom", Age = 33 };
                var user2 = new User { Name = "Alice", Age = 26 };

                db.Users.Add(user1);
                db.Users.Add(user2);

                // db.Users.AddRange(user1, user2);
                db.SaveChanges();
                Console.WriteLine("Object are successfully saved");
            }

            using (var db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Saved objects:");
                users.PrintUsers();
            }

            using (var db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    db.SaveChanges();
                }

                Console.WriteLine("Records after edit:");
                var users = db.Users.ToList();
                users.PrintUsers();
            }

            using (var db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                Console.WriteLine("Records after deletion:");
                var users = db.Users.ToList();
                users.PrintUsers();
            }
        }

        public static void CheckEdition()
        {
            User user = null;
            using (var db = new ApplicationContext())
            {
                user = db.Users.FirstOrDefault();
                Console.WriteLine("Records before edit:");

                var users = db.Users.ToList();
                users.PrintUsers();
            }

            using (var db = new ApplicationContext())
            {
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    db.SaveChanges();
                }

                Console.WriteLine("Records after edit:");
                var users = db.Users.ToList();
                users.PrintUsers();
            }
        }

        public static void Main(string[] args)
        {
            CheckEdition();

        }
    }
}