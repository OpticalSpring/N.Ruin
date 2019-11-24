using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool open;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (open == true && gameObject.transform.position.x < player.transform.position.x && Vector3.Distance(gameObject.transform.position, player.transform.position) < 5) 
        {
            open = false;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 16);
        }
        if (open == true) {
            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(-2.3f, 0, 0), Time.deltaTime * 3);
        //    gameObject.transform.GetChild(0).transform.localEulerAngles = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localEulerAngles, new Vector3(0, 0, 100), Time.deltaTime * 3);
        //    gameObject.transform.GetChild(1).transform.localEulerAngles = Vector3.Lerp(gameObject.transform.GetChild(1).transform.localEulerAngles, new Vector3(0, 0, 80), Time.deltaTime * 3);
        }
        else
        {
            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 3);
            //        gameObject.transform.GetChild(0).transform.localEulerAngles = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localEulerAngles, new Vector3(0, 0, 179), Time.deltaTime * 3);
            //        gameObject.transform.GetChild(1).transform.localEulerAngles = Vector3.Lerp(gameObject.transform.GetChild(1).transform.localEulerAngles, new Vector3(0, 0, 0), Time.deltaTime * 3);
        }
    }
}
