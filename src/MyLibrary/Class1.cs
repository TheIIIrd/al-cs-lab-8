using System;
using System.Xml.Serialization;

namespace MyLibrary
{
    [XmlRoot("User")]
    public class User
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        
        [XmlElement("Age")]
        public int Age { get; set; }
    }

    [XmlRoot("Product")]
    public class Product
    {
        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }

    [XmlRoot("Order")]
    public class Order
    {
        [XmlElement("Customer")]
        public User Customer { get; set; }

        [XmlElement("Product")]
        public Product Product { get; set; }
        
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
