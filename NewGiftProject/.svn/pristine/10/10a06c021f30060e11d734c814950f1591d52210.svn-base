using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public float flashTime;


    private void Start()
    {
        StartCoroutine("Flash");
    }
    IEnumerator Flash()
    {
        while (true)
        {
            yield return new WaitForSeconds(flashTime);
            GetComponent<DeathSpotLight>().enabled = false;
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(flashTime);
            GetComponent<DeathSpotLight>().enabled = true;
            GetComponent<Light>().enabled = true;
        }
    }
}
