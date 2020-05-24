using UnityEngine;

namespace Episodes.Ep01SpaceInvaders.Scripts
{
    public class ep03GameOverOnCollide : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            ep03GameManager.GameOver = true;
        }
    }
}