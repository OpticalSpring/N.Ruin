using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSet : MonoBehaviour
{
    public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Stage") < stageNumber)
        {
            PlayerPrefs.SetInt("Stage", stageNumber);
        }
    }
    
}
