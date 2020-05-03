using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionOnSphere : MonoBehaviour
{
    public float SphereSize = 10f;

    public int Seed = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Random.seed = Seed;

        foreach (GameObject cu in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cu.transform.position = Random.onUnitSphere * SphereSize;
            //cu.transform.localScale = new Vector3(1, Random.value * MaxHeight, 1);
        }
    }
}