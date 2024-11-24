using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void OnEnable()
    {
        TowerManager.activeKeys = new HashSet<int>(){0,1,2,3};
    }
}
