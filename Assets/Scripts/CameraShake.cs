using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;
    private void Awake()
        /* Awake runs once before the game starts
         *  (it is used here b/c we must get the camera component)
         */
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    public void CinemachineCameraShaker(float intensity, float time)
        /* Takes in two args that dictate the camera shakes time and intensity
         */
    {
        
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        // Must get a component of the cinemachine camera

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        // Withing that component we must get the amplitude gain and set it to the intensity
        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;

    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                //Time is over

                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                // Must get a component of the cinemachine camera

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                Mathf.Lerp(startingIntensity, 0f, (1-(shakeTimer / shakeTimerTotal)));
            }
        }
    }
}
