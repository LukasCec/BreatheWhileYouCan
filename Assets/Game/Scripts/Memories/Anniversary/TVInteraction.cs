using UnityEngine;

public class TVInteraction : MemoryInteractable
{
    [SerializeField] private GameObject tvScreen;

    public override void Interact()
    {
        tvScreen.SetActive(false);
        Debug.Log("TV turned off. Partner looks up.");
    }
}
