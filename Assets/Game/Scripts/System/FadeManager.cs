using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float defaultFadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   


    public void FadeIn(float duration = -1f) => StartCoroutine(Fade(1f, 0f, duration));
    public void FadeOut(float duration = -1f) => StartCoroutine(Fade(0f, 1f, duration));

    private IEnumerator Fade(float from, float to, float duration)
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image not assigned!");
            yield break;
        }

        float t = 0f;
        duration = duration < 0f ? defaultFadeDuration : duration;

        Color color = fadeImage.color;
        while (t < duration)
        {
            float a = Mathf.Lerp(from, to, t / duration);
            fadeImage.color = new Color(color.r, color.g, color.b, a);
            t += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, to);
    }
}
