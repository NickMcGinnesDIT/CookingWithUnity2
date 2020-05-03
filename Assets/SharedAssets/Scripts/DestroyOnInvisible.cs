using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    //if the object stays on screen for longer than timer it destroys
    public float Timer = 30f;
    private float t = 0f;

    private void Update()
    {
        t += Time.deltaTime;
        if (t > Timer)
            Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}