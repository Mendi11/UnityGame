using UnityEngine;
using System.Collections;

public class Screenshake : MonoBehaviour
{

    Vector3 moriginalCameraPosition = new Vector3(-6.09f, 10.95f, -5.38f);

    float mshakeAmt = 0;
    private Camera mmainCamera;

    void Awake()
    {

        mmainCamera = Camera.main;
        mshakeAmt = 0.01f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }

    void CameraShake()
    {
        if (mshakeAmt > 0)
        {
            float quakeAmt = Random.value * mshakeAmt * 2 - mshakeAmt;
            Vector3 pp = mmainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            mmainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mmainCamera.transform.position = moriginalCameraPosition;

    }

}