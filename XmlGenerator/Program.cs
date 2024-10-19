using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace XmlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetAssembly(typeof(User)); // Замените на любой класс из вашей библиотеки
            var types = assembly.GetTypes();

            using (var writer = new XmlTextWriter("classDiagram.xml", Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Classes");

                foreach (var type in types)
                {
                    var commentAttribute = (CommentAttribute)Attribute.GetCustomAttribute(type, typeof(CommentAttribute));
                    writer.WriteStartElement("Class");
                    writer.WriteAttributeString("Name", type.Name);
                    if (commentAttribute != null)
                    {
                        writer.WriteElementString("Comment", commentAttribute.Comment);
                    }
                    writer.WriteEndElement(); // End of Class
                }

                writer.WriteEndElement(); // End of Classes
                writer.WriteEndDocument();
            }

            Console.WriteLine("XML файл успешно сгенерирован: classDiagram.xml");
        }
    }
}
