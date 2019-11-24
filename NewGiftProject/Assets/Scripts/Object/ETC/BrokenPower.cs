using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPower : MonoBehaviour
{
    public bool dd;
    GameObject player;
    public GameObject r;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.F3) && Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.B) && dd == false)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1)
            {
                dd = true;
                r.SetActive(true);
            }
        }
    }
}
