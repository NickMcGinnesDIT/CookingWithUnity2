using System.Collections;
using UnityEngine;

namespace Episodes.Ep06Vectors
{
    public class Ep06RotateTowardAndMoveForward : MonoBehaviour
    {
        public float Speed = .1f;
        public float RotationTime;
        public GameObject goalObject;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(RotateOverTime(RotationTime));
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        IEnumerator RotateOverTime(float time)
        {
            float currentTime = 0;
            while (true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.LookRotation(goalObject.transform.position - transform.position), time * Time.deltaTime);
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}