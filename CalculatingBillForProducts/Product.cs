using System;

namespace CalculatingBillForProducts
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public Tax Tax;
        public double Quantity;

        public double Amount;

        public double CalculateTotalCost()
        {

            double tax = Convert.ToDouble(Tax.Percent);
            double percent = (Price * tax) / 100;
            double totalAmount = Quantity * (Price + percent);
            return totalAmount;

        }
    }
}