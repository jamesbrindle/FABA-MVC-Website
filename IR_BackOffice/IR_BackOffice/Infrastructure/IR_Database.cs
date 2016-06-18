using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using IR_BackOffice.Objects;
using IR_BackOffice_Data;

namespace IR_BackOffice.Infrastructure
{
    public class IR_Database : DbContext, IBackOfficeDataSource
    {
        public IR_Database()
            : base("DefaultConnection")
        {

        }

        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<BookmakerItem> BookmakerItems { get; set; }
        public DbSet<LeagueCodes> LeagueCodes { get; set; }
        public DbSet<TipsItem> TipsItems { get; set; }
        
        IQueryable<NewsItem> IBackOfficeDataSource.NewsItems
        {
            get { return NewsItems; }
        }

        IQueryable<BookmakerItem> IBackOfficeDataSource.BookmakerItems
        {
            get { return BookmakerItems; }
        }

        IQueryable<TipsItem> IBackOfficeDataSource.TipsItems
        {
            get { return TipsItems; }
        }

        IQueryable<LeagueCodes> IBackOfficeDataSource.LeagueCodes
        {
            get { return LeagueCodes; }
        }
    }
}