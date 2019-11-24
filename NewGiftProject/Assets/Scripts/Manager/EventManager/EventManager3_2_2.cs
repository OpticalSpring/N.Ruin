using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager3_2_2 : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Event_0");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 13);
    }

    // Update is called once per frame
    void Update()
    {
        wall.transform.Translate(Vector3.down * Time.deltaTime * 5);
    }

    IEnumerator Event_0()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("보고 있습니까?");
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("만약 결말이 이미 정해져 있다면 당신은 어떨 것 같습니까? ");
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("......");
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("아무것도 아닙니다. ");
        yield return new WaitForSeconds(5f);
        GetComponent<AdminText>().TextUpdate("계속 진행하십시오. 엔딩을 위해.");
        yield return new WaitForSeconds(5f);
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
    }
}
