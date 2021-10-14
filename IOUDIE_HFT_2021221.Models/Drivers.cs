﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Models
{
    [Table("drivers")]
    public class Drivers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }
    }
}
