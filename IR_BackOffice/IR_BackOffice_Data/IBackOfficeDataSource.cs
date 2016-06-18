using System.Linq;

namespace IR_BackOffice_Data
{
    public interface IBackOfficeDataSource
    {
        IQueryable<NewsItem> NewsItems { get; }
        IQueryable<BookmakerItem> BookmakerItems { get; }
        IQueryable<TipsItem> TipsItems { get; }
        IQueryable<LeagueCodes> LeagueCodes { get; }
    }
}
