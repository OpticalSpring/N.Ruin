using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction2 : MonoBehaviour
{
    public GameObject player;
    public bool use;
    public GameObject selectUI;
    public Vector3 UIScale;
    Camera cam;
    public GameObject what;
    public bool asd;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        selectUI.GetComponent<UISelect>().UIScale = new Vector3(0, 0, 0);
        selectUI.GetComponent<UISelect>().ggggg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (use == false)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 0.5f && selectUI.GetComponent<UISelect>().ready == false)
            {
                UIScale = new Vector3(1f, 1f, 1f);
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    use = true;
                    UIScale = new Vector3(0, 0, 0);
                    if (selectUI.GetComponent<UISelect>().ggggg == 0)
                    {
                        selectUI.GetComponent<UISelect>().ggggg = 1;
                        selectUI.GetComponent<UISelect>().UIScale = new Vector3(1, 1, 1);
                        
                    }
                    player.GetComponent<PlayerControl>().Stop = true;
                }
            }
            else
            {
                UIScale = new Vector3(0f, 0f, 0f);
                selectUI.GetComponent<UISelect>().UIScale = new Vector3(0, 0, 0);
                //selectUI.GetComponent<UISelect>().ggggg = 0;
            }
        }
            if (selectUI.GetComponent<UISelect>().Get == true && asd == false)
            {
                use = true;
            asd = true;
                StartCoroutine("DrugOn");
            }
        Vector3 newPos = cam.WorldToScreenPoint(player.transform.position) + new Vector3(0, 150, 0);
        newPos.z = 0;
        what.transform.position = newPos;
        what.transform.localScale = Vector3.Lerp(what.transform.localScale, UIScale, 10 * Time.deltaTime);
    }

    IEnumerator DrugOn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(4, 8);
        GetComponent<Animator>().SetInteger("AniState", 1);
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
