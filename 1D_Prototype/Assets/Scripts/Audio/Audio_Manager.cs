using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance = null;

    public float pitchMin;
    public float pitchMax;
    public float sourceVol;

    public AudioClip[] playerFSGrass;
    public AudioClip[] playerFSConcrete;
    public AudioClip[] playerDeath;
    public AudioSource playerSFX;
    public AudioMixerGroup playerMixer;

    AudioSource m_MyAudioSource;
    GameObject myplayerSFX;

    private void Awake()
    {
        if (instance == null) { instance = this; } // Checks if there is already a Audio manager and removes it
        else if (instance != this) { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject); // Don't get rid of the audio manager when the scene changes
    }

    void Start()
    {
        //playerSFX = gameObject.AddComponent<AudioSource>(); // Adds master player AudioSource on start
    }

    // Update is called once per frame
    void Update()
    {
        myplayerSFX = GameObject.Find("playerSFX");
        m_MyAudioSource = myplayerSFX.GetComponent<AudioSource>();
        playerSFX = m_MyAudioSource;
    }

    public void RandomPlayerFS (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, playerFSGrass.Length); // randomly select a clip from the footstep sound array
        float randomPitch = Random.Range(pitchMin, pitchMax); // randomlly assign a pitch to that sound

        playerSFX.pitch = randomPitch;
        playerSFX.clip = clips[randomIndex];
        playerSFX.Play();
    }

    public void RandomDeath(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, playerDeath.Length); // randomly select a clip from the death sound array
        float randomPitch = Random.Range(pitchMin, pitchMax); // randomlly assign a pitch to that sound

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
