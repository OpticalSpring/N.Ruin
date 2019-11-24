using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public int savePointNumber;
    SaveManager saveManager;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("GameManager").GetComponent<SaveManager>();
       player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (savePointNumber > saveManager.progressState)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
            {
                saveManager.Save(savePointNumber);
            }
        }
    }
}
