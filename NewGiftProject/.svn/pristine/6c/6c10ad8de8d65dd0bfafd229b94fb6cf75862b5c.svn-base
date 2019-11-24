using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerBombBomb : MonoBehaviour
{
    public Vector3 nextScale;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Bomb");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, nextScale, Time.deltaTime*5);
    }

    IEnumerator Bomb()
    {
        while (true)
        {
            nextScale = new Vector3(5, 5, 5);
            yield return new WaitForSeconds(0.4f);
            nextScale = new Vector3(5.1f, 5.1f, 5.1f);
            yield return new WaitForSeconds(0.2f);


        }
    }
}
