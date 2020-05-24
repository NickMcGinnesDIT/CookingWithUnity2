using UnityEngine;

namespace Episodes.Ep04FPPuzzle
{
    public class Ep05EnableCollisionAndChangeMaterial : MonoBehaviour
    {
        public Material ActiveMaterial;
        private Material InactiveMaterial;


        private void Start()
        {
            InactiveMaterial = GetComponent<Renderer>().material;
        }

        void ObjectActivate()
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<Renderer>().material = ActiveMaterial;
        }

        void ObjectDeactivate()
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().material = InactiveMaterial;
        }
    }
}