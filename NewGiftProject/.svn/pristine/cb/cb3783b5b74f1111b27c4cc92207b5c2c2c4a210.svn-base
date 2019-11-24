using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLight2 : MonoBehaviour
{
    public GameObject[] dLight;
    public GameObject[] emission;
    public GameObject so;
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
            for (int i = 0; i < 5; i++)
            {
                
                dLight[i].SetActive(true);
                emission[i].GetComponent<MeshRenderer>().material.SetFloat("_Emission", 1);
            }
            so.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 5; i++)
            {

                dLight[i].SetActive(false);
                emission[i].GetComponent<MeshRenderer>().material.SetFloat("_Emission", 0);
            }
           
            yield return new WaitForSeconds(2f);
        }
    }
}
