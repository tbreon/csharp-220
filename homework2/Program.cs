using System;
using System.Collections.Generic;
using System.Linq;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //1. Display to the console, the names of the users where the password is "hello". Hint: Where
            var usersHelloPassword = from user in users where user.Password=="hello" select user;

            Console.WriteLine("Users with password of hello:");
            foreach (var user in usersHelloPassword)
            {
                Console.WriteLine("Name = {0}", user.Name);
            }

            //2. Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve". It has to be data-driven. Hint: Remove or RemoveAll
            var deleteLowerCasePasswordOfName = from user in users where user.Password==user.Name.ToLower() select user;

            users.RemoveAll(user => deleteLowerCasePasswordOfName.Any(deleteLowerCasePasswordOfName => deleteLowerCasePasswordOfName.Password == user.Password));

            //3. Delete the first User that has the password "hello". Hint: First or FirstOrDefault
            users.Remove(usersHelloPassword.First());

            //4. Display to the console the remaining users with their Name and Password.
            Console.WriteLine("\nRemaining users with name and password:");

            foreach (var user in users)
            {
                Console.WriteLine("Name = {0}, Password = {1}", user.Name, user.Password);
            }
        }
    }
}
