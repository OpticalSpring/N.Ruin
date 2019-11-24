using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuffDrug : MonoBehaviour
{
    public GameObject player;
    public bool realDrug;
    public bool use;
    public Vector3 UIScale;
    public Vector4 UIScale2;
    public int height;
    public bool ing;
    public bool corps;
    public bool auto;
    Camera cam;
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
                UIScale = new Vector3(1f,1f, 1f);
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
        if(ing == true)
        Turn(player.transform.GetChild(0).gameObject, gameObject.transform.position);
        Vector3 newPos = cam.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0,200,0);
        newPos.z = 0;
        Vector3 newPos2 = cam.WorldToScreenPoint(player.transform.position) + new Vector3(0, height, 0);
        newPos2.z = 0;
        gameObject.transform.GetChild(0).GetChild(0).position = newPos;
        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10*Time.deltaTime);
        gameObject.transform.GetChild(1).GetChild(0).position = newPos2;
        //gameObject.transform.GetChild(1).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(1).GetChild(0).localScale, UIScale2, 10 * Time.deltaTime);
        gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().color = Vector4.Lerp(gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().color, UIScale2, Time.deltaTime * 4);
    }

    IEnumerator DrugOn()
    {
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = true;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerControl>().SetAniState(5);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 2);
        ing = true;
        yield return new WaitForSeconds(1.0f);
        if (auto == true)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 12);
        }
        yield return new WaitForSeconds(1.0f);
        if (corps == true)
        {
            gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>().SetInteger("AniState", 1);
        }

        player.GetComponent<PlayerControl>().SetAniState(6);
            yield return new WaitForSeconds(0.5f);
        GameObject.Find("EventManager").GetComponent<PlayerText>().TextUpdate("약을 획득했다.");
        UIScale2 = new Vector4(1, 1, 1, 1);
        yield return new WaitForSeconds(2.0f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 3);
        yield return new WaitForSeconds(1.0f);
        UIScale2 = new Vector4(1, 1, 1, 0);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().ValueUp();
        GameObject.Find("GameManager").GetComponent<DebuffManager>().stop = false;
        player.gameObject.GetComponent<PlayerControl>().Stop = false;
            player.GetComponent<PlayerControl>().SetAniState(0);
            ing = false;

    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }
}
