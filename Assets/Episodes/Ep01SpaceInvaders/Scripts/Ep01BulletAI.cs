using UnityEngine;

namespace Episodes.Ep01SpaceInvaders.Scripts
{
    public class Ep01BulletAI : MonoBehaviour
    {
        public float Speed = 5f;

        // Start is called before the first frame update
        void Start()
        {
            Vector3 newVelocity = Vector3.zero;
            newVelocity.y += Speed;
            GetComponent<Rigidbody>().velocity = newVelocity;
        }

        // Update is called once per frame
        void Update()
        {
            /*
        Vector3 newPosition = transform.position;
        newPosition.y += Speed * Time.deltaTime;
        transform.position = newPosition;
        */
        }
    }
}