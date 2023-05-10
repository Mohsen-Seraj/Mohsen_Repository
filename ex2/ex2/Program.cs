using System;
using System.Collections.Generic;
using System.Linq;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Lists

            List<Product> itemlist = new List<Product>
            {
           new Product { Id = 1,  Name = "Biscuit  " },
           new Product { Id = 2,  Name = "Chocolate" },
           new Product { Id = 3,  Name = "Butter   " },
           new Product { Id = 4,  Name = "Brade    " },
           new Product { Id = 5,  Name = "Honey    " }
            };

            List<Purchase> purchlist = new List<Purchase>
            {
           new Purchase { InvoiceNo=100, ProductId = 3,  Quantity = 800 },
           new Purchase { InvoiceNo=101, ProductId = 5,  Quantity = 650 },
           new Purchase { InvoiceNo=102, ProductId = 3,  Quantity = 900 },
           new Purchase { InvoiceNo=103, ProductId = 4,  Quantity = 700 },
           new Purchase { InvoiceNo=104, ProductId = 3,  Quantity = 900 },
           new Purchase { InvoiceNo=105, ProductId = 4,  Quantity = 650 },
           new Purchase { InvoiceNo=106, ProductId = 1,  Quantity = 458 }
            };
            #endregion


            #region Right Join

            Console.WriteLine("Right Join : ");

            var jr = from pu in purchlist
                     join pr in itemlist on pu.ProductId equals pr.Id into RightJoin
                     from p in RightJoin.DefaultIfEmpty()
                     select new { p.Id, Name = p?.Name, pu.InvoiceNo, pu.ProductId, pu.Quantity };

            foreach (var j in jr)
            {

                Console.WriteLine(j);
            }


            #endregion


            Console.WriteLine("-------------------------------------------------------------");


            #region Left Join

            Console.WriteLine("Left Join : ");

            var jl = from pr in itemlist
                     join pu in purchlist on pr.Id equals pu.ProductId into Leftjoin
                     from p in Leftjoin.DefaultIfEmpty()
                     select new
                     { pr.Id, pr.Name, InvoiceNo = p?.InvoiceNo ?? 0, ProductId = p?.ProductId ?? 0, Quantity = p?.Quantity ?? 0 };

            foreach (var j in jl)
            {

                Console.WriteLine(j);
            }
            #endregion


            Console.WriteLine("-------------------------------------------------------------");


            #region Product List WhithLINQ

            var Product = from pr in itemlist select new {pr.Id , pr.Name};
            Console.WriteLine("Here is the Product List :");
            foreach (var i in Product)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region Product List WhithOutLINQ
            //foreach (var i in itemlist)
            //{
            //    Console.WriteLine("Item Id: "+ i.Id + "   Title: " + i.Name);
            //}
            #endregion


            Console.WriteLine("-------------------------------------------------------------");


            #region Purchase List WithLINQ
            var Purchase = from pr in purchlist select new { pr.InvoiceNo, pr.ProductId, pr.Quantity };
            Console.WriteLine("Here is the Purchase List :");
            foreach (var pr in Purchase)
            {
                Console.WriteLine(pr);
            }
            #endregion

            #region Purchase List WhithOutLINQ
            //foreach (var p in purchlist)
            //{
            //    Console.WriteLine("Invoice No: "+p.InvoiceNo + "   Product Id : " + p.ProductId + "   Quantity : " + p.Quantity);
            //}
            #endregion


            Console.WriteLine("-------------------------------------------------------------");


            #region list after Joining

            var join = from pu in purchlist join pr in itemlist on pu.ProductId equals pr.Id
                        select new {pr.Id, pr.Name, pu.Quantity };

            Console.WriteLine("Product ID   " + " Product Name   " + "Purchase Quantity");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var j in join)
            {
               
                Console.WriteLine(j.Id + "               " + j.Name + "           " + j.Quantity.ToString());
            }
            #endregion


            Console.ReadKey();
        }

        

    }
}
