using UnityEngine;

public class Ep05ActiveateBridge : MonoBehaviour
{
    public GameObject Bridge;
    public GameObject Key;

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
        if (other.CompareTag(gameObject.tag))
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
            {
                obj.SendMessage("ObjectActivate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
            {
                obj.SendMessage("ObjectDeactivate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}