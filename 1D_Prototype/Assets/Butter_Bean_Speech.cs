using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter_Bean_Speech : MonoBehaviour
{
    public AudioSource butterBean;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        butterBean.Play();
    }

}
