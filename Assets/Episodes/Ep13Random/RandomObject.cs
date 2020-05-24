using UnityEngine;

namespace Episodes.Ep13Random
{
    public class RandomObject : MonoBehaviour
    {
        public GameObject[] thingies;
        public Material[] mats;
        public float spawnDelay = 5f;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("SpawnThing", 1f, spawnDelay);
        }

        // Update is called once per frame
        void Update()
        {
        }

        void SpawnThing()
        {
            GameObject cu = Instantiate(thingies[Random.Range(0, thingies.Length)], transform.position, transform.rotation);
            cu.gameObject.GetComponent<Renderer>().material = mats[Random.Range(0, mats.Length)];
        }
    }
}