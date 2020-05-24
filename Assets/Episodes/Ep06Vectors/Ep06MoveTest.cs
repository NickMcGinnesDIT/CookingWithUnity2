using UnityEngine;

namespace Episodes.Ep06Vectors
{
    public class Ep06MoveTest : MonoBehaviour
    {
        //public Vector3 MovementDirection;
        public float Speed = 1f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //transform.position += MovementDirection * Time.deltaTime;
            //transform.position += Vector3.up * Speed;
            transform.position += transform.forward * Speed;
        }
    }
}