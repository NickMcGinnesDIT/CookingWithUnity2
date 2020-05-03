using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public GameObject DeathAudioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (DeathAudioSource != null)
            Instantiate(DeathAudioSource);

        Destroy(gameObject);
    }
}