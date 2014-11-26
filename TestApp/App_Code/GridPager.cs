using System;

public class GridPager
{
    public int TotalItems { get; set; }             // Total no of records
    public int PerPage { get; set; }                // Items per page
    public int CurrentPage { get; set; }            // Current page no
    public int TotalPages { get; private set; }     // Total no of pages
    public int InnerLinks { get; set; }             // Links around current page
    public int OuterLinks { get; set; }             // Links around first and last page
    public string ParamName { get; set; }           // Parameter name for page no
    public string ListClass { get; set; }           // CSS Class name for generated pager

    public string PageUrl { get; set; }
    private int ItemsBeforeNextGap { get; set; }
    private int ItemsBeforePrevGap { get; set; }
    private int ItemsBetween { get; set; }

    private bool Next { get; set; }
    private bool Prev { get; set; }
    private bool ShowNextGap { get; set; }
    private bool ShowPrevGap { get; set; }

	public GridPager()
	{
        PerPage = 30;
        InnerLinks = 4;
        OuterLinks = 1;
        CurrentPage = 1;
        ListClass = "pagination";
        ParamName = "page";

        Next = false;
        Prev = false;
        ShowNextGap = false;
        ShowPrevGap = false;
        PageUrl = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
	}

    public string Paginate()
    {
        int pagerStart = 0, pagerEnd = 0, startAdjust = 0, endAdjust = 0;
        System.Text.StringBuilder pagerBuilder = null;
        
        // Validation
        if (PerPage < 1)
        {
            throw new Exception("Invalid page size");
        }
        if (InnerLinks < 1)
        {
            throw new Exception("Invalid inner link count size");
        }
        if (TotalItems < 0)
        {
            throw new Exception("Invalid total items");
        }

        TotalPages = (int)Math.Ceiling(TotalItems * 1.0 / PerPage);

        if (TotalPages != 0 && (CurrentPage < 1 || CurrentPage > TotalPages))
        {
            throw new Exception("Invalid current page");
        }

        // Computation
        Prev = (TotalPages > 0 && CurrentPage > 1);
        Next = (TotalPages > 0 && CurrentPage < TotalPages);

        pagerStart = CurrentPage - InnerLinks;
        if (pagerStart < 1)
        {
            endAdjust = 1 - pagerStart;
            pagerStart = 1;
        }

        pagerEnd = CurrentPage + InnerLinks;
        if (pagerEnd > TotalPages)
        {
            startAdjust = pagerEnd - TotalPages;
            pagerEnd = TotalPages;
        }

        pagerStart -= startAdjust;
        pagerEnd += endAdjust;
        if (pagerStart < 1)
        {
            pagerStart = 1;
        }
        if (pagerEnd > TotalPages)
        {
            pagerEnd = TotalPages;
        }

        ShowPrevGap = (pagerStart > OuterLinks + 1) && (OuterLinks > 0);
        ShowNextGap = (pagerEnd < TotalPages - OuterLinks) && (OuterLinks > 0);

        // Display generation
        pagerBuilder = new System.Text.StringBuilder();
        pagerBuilder.AppendFormat("<ul class=\"{0}\">", ListClass);
        if (Prev)
        {
            pagerBuilder.AppendFormat("<li><a href=\"{1}?{2}={3}\">{0}</a></li>", "Prev", PageUrl, ParamName, CurrentPage - 1);
        }
        for (int i = 1; i <= OuterLinks; i++)
        {
            if (i < pagerStart)
            {
                pagerBuilder.AppendFormat("<li><a href=\"{1}?{2}={3}\">{0}</a></li>", i, PageUrl, ParamName, i);
            }
            else
            {
                break;
            }
        }
        if (ShowPrevGap)
        {
            pagerBuilder.AppendFormat("<li><a href=\"#\">{0}</a></li>", "...");
        }

        for (int i = pagerStart; i <= pagerEnd; i++)
        {
            if (i == CurrentPage)
            {
                pagerBuilder.AppendFormat("<li><a class=\"current\" href=\"{1}?{2}={3}\">{0}</a></li>", i, PageUrl, ParamName, i);
            }
            else
            {
                pagerBuilder.AppendFormat("<li><a href=\"{1}?{2}={3}\">{0}</a></li>", i, PageUrl, ParamName, i);
            }
        }

        if (ShowNextGap)
        {
            pagerBuilder.AppendFormat("<li><a href=\"#\">{0}</a></li>", "...");
        }
        for (int i = TotalPages - OuterLinks + 1; i <= TotalPages; i++)
        {
            if (i > pagerEnd)
            {
                pagerBuilder.AppendFormat("<li><a href=\"{1}?{2}={3}\">{0}</a></li>", i, PageUrl, ParamName, i);
            }
        }
        if (Next)
        {
            pagerBuilder.AppendFormat("<li><a href=\"{1}?{2}={3}\">{0}</a></li>", "Next", PageUrl, ParamName, CurrentPage + 1);
        }
        pagerBuilder.AppendFormat("</ul>");
        return pagerBuilder.ToString();
    }
}