using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    public GameObject[] button;
    public GameObject player;
    Camera cam;
    public Vector3 UIScale;
    public int count;
    public bool ready;
    public bool Get;
    public int ggggg;
    public int ro;
    public Sprite[] spr;
    public int endCount;
    public GameObject li;
    // Start is called before the first frame update
    void Start()
    {
        endCount = PlayerPrefs.GetInt("EndCount");
        cam = GameObject.Find("MainCam").transform.GetChild(0).GetChild(0).gameObject.GetComponent<Camera>();
        player = GameObject.Find("Player");
        ro = 2;
        //B2On();
        //B1Off();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = cam.WorldToScreenPoint(player.transform.position) + new Vector3(0, 150, 0);
        newPos.z = 0; gameObject.transform.position = newPos;
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, UIScale, 10 * Time.deltaTime);
        KeyInput();
    }

    void KeyInput()
    {
        if (ggggg == 1 && Get == false)
        {
            player.GetComponent<PlayerControl>().Turn(player.transform.GetChild(0).gameObject, new Vector3(10000, 0, 0));
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ro = 1;
                B2On();
                B1Off();

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                ro = 0;
                B1On();
                B2Off();
            }
            if (Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Z))
            {
                if (ready == false)
                {
                    if (ro == 0 || (count >= 2 && endCount == 0 && ro != 2))
                    {
                        B1Sel();
                    }
                    else if (ro == 1)
                    {
                        B2Sel();
                    }
                }
            }
        }
        else
        {
            UIScale = Vector3.zero;
        }
    }

    public void B1On()
    {
        button[0].SetActive(true);
        gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().sprite = spr[1];
        gameObject.transform.GetChild(4).gameObject.GetComponent<Image>().sprite = spr[2];
       
    }
    public void B1Off()
    {
        button[0].SetActive(false);
        gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().sprite = spr[0];
        gameObject.transform.GetChild(4).gameObject.GetComponent<Image>().sprite = spr[3];
    }
    public void B2On()
    {
        button[1].SetActive(true);
        
        gameObject.transform.GetChild(5).gameObject.GetComponent<Image>().sprite = spr[3];
        gameObject.transform.GetChild(6).gameObject.GetComponent<Image>().sprite = spr[1];
    }
    public void B2Off()
    {
        button[1].SetActive(false);
        gameObject.transform.GetChild(5).gameObject.GetComponent<Image>().sprite = spr[2];
        gameObject.transform.GetChild(6).gameObject.GetComponent<Image>().sprite = spr[0];
    }

    public void B1Sel()
    {
        Get = true;
        ready = true;
    }

    public void B2Sel()
    {
        count++;
        StartCoroutine("B2Reload");
    }

    IEnumerator B2Reload()
    {
        ready = true;
        ro = 2;
        B1Off();
        B2Off();
        UIScale = new Vector3(0, 0, 0);
        if (count > 2 && endCount != 0)
        {
            player.GetComponent<PlayerControl>().Stop = false;
            GameObject.Find("TrueEventManager").GetComponent<TrueEndRoot>().eventNumber = 1;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 14);
            li.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(3f);
            UIScale = new Vector3(1, 1, 1);
            ro = 2;
            B1Off();
            B2Off();
            
            if (count == 1)
            {
                gameObject.transform.GetChild(4).gameObject.SetActive(false);
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
            }
            if (count >= 2 && endCount == 0)
            {
                gameObject.transform.GetChild(5).gameObject.SetActive(false);
                gameObject.transform.GetChild(6).gameObject.SetActive(true);
            }
        }
        yield return new WaitForSeconds(1f);
        ready = false;
    }
}
