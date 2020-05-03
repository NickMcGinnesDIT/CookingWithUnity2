using UnityEngine;

namespace Episodes.Ep08TowerDefence
{
    public class Ep08BasicTower : MonoBehaviour
    {
        public GameObject bullet;
        public float bulletSpeed = 5f;
        public float fireRate = 1f;
        public float fireRadius = 5f;

        // Start is called before the first frame update

        void Start()
        {
            InvokeRepeating("SpawnBullet", 0f, fireRate);
        }

        void SpawnBullet()
        {
            GameObject target = null; //create target ref as null

            foreach (Collider col in Physics.OverlapSphere(transform.position, fireRadius))
            {
                if (col.tag.Equals("Enemy"))
                {
                    target = col.gameObject; //scan for targets and assign first one found
                    break;
                }
            }

            if (target != null) //check if target is no longer null, run code
            {
                GameObject newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);

                newBullet.GetComponent<Rigidbody>()
                    .AddForce((target.transform.position - transform.position).normalized * bulletSpeed,
                        ForceMode.VelocityChange);
            }


            /*  //redesign of code, you dont need gameobject refs, only vectors
            Vector3 spawnPosition = transform.position;
            Vector3 targetDirection = (GameObject.FindGameObjectWithTag("Enemy").transform.position - spawnPosition)
                .normalized;

            GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.Euler(targetDirection));
            newBullet.GetComponent<Rigidbody>().AddForce(targetDirection * bulletSpeed, ForceMode.VelocityChange);
            */
        }
    }
}