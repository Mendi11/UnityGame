using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour
{

    Vector3 originalCameraPosition = new Vector3(-6.09f, 10.95f, -5.38f);

    float shakeAmt = 0;
    private Camera mainCamera;

    void Awake()
    {

        mainCamera = Camera.main;
        shakeAmt = 0.01f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;

    }

}