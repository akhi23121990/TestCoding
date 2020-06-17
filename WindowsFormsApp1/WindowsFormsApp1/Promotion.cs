using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Promotion
    {
        public Promotion(int quantity, double amount, Promotiontype Promotiontype, string DependentProduct)
        {
            _Quantity = quantity;
            _Amount = amount;
            _Promotiontype = Promotiontype;
            _DependentProduct = DependentProduct;
        }

        //public string Product { get; set; }
        public int _Quantity { get; set; }
        public Double _Amount { get; set; }
        public Promotiontype _Promotiontype { get; set; }
        public string _DependentProduct { get; set; }
    }

    public enum Promotiontype
    {
       Single=0,
       Combo=1
    }
}
