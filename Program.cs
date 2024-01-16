using System;
using System.IO;
using System.Xml;
class Program
{
    static void Main()
    {
        // Создаем XML документ
        XmlDocument doc = new XmlDocument();
        // Создаем корневой элемент
        XmlElement root = doc.CreateElement("telef");
        doc.AppendChild(root);
// Добавление строки, связывающей XML файл с CSS файлом        
XmlProcessingInstruction pi = doc.CreateProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"tt.css\"");
        doc.AppendChild(pi);
        // Читаем данные из файла "phones.txt"
        string[] lines = File.ReadAllLines("phones.txt");
        foreach (string line in lines)
        {
            // Создаем вложенный элемент tele
            XmlElement phone = doc.CreateElement("tele");
            root.AppendChild(phone);
            // Разделяем строку на поля
            string[] fields = line.Split(
);
            // Добавляем элементы в тег tele
            phone.AppendChild(CreateElementWithText(doc, "Название", fields[0].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "изготовитель", fields[1].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "цвет", fields[2].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "тип_экрана", fields[3].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "размер_корпуса", fields[4].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "год_изготовления", fields[5].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "время_зарядки", fields[6].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "время_работы_в_ожидании", fields[7].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "чехол", fields[8].Trim()));
        }
        // Сохраняем XML документ в файл
        doc.Save("Телефоны.xml");
        // Создаем CSS файл
        string css = "telef {display: table; width: 100%; border-collapse: collapse; background-color: #DB7093; } tele { display: table-row; } tele:nth-child(even) {background-color: #FFA07A;} tele:nth-child(odd) { background-color: #DB7093;} Название, изготовитель, цвет, тип_экрана, размер_корпуса, год_изготовления, время_зарядки, время_работы_в_ожидании, чехол { color: red; display: table-cell; padding: 15px; text-align: left; border-bottom: 1px solid #ddd;}";
        File.WriteAllText("tt.css", css);
        Console.WriteLine("Файлы успешно созданы.");
    }
    // Вспомогательная функция для создания элемента с текстом
    static XmlElement CreateElementWithText(XmlDocument doc, string elementName, string text)
    {
        XmlElement element = doc.CreateElement(elementName);
        element.InnerText = text;
        return element;
    }
}
