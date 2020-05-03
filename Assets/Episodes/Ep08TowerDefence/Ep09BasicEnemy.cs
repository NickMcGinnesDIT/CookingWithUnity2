using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Episodes.Ep08TowerDefence
{
    public class Ep09BasicEnemy : MonoBehaviour
    {
        public int health = 10;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag.Equals("Bullet"))
            {
                Destroy(collision.gameObject);
                health--;
                Debug.Log(string.Format("Hit, {0}, {1}", health,Time.time));
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}