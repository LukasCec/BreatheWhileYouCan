using UnityEngine;

public class StartIntroDialogue : MonoBehaviour
{
    [SerializeField] private TextAsset introInk;

    private void Start()
    {
        DialogueManager.Instance.StartDialogue(introInk);
    }
}
