using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void TowerSelect(int index)
    {

        TowerManager.PlayerSelectTowerIndex = index;

        // 이후 Scene 변경?

        SceneManager.LoadScene("Game_ptk_2");

    }
    public void NewTowerSelect()
    {

        // TowerManager.PlayerSelectTowerIndex = index;

        // 이후 Scene 변경?
        if (TowerManager.PlayerSelectTowerIndex != -1)
        {
            SceneManager.LoadScene("Game_ptk_2");
        }

    }
}