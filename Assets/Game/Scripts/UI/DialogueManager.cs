using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;

    private Story currentStory;
    private bool isDialoguePlaying;

    [SerializeField] private CanvasGroup dialogueCanvasGroup;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float visibleDuration = 3f;

    private void Start()
    {
        dialoguePanel.SetActive(true);
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialoguePlaying) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void StartDialogue(TextAsset inkText)
    {
        currentStory = new Story(inkText.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        StartCoroutine(AutoPlayDialogue());
    }

    private IEnumerator AutoPlayDialogue()
    {
        while (currentStory.canContinue)
        {
            string text = currentStory.Continue().Trim();
            dialogueText.text = text;

            // Fade In
            yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 0f, 1f, fadeDuration));

            // Show
            yield return new WaitForSeconds(visibleDuration);

            // Fade Out
            yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 1f, 0f, fadeDuration));
        }

        EndDialogue();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string text = currentStory.Continue().Trim();
            dialogueText.text = text;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = end;
    }
}
