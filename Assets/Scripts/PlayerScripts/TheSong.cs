using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class TheSong : MonoBehaviour
{
    
    public GameObject SongObject;
    public float SongRadius;
    public int SongPowerLevel;
    static public float SongTime;
    public bool SongIsPlaying;
    public float SongBaseTime;
    public bool ResetReady;
    protected Collider2D SongCollider;
    public TextMeshProUGUI SongTimeText;
    public string SongHUDText;
    public LayerMask SongLayer;

    void Start()
    {
        //SongTimeHUD();
        Initialization();
        //SetSongTime();
    }
    // Sets the power bools for character power level.


    void SetSongTime()
    {
        SongTime = SongBaseTime * SongPowerLevel;
    }
    //Sets all variables and objects to the correct starting setting
    protected virtual void Initialization()
    {
        SongCollider = SongObject.GetComponent<Collider2D>();
        SongRadius = 4f;
        SongPowerLevel = 2;
        SongIsPlaying = false;
    }

    public 
    // Update is called once per frame
    void Update()
    {
        SongObject.gameObject.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
        SongTimeHUD();
        if(Input.GetButtonDown("PlaySong") && SongTime > 0)
        {
            toggleSong();
        }
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
            }
            else
            {
                SongIsPlaying = false;
            }
        }
        if(Input.GetButtonDown("Interact") && ResetReady == true)
        {
            SetSongTime();
        }

    }
    // Triggers effect based on active power
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "RecordPlayer")
            {
                ResetReady = true;
            }
            if(SongIsPlaying == true)
            {
                if(other.tag == "Power1" && SongPowerLevel >= 2)
                {
                    other.gameObject.SetActive(false);
                }
            }
            else
            {
                return;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "RecordPlayer")
            {
                ResetReady = false;
            }
            else
            {
                return;
            }
        }
        private void SongTimeHUD()
        {
            TimeSpan SongTimeSpan = TimeSpan.FromSeconds(SongTime);
            SongHUDText = string.Format("Song Time: {0:D2}:{1:D2}", SongTimeSpan.Minutes, SongTimeSpan.Seconds);
            SongTimeText.text = SongHUDText;
        }
        void toggleSong()
        {
            if(SongIsPlaying == false)
            {
                SongIsPlaying = true;
            }
            else
            {
                SongIsPlaying = false;
            }
        }
}
