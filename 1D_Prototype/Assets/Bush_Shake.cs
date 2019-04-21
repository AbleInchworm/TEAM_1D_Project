using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush_Shake : MonoBehaviour
{
    public AudioSource bushSource;
    public AudioClip[] bushSFX;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomIndex = Random.Range(0, bushSFX.Length);
        bushSource.clip = bushSFX[randomIndex];
        bushSource.Play();
    }
}
