using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager3_2 : MonoBehaviour
{
    public int eventNumber;
    public GameObject player;
    public GameObject[] checkPos; public GameObject mainCam; public int progressState;

    public GameObject wallLight;
    public Material changeM;
    SoundManager sm;
    public GameObject eleDoor;
    public GameObject[] ele;
    public Material[] mat;
    public GameObject[] warSound;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 6);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6, 8);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6, 9);
        player = GameObject.Find("Player");
        progressState = PlayerPrefs.GetInt("ProgressState");
        if (progressState > 0) { eventNumber = 2;}
        if (progressState > 1) { eventNumber = 3; }
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                if (Vector3.Distance(player.transform.position, checkPos[0].transform.position) < 1)
                {
                    StartCoroutine("Event_0");
                    eventNumber++;
                }
                break;
            case 1:
                if (Vector3.Distance(player.transform.position, checkPos[1].transform.position) < 1)
                {
                    StartCoroutine("Event_1");
                    eventNumber++;
                }
                break;
            case 2:
                if (Vector3.Distance(player.transform.position, checkPos[4].transform.position) < 1)
                {
                    StartCoroutine("Event_4");
                    eventNumber++;
                }
                break;
            case 3:
                if (Vector3.Distance(player.transform.position, checkPos[2].transform.position) < 1)
                {
                    StartCoroutine("Event_2");
                    eventNumber++;
                }
                break;
            case 4:
                if (Vector3.Distance(player.transform.position, checkPos[3].transform.position) < 1)
                {
                    StartCoroutine("Event_3");
                    eventNumber++;
                }
                break;
        }
        
        ClubSound();
    }

    float k1, k2, k3;
    float k11, k22, k33;
    void ClubSound()
    {
        float md = Vector3.Distance(player.transform.position, checkPos[4].transform.position);

        k1 = Mathf.Lerp(k1, k11, Time.deltaTime * 0.5f);
        k2 = Mathf.Lerp(k2, k22, Time.deltaTime * 0.5f);
        k3 = Mathf.Lerp(k3, k33, Time.deltaTime * 0.5f);
        if (warSound[0].GetComponent<WarnningSoundSet>().dis > 5 && warSound[1].GetComponent<WarnningSoundSet>().dis > 20)
            sm.SoundVolumeSet(1, 6, k1);
        sm.SoundVolumeSet(6, 8, k2);
        sm.SoundVolumeSet(6, 9, k3);
        if (md < 15)
        {
            k11 = 0;
            k22 = 0;
            k33 = 1;
        }
        else if(md < 35)
        {
            k11 = 0;
            k22 = 1;
            k33 = 0f;
        }
        else if(md < 55)
        {
            k11 = 0.8f;
            k22 = 0.3f;
            k33 = 0;
        }
        else
        {
            k11 = 1;
            k22 = 0.0f;
            k33 = 0;
        }
    }
    IEnumerator Event_4()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(11);
        yield return new WaitForSeconds(2.5f);
        GetComponent<AdminText>().TextUpdate("한눈팔지 마십시오.");
        yield return new WaitForSeconds(1f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
    }

    IEnumerator Event_0()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        for (int i = 0; i < 50; i++)
        {
            player.gameObject.GetComponent<PlayerControl>().Turn(player.gameObject.transform.GetChild(0).gameObject, new Vector3(0, 0, 10000));
            yield return new WaitForSeconds(0.02f);
        }
        player.gameObject.GetComponent<PlayerControl>().SetAniState(17);
        yield return new WaitForSeconds(2f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        GetComponent<AdminText>().TextUpdate("한눈팔지 마십시오.");
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("한눈팔지 마십시오.");
        yield return new WaitForSeconds(7.5f);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
        player.gameObject.GetComponent<PlayerControl>().turnPoint = new Vector3(10000, 0, 0);
    }

    IEnumerator Event_1()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        mainCam.GetComponent<CameraMove>().move = false;
        mainCam.GetComponent<CameraMove>().newPos2 = new Vector3(83, 1.9f, 0);
        yield return new WaitForSeconds(6f);
        mainCam.GetComponent<CameraMove>().move = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = false;

        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
    }
    IEnumerator Event_2()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(18);
        yield return new WaitForSeconds(5.5f);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;

    }

    IEnumerator Event_3()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 18);
        eleDoor.GetComponent<DoorElevator>().open = true;
        wallLight.GetComponent<MeshRenderer>().material = changeM;
        ele[0].GetComponent<MeshRenderer>().material = mat[0];
        ele[1].GetComponent<MeshRenderer>().material = mat[1];
        yield return new WaitForSeconds(1f);
    }
}
