using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pager pgr = new Pager { CurrentPage = 1, TotalItems = 70, PageSize = 5, PagerSize = 9, FirstLastItemCount = 2 };
            //Pager pgr = new Pager { CurrentPage = 1, TotalItems = 70, PageSize = 5, PagerSize = 3, FirstLastItemCount = 1 };
            //Pager pgr = new Pager { CurrentPage = 1, TotalItems = 1190, PageSize = 5, PagerSize = 9, FirstLastItemCount = 2};
            Pager pgr = new Pager { CurrentPage = 1, TotalItems = 1190, PageSize = 5, PagerSize = 3, FirstLastItemCount = 1 };
            //Pager pgr = new Pager { CurrentPage = 1, TotalItems = 10, PageSize = 1, PagerSize = 5, FirstLastItemCount = 2 };
            pgr.Paginate();

            int pgCount = pgr.PageCount;
            for (int i = 2; i <= pgCount; i++)
            {
                pgr.CurrentPage = i;
                pgr.Paginate();
            }

            Console.Read();
        }
    }
}
