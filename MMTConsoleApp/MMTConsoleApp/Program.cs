using System;

namespace MMTConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsumeProduct objProduct = new ConsumeProduct();
            objProduct.GetAllProductData();

            Console.WriteLine("=============== Product Names =================");

            objProduct.GetAllProducts();
            

            Console.ReadLine();
        }
    }
}
