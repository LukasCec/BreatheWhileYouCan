using System.Collections;
using UnityEngine;

public class MemoryTestTrigger : MonoBehaviour
{
    [SerializeField] private string journalText = "Dvereeee.";

    private void Start()
    {
        StartCoroutine(AutoReturn());
    }

    private IEnumerator AutoReturn()
    {
        yield return new WaitForSeconds(5f);
        SceneTransitionManager.Instance.ReturnFromMemory(journalText);
    }
}
