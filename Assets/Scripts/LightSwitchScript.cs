using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;
    public Light spotlight1;
    public Light spotlight2;
    public Light pointLight;
    public float intensityDecreaseAmount = 0.3f;
    public AudioSource audioSource;
    public AudioClip clickSound;

    private Renderer lampRenderer;
    private bool isLightOn = true;

    private float originalIntensity;

    private void Start()
    {
        lampRenderer = GetComponent<Renderer>();
        lampRenderer.material = onMaterial;
        spotlight1.enabled = isLightOn;
        spotlight2.enabled = isLightOn;

        if (pointLight != null)
        {
            originalIntensity = pointLight.intensity;
        }
    }

    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        lampRenderer.material = isLightOn ? onMaterial : offMaterial;
        spotlight1.enabled = isLightOn;
        spotlight2.enabled = isLightOn;

        if (pointLight != null)
        {
            if (isLightOn)
            {
                pointLight.intensity = originalIntensity;
            }
            else
            {
                pointLight.intensity -= intensityDecreaseAmount;
            }
        }

        PlayClickSound();
    }

    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private void OnMouseDown()
    {
        ToggleLight();
    }
}
