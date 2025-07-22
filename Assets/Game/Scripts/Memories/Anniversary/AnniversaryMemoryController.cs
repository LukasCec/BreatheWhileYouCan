using System.Collections;
using UnityEngine;

public class AnniversaryMemoryController : MonoBehaviour
{
    [SerializeField] private YoungerSelfMover youngerSelf;

    private void Start()
    {
        StartCoroutine(SceneFlow());
    }

    private IEnumerator SceneFlow()
    {
        yield return new WaitForSeconds(1f);

        youngerSelf.StartMoving();

        yield return new WaitForSeconds(5f);

        
    }
}
