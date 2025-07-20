using TMPro;
using UnityEngine;
using System.Collections;


public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeInDuration = 0.2f;
    [SerializeField] private float fadeOutDuration = 0.1f;


    private Coroutine fadeCoroutine;


    private void Start()
    {
        Hide();
    }

    public void Show(string prompt)
    {
        promptText.text = prompt;
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeCanvasGroup(1f));
    }

    public void Hide()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeCanvasGroup(0f));
    }

    private IEnumerator FadeCanvasGroup(float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float duration = (targetAlpha == 1f) ? fadeInDuration : fadeOutDuration;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }


}
