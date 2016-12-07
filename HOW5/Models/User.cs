namespace HOW5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Advisor { get; set; }

        public int CatalogYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Major { get; set; }

        [Required]
        [StringLength(50)]
        public string Minor { get; set; }

        public int VNumber { get; set; }
    }
}
