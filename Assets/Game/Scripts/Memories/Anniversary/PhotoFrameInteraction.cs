using UnityEngine;

public class PhotoFrameInteraction : MemoryInteractable
{
    [SerializeField] private Transform rotatedPosition;

    private bool used = false;

    public override void Interact()
    {
        if (!used)
        {
            transform.rotation = rotatedPosition.rotation;
            used = true;
            Debug.Log("Photo frame flipped. Partner sighs.");
        }
    }
}
