using System;
using System.IO;
using System.Xml;
class Program
{
    static void Main()
    {
        // ������� XML ��������
        XmlDocument doc = new XmlDocument();
        // ������� �������� �������
        XmlElement root = doc.CreateElement("telef");
        doc.AppendChild(root);
// ���������� ������, ����������� XML ���� � CSS ������        
XmlProcessingInstruction pi = doc.CreateProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"tt.css\"");
        doc.AppendChild(pi);
        // ������ ������ �� ����� "phones.txt"
        string[] lines = File.ReadAllLines("phones.txt");
        foreach (string line in lines)
        {
            // ������� ��������� ������� tele
            XmlElement phone = doc.CreateElement("tele");
            root.AppendChild(phone);
            // ��������� ������ �� ����
            string[] fields = line.Split(
);
            // ��������� �������� � ��� tele
            phone.AppendChild(CreateElementWithText(doc, "��������", fields[0].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "������������", fields[1].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "����", fields[2].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "���_������", fields[3].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "������_�������", fields[4].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "���_������������", fields[5].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "�����_�������", fields[6].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "�����_������_�_��������", fields[7].Trim()));
            phone.AppendChild(CreateElementWithText(doc, "�����", fields[8].Trim()));
        }
        // ��������� XML �������� � ����
        doc.Save("��������.xml");
        // ������� CSS ����
        string css = "telef {display: table; width: 100%; border-collapse: collapse; background-color: #DB7093; } tele { display: table-row; } tele:nth-child(even) {background-color: #FFA07A;} tele:nth-child(odd) { background-color: #DB7093;} ��������, ������������, ����, ���_������, ������_�������, ���_������������, �����_�������, �����_������_�_��������, ����� { color: red; display: table-cell; padding: 15px; text-align: left; border-bottom: 1px solid #ddd;}";
        File.WriteAllText("tt.css", css);
        Console.WriteLine("����� ������� �������.");
    }
    // ��������������� ������� ��� �������� �������� � �������
    static XmlElement CreateElementWithText(XmlDocument doc, string elementName, string text)
    {
        XmlElement element = doc.CreateElement(elementName);
        element.InnerText = text;
        return element;
    }
}
