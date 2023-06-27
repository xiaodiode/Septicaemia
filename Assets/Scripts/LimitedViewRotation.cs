using UnityEngine;

public class LimitedViewRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        // Check for rotation input
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation *= Quaternion.Euler(0f, 90f, 0f);
        }

        // Smoothly rotate the camera towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
