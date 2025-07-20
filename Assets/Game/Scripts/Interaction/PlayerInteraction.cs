using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private LayerMask interactLayer;

    private Camera cam;
    private InteractionPromptUI promptUI;

    void Awake()
    {
        promptUI = FindObjectOfType<InteractionPromptUI>();
    }


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        ShowPrompt();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }


    void TryInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    void ShowPrompt()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                promptUI.Show(interactable.interactionPrompt);
                return;
            }
        }

        promptUI.Hide();
    }

}
