// Attach this script to the fan's rotating element GameObject

using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Rotate the fan's rotating element around its local right axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
