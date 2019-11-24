using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffDistance : MonoBehaviour
{
    public GameObject player;
    DebuffManager debuffManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        debuffManager = GameObject.Find("GameManager").GetComponent<DebuffManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        //if(distance < debuffManager.debuffDistance)
        {
            debuffManager.debuffDistance = distance;
        }
    }
}
