using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMoivie : MonoBehaviour
{


    public Image image_offA;
    public Image image_offB;
    public Image image_offC;
    public Image image_offD;
    Image nowOff;

    public Image imageA;
    public Image imageB;
    public Image imageC;
    public Image imageD;
    Image nowMovie;

    public Sprite[] spritesA;
    public Sprite[] spritesB;
    public Sprite[] spritesC;
    public Sprite[] spritesD;
    public Sprite[] nowstripe;
    float nowTime = 0;
    float time = 0;
    float speed = 15;
    bool bSelect = false;
    int iT1 = 0;
    int selec=-1;
    void Start()
    {
        TowerManager.PlayerSelectTowerIndex = selec;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {

        //영상제생속도
        nowTime += speed * Time.deltaTime;
        iT1 = (int)nowTime;
        //영상시작\
        if (nowTime < 100&&bSelect==true)
        {
            nowMovie.sprite = nowstripe[iT1];

        }
        else if (nowTime > 100)
        {
            iT1 = 0;
            nowTime = 0;
        }

    }


    public void buttonA()
    {
        selec = 0;
        TowerManager.PlayerSelectTowerIndex = selec;
        imageA.sprite = spritesA[0];
        imageB.sprite = spritesB[0];
        imageC.sprite = spritesC[120];
        imageD.sprite = spritesD[58];
        iT1 = 0;
        nowTime = 0;
        speed = 15;
        nowMovie = imageA;

        nowstripe = spritesA;
        image_offA.gameObject.SetActive(false);
        image_offD.gameObject.SetActive(true);
        image_offC.gameObject.SetActive(true);
        image_offB.gameObject.SetActive(true);

        bSelect = true;

    }
    public void buttonB()
    {
        selec = 1;
        TowerManager.PlayerSelectTowerIndex = selec;
        imageA.sprite = spritesA[0];
        imageB.sprite = spritesB[0];
        imageC.sprite = spritesC[120];
        imageD.sprite = spritesD[58];
        iT1 = 0;
        nowTime = 0;
        speed = 30;
        nowMovie = imageB;

        nowstripe = spritesB;
        image_offA.gameObject.SetActive(true);
        image_offB.gameObject.SetActive(false);
        image_offC.gameObject.SetActive(true);
        image_offD.gameObject.SetActive(true);

        bSelect = true;



    }
    public void buttonC()
    {
        selec = 2;
        TowerManager.PlayerSelectTowerIndex = selec;
        imageA.sprite = spritesA[0];
        imageB.sprite = spritesB[0];
        imageC.sprite = spritesC[120];
        imageD.sprite = spritesD[58];
        iT1 = 0;
        nowTime = 0;
        speed = 40;
        nowMovie = imageC;

        nowstripe = spritesC;
        image_offA.gameObject.SetActive(true);
        image_offB.gameObject.SetActive(true);
        image_offC.gameObject.SetActive(false);
        image_offD.gameObject.SetActive(true);

        bSelect = true;

 


    }
    public void buttonD()
    {
        selec = 3;
        TowerManager.PlayerSelectTowerIndex = selec;
        imageA.sprite = spritesA[0];
        imageB.sprite = spritesB[0];
        imageC.sprite = spritesC[120];
        imageD.sprite = spritesD[58];
        iT1 = 0;
        nowTime = 0;
        speed = 50;
        nowMovie = imageD;

        nowstripe = spritesD;
        image_offA.gameObject.SetActive(true);
        image_offB.gameObject.SetActive(true);
        image_offC.gameObject.SetActive(true);
        image_offD.gameObject.SetActive(false);

        bSelect = true;
        

    }


}
