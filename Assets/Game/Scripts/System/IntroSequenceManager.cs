using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class IntroSequenceManager : MonoBehaviour
{
    [Header("Post-Processing")]
    [SerializeField] private Volume volume;
    [SerializeField] private float blinkInterval = 2f;
    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private Transform playerStartPoint;
    [SerializeField] private TextAsset introInk;
    private bool dialogueStarted = false;

    private DepthOfField blur;
    private bool isBlinking = true;


    private void Start()
    {
        if (volume.profile.TryGet(out blur))
        {
            StartCoroutine(PlayIntroSequence());
        }
    }

    private IEnumerator PlayIntroSequence()
    {
        // 1. Aktivuj fadeCanvas
        fadeCanvas.gameObject.SetActive(true);

        // 2. Blikanie (rozmazanie + fade-in/out)
        float elapsed = 0f;
        while (elapsed < 10f)
        {
            if (!dialogueStarted && elapsed >= 5f)
            {
                DialogueManager.Instance.StartDialogue(introInk);
                dialogueStarted = true;
            }

            yield return StartCoroutine(Fade(fadeCanvas, 0, 1, 0.5f));
            yield return StartCoroutine(Fade(fadeCanvas, 1, 0, 0.5f));
            yield return new WaitForSeconds(blinkInterval);
            elapsed += 1f + blinkInterval;
        }




        // 4. PoËkaj, k˝m skonËÌ dialÛg
        yield return new WaitUntil(() => DialogueManager.Instance.IsFinished());

        // 5. Fade do Ëierna
        yield return StartCoroutine(Fade(fadeCanvas, 0, 1, 2f));

        // 6. Odstr·Ú blur efekt
        blur.active = false;

        // 7. PresuÚ hr·Ëa vedæa postele
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerStartPoint.position;

        // 8. Fade sp‰ù do reality
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(Fade(fadeCanvas, 1, 0, 2f));
        fadeCanvas.gameObject.SetActive(false);
    }

    private IEnumerator Fade(CanvasGroup canvas, float from, float to, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            canvas.alpha = Mathf.Lerp(from, to, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        canvas.alpha = to;
    }
}
