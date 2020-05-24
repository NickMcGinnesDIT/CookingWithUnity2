using UnityEngine;

namespace Episodes.Ep13Random
{
    public class RandomCameraShake : MonoBehaviour
    {
        public Vector3 OriginalPosition;

        public float Intensity = 1f;

        // Start is called before the first frame update
        void Start()
        {
            OriginalPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = OriginalPosition + (Random.insideUnitSphere * Intensity);
        }
    }
}