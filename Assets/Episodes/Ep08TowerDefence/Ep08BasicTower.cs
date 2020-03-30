using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep08BasicTower : MonoBehaviour
{

    public GameObject bullet;
    public float bulletSpeed = 5f;
    public float fireRate = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet",0f,fireRate);
    }

    void SpawnBullet()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");
        GameObject newBullet = Instantiate(bullet, transform.position,  Quaternion.Euler(target.transform.position - transform.position).normalized);
        newBullet.GetComponent<Rigidbody>().AddForce((target.transform.position - transform.position).normalized * bulletSpeed,ForceMode.VelocityChange);
    }
}
