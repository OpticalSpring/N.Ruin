using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInteraction : MonoBehaviour
{
    public GameObject player;
    public bool realDrug;
    public bool use;
    public Vector3 UIScale;
    public Vector3 UIScale2;
    public bool ing;
    public bool done;
    public GameObject[] door;
    Camera cam;
    public bool ready;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (use == false && ready == true)
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
        Vector3 newPos = cam.WorldToScreenPoint(gameObject.transform.position) + new Vector3(0, 200, 0);
        newPos.z = 0;
        gameObject.transform.GetChild(0).GetChild(0).position = newPos;
        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10 * Time.deltaTime);
    }

    IEnumerator DrugOn()
    {
        for (int i = 0; i < 50; i++)
        {
            player.gameObject.GetComponent<PlayerControl>().Turn(player.gameObject.transform.GetChild(0).gameObject, new Vector3(1000, 0, -1));
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine("Open");
        player.transform.Rotate(Vector3.up * 90);
        player.gameObject.GetComponent<PlayerControl>().Stop = true;
        ing = true;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerControl>().SetAniState(8);

        yield return new WaitForSeconds(2f);
        UIScale2 = new Vector3(0, 0, 0);
        done = true;
        yield return new WaitForSeconds(4f);
        GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
    }

    IEnumerator Open()
    {
        for(int i = 0; i < 15; i++)
        {
            door[0].transform.position += new Vector3(0, 0, Time.deltaTime);
            door[1].transform.position -= new Vector3(0, 0, Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }


    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 1000000 * Time.deltaTime);
    }
}
