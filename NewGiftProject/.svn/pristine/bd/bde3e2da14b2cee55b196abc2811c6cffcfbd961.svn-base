using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public GameObject player;
    public bool[] swit = new bool[6];
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < 4.35f)
        {
            swit[0] = true;
            swit[1] = false;
        }
        else if (player.transform.position.x < 22.15f)
        {
            swit[0] = false;
            swit[1] = true;
            swit[2] = false;
        }
        else if (player.transform.position.x < 25.52f)
        {
            swit[1] = false;
            swit[2] = true;
            swit[3] = false;
        }
        else if (player.transform.position.x < 43.26f)
        {
            swit[2] = false;
            swit[3] = true;
            swit[4] = false;
        }
        else if (player.transform.position.x < 79.11f)
        {
            swit[3] = false;
            swit[4] = true;
            swit[5] = false;
        }
        else
        {
            swit[4] = false;
            swit[5] = true;
        }

        for (int i = 0; i < swit.Length; i++)
        {
            if (swit[i] == false)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = Vector4.Lerp(gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color, new Color(0, 0, 0, 1.0f),Time.deltaTime);
            }
            else
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = Vector4.Lerp(gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color, new Color(0, 0, 0, 0.0f), Time.deltaTime);
            }
        }
    }
}
