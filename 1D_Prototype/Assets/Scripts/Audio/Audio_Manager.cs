using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance = null;

    public float pitchMin;
    public float pitchMax;


    public AudioClip[] playerFS;
    public AudioSource playerSFX;
    public AudioMixerGroup playerMixer;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null) { instance = this; } // Checks if there is already a Audio manager and removes it
        else if (instance != this) { Destroy(gameObject);}

        DontDestroyOnLoad(gameObject); // Don't get rid of the audio manager when the scene changes
    }


    void Start()
    {
        //playerSFX = gameObject.AddComponent<AudioSource>(); // Adds master player AudioSource on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerFS()
    {
        int randomFS = Random.Range(0, playerFS.Length);        
    }

    public void RandomizeSFX (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, playerFS.Length);
        float randomPitch = Random.Range(pitchMin, pitchMax);

        playerSFX.pitch = randomPitch;
        playerSFX.clip = clips[randomIndex];
        playerSFX.Play();

    }

    public void PlaySound (AudioClip clip)
    {
        playerSFX.clip = clip;
        playerSFX.Play();
    }
}
