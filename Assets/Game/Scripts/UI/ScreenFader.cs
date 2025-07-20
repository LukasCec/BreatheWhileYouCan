using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;

    void Awake()
    {
        canvasGroup.alpha = 0f;
    }

    public IEnumerator FadeIn(float duration = -1f)
    {
        if (duration < 0) duration = fadeDuration;
        float t = 0f;
        while (t < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }

    public IEnumerator FadeOut(float duration = -1f)
    {
        if (duration < 0) duration = fadeDuration;
        float t = 0f;
        while (t < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }
}
