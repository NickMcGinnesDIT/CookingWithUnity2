using UnityEngine;

namespace Episodes.Ep08TowerDefence
{
    public class Ep08PathThroughObjects : MonoBehaviour
    {
        public GameObject[] pathPoints;
        public float speed = 1f;
        public float goalSize = 0.1f;

        public GameObject graphicalPathObject;

        private int _currentPathIndex;
        private Vector3 _movementDirection;


        private void Start()
        {
            _movementDirection = (pathPoints[_currentPathIndex].transform.position - transform.position).normalized;
            CreateGraphicalPathObjects();
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

        void Update()
        {
            //movement code
            transform.position += _movementDirection * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == pathPoints[_currentPathIndex])
            {
                Transform myTransform = transform;
                myTransform.position = pathPoints[_currentPathIndex].transform.position;
                _currentPathIndex++;
                if (_currentPathIndex >= pathPoints.Length)
                {
                    //add logic to deduct health from player
                    Destroy(gameObject);
                }
                else
                {
                    _movementDirection =
                        (pathPoints[_currentPathIndex].transform.position - myTransform.position).normalized;
                }
            }
        }
    }
}