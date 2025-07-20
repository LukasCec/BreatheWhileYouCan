using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private string tunnelSceneName = "TunnelTransitionScene";
    [SerializeField] private float tunnelDuration = 6f;

    private string nextSceneToLoad;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); 
    }

    public void TransitionToMemory(string memorySceneName)
    {
        nextSceneToLoad = memorySceneName;
        StartCoroutine(TransitionSequence());
    }

    private IEnumerator TransitionSequence()
    {
        
        FadeManager.Instance.FadeOut(1f);
        yield return new WaitForSeconds(1f);

       
        SceneManager.LoadScene(tunnelSceneName);
        yield return null; 

       
        FadeManager.Instance.FadeIn(0.5f);
        yield return new WaitForSeconds(tunnelDuration);

        FadeManager.Instance.FadeOut(0.5f);
        yield return new WaitForSeconds(0.5f);

       
        SceneManager.LoadScene(nextSceneToLoad);
        yield return null;

       
        FadeManager.Instance.FadeIn(1f);
    }

    public void ReturnFromMemory(string journalText)
    {
        StartCoroutine(ReturnSequence(journalText));
    }

    private IEnumerator ReturnSequence(string journalText)
    {
        FadeManager.Instance.FadeOut(1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(tunnelSceneName);
        yield return null;

        FadeManager.Instance.FadeIn(0.5f);
        yield return new WaitForSeconds(tunnelDuration);

        FadeManager.Instance.FadeOut(0.5f);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("PresentRoom");
        yield return null;

        FadeManager.Instance.FadeIn(1f);

       
        JournalManager.Instance.AddEntry(journalText);
    }

}
