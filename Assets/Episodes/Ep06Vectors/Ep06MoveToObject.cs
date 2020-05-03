using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep06MoveToObject : MonoBehaviour
{
    public float Speed = .1f;

    public GameObject goalObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (goalObject.transform.position - transform.position).normalized * Speed * Time.deltaTime;
    }
}