using System;
using System.Collections.Generic;

namespace Sklep_test_2
{
    class Program
    {
        /*
         * Przykład implementacji koszyka oraz zamówień do
         * projektu wydziałowego sklepu z koszulkami
         *
         * Przedstawione są tutaj przypadki dodawania oraz usuwania kolszulek do koszyka, złożenie zamówienia z
         * możliwością jego modyfikacji oraz zmiana statusu zamówienia uniemożliwiająca dokonywanie zmian w
         * aktualnym zamówieniu.
         */
        static void Main(string[] args)
        {
            //przykładowe przedmioty w magazynie
            #region
            var przedmiot1 = new Item(Item.TypeOfShirt.Male, Item.SizeOfShirt.XXL, "k1");
            var przedmiot2 = new Item(Item.TypeOfShirt.Male, Item.SizeOfShirt.XXL, "k2");
            var przedmiot3 = new Item(Item.TypeOfShirt.Male, Item.SizeOfShirt.XXL, "k3");
            var przedmiot4 = new Item(Item.TypeOfShirt.Male, Item.SizeOfShirt.XXL, "k4");
            var przedmiot5 = new Item(Item.TypeOfShirt.Male, Item.SizeOfShirt.XXL, "k5");

            var dodatkowyPrzedmiot1 = new Item(Item.TypeOfShirt.Female, Item.SizeOfShirt.XS, "Damska1");
            var dodatkowyPrzedmiot2 = new Item(Item.TypeOfShirt.Female, Item.SizeOfShirt.XS, "Damska2");
            #endregion

            //utworzenie koszyka - dla każdego indywidualnego użytkownika będzie on miał
            //docelowo nazwę (albo wewnętrznie nazwe) na podstawie loginu urzytkownika
            #region
            var cart = new Cart();
            #endregion

            //funkcje odpowiedzialne za dodawanie i usuwanie pozycji z koszyka
            //tutaj wszystko dzieje się swobodnie gdyż nie ma blokady dodawania ilości
            //ani blokady modyfikacji
            #region
            cart.RemoveProduct(4);
            cart.AddProduct(przedmiot1);
            cart.AddProduct(przedmiot2);
            cart.AddProduct(przedmiot3);
            cart.AddProduct(przedmiot4);
            cart.AddProduct(przedmiot5);
            cart.RemoveProduct(4);
            cart.RemoveProduct(3);
            cart.RemoveProduct(4);
            cart.RemoveProduct(4);
            #endregion

            //wyświetlam zawartość koszyka.
            #region
            cart.PrintCart();
            #endregion

            //utworzenie zamówienia i przekazanie aktualnej wersji koszyka bezpiśrednio do niego
            //w zamówieniu funkcje będą dostępne w zależności od stanu zamówienia
            //stany : Oczekujące na płatność, Opłacone - zlecone do realizacji, Do odbioru.
            //test zmiany zamówienia przed opłatą
            #region
            var order = new Order(cart);
            order.AddProduct(dodatkowyPrzedmiot1);
            order.AddProduct(dodatkowyPrzedmiot2);
            order.Cart.PrintCart();
            order.Cart.RemoveProduct(1);
            order.RemoveProduct(0);
            order.Cart.PrintCart();
            #endregion

            //zmiana statusu zamówienia i test działania funkcji
            #region
            order.OrderStatus = Order.Status.CHECKED;

            order.AddProduct(dodatkowyPrzedmiot1);
            order.AddProduct(dodatkowyPrzedmiot2);
            order.RemoveProduct(1);
            order.RemoveProduct(0);
            #endregion

            Console.ReadLine();
        }
    }
}
