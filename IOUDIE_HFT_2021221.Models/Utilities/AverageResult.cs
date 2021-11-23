using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOUDIE_HFT_2021221.Models.Utilities
{
    public class AverageResult
    {
        public string BrandName { get; set; }
        public double AveragePrice { get; set; }



        public override bool Equals(object obj)
        {
            if (obj is AverageResult)
            {
                var other = obj as AverageResult;
                return this.AveragePrice == other.AveragePrice && this.BrandName == other.BrandName;
                //close
            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return this.BrandName.GetHashCode() + (int)this.AveragePrice;
        }
        public override string ToString()
        {
            return $"BrandName={BrandName}, AveragePrice={AveragePrice},";
        }
    }
}
