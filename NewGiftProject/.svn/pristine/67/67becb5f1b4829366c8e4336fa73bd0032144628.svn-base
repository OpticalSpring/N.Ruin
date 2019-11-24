using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchNull : MonoBehaviour
{
    public GameObject player;
    public bool realDrug;
    public bool use;
    public Vector3 UIScale;
    public Vector3 UIScale2;
    public bool ing;
    public bool done;
    Camera cam;
    public bool inputReady;
    public bool textUp;

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
        {
            Turn(player.transform.GetChild(0).gameObject, gameObject.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Z) && inputReady == true) DrugOff();
        Vector3 newPos = cam.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0, 200, 0);
        newPos.z = 0;
        gameObject.transform.GetChild(0).GetChild(0).position = newPos;
        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10 * Time.deltaTime);
        gameObject.transform.GetChild(1).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(1).GetChild(0).localScale, UIScale2, 10 * Time.deltaTime);
    }

    IEnumerator DrugOn()
    {

        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        ing = true;
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 2);
        player.GetComponent<PlayerControl>().SetAniState(5);
        yield return new WaitForSeconds(2f);
        UIScale2 = new Vector3(1, 1, 1);
        player.GetComponent<PlayerControl>().SetAniState(0);
        if (textUp == true)
        {
            GameObject.Find("EventManager").GetComponent<PlayerText>().TextUpdate("비어있다.");
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 9);
        yield return new WaitForSeconds(1f);
        inputReady = true;
        DrugOff();
    }

    void DrugOff()
    {
        ing = false;
        UIScale2 = new Vector3(0, 0, 0);
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
        done = true;
        inputReady = false;
    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }
}
