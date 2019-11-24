using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLight : MonoBehaviour
{
    public GameObject[] dLight;
    public GameObject[] emission;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            //dLight[i].GetComponent<Camera>().fieldOfView = 30;
        }
        StartCoroutine("Flash");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Flash()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dLight[j].SetActive(true);
                    emission[j].GetComponent<MeshRenderer>().material.SetFloat("_Emission", 1);
                }
                dLight[i].SetActive(false);
                emission[i].GetComponent<MeshRenderer>().material.SetFloat("_Emission", 0);
        GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3f);
            }
        }
    }
}
