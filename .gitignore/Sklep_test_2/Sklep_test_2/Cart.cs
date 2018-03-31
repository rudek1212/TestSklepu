using System;
using System.Collections.Generic;
using System.Linq;

namespace Sklep_test_2
{
    /// <summary>
    ///     Koszyk będący wzorcem do dalszego zamówienia.
    /// </summary>
    internal class Cart
    {
        public List<Item> list = new List<Item>();

        //logika odpowiedzialna za dodawanie produktu do koszyka
        internal virtual void AddProduct(Item product)
        {
            list.Add(product);
            //todo cw
            Console.WriteLine("Product added");
        }

        //logika odpowiedzialna za usuwanie produktu z koszyka
        internal virtual void RemoveProduct(int id)
        {
            if (list.Count == 0) Console.WriteLine("No products in cart"); //todo cw
            else
            {
                try
                {
                    for (var i = list.Count; i > 0; i--)
                        if (list.ElementAt(i - 1).Id == id)
                        {
                            list.RemoveAt(i - 1);
                            break;
                        }
                }
                catch (Exception e)
                {
                    //todo cw
                    Console.WriteLine(e);
                    throw;
                }

                //todo cw
                Console.WriteLine("Product removed");
            }
        }

        //logoka odpowiedzialna za wyświetlanie zawartości koszyka/zamówienia (czysto na potrzeby testów konsolowych)
        internal void PrintCart()
        {
            foreach (var item in list)
                //todo cw
                Console.WriteLine(item.ToString());
        }
    }
}