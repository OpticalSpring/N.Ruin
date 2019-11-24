using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCManager : MonoBehaviour
{
    public GameObject ESC;
    public bool on;
    bool one;
    public GameObject[] rec;

    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(on == false && one == false)
            {
                on = true;
                Open();
            }
            else
            {
                
                Close();
            }
        }
    }

    public void Open()
    {
        Cursor.visible = true;
        ESC.SetActive(true);
        rec[0].SetActive(true);
        rec[1].SetActive(false);
        Time.timeScale = 0;
    }

    public void Close()
    {
        Cursor.visible = false;
        Cursor.visible = false;
        ESC.SetActive(false);
        rec[0].SetActive(false);
        rec[1].SetActive(true);
        Time.timeScale = 1;
        on = false;
    }

    public void ReLoad()
    {
        Close();
        GetComponent<SaveManager>().ReLoadScene();
        one = true;
    }

    public void Exit()
    {
        Close();
        GetComponent<SaveManager>().Exit();
        one = true;
    }
}
