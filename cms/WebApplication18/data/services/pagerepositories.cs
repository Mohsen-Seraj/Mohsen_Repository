using datalayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cms
{
    public class pagerepositories : ipagerepositories
    {
        private mycmscontext db;

        public pagerepositories(mycmscontext context)
        {

            db = context;



        }


        public bool deletepage(page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;

            }

            catch (Exception)
            {
                return false;
                
            }
        }



        public bool deletepage(int pageid)
        {
            try
            {
                var page = getpagebyid(pageid);
                deletepage(page);

                return true;

            }

            catch (Exception)
            {
                return false;

            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<page> getallpage()
        {
            return db.pages;
        }



        public page getpagebyid(int pageid)
        {
           return db.pages.Find(pageid);
        }




        public bool insertpage(page page)
        {
            try
            {
                db.pages.Add(page);
                return true;

            }

            catch (Exception)
            {
                    return false;

            }

        }

        public IEnumerable<page> lastnews(int take = 15)
        {
            return db.pages.OrderByDescending(p => p.createdate).Take(take);
        }

        public IEnumerable<page> pageinslider()
        {
            return db.pages.Where(p => p.showinslider == true);
        }

        public void save()
        {
            db.SaveChanges();
        }



        public IEnumerable<page> searchpage(string search)
        {
            return db.pages.Where(p => p.title.Contains(search) || p.shortdescription.Contains(search) || p.text.Contains(search)).Distinct();
        }



        public IEnumerable<page> showgroupbyid(int groupid)
        {
            return db.pages.Where(p => p.groupid == groupid);
        }

        public IEnumerable<page> top(int t = 10)
        {

          return  db.pages.OrderByDescending(p => p.visit).Take(t);


        }

       

        public bool updatetpage(page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;         
                    return true;

            }

            catch (Exception)
            {
                return false;

            }
        }
    }
}