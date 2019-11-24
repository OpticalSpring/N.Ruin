using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject player;
    public bool realDrug;
    public bool use;
    public Vector3 UIScale;
    public Vector3 UIScale2;
    public bool ing; Camera cam;
    public bool ready;
    public GameObject door;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        if (use == false)
        {

            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 0.5f && ready == true)
            {
                // gameObject.transform.GetChild(0).gameObject.SetActive(true);
                UIScale = new Vector3(1f, 1f, 1f);
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if(GameObject.Find("EventManager").GetComponent<EventManager2_3>().eventNumber == 1)
                    {
                        use = true;
                        ready = false;
                        UIScale = new Vector3(0, 0, 0);
                    }
                    else if(GameObject.Find("EventManager").GetComponent<EventManager2_3>().getKey == true)
                    {
                        use = true;
                        UIScale = new Vector3(0, 0, 0);
                        ready = false;
                        StartCoroutine("DrugOn");
                    }
                }
            }
            else
            {
                //gameObject.transform.GetChild(0).gameObject.SetActive(false);
                UIScale = new Vector3(0, 0, 0);
            }
        }
        if (ing == true)
            Turn(player.transform.GetChild(0).gameObject, new Vector3(1000,0,0)); Vector3 newPos = cam.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0, 200, 0);
        newPos.z = 0;
        gameObject.transform.GetChild(0).GetChild(0).position = newPos;
        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10 * Time.deltaTime);
        gameObject.transform.GetChild(0).GetChild(1).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(1).localScale, UIScale2, 10 * Time.deltaTime);


    }

    IEnumerator DrugOn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 8);
        door.GetComponent<Animator>().SetInteger("AniState", 1);
        ing = true;
        player.GetComponent<PlayerControl>().SetAniState(15);
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 4);
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
        
    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }
}
