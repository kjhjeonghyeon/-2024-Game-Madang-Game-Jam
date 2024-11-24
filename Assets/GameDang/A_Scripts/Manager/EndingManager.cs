using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{

    [SerializeField] List<GameObject> endings;
    private void Start()
    {
        endings[TowerManager.PlayerSelectTowerIndex].SetActive(true);
    }
}
