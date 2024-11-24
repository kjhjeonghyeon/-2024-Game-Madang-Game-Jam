using UnityEngine;

public class Fade : MonoBehaviour
{
   public  GameObject fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeOut()
    {
        fade.SetActive(true);
    }
}
