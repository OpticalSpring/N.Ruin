using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrueEndRoot : MonoBehaviour
{
    public GameObject door;
    public int eventNumber;
    public GameObject player;
    public GameObject[] ele;
    public Material[] mat;
    public GameObject[] UI;
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (eventNumber)
        {
            case 0:
                break;
            case 1:
                if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 17);
                    door.GetComponent<DoorElevator>().open = true;
                    eventNumber++;
                }
                break;
            case 2:
                if(gameObject.transform.position.x - player.transform.position.x > 1)
                {
                    StartCoroutine("End");
                    eventNumber++;
                }
                break;

        }
    }


    IEnumerator End()
    {
                    ele[0].GetComponent<MeshRenderer>().material = mat[0];
                    ele[1].GetComponent<MeshRenderer>().material = mat[1];
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 16);
        door.GetComponent<DoorElevator>().open = false;
        PlayerPrefs.SetInt("EndCount", 0);
        UI[0].SetActive(false);
        UI[1].SetActive(false);
        yield return new WaitForSeconds(4);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().debuffValue = 4.99f;
        yield return new WaitForSeconds(1);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().debuffValue = 4.99f;
        yield return new WaitForSeconds(1);
        GameObject.Find("GameManager").GetComponent<DebuffManager>().debuffValue = 0.99f;
        yield return new WaitForSeconds(2);
        bg.SetActive(true);
        SceneManager.LoadSceneAsync(11);
    }
}
