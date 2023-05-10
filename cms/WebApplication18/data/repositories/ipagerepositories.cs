using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cms
{
  public  interface ipagerepositories:IDisposable
    {

        IEnumerable<page> getallpage();

        page getpagebyid(int pageid);

        bool insertpage(page page);

        bool updatetpage(page page);

        bool deletepage(page page);

        bool deletepage(int pageid);

        void save();

        IEnumerable<page> top(int t = 10);

        IEnumerable<page> pageinslider();
        IEnumerable<page> lastnews(int take = 15);
        IEnumerable<page> showgroupbyid(int groupid);

        IEnumerable<page> searchpage(string search);

    }
}
