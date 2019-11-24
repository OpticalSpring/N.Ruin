using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    public GameObject player;
    public bool chaseMode;
    public bool use;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (use == false)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
            {
                player.GetComponent<PlayerFSM>().chaseState = chaseMode;
                use = true;
            }

        }
    }
}
