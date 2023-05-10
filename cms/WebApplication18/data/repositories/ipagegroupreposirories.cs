using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cms
{
   public interface ipagegroupreposirories:IDisposable
    {
        IEnumerable<pagegroup> Getallgroups();

        pagegroup getgroupid(int groupid);

        bool insertgroup(pagegroup pagegroup);

        bool updategroup(pagegroup pagegroup);

        bool deletegroup(pagegroup pagegroup);

        bool deletegroup(int groupid);

        void save();

        IEnumerable<showgroupviewmodel> getgroupsforview();

    }
}
