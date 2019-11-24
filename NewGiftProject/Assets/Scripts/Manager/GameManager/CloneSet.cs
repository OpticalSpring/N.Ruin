using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSet : MonoBehaviour
{
    public int endCount;
    public GameObject[] cloneObject;
    public GameObject[] glassObject;
    public Material changeMat;
    // Start is called before the first frame update
    void Start()
    {
        endCount = PlayerPrefs.GetInt("EndCount");
        if(endCount > 11)
        {
            endCount = 11;
        }
        for (int i = 0; i < endCount; i++)
        {
            cloneObject[i].SetActive(false);
            glassObject[i].GetComponent<MeshRenderer>().material = changeMat;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
