using APICDA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace APICDA.Data
{
    public class SeedUser
    {
        public static void SeedAsync(ShopDbContext context)
        {

            context.Database.EnsureCreated();
            User userSeed = new User();
            userSeed.login = "test";
            string password = "test";
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashString = Encoding.UTF8.GetString(hashBytes);
            userSeed.password = hashString;
            context.Users.Add(userSeed);
            context.SaveChanges();
        }
    }
}
