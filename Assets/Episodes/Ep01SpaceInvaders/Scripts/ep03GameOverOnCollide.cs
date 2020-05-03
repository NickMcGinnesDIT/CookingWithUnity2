using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep03GameOverOnCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ep03GameManager.GameOver = true;
    }
}