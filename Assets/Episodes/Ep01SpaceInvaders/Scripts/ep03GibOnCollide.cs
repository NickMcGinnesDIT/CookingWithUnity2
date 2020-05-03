using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep03GibOnCollide : MonoBehaviour
{
    public bool Gib = false;
    public GameObject[] Gibs;

    public GameObject DeathAudioSource;

    public float ExplosionForce = 100f;

    public float SpawnRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Gib)
            DoGib();

        if (DeathAudioSource != null)
            Instantiate(DeathAudioSource);

        Destroy(gameObject);
    }

    private void DoGib()
    {
        foreach (GameObject gib in Gibs)
        {
            GameObject instance = Instantiate(gib, transform.position + Random.insideUnitSphere * SpawnRadius,
                transform.rotation);
            instance.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, transform.position, SpawnRadius);
        }
    }
}