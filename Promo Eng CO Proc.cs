using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo_Eng_CO_Proc
{
    class Eng
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("total number of order");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {                
                Console.WriteLine("enter the type of product:A,B,C or D");
                string type= Console.ReadLine();
                Product p = new Product(type);
                products.Add(p);
            }

            int totalPrice = GetTotalPrice(products);
            Console.WriteLine(totalPrice);
            Console.ReadLine();
        }

        private static int GetTotalPrice(List<Product> products)
        {
            int counterofA = 0, priceofA = 50, 
		counterofB = 0, priceofB = 30;
            	CounterofC = 0,	priceofC = 20;
            	CounterofD = 0,	priceofD = 15;

            foreach (Product pr in products)
            {
                if (pr.Id == "A" || pr.Id=="a")
                {
                    counterofA = counterofA + 1;
                }
                if (pr.Id == "B" || pr.Id=="b")
                {
                    counterofB = counterofB + 1;
                }
                if (pr.Id == "C" || pr.Id=="c")
                {
                    CounterofC = CounterofC + 1;
                }
                if (pr.Id == "D" || pr.Id=="d")
                {
                    CounterofD = CounterofD + 1;
                }
            }
            int totalPriceofA = (counterofA / 3) * 130 + (counterofA % 3 * priceofA);
            int totalPriceofB = (counterofB / 2) * 45 + (counterofB % 2 * priceofB);
            int totalPriceofC = (CounterofC * priceofC);
            int totalPriceofD = (CounterofD * priceofD);
            return totalPriceofA + totalPriceofB + totalPriceofC + totalPriceofD;

        }
    }
}