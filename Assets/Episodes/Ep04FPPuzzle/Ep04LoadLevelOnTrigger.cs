using UnityEngine;
using UnityEngine.SceneManagement;

namespace Episodes.Ep04FPPuzzle
{
    public class Ep04LoadLevelOnTrigger : MonoBehaviour
    {
        public string LevelName;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(LevelName);
            }
        }
    }
}