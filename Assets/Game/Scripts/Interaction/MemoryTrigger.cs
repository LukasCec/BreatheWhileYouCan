using UnityEngine;

public class MemoryTrigger : Interactable
{
    [SerializeField] private string memorySceneName;

    public override void Interact()
    {
        base.Interact();
        SceneTransitionManager.Instance.TransitionToMemory(memorySceneName);
    }
}
