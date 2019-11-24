using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager2_1 : MonoBehaviour
{
    public int eventNumber;
    public GameObject player;
    public GameObject[] checkPos;
    public GameObject fakeNeon;
    public GameObject fakeNeon2;
    public int progressState;
    public GameObject drug;
    public GameObject robot;
    public GameObject crop;
    public GameObject[] siren;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 2);

        progressState = PlayerPrefs.GetInt("ProgressState");
        if (progressState > 0) eventNumber = 4;
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
                if (Vector3.Distance(player.transform.position, checkPos[0].transform.position) < 1)
                {
                    StartCoroutine("Event_1");
                    eventNumber++;
                }
                break;
            case 2:
                if (Vector3.Distance(player.transform.position, checkPos[1].transform.position) < 1)
                {
                    StartCoroutine("Event_2");
                    eventNumber++;
                }
                break;
            case 3:
                eventNumber++;
                break;
            case 4:
                if (Vector3.Distance(player.transform.position, checkPos[2].transform.position) < 1)
                {
                    eventNumber++;
                    StartCoroutine("Event_4");
                }
                    break;
        }
    }
    
    IEnumerator Event_0()
    {
        
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop2 = true;
        yield return new WaitForSeconds(0.1f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(9);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 0);
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        yield return new WaitForSeconds(4f);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        player.gameObject.GetComponent<PlayerControl>().Stop2 = false;
    }


    IEnumerator Event_1()
    {
        GetComponent<AdminText>().TextUpdate("<color=#d3deab>[ 앉기 LCtrl ]</color>");
        yield return new WaitForSeconds(3f);
        GetComponent<AdminText>().TextUpdate("들키지 않고 이동하십시오.");
    }

    IEnumerator Event_2()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 17);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundVolumeSet(4, 17, 0.3f);
        robot.GetComponent<Animator>().SetInteger("AniState", 1);
        yield return new WaitForSeconds(2f);
        crop.transform.parent = null;
        crop.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Event_4()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 18);
        GetComponent<PlayerText>().TextUpdate("!");

        yield return new WaitForSeconds(1f);

        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5, 7);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().chase = true;

        siren[0].GetComponent<MeshRenderer>().material = mat;
        siren[1].GetComponent<MeshRenderer>().material = mat;
    }

    IEnumerator RunSt()
    {
        fakeNeon2.SetActive(true);
        player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Interaction;
        player.GetComponent<PlayerControl>().nowSpeed[1] = 0;
        player.GetComponent<PlayerControl>().animator.SetFloat("Movement",0);
        player.GetComponent<PlayerControl>().enabled = false;
        yield return new WaitForSeconds(2f);
        fakeNeon2.SetActive(false);
        player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Idle;
        player.GetComponent<PlayerControl>().enabled = true;
    }
}
