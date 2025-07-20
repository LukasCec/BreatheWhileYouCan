using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string fileName = "journalData.json";

    public static void SaveJournal(JournalSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        string fullPath = GetPath();
        File.WriteAllText(fullPath, json);
        Debug.Log($"Journal saved to: {fullPath}");
    }

    public static JournalSaveData LoadJournal()
    {
        string fullPath = GetPath();

        if (!File.Exists(fullPath))
        {
            Debug.Log("No journal save file found. Returning empty.");
            return new JournalSaveData(); 
        }

        string json = File.ReadAllText(fullPath);
        JournalSaveData data = JsonUtility.FromJson<JournalSaveData>(json);
        Debug.Log("Journal loaded.");
        return data;
    }

    private static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }

    public static void DeleteJournalData()
    {
        string fullPath = GetPath();

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("Journal save file deleted.");
        }
        else
        {
            Debug.Log("No save file to delete.");
        }
    }
}
