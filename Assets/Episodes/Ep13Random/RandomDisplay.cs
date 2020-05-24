using UnityEngine;

namespace Episodes.Ep13Random
{
    public class RandomDisplay : MonoBehaviour
    {
        private string _outputString = "0";
        private string _outputString1 = "0";

        private string _outputString2 = "0";

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnGUI()
        {
            GUILayout.Label(_outputString);
            GUILayout.Label(_outputString1);
            GUILayout.Label(_outputString2);

            if (GUILayout.Button("Random.Value"))
            {
                _outputString = Random.value.ToString();
            }

            if (GUILayout.Button("Random.Range"))
            {
                _outputString = Random.Range(0, 100).ToString();
            }

            if (GUILayout.Button("Random.insideUnitSphere"))
            {
                _outputString = Random.insideUnitSphere.x.ToString();
                _outputString1 = Random.insideUnitSphere.y.ToString();
                _outputString2 = Random.insideUnitSphere.z.ToString();
            }

            if (GUILayout.Button("Random.insideUnitCircle"))
            {
                _outputString = Random.insideUnitCircle.x.ToString();
                _outputString1 = Random.insideUnitCircle.y.ToString();
                //_outputString2 = Random.insideUnitCircle.z.ToString();
            }

            if (GUILayout.Button("Random.onUnitSphere"))
            {
                _outputString = Random.onUnitSphere.x.ToString();
                _outputString1 = Random.onUnitSphere.y.ToString();
                _outputString2 = Random.onUnitSphere.z.ToString();
            }
        }
    }
}