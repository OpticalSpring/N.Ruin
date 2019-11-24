using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager3_3 : MonoBehaviour
{
    public GameObject eleDoor; public int eventNumber;
    public GameObject ele;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6, 13);
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                    StartCoroutine("Event_0");
                    eventNumber++;
                
                break;
        }
    }

    IEnumerator Event_0()
    {
        yield return new WaitForSeconds(3); GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 14);
        eleDoor.GetComponent<DoorElevator>().open = true;
        ele.GetComponent<MeshRenderer>().material = mat;
    }
}
