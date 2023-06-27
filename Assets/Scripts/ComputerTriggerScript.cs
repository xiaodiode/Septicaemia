

#pragma warning disable 0618




using System.Collections;
using UnityEngine;


public class ComputerTriggerScript : MonoBehaviour
{
    public GameObject computerScreen;
    public Material computerOnMaterial;
    public Material computerOffMaterial;
    public AudioClip startupSound;
    public AudioClip exitSound;
    public AudioSource startupAudioSource;
    public AudioSource exitAudioSource;


    private Material previousMaterial;
    private Renderer computerScreenRenderer;
    private bool isComputerActive = false;
    private bool canExitComputer = false;
    private bool canEnterComputer = true;
    private float computerActiveTime = 0f;
    private float computerExitDelay = 10f; // Exit delay in seconds
    private float computerEnterDelay = 3f; // Enter delay in seconds
    private const float materialChangeDelay = 1f; // Material change delay in seconds


    private void Start()
    {
        computerScreenRenderer = computerScreen.GetComponent<Renderer>();
        previousMaterial = computerScreenRenderer.material;


        // Add an AudioSource component for the exit sound
        exitAudioSource = gameObject.AddComponent<AudioSource>();
        exitAudioSource.playOnAwake = false;
        exitAudioSource.clip = exitSound;
        exitAudioSource.spatialBlend = 0f; // Make the sound non-spatial


        // Assign the startup sound clip to the existing AudioSource component
        startupAudioSource.clip = startupSound;
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isComputerActive && canEnterComputer)
            {
                StartCoroutine(ChangeMaterialWithDelay(computerOnMaterial));
                canEnterComputer = false;
                StartCoroutine(EnableComputerEntry());
                startupAudioSource.Play(); // Add this line to play the startup sound
            }
        }
    }



    private void Update()
    {
        if (isComputerActive)
        {
            computerActiveTime += Time.deltaTime;


            if (Input.GetKeyDown(KeyCode.S) && canExitComputer && computerActiveTime >= computerExitDelay)
            {
                StartCoroutine(ChangeMaterialWithDelay(computerOffMaterial));
                PlayComputerExitSound();
                canEnterComputer = false;
                StartCoroutine(EnableComputerEntry());
            }
        }
    }


    private void PlayComputerExitSound()
    {
        exitAudioSource.Play();
    }


    private IEnumerator ChangeMaterialWithDelay(Material material)
    {
        yield return new WaitForSeconds(materialChangeDelay);
        computerScreenRenderer.material = material;
        if (material == computerOnMaterial)
        {
            isComputerActive = true;
            canExitComputer = true;
        }
        else if (material == computerOffMaterial)
        {
            isComputerActive = false;
            canExitComputer = false;
            computerActiveTime = 0f;
        }
    }


    private IEnumerator EnableComputerEntry()
    {
        yield return new WaitForSeconds(computerEnterDelay);
        canEnterComputer = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        canExitComputer = true;
    }


    private void OnTriggerExit(Collider other)
    {
        canExitComputer = false;
    }
}



