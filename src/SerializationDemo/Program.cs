using System;
using System.IO;
using System.Xml.Serialization;
using MyLibrary;

class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляров классов
        User user = new User { Name = "Alice", Age = 30 };
        Product product = new Product { ProductName = "Laptop", Price = 999.99m };
        Order order = new Order { Customer = user, Product = product, Quantity = 1 };

        // Сериализация
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        string xml;

        // Сериализация в строку
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, order);
            xml = writer.ToString();
            Console.WriteLine("Сериализованный XML:\n" + xml);
        }

        // Десериализация
        Console.WriteLine("\nДесериализация из XML:");

        using (var reader = new StringReader(xml))
        {
            Order deserializedOrder = (Order)serializer.Deserialize(reader);
            Console.WriteLine($"Клиент: {deserializedOrder.Customer.Name}, Возраст: {deserializedOrder.Customer.Age}");
            Console.WriteLine($"Продукт: {deserializedOrder.Product.ProductName}, Цена: {deserializedOrder.Product.Price}, Количество: {deserializedOrder.Quantity}");
        }
    }
}
