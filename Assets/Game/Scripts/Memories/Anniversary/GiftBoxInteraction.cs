using UnityEngine;

public class GiftBoxInteraction : MemoryInteractable
{
    [SerializeField] private GameObject messageText;

    public override void Interact()
    {
        messageText.SetActive(true);
        Debug.Log("Opened gift box. Note revealed.");
    }
}
