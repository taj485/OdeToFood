using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OdeToFood.Auth.Models;


namespace OdeToFood.Auth.Services
{
    public class UserDBContext :DbContext
    {
        public DbSet<UserModel> UserAccount { get; set; }
    }
}