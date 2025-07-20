using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Debug.Log("GameManager initialized");
        DontDestroyOnLoad(gameObject);
    }

    
    public bool subtitlesEnabled = true;
    public float subtitleFontSize = 1f;

    
}
