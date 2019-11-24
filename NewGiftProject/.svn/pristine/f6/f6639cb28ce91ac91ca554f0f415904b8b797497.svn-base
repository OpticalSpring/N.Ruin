using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager4_2 : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCam;
    public int endCount;
    public GameObject[] researcher;
    // Start is called before the first frame update
    void Start()
    {
        endCount = PlayerPrefs.GetInt("EndCount");
        player = GameObject.Find("Player");
        mainCam = GameObject.Find("MainCam");
        StartCoroutine("Event_0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Event_0()
    {
        yield return new WaitForSeconds(0.1f);
        
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        player.gameObject.GetComponent<PlayerControl>().Stop2 = true;
        player.gameObject.GetComponent<PlayerControl>().SetAniState(7);
        player.gameObject.transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
        player.gameObject.transform.position = new Vector3(0, 0, 1.5f);
        yield return new WaitForSeconds(0.1f);
        player.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = 0;

        yield return new WaitForSeconds(5f);
        player.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = 1;
        if (endCount == 12)
        {
            GameObject.Find("EventManager").GetComponent<AdminText>().TextUpdate("만족하십니까?");
            PlayerPrefs.SetInt("EndCount", 0);
        }
        mainCam.GetComponent<CameraMove>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        player.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().speed = 0;
        if (endCount == 12)
        {
            player.SetActive(false);
            researcher[0].SetActive(false);
            researcher[1].SetActive(false);
        }

        yield return new WaitForSeconds(4);
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
        yield return new WaitForSeconds(1);

    }
}
