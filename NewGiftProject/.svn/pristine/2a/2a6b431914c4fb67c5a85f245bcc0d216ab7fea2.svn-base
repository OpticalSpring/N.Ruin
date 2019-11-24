using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneChase : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    public bool chase;
    public GameObject chaseObject;
    public GameObject endObject;
    bool aa;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,chaseObject.transform.position) < 2)
        {
            chase = true;
        }
        if (chase == true)
        {
            Vector3 nePos = player.transform.position - gameObject.transform.position;
            if(aa == true)
            {
                nePos = new Vector3(80, 0, -100) - gameObject.transform.position;
            }
            Vector3 look = Vector3.Slerp(gameObject.transform.forward, nePos.normalized, Time.deltaTime);
            gameObject.transform.rotation = Quaternion.LookRotation(look, Vector3.up);
            gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1)
            {
                aa = true;
            }

            if (Vector3.Distance(gameObject.transform.position, endObject.transform.position) < 1)
            {
                aa = true;
            }
        }
    }
}
