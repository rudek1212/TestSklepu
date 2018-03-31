using System;
using System.Linq;

namespace Sklep_test_2
{
    internal class Order
    {
        /// <summary>
        ///     PAYMENT - oczekuje na płatność
        ///     CHECKED - zapłacone i oczekujące na realizacje
        ///     RELEASE - produkt oczekuje na wydanie
        /// </summary>
        public enum Status
        {
            PAYMENT = 0,
            CHECKED = 1,
            RELEASE = 2
        }

        public Order()
        {
            Id = _counter++;
            Cart = new Cart();
        }
        public Order(Cart cart)
        {
            Id = _counter++;
            Cart = cart;
        }

        private static int _counter = 1000000;
        public int Id { get; }
        public Cart Cart { get; }
        public Status OrderStatus { get; set; }

        //logika odpowiedzialna za dodawanie produktu do koszyka
        public void AddProduct(Item product)
        {
            if (OrderStatus == 0)
            {
                Cart.list.Add(product);
                //todo cw
                Console.WriteLine("Product added");
            }
            else Console.WriteLine("Method not accesible. Actual state of order is:" + OrderStatus); //todo cw
        }

        //logika odpowiedzialna za usuwanie produktu z koszyka
        public void RemoveProduct(int id)
        {
            if (OrderStatus == 0)
            {
                if (Cart.list.Count == 0) Console.WriteLine("No products in cart"); //todo cw
                else
                {
                    try
                    {
                        for (var i = Cart.list.Count; i > 0; i--)
                            if (Cart.list.ElementAt(i - 1).Id == id)
                            {
                                Cart.list.RemoveAt(i - 1);
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
            else Console.WriteLine("Method not accesible. Actual state of order is:" + OrderStatus); //todo cw
        }
    }
}