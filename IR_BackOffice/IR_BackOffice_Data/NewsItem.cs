using System;

namespace IR_BackOffice_Data
{
    public class NewsItem
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text{ get; set; }
        public virtual string ShortText { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual bool IsLive { get; set; }
    }
}
