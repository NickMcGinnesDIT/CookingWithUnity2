using UnityEngine;

namespace CookingWithUnity2.Episodes.Ep08TowerDefence
{
    public class Ep10EnemySpawner : MonoBehaviour
    {
        public GameObject[] pathPoints;
        public GameObject[] spawnList;

        public float spawnTime = 0.5f;
        public GameObject graphicalPathObject;

        private int spawnIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating(methodName: "Spawn", time: 0f, repeatRate: spawnTime);
            CreateGraphicalPathObjects();
        }

        // Update is called once per frame
        void Update()
        {
        }

        void Spawn()
        {
            //spawn next enemy in the spawnlist
            GameObject reference = Instantiate(spawnList[spawnIndex], transform.position, Quaternion.identity);
            spawnIndex++;
            if (spawnIndex >= spawnList.Length)
            {
                CancelInvoke();
            }
            //set enemy path information
            reference.SendMessage("SetPathPoints", pathPoints);
        }

        void CreateGraphicalPathObjects()
        {
            //create object between transform.position and first waypoint
            Vector3 pathObjectPosition =
                ((pathPoints[0].transform.position - transform.position) * 0.5f) + transform.position;
            Quaternion pathObjectRotation =
                Quaternion.LookRotation(pathPoints[0].transform.position - transform.position);

            GameObject pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectRotation);

            Vector3 newScale = pathObject.transform.localScale;
            newScale.z = (pathPoints[0].transform.position - transform.position).magnitude / 10f;
            pathObject.transform.localScale = newScale;

            Vector2 newTextureScale = Vector2.one;
            newTextureScale.y = newScale.z * 2f;
            pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;

            for (int i = 1; i < pathPoints.Length; i++)
            {
                //stuff happens
                pathObjectPosition =
                    ((pathPoints[i].transform.position - pathPoints[i - 1].transform.position) * 0.5f) +
                    pathPoints[i - 1].transform.position;
                pathObjectRotation =
                    Quaternion.LookRotation(pathPoints[i].transform.position - pathPoints[i - 1].transform.position);

                pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectRotation);

                newScale = pathObject.transform.localScale;
                newScale.z = (pathPoints[i].transform.position - pathPoints[i - 1].transform.position).magnitude / 10f;
                pathObject.transform.localScale = newScale;

                newTextureScale = Vector2.one;
                newTextureScale.y = newScale.z * 2f;
                pathObject.GetComponent<Renderer>().material.mainTextureScale = newTextureScale;
            }
        }
    }
}