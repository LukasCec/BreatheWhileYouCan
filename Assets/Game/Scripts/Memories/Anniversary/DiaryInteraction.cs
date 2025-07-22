using UnityEngine;

public class DiaryInteraction : MemoryInteractable
{
    [SerializeField] private GameObject diaryPage;

    public override void Interact()
    {
        diaryPage.SetActive(true);
        Debug.Log("Opened diary. Entry appears.");
    }
}
