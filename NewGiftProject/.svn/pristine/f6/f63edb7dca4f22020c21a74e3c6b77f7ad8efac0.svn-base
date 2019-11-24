using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager3_4 : MonoBehaviour
{
    public int eventNumber;
    public GameObject[] slight;
    public GameObject player;
    public GameObject robot;
    public GameObject robotHand;
    public GameObject lightObj;
    public GameObject lo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6,4);

    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                if (player.transform.position.x- slight[0].transform.position.x > 3)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 23);
                    slight[1].SetActive(true);
                    eventNumber++;
                }
                break;
            case 1:
                if (player.transform.position.x - slight[1].transform.position.x > 3)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 24);
                    slight[2].SetActive(true);
                    eventNumber++;
                }
                break;
            case 2:
                if (player.transform.position.x - slight[2].transform.position.x > 3)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 25);
                    slight[3].SetActive(true);
                    eventNumber++;
                }
                break;
            case 3:
                if (player.transform.position.x - slight[3].transform.position.x > 3)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 26);
                    slight[4].SetActive(true);
                    eventNumber++;
                }
                break;
            case 4:
                if (gameObject.transform.GetChild(0).position.x - player.transform.position.x < 0.5f)
                {
                    StartCoroutine("Event_4");
                    eventNumber++;
                }
                break;
            case 5:
                if (gameObject.transform.GetChild(1).position.x - player.transform.position.x < 0.5f)
                {
                    StartCoroutine("Event_5");
                    eventNumber++;
                }
                break;
        }
        GameObject.Find("GameManager").GetComponent<DebuffManager>().debuffValue = 100;

    }

    IEnumerator Event_4()
    {
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(18);
        yield return new WaitForSeconds(5.5f);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
    }

    IEnumerator Event_5()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5, 7);
        lo.SetActive(false);
        robot.SetActive(true);
        robot.GetComponent<Animator>().SetInteger("AniState", 1);
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(10);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 17);
        yield return new WaitForSeconds(1f);
        lightObj.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        lightObj.SetActive(false);
        yield return new WaitForSeconds(2f);
        player.transform.parent = robotHand.transform;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(30);
        player.transform.localPosition = new Vector3(-2.16f, 00f, 0.22f);
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("EndCount", PlayerPrefs.GetInt("EndCount") + 1);
        GameObject.Find("EventManager").GetComponent<AdminText>().TextUpdate("[실험 종료]");
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
    }
}
