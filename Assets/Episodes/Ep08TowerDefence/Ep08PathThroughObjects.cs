using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep08PathThroughObjects : MonoBehaviour
{
	public GameObject[] PathPoints;
	public float Speed = 1f;
	public float goalSize = 0.1f;
	
	private int _currentPathIndex = 0;
	private Vector3 _movementDirection;


	private void Start()
	{
		_movementDirection = (PathPoints[_currentPathIndex].transform.position - transform.position).normalized;
	}

	// Update is called once per frame
	void Update()
	{
		
		//movement code
		transform.position += _movementDirection * Speed * Time.deltaTime;
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == PathPoints[_currentPathIndex])
		{
			transform.position = PathPoints[_currentPathIndex].transform.position;
			_currentPathIndex++;
			_movementDirection = (PathPoints[_currentPathIndex].transform.position - transform.position).normalized;
			
		}
	}
}