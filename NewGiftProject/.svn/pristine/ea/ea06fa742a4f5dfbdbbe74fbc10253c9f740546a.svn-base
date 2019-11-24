using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearcherSound : MonoBehaviour
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void SoundRun()
    {
        soundManager.SoundPlay(2, Random.Range(28, 31));
            
    }

}
