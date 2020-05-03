using UnityEngine;

namespace Episodes.Ep08TowerDefence
{
    public class Ep08CreateTowerOnClicked : MonoBehaviour
    {
        public GameObject towerPrefab;
        
        public void Clicked(Vector3 position)
        {
            Instantiate(towerPrefab, position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}