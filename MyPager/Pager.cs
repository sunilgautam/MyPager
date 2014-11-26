using System;
namespace MyPager
{
    // Pager pgr = new Pager { CurrentPage = 1, TotalItems = 1002, PageSize = 25, PagerSize = 20 };
    // pgr.Paginate();
    class Pager
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int PagerSize { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; private set; }
        public int FirstLastItemCount { get; set; }

        private int ItemsBeforeNextGap { get; set; }
        private int ItemsBeforePrevGap { get; set; }
        private int ItemsBetween { get; set; }

        private bool Next { get; set; }
        private bool Prev { get; set; }
        private bool ShowNextGap { get; set; }
        private bool ShowPrevGap { get; set; }

        public Pager()
        {
            PageSize = 20;
            PagerSize = 15;
            CurrentPage = 1;
            Next = false;
            Prev = false;
            ShowNextGap = false;
            ShowPrevGap = false;
            FirstLastItemCount = 2;
        }

        public void Paginate()
        {
            if (PageSize < 1)
            {
                throw new Exception("Invalid page size");
            }
            if (PagerSize < 1)
            {
                throw new Exception("Invalid pager size");
            }
            if (TotalItems < 0)
            {
                throw new Exception("Invalid total items");
            }

            PageCount = (int)Math.Ceiling(TotalItems * 1.0 / PageSize);

            if (PageCount != 0 && (CurrentPage < 1 || CurrentPage > PageCount))
            {
                throw new Exception("Invalid current page");
            }

            /**************************************************/

            Prev = (PageCount > 0 && CurrentPage > 1);
            Next = (PageCount > 0 && CurrentPage < PageCount);

            int pagerStart = 0, pagerEnd = 0, startAdjust = 0, endAdjust = 0;

            pagerStart = CurrentPage - (int)Math.Floor((PagerSize - 1) / 2.0);
            if (pagerStart < 1)
            {
                endAdjust = 1 - pagerStart;
                pagerStart = 1;
            }

            pagerEnd = CurrentPage + (int)Math.Ceiling((PagerSize - 1) / 2.0);
            if (pagerEnd > PageCount)
            {
                startAdjust = pagerEnd - PageCount;
                pagerEnd = PageCount;
            }

            pagerStart -= startAdjust;
            pagerEnd += endAdjust;
            if (pagerStart < 1)
            {
                pagerStart = 1;
            }
            if (pagerEnd > PageCount)
            {
                pagerEnd = PageCount;
            }

            ShowPrevGap = (pagerStart > FirstLastItemCount + 1);
            ShowNextGap = (pagerEnd < PageCount - FirstLastItemCount);

            //Console.WriteLine("------------------------------------------------------------");
            //Console.WriteLine("Total items : {0}", TotalItems);
            //Console.WriteLine("Page count : {0}", PageCount);
            //Console.WriteLine("Current page : {0}", CurrentPage);
            //Console.WriteLine("Start : {0} EndAdjust : {1}", pagerStart, endAdjust);
            //Console.WriteLine("End : {0} StartAdjust : {1}", pagerEnd, startAdjust);
            //Console.WriteLine("{0} {1} : {2}", pagerStart, pagerEnd, pagerEnd - pagerStart + 1);
            //Console.WriteLine();

            /***************************************************/
            if (Prev)
            {
                Console.Write("[Prev] ");
            }
            for (int i = 1; i <= FirstLastItemCount; i++)
            {
                if (i < pagerStart)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    break;
                }
            }
            if (ShowPrevGap)
            {
                Console.Write("... ");
            }
            Console.Write("| ");

            for (int i = pagerStart; i <= pagerEnd; i++)
            {
                if (i == CurrentPage)
                {
                    Console.Write("[{0}] ", i);
                }
                else
                {
                    Console.Write(i + " ");
                }
            }

            Console.Write("| ");
            if (ShowNextGap)
            {
                Console.Write("... ");
            }
            for (int i = PageCount - FirstLastItemCount + 1; i <= PageCount; i++)
            {
                if (i > pagerEnd)
                {
                    Console.Write(i + " "); 
                }
            }
            if (Next)
            {
                Console.Write("[Next]");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}