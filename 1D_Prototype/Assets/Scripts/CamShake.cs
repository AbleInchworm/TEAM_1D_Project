using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{
    public static CamShake instance;

    public float ShakeTime = 0.3f;
    public float ShakeAmplitude = 1.2f;
    public float ShakeFrequencey = 2.0f;
    private float ShakeElapsedTime = 0f;

    public CinemachineVirtualCamera VirtualCam;
    private CinemachineBasicMultiChannelPerlin vCamNoise;
    // Start is called before the first frame update
    void Start()
    {
        if (VirtualCam != null)
            vCamNoise = VirtualCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShakeDatCam();
        }
    }

    public void ShakeDatCam()
    {
        ShakeElapsedTime = ShakeTime;

        if (VirtualCam != null || vCamNoise != null)
        {
            if (ShakeElapsedTime > 0)
            {
                vCamNoise.m_AmplitudeGain = ShakeAmplitude;
                vCamNoise.m_FrequencyGain = ShakeFrequencey;

                ShakeElapsedTime -= Time.deltaTime;                
            }
            else
            {
                vCamNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }
}
