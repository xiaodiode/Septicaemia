using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;

    private float rotationSpeed = (77.2f / 12) / 60f /12;  // Speed of the hour hand in degrees per second
    private float slowRotationSpeed = (77.2f / 12) / 60f;  // Speed of the minute hand in degrees per second

    private void Update()
    {
        // Calculate the rotation angles based on time
        float hourAngle = Time.time * rotationSpeed % 360f;
        float minuteAngle = Time.time * slowRotationSpeed % 360f;

        // Apply rotation to the clock hands
        hourHand.localRotation = Quaternion.Euler(-hourAngle, 90f, 0f);
        minuteHand.localRotation = Quaternion.Euler(-minuteAngle, 90f, 0f);
    }
}
