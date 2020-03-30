using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ep08CreateTowerOnClicked : MonoBehaviour
{

    public GameObject TowerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked(Vector3 position)
    {
        Instantiate(TowerPrefab, position + Vector3.up * 0.5f, Quaternion.identity);
    }
}
