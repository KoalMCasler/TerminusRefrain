using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSong : MonoBehaviour
{
    public GameObject SongObject;
    public float SongRadius;
    public int SongPower;
    public float SongTime;
    public bool SongIsPlaying;
    protected Collider2D SongCollider;

    void Start()
    {
        SongRadius = 1f;
        SongPower = 1;
        SongTime = 1f;
        SongIsPlaying = false;
        Initializtion();
    }

    protected virtual void Initializtion()
    {
        SongCollider = SongObject.GetComponent<Collider2D>();
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
            SongObject.SetActive(true);
            SongObject.transform.localScale = new Vector3(SongRadius,SongRadius,SongRadius);
        }
        if(Input.GetButtonDown("PlaySong") && SongTime > 0)
        {
            SongIsPlaying = true;
        }
        if(Input.GetButton("StopSong"))
        {
            SongIsPlaying = false;
        }
        

    }
}
