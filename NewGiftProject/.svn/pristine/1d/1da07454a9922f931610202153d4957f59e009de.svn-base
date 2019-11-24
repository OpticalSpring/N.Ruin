using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public bool chase;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(chase == true)
        {
            float distance = Vector3.Distance(player.transform.position, target.transform.position);
            gameObject.transform.GetChild(5).GetChild(0).gameObject.GetComponent<AudioSource>().volume = (50 - distance)/50;
            gameObject.transform.GetChild(5).GetChild(1).gameObject.GetComponent<AudioSource>().volume = (50 - distance)/50;
            gameObject.transform.GetChild(5).GetChild(2).gameObject.GetComponent<AudioSource>().volume = (50 - distance)/50;
        }
    }

    public void SoundPlay(int i, int j)
    {
        gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().Play();
    }

    public void SoundStop(int i, int j)
    {
        StartCoroutine(I1(i, j));
    }

    public void AllSoundStop()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
            {
                StartCoroutine(I1(i, j));
            }
        }
    }

    public void SoundPause(int i, int j)
    {
        gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().Pause();
    }

    public void RandomPlay(int i, int x, int y)
    {
        int j = Random.Range(x, y+1);
        SoundPlay(i, j);
    }

    public void SoundVolumeSet(int i, int j, float k)
    {
        gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().volume = k;
    }
    
   

    IEnumerator I1(int i, int j)
    {
        for (int k = 100; k> 0; --k)
        {
            if(gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().volume > (float)k / 100)
            gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().volume = (float)k / 100;
           
            yield return new WaitForSeconds(0.01f);
        }
    }
}