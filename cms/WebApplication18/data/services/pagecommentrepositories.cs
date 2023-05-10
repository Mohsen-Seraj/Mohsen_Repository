using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms
{
    public class pagecommentrepositories : ipagecommentrepositories
    {
        private mycmscontext db;

        public pagecommentrepositories(mycmscontext context)
        {

            db = context;



        }
        public void addcomment(pagecomment comment)
        {
          

                db.pagecomments.Add(comment);
                db.SaveChanges();
                

          

        }

        public IEnumerable<pagecomment> getcommentbynewsid(int pageid)
        {
          return  db.pagecomments.Where(p => p.pageid == pageid);
        }
    }
}