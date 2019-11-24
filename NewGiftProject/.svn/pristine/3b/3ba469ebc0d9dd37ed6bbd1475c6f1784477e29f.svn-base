using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash8 : MonoBehaviour
{
    public GameObject[] light;
    public GameObject so;
    // Start is called before the first frame update
    void Start()
    {
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
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    light[i].SetActive(true);
                }
                else
                {
                    light[i].SetActive(false);
                }
            }
            so.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    light[i].SetActive(false);
                }
                else
                {
                    light[i].SetActive(true);
                }
            }
            so.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2f);
        }
    }
}
