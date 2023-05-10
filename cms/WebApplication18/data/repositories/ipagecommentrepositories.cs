using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cms
{
   public interface ipagecommentrepositories
    {



        IEnumerable<pagecomment> getcommentbynewsid(int pageid);

        void addcomment(pagecomment comment);

        







    }
}
