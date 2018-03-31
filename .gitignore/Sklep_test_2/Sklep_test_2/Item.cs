using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep_test_2
{
    /// <summary>
    /// Klasa będąca wzorcem produktu dodwawanego później do zamówień bądź koszyka.
    /// </summary>
    class Item
    {
        internal enum SizeOfShirt
        {
            XS,S,M,L,XL,XXL,XXXL
        }

        internal enum TypeOfShirt
        {
            Male,Female
        }

        private static int counter;
        private TypeOfShirt Type { get; }
        private SizeOfShirt Size { get; }
        private string Name { get; }
        internal int Id { get; set; }

        public Item()
        {
            Type = TypeOfShirt.Male;
            Size = SizeOfShirt.XL;
            Name = "WMiIShirt";
            Id = counter++;
        }

        public Item(TypeOfShirt type, SizeOfShirt size, string name)
        {
            Type = type;
            Size = size;
            Name = name;
            Id = counter++;
        }

        public override string ToString()
        {
            return Name + " " + Type + " " + Size + " " + Id;
        }
    }
}
