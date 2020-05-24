using UnityEngine;

namespace CookingWithUnity2.Episodes.Ep08TowerDefence
{
    public class Ep08PathThroughObjects : MonoBehaviour
    {
        public GameObject[] pathPoints;

        public float speed = 1f;
        //public float goalSize = 0.1f;


        private int _currentPathIndex;
        private Vector3 _movementDirection;


        private void Start()
        {
           _movementDirection = (pathPoints[_currentPathIndex].transform.position - transform.position).normalized;
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

        void SetPathPoints(GameObject[] inputPathPoints)
        {
            pathPoints = inputPathPoints;
        }
    }
}   