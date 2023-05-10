using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms
{
    public class loginrepositories : iloginrepositories
    {
        private mycmscontext db;

      public  loginrepositories(mycmscontext context)
        {

            db = context;

        }


        public bool isexistuser(string username, string password)
        {
            return db.adminlogins.Any(u => u.username == username && u.password == password);
        }
    }
}