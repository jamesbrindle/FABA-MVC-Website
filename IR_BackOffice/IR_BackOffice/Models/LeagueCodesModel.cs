using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;
using IR_BackOffice_Data;

namespace IR_BackOffice.Models
{
    public class LeagueCodesContext : DbContext
    {
        public LeagueCodesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<LeagueCodes> LeagueCodeProfile { get; set; }
    }

    [Table("LeagueCodes")]
    public class LeagueCodes
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LeagueCode { get; set; }
        public string Name { get; set; }
    }

    public class CreateLeagueCodeViewModel
    {
        [Required]
        [Display(Name="LeagueCode")]
        public string LeagueCode { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }

    public class EditLeagueCodeModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "LeagueCode")]
        public string LeagueCode { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}