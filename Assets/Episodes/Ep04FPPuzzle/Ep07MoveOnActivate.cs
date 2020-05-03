using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep07MoveOnActivate : MonoBehaviour
{
    public Vector3 MovementVector;
    public float MovementTime = 2f;

    private Vector3 _startPosition;
    private bool _canMove = false;

    private bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        StartCoroutine(MoveOverTime());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ObjectActivate()
    {
        _canMove = true;
    }

    void ObjectDeactivate()
    {
        _canMove = false;
    }

    IEnumerator MoveOverTime()
    {
        float timer = 0;

        while (true)
        {
            if (_canMove)
            {
                if (!reverse)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

                if (timer > MovementTime && !reverse)
                    reverse = true;
                if (timer < 0f && reverse)
                    reverse = false;

                transform.position =
                    Vector3.Lerp(_startPosition, _startPosition + MovementVector, timer / MovementTime);
            }

            yield return null;
        }
    }
}