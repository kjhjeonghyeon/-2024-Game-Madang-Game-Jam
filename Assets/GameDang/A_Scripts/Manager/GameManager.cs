using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string GameScene;
    public void NewTowerSelect()
    {
        if (TowerManager.PlayerSelectTowerIndex != -1)
        {
            SceneManager.LoadScene("Battle");
        }
    }

    public void StartScene()
    {

        GameScene = "Start";
        Invoke("SlowScene", 0.9f);
    }
    public void SelsectScene()
    {

        GameScene = "Select";
        Invoke("SlowScene", 4f);
    }
    void SlowScene()
    {
        SceneManager.LoadScene(GameScene);
    }
}