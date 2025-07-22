using UnityEngine;

public class YoungerSelfMover : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float speed = 1.5f;

    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}
