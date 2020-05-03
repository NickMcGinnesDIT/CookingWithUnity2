using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep01MoveLeftAndRight : MonoBehaviour
{
    public float MoveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}