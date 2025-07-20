using UnityEngine;
using TMPro;

public class JournalUI : MonoBehaviour
{
    public static JournalUI Instance;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject entryTextPrefab;
    [SerializeField] private Transform contentContainer;

    private bool isOpen = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isOpen)
                animator.SetTrigger("Hide");
            else
                animator.SetTrigger("Show");

            isOpen = !isOpen;
        }
    }

    public void AddVisualEntry(JournalEntry entry)
    {
        GameObject entryGO = Instantiate(entryTextPrefab, contentContainer);
        TextMeshProUGUI textComponent = entryGO.GetComponent<TextMeshProUGUI>();

        if (textComponent != null)
        {
            textComponent.text = entry.text;
        }
    }
}
