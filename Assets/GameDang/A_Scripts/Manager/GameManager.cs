using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void NewTowerSelect()
    {
        if (TowerManager.PlayerSelectTowerIndex != -1)
        {
            SceneManager.LoadScene("Battle _Kim");
        }
    }
}