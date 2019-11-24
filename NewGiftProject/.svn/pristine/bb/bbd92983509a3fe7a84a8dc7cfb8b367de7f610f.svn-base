using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetInteger("AniState", 0);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("Movement", 4);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(4 * Time.deltaTime,0,0);
    }
}
