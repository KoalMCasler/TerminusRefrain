using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TheSong : MonoBehaviour
{
    
    public GameObject SongObject;
    public GameObject SongPower1;
    public GameObject SongPower2;
    public GameObject SongPower3;
    public GameObject SongPower4;
    public float SongRadius;
    public int SongPowerLevel;
    public float SongTime;
    public bool SongIsPlaying;
    public float SongBaseTime;
    public bool ResetReady;
    protected Collider2D SongCollider;
    protected Collider2D PowerCollider1;
    protected Collider2D PowerCollider2;
    protected Collider2D PowerCollider3;
    protected Collider2D PowerCollider4;
    public TextMeshProUGUI SongTimeText;
    public string SongHUDText;

    void Start()
    {
        SongTimeHUD();
        Initializtion();
        SetSongTime();
        StartPowers();
    }
    // Sets the power bools for character power level.
    void StartPowers()
    {
        SongPower1.SetActive(false);
        SongPower2.SetActive(false);
        SongPower3.SetActive(false);
        SongPower4.SetActive(false);
    }

    void SetSongTime()
    {
        SongTime = SongBaseTime * SongPowerLevel;
    }
    //Sets all variables and objects to the correct starting setting
    protected virtual void Initializtion()
    {
        SongCollider = SongObject.GetComponent<Collider2D>();
        PowerCollider1 = SongPower1.GetComponent<Collider2D>();
        PowerCollider2 = SongPower2.GetComponent<Collider2D>();
        PowerCollider3 = SongPower3.GetComponent<Collider2D>();
        PowerCollider4 = SongPower4.GetComponent<Collider2D>();
        SongRadius = 4f;
        SongPowerLevel = 2;
        SongIsPlaying = false;
    }

    public 
    // Update is called once per frame
    void Update()
    {
        SongTimeHUD();
        // Makes sure the song is only playing when told to.
        if(SongIsPlaying == false)
        {
            SongObject.SetActive(false);
        }
        // Sets song object active and starts song count down to limit song plat time. 
        if(SongIsPlaying == true)
        {
            if(SongTime > 0)
            {
                SongTime -= Time.deltaTime;
                SongObject.SetActive(true);
                SongObject.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
                SongPower1.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
                SongPower2.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
                SongPower3.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
                SongPower4.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
                
            }
            else
            {
                SongIsPlaying = false;
            }
        }
        // Song input
        if(Input.GetButtonDown("PlaySong") && SongTime > 0)
        {
            SongIsPlaying = true;
        }
        if(Input.GetButton("StopSong"))
        {
            SongIsPlaying = false;
        }
        if(Input.GetButtonDown("Interact") && ResetReady == true)
        {
            SetSongTime();
        }
        // Sets song powers to active if song is playing and specific power bools true
        if(SongPowerLevel == 2 && SongIsPlaying == true)
        {
            SongPower1.SetActive(true);
        }
        else
        {
            SongPower1.SetActive(false);
        }
        if(SongPowerLevel == 3 && SongIsPlaying == true)
        {
            SongPower2.SetActive(true);
        }
        else
        {
            SongPower2.SetActive(false);
        }
        if(SongPowerLevel == 4 && SongIsPlaying == true)
        {
            SongPower3.SetActive(true);
        }
        else
        {
            SongPower3.SetActive(false);
        }
        if(SongPowerLevel == 5 && SongIsPlaying == true)
        {
            SongPower4.SetActive(true);
        }
        else
        {
            SongPower4.SetActive(false);
        }
        if(Input.GetButtonDown("Interact") && ResetReady == true)
        {
            SetSongTime();
        }

    }
    // Triggers effect based on active power
        private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Power1" && SongPowerLevel >= 2) 
        {
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Power2" && SongPowerLevel >= 3) 
        {
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Power3" && SongPowerLevel >= 4) 
        {
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Power4" && SongPowerLevel >= 5) 
        {
            other.gameObject.SetActive(false);
        }
        if(other.tag == "RecordPlayer")
        {
            ResetReady = true;
        }
    }
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "RecordPlayer")
            {
                ResetReady = false;
            }
        }
        private void SongTimeHUD()
        {
            TimeSpan SongTimeSpan = TimeSpan.FromSeconds(SongTime);
            SongHUDText = string.Format("Song Time: {0:D2}:{1:D2}", SongTimeSpan.Minutes, SongTimeSpan.Seconds);
            SongTimeText.text = SongHUDText;
        }
}
