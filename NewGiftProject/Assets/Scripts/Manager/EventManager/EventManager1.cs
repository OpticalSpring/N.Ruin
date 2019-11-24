using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager1 : MonoBehaviour
{
    public int eventNumber;
    public GameObject[] door;
    public GameObject player;
    public GameObject[] checkPos;
    public GameObject fakePlayer;
    public GameObject spotLight;
    public GameObject ef;
    public GameObject ek;
    public int progressState;
    public GameObject UI;
    DebuffManager de;
    public GameObject mainCam;
    public GameObject[] searchObj;
    public GameObject[] cameraTrigger;
    public GameObject[] researcher;
    public GameObject rDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("MainCam");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(6, 1);
        UI.SetActive(false);
        de = GameObject.Find("GameManager").GetComponent<DebuffManager>();
        player = GameObject.Find("Player");
        progressState = PlayerPrefs.GetInt("ProgressState");
        if (progressState > 0) { eventNumber = 7; GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 18); }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (eventNumber <=7)
        {
            de.debuffValue = 100;
        }
        for (int i = 1; i < 5; i++)
        {
            if (player.transform.position.x < door[i].transform.position.x && Vector3.Distance(player.transform.position, door[i].transform.position) < 2 && door[i].GetComponent<DoorOpen>().open == false)
            {
                door[i].GetComponent<DoorOpen>().open = true;
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
            }
        }
        switch (eventNumber)
        {
            case 0:
                StartCoroutine("Event_0");
                eventNumber++;
                
                break;
            case 1:
                if(searchObj[0].GetComponent<SearchObject>().done == true)
                {
                    StartCoroutine("Event_1");
                    eventNumber++;
                }
                break;
            case 2:
                break;
            case 3:
                if(Vector3.Distance(player.transform.position, checkPos[0].transform.position) < 1)
                {
                    eventNumber++;
                   // StartCoroutine("Event_3");
                }
                break;
            case 4:
                if (Vector3.Distance(player.transform.position, checkPos[1].transform.position) < 1)
                {
                    eventNumber++;
                    StartCoroutine("Event_4");
                    //복도 끝 사운드 출력
                }
                break;
            case 5:
                if (Vector3.Distance(checkPos[2].transform.position, player.transform.position) < 1)
                {
                    eventNumber++;
                    fakePlayer.GetComponent<FakePlayer>().death = false;
                    StartCoroutine("Event_5");
                }
                break;
            case 6:
                if (Vector3.Distance(checkPos[3].transform.position, player.transform.position) < 1)
                {
                    eventNumber++;
                    StartCoroutine("Event_6");
                }
                break;
            case 7:
                if (Vector3.Distance(checkPos[4].transform.position, player.transform.position) < 1)
                {
                UI.SetActive(true);
                    eventNumber++;
                    StartCoroutine("Event_7");
                    StartCoroutine("LightOn");
                }
                break;
            case 8:
                if (Vector3.Distance(checkPos[5].transform.position, player.transform.position) < 1)
                {
                    eventNumber++;
                    StartCoroutine("Event_8");
                }
                    break;
            case 9:
                break;
            case 10:
                eventNumber++;
                StartCoroutine("Event_10");
                break;
            case 11:
                if(searchObj[1].GetComponent<DebuffDrug>().use == true)
                {
                    eventNumber++;
                    StartCoroutine("Event_11");
                }
                break;
            case 12:
                if(searchObj[2].GetComponent<PipeInteraction>().use == true)
                {
                    eventNumber++;
                    StartCoroutine("Event_12");
                }
                break;
        }
    }

    IEnumerator Event_0()
    {

        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop2 = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(7);
        player.gameObject.transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
        player.gameObject.transform.position = new Vector3(0, 0, 1.5f);
        yield return new WaitForSeconds(24);
        player.GetComponent<PlayerControl>().PlayerMoveStart(GameObject.Find("GameManager").GetComponent<SaveManager>().playerStartPoint[0].transform);
        yield return new WaitForSeconds(1);
        GetComponent<PlayerText>().TextUpdate("…?");
        yield return new WaitForSeconds(2);
        GetComponent<AdminText>().TextUpdate("<color=#d3deab>[ 이동 ← / → ]</color>");
        yield return new WaitForSeconds(3);
        GetComponent<AdminText>().TextUpdate("<color=#d3deab>[ 조사 Z ]</color>");

    }

    IEnumerator Event_1()
    {
        GameObject.Find("EventManager").GetComponent<PlayerText>().TextUpdate("...");
        yield return new WaitForSeconds(1);
        door[0].GetComponent<DoorOpen>().open = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
        eventNumber++;
        GetComponent<AdminText>().TextUpdate("N.Ruin에 오신 것을 환영합니다.");
        yield return new WaitForSeconds(3);
        GetComponent<AdminText>().TextUpdate("지금부터 튜토리얼을 진행하겠습니다.");
        yield return new WaitForSeconds(3);
        GetComponent<AdminText>().TextUpdate("다음 장소로 이동해 주십시오.");

    }

    

    IEnumerator Event_3()
    {

        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        GetComponent<PlayerText>().TextUpdate("!");
        GetComponent<AdminText>().TextUpdate("(4번 실험관에서 쿵쿵거리는 소리가 남)");
        yield return new WaitForSeconds(4);
        GetComponent<AdminText>().TextUpdate("위급한 상황에 처했을 때 <color=#d3deab>[ Shift + ←→ ]</color>로 달릴 수 있습니다.");
        player.gameObject.GetComponent<PlayerControl>().Stop = false;

    }

    IEnumerator Event_4()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator Event_5()
    {
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        GetComponent<PlayerText>().TextUpdate("...");
        yield return new WaitForSeconds(2);
        mainCam.GetComponent<CameraMove>().move = false;
        mainCam.GetComponent<CameraMove>().newPos2 = new Vector3(33, 1.54f, 0);
        yield return new WaitForSeconds(7);
        mainCam.GetComponent<CameraMove>().move = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        GetComponent<PlayerText>().TextUpdate("!");
        GetComponent<AdminText>().TextUpdate("어떤 종류의 빛은 위험할지도 모릅니다.");
    }

    IEnumerator Event_6()
    {
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        researcher[0].GetComponent<Researcher>().aniState = 1;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(11);
        yield return new WaitForSeconds(3.5f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(0);
        rDoor.GetComponent<DoorOpen>().open = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
        researcher[0].GetComponent<Researcher>().aniState = 2;
        researcher[1].GetComponent<Researcher>().aniState = 2;
        researcher[0].GetComponent<Researcher>().MoveStart(new Vector3(25, 0, 2.5f));
        researcher[1].GetComponent<Researcher>().MoveStart(new Vector3(25, 0, 2.5f));
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        GetComponent<AdminText>().TextUpdate("위급한 상황에 처했을 때 <color=#d3deab>[ Shift + ←→ ]</color>로 달릴 수 있습니다.");
        yield return new WaitForSeconds(3);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 18);
    }

    IEnumerator Event_7()
    {
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        mainCam.GetComponent<CameraMove>().move = false;
        mainCam.GetComponent<CameraMove>().newPos2 = new Vector3(47, 1.54f, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundStop(7, 18);

        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5, 7);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(5, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().chase = true;
        yield return new WaitForSeconds(1);
        mainCam.GetComponent<CameraMove>().move = true;
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
    }

    IEnumerator Event_8()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundStop(5, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().chase = false;
        GameObject.Find("GameManager").GetComponent<DebuffManager>().debuffValue = 75;
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(12);
        yield return new WaitForSeconds(2);
        eventNumber++;

    }

    IEnumerator Event_10()
    {
        yield return new WaitForSeconds(2);
        GetComponent<AdminText>().TextUpdate("약을 찾아 복용하십시오. 상태가 안정될 것입니다.");
        yield return new WaitForSeconds(3);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 7);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundVolumeSet(4, 7, 0.5f);
        player.gameObject.GetComponent<PlayerControl>().SetAniState(13);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        player.gameObject.GetComponent<PlayerControl>().turnPoint += new Vector3(100, 0, 0);
    }

    IEnumerator Event_11()
    {
       
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundVolumeSet(4, 7, 1f);
       yield return new WaitForSeconds(7);
        searchObj[2].GetComponent<PipeInteraction>().ready = true;
        GetComponent<PlayerText>().TextUpdate("!");
        GetComponent<AdminText>().TextUpdate("방을 조사하여 위험에서 벗어나십시오.");
    }


    IEnumerator Event_12()
    {
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        mainCam.GetComponent<CameraMove>().move = false;
        mainCam.GetComponent<CameraMove>().newPos2 = new Vector3(83, 1.54f, 0);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundStop(4, 7);
        yield return new WaitForSeconds(2);
        researcher[0].transform.position = new Vector3(76, 0, 0);
        researcher[1].transform.position = new Vector3(75, 0, -1);
        researcher[0].GetComponent<Researcher>().aniState = 2;
        researcher[1].GetComponent<Researcher>().aniState = 2;
        researcher[0].GetComponent<Researcher>().MoveStart(new Vector3(100, 0, 0f));
        researcher[1].GetComponent<Researcher>().MoveStart(new Vector3(100, 0, -1f));
        door[4].GetComponent<DoorOpen>().open = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
        yield return new WaitForSeconds(1);
        mainCam.GetComponent<CameraMove>().move = true;
    }
    IEnumerator LightOn()
    {
        for(int i = 0; i < ek.transform.childCount; i++)
        {
            ek.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < 24; i++)
        {
            ek.transform.GetChild(i).gameObject.SetActive(false);
            ef.transform.GetChild(i).gameObject.SetActive(true);
            spotLight.transform.GetChild(i).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f-(i/60f));
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 24; i++)
        {
            spotLight.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    

}
