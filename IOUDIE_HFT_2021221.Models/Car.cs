using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }


        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual List<Driver> Drivers { get; set; }


    }
}
