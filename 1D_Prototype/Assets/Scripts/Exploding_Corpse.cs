using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding_Corpse : MonoBehaviour {

    public ParticleSystem explode;

    public void Playexplode()
    {
        explode.Play();
    }  
}
