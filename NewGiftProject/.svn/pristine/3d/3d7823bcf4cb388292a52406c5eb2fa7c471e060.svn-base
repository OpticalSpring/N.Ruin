using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager3_1 : MonoBehaviour
{
    public int eventNumber;
    public GameObject player;
    public GameObject[] checkPos;
    public GameObject street;
    int progressState;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 5);
        progressState = PlayerPrefs.GetInt("ProgressState");
        if (progressState > 0)
        {
            eventNumber = 1;
        }
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
        }
    }

    IEnumerator Event_0()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(18);
        yield return new WaitForSeconds(5.5f);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;

        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);

    }

    IEnumerator Event_1()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        for (int i = 0; i < 50; i++)
        {
            player.gameObject.GetComponent<PlayerControl>().Turn(player.gameObject.transform.GetChild(0).gameObject, new Vector3(0, 0, 10000));
            yield return new WaitForSeconds(0.02f);
        }
        player.gameObject.GetComponent<PlayerControl>().SetAniState(16);
        yield return new WaitForSeconds(3f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        GetComponent<AdminText>().TextUpdate("그 쪽이 아닙니다.");
        yield return new WaitForSeconds(5f);
        street.SetActive(false);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        player.gameObject.GetComponent<PlayerControl>().turnPoint = new Vector3(10000, 0, 0);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
    }
    
}
