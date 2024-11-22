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
    public Image nowOff;

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
    int iT1=0;
    int iT2=0;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        time += speed * Time.deltaTime;
       iT1 = (int)time;
       iT2 = (int)nowTime;
        nowTime += speed * Time.deltaTime;
        
        if (iT1==0)
        {
            speed = 15;
            nowMovie = imageA;
            nowOff = image_offA;
            nowstripe=spritesA;
            image_offD.gameObject.SetActive(true);
            nowOff.gameObject.SetActive(false);

            nowTime = 0;
        }
        if (iT1 == 60)
        {
            speed = 30;
            nowMovie = imageB;
            nowOff = image_offB;
            nowstripe=spritesB;
            image_offA.gameObject.SetActive(true);
            nowOff.gameObject.SetActive(false);

            nowTime = 0;
        }
        if (iT1==130)
        {
            speed = 50;
            nowMovie = imageC;
            nowOff = image_offC;
            nowstripe = spritesC;
            image_offB.gameObject.SetActive(true);
            nowOff.gameObject.SetActive(false);

            nowTime = 0;
        }
        if (iT1== 240)
        {
            speed = 30;
            nowMovie = imageD;
            nowOff = image_offD;
            nowstripe=spritesD;
            image_offC.gameObject.SetActive(true);
            nowOff.gameObject.SetActive(false);
            nowTime = 0;

        }
        else if (iT1 >320)
        {
            time = 0;
            image_offD.gameObject.SetActive(true);
            nowOff.gameObject.SetActive(false);
            nowTime = 0;
        }
        nowMovie.sprite = nowstripe[iT2];
    }

  
}
