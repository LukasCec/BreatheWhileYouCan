using UnityEngine;

public class PersistentBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject sceneLoaderPrefab;
    [SerializeField] private GameObject gameManagerPrefab;

    private void Awake()
    {
        if (SceneLoader.Instance == null && sceneLoaderPrefab != null)
        {
            Instantiate(sceneLoaderPrefab);
        }

        if (GameManager.Instance == null && gameManagerPrefab != null)
        {
            Instantiate(gameManagerPrefab);
        }
    }
}
