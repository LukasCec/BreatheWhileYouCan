using System;

[Serializable]
public class JournalEntry
{
    public string text;
    public DateTime timestamp;

    public JournalEntry(string text)
    {
        this.text = text;
        this.timestamp = DateTime.Now;
    }
}
