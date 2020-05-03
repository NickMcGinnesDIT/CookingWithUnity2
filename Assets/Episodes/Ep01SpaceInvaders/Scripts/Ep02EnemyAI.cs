using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep02EnemyAI : MonoBehaviour
{
    public float Speed = 2f;
    public float RightEdgePadding;
    public float LeftEdgePadding;
    public float DropDistance;

    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += Speed * direction * Time.deltaTime;
        transform.position = newPosition;


        if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width)
        {
            direction = -1;
            newPosition = transform.position;
            float cameraObjectDifference = transform.position.z - Camera.main.transform.position.z;
            newPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, cameraObjectDifference)).x;
            newPosition.y -= DropDistance;
            transform.position = newPosition;
        }

        if (Camera.main.WorldToScreenPoint(transform.position).x < 0f + LeftEdgePadding)
        {
            direction = 1;
            newPosition = transform.position;
            float cameraObjectDifference = transform.position.z - Camera.main.transform.position.z;
            newPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cameraObjectDifference)).x;
            newPosition.y -= DropDistance;
            transform.position = newPosition;
        }
    }

    void DropPostion(float xPos)
    {
        Vector3 np = transform.position;
        np.y -= DropDistance;
        np.x = xPos;
        transform.position = np;
    }
}