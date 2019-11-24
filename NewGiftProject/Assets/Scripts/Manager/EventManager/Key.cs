using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject player;
    public bool realDrug;
    public bool use;
    public Vector3 UIScale;
    public Vector4 UIScale2;
    public bool ing; Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (use == false && GameObject.Find("EventManager").GetComponent<EventManager2_3>().keyCount <= GameObject.Find("EventManager").GetComponent<EventManager2_3>().getKeyCount)
        {

            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 0.5f)
            {
                // gameObject.transform.GetChild(0).gameObject.SetActive(true);
                UIScale = new Vector3(1f, 1f, 1f);
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    use = true;
                    UIScale = new Vector3(0, 0, 0);
                    StartCoroutine("DrugOn");
                }
            }
            else
            {
                //gameObject.transform.GetChild(0).gameObject.SetActive(false);
                UIScale = new Vector3(0, 0, 0);
            }
        }
        if (ing == true)
            Turn(player.transform.GetChild(0).gameObject, gameObject.transform.position); Vector3 newPos = cam.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0, 200, 0);
        newPos.z = 0;
        Vector3 newPos2 = cam.WorldToScreenPoint(player.transform.position) + new Vector3(0, 250, 0);
        newPos2.z = 0;
        gameObject.transform.GetChild(0).GetChild(0).position = newPos;
        gameObject.transform.GetChild(0).GetChild(1).position = newPos2;
        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10 * Time.deltaTime);
        gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color = Vector4.Lerp(gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color, UIScale2, Time.deltaTime * 4);
    }

    IEnumerator DrugOn()
    {
        if(GameObject.Find("EventManager").GetComponent<EventManager2_3>().keyCount == GameObject.Find("EventManager").GetComponent<EventManager2_3>().getKeyCount)
        {
            realDrug = true;
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 2);
        ing = true;
        player.GetComponent<PlayerControl>().SetAniState(5);
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        yield return new WaitForSeconds(1.5f);
        if (realDrug == true)
        {
             UIScale2 = new Vector4(1, 1, 1,1);
            GameObject.Find("EventManager").GetComponent<EventManager2_3>().KeyInteraction();
            player.GetComponent<PlayerControl>().SetAniState(0);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 6);
            yield return new WaitForSeconds(1.0f);
            player.gameObject.GetComponent<PlayerControl>().Stop = false;
            ing = false;
            GameObject.Find("EventManager").GetComponent<EventManager2_3>().keyCount++;
        }
        else
        {
            GameObject.Find("EventManager").GetComponent<EventManager2_3>().keyCount++;
            player.GetComponent<PlayerControl>().SetAniState(0);
            yield return new WaitForSeconds(1.0f);
            player.gameObject.GetComponent<PlayerControl>().Stop = false;
            ing = false;
        }
        yield return new WaitForSeconds(2f);
        UIScale2 = new Vector4(1, 1, 1, 0);
    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }
}
