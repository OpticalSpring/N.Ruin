using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager4_1 : MonoBehaviour
{
    public GameObject robot;
    public GameObject crop;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Event_2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Event_2()
    {
        robot.GetComponent<Animator>().SetInteger("AniState", 1);
        yield return new WaitForSeconds(0.01f);
        robot.GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(3f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 17);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundVolumeSet(4, 17, 0.1f);
        robot.GetComponent<Animator>().speed = 1;
        yield return new WaitForSeconds(2f);
        crop.transform.parent = null;
        crop.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
    }
}
