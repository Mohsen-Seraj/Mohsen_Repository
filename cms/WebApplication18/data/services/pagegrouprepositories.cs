using datalayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
 
namespace cms
{
    public class pagegrouprepositories : ipagegroupreposirories
    {

        private mycmscontext db;

        public pagegrouprepositories(mycmscontext context)
        {

            db = context;



        }


        public bool deletegroup(pagegroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;

            }
           

        }

        public bool deletegroup(int groupid)
        {
            try
            {
                var group = getgroupid(groupid);
                deletegroup(group);
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

        public IEnumerable<pagegroup> Getallgroups()
        {
            return db.pagegroups;

        }

        public pagegroup getgroupid(int groupid)
        {
            return db.pagegroups.Find(groupid);
        }

        public IEnumerable<showgroupviewmodel> getgroupsforview()
        {
            return db.pagegroups.Select(g => new showgroupviewmodel()
            {

                groupid = g.groupid,
                grouptitle = g.grouptitle,
                pagecount = g.pages.Count



            });
        }

        public bool insertgroup(pagegroup pagegroup)
        {
            try
            {

                db.pagegroups.Add(pagegroup);
                return true;

            }
            catch (Exception)
            {
                return false;

            }


        }

        public void save()
        {
            db.SaveChanges();
        }

        public bool updategroup(pagegroup pagegroup)
        {

            try
            {
                db.Entry(pagegroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;


            }



        }
    }
}