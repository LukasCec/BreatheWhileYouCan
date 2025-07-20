using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance;

    private List<JournalEntry> entries = new List<JournalEntry>();

    public IReadOnlyList<JournalEntry> Entries => entries;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

       
        DontDestroyOnLoad(gameObject);
        LoadEntries();
    }
    
    

    private void LoadEntries()
    {
        JournalSaveData data = SaveSystem.LoadJournal();

        entries = data.entries.Select(e => new JournalEntry(e)).ToList();


        foreach (var entry in entries)
        {
            JournalUI.Instance?.AddVisualEntry(entry);
        }
    }

    public void AddEntry(string text)
    {
        JournalEntry entry = new JournalEntry(text);
        entries.Add(entry);

        JournalUI.Instance?.AddVisualEntry(entry);
        SaveEntries();
    }

    private void SaveEntries()
    {
        JournalSaveData data = new JournalSaveData();
        data.entries = entries.Select(e => e.text).ToList();

        SaveSystem.SaveJournal(data);
    }
}
