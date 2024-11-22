using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void TowerSelect(int index)
    {
        TowerManager.PlayerSelectTowerIndex = index;

        // 이후 Scene 변경?
        //
        SceneManager.LoadScene("Game_ptk_2");
    }
}