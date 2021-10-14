using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Models
{
    [Table("cars")]
   
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int? BasePrice { get; set; }

        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }

        public virtual List<Drivers> Drivers { get; set; }
    }
}
