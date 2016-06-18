using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;

namespace IR_BackOffice.Models
{
    public class TipsContext : DbContext
    {
        public TipsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<TipsItem> TipsProfile { get; set; }
    }

    [Table("TipsItem")]
    public class TipsItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsLive { get; set; }
    }

    public class CreateTipsViewModel
    {
        private DateTime _dateAdded = DateTime.Now;
        private bool _isLive = true;

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [UIHint("tinymce_full"), AllowHtml]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; }
        }

        //[Display(Name = "Image")]
        //public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Is Live?")]
        public bool IsLive
        {
            get { return _isLive; }
            set { _isLive = value; }
        }
    }

    public class EditTipsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [UIHint("tinymce_full"), AllowHtml]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        //[Display(Name = "Image")]
        //public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Is Live?")]
        public bool IsLive { get; set; }
    }
}