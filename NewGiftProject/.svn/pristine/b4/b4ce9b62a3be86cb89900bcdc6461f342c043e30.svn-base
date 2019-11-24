using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    GameObject player;
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2 && one == false)
        {
            one = true;
            GameObject.Find("GameManager").GetComponent<SaveManager>().NextScene();
        }
    }
    
}
