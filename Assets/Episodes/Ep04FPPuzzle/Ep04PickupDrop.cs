using UnityEngine;

namespace Episodes.Ep04FPPuzzle
{
    public class Ep04PickupDrop : MonoBehaviour
    {
        public float PickupDistance = 5f;
        public float HoldDistance = 4f;
        public LayerMask PickupMask;
        private bool _isHoldingSomething = false;
        [SerializeField] private GameObject _heldObject;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            PickupCheck();
        }

        private void PickupCheck()
        {
            RaycastHit hitinfo;


            if (!_isHoldingSomething)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //we are not holding an object
                    if (Physics.Raycast(transform.position, transform.forward, out hitinfo, PickupDistance, PickupMask))
                    {
                        Debug.Log("Looking at " + hitinfo.collider);
                        hitinfo.collider.transform.parent = transform.parent;
                        hitinfo.collider.GetComponent<Rigidbody>().isKinematic = true;
                        _heldObject = hitinfo.collider.gameObject;
                        _isHoldingSomething = true;
                    }
                }
            }
            else
            {
                //we are holding an object
                Vector3 newPosition = transform.position;
                newPosition += transform.forward * HoldDistance;
                _heldObject.transform.position = newPosition;


                if (Input.GetMouseButtonDown(0))
                {
                    _heldObject.GetComponent<Rigidbody>().isKinematic = false;
                    _heldObject.transform.parent = null;
                    _heldObject = null;
                    _isHoldingSomething = false;
                }
            }
        }
    }
}