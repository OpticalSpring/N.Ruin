using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager2_3 : MonoBehaviour
{
    public GameObject player;
    public int keyCount;
    public GameObject keyGroups;
    public GameObject chaseLight;
    public GameObject mainCam;
    public GameObject doorPos;
    public int eventNumber;

    public Material[] mat;
    public GameObject[] skin;
    public GameObject[] cloth;
    public GameObject[] hair;
    public bool getKey;
    public GameObject door;
    public int nowKeyCount;
    public int getKeyCount;

    void Change()
    {
        for (int i = 0; i < skin.Length; i++)
        {
            skin[i].GetComponent<SkinnedMeshRenderer>().material = mat[0];
            cloth[i].GetComponent<SkinnedMeshRenderer>().material = mat[1];
            hair[i].GetComponent<SkinnedMeshRenderer>().material = mat[2];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 3);
        getKeyCount = Random.Range(0, 4);
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
            case 1:
                if(door.GetComponent<DoorInteraction>().use == true)
                {
                    door.GetComponent<DoorInteraction>().use = false;
                    eventNumber++;
                    StartCoroutine("ChaseStart");
                }
                break;
            case 2:
               
                break;
            case 3:
                break;
        }
       
    }

    public void KeyInteraction()
    {
        eventNumber++;
        getKey = true;
        door.GetComponent<DoorInteraction>().ready = true;
        Debug.Log("DoorOpen");
    }
    IEnumerator Event_0()
    {
        
        yield return new WaitForSeconds(0.1f);
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        for (int i = 0; i < 60; i++)
        {
            player.gameObject.GetComponent<PlayerControl>().nowSpeed[1] = 10;
            player.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        player.gameObject.GetComponent<PlayerControl>().SetAniState(12);
        yield return new WaitForSeconds(3);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(13);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
    }
    IEnumerator ChaseStart()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 10);
        yield return new WaitForSeconds(1f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundStop(1, 3);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 4);
        chaseLight.SetActive(true);
        mainCam.GetComponent<CameraMove>().move = false;
        mainCam.GetComponent<CameraMove>().newPos2 = new Vector3(30, 2, 0);
        yield return new WaitForSeconds(3f);
        keyGroups.SetActive(true);
        Change();
        yield return new WaitForSeconds(1f);
        mainCam.GetComponent<CameraMove>().move = true;
        for (int i = 0; i < 4; i++)
        {
            keyGroups.transform.GetChild(i).gameObject.GetComponent<Key>().use = false;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<AdminText>().TextUpdate("주변을 살펴 열쇠를 찾으십시오.");
    }
}
