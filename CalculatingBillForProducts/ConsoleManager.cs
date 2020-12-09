using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatingBillForProducts
{

    public class ConsoleManager
    {

        List<Product> ProductsList = new List<Product>();
        public List<Product> getProductsList()
        {
            List<Tax> tax = new List<Tax>() {
                new Tax() {TaxName = "chocolateGST", Percent = 5},
                new Tax() {TaxName = "pizzaGST", Percent = 10}
            };
            List<Product> product = new List<Product>() {
                new Product() {Id = 1, Name = "Chocolate", Price = 100, Tax = (from t in tax where t.TaxName == "chocolateGST" select t).FirstOrDefault(), Quantity = 0, Amount = 0},
                new Product() {Id = 2, Name = "Pizza", Price = 500, Tax = (from t in tax where t.TaxName == "pizzaGST" select t).FirstOrDefault(), Quantity = 0, Amount = 0}
            };
            return product;
        }

        public ConsoleManager()
        {
            ProductsList.AddRange(getProductsList());
        }

        public void DisplayMenu()
        {
            foreach (var product in ProductsList)
            {
                Console.WriteLine(product.Id + " " + product.Name);
            }
        }

        public double DisplayTotalCost(Product product)
        {
            return product.CalculateTotalCost();
        }

        public Product CheckProductId(int userInput)
        {

            Product selectedProduct = new Product();

            foreach (var product in ProductsList)
            {
                if (product.Id == Convert.ToInt32(userInput))
                {
                    Console.WriteLine("Please specify Quantity");
                    double quantity = Convert.ToInt32(Console.ReadLine());
                    product.Quantity += quantity;
                    selectedProduct = product;
                }
            }
            return selectedProduct;
        }

        public void GetTotalBill()
        {
            double TotalAmount = 0;
            List<Product> SelectedProductsList = new List<Product>();

            while (true)
            {
                Console.WriteLine("Please specify Product Id or Press x to Exit");
                string userInput = Console.ReadLine();
                if (userInput == "x")
                {
                    Console.WriteLine();
                    Console.WriteLine("-------------------------Bill-------------------------");
                    //Console.WriteLine("{0,-5} {1,0} {2,20} {3,20} {4,20}\n", "Sno.", "Prouct_Name", "Price(Rs.)", "Quantity(Pcs)", "Amount(Rs.)");
                    Console.WriteLine("{0,-20} {1,0} {2,20} {3,20}\n", "Prouct_Name", "Price(Rs.)", "Quantity(Pcs)", "Amount(Rs.)");
                    int c = 1;
                    foreach (Product i in SelectedProductsList)
                    {
                        //Console.WriteLine("{0,-5} {1,0:N1} {2,20:N1} {3,20:N1} {4,20:N1} ", c, i.Name, i.Price, i.Quantity, i.Amount);
                        Console.WriteLine("{0,-20} {1,0} {2,20} {3,20}", i.Name, i.Price, i.Quantity, i.Amount);
                        c++;
                    }
                    break;
                }

                Product SelectedProduct = new Product();
                SelectedProduct = CheckProductId(Convert.ToInt32(userInput));
                SelectedProduct.Amount = DisplayTotalCost(SelectedProduct);
                TotalAmount += SelectedProduct.Amount;
                List<Product> lists = new List<Product>() {
                    new Product() {Id = SelectedProduct.Id, Name = SelectedProduct.Name, Price = SelectedProduct.Price, Quantity = SelectedProduct.Quantity, Amount = SelectedProduct.Amount}
                };
                SelectedProductsList.AddRange(lists);
                //foreach(Product i in SelectedProductsList) {
                //  Console.WriteLine("Product_Name: "+i.Name+"  Price: Rs."+i.Price+"  Quantity: "+i.Quantity+"  Amount: Rs."+i.Amount);
                //}
            }
            Console.WriteLine("\nTotal Bill of all items: Rs." + TotalAmount);
        }
    }
}