using System.IO;
using System.Security.Cryptography.X509Certificates;
class Journal
{
    public string _fileName;
    public List<Entry> _entries;


    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))

        {

            foreach (Entry myEntry in _entries)
            {
                string text = $"{myEntry._entryDate} | {myEntry._prompt} | {myEntry._entryText}";
                outputFile.WriteLine(text);
            }
        }
    }

    public void Load()
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry myEntry = new Entry();
            _entries.Add(myEntry);
            myEntry._entryDate = parts[0];
            myEntry._prompt = parts[1];
            myEntry._entryText = parts[2];
        }

    }
}