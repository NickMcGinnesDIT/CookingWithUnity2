using UnityEngine;

namespace Episodes.Ep01SpaceInvaders.Scripts
{
    public class ep03ChangeScoreOnCollide : MonoBehaviour
    {
        public int pointValue = 1;

        private void OnCollisionEnter(Collision collision)
        {
            ep03GameManager.Score += pointValue;
        }
    }
}