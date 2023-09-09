using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected Collider2D SongCollider;
    protected Collider2D PowerCollider1;
    protected Collider2D PowerCollider2;
    protected Collider2D PowerCollider3;
    protected Collider2D PowerCollider4;

    void Start()
    {
        SongRadius = 1f;
        SongPowerLevel = 1;
        SongIsPlaying = false;
        Initializtion();
        SetSongTime();
        StartPowers();
    }

    void StartPowers()
    {
        SongPower1.SetActive(false);
        SongPower2.SetActive(false);
        SongPower3.SetActive(false);
        SongPower4.SetActive(false);
    }

    void SetSongTime()
    {
        SongTime = 90f;
    }

    protected virtual void Initializtion()
    {
        SongCollider = SongObject.GetComponent<Collider2D>();
        PowerCollider1 = SongPower1.GetComponent<Collider2D>();
        PowerCollider2 = SongPower2.GetComponent<Collider2D>();
        PowerCollider3 = SongPower3.GetComponent<Collider2D>();
        PowerCollider4 = SongPower4.GetComponent<Collider2D>();
    }

    public 
    // Update is called once per frame
    void Update()
    {
        if(SongIsPlaying == false)
        {
            SongObject.SetActive(false);
        }
        if(SongIsPlaying == true)
        {
            if(SongTime > 0)
            {
                SongTime -= Time.deltaTime;
                SongObject.SetActive(true);
                SongObject.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
            }
            else
            {
                SongIsPlaying = false;
                SetSongTime();
            }
        }
        if(Input.GetButtonDown("PlaySong") && SongTime > 0)
        {
            SongIsPlaying = true;
        }
        if(Input.GetButton("StopSong"))
        {
            SongIsPlaying = false;
        }
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

    }
}
