using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ON : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2.2f, 0);
    Vector3 offsetIngame;
    public bool Set;
    public GameObject ui;
    
    Vector3 scaleValue;
    Vector3 positionValue;
    bool clear;
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (Set == false && clear == false)
    //            {
    //                 Set = true;
    //                ui.SetActive(true);
    //                UION();
    //            }
            
    //    }
    //}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                clear = true;
                StartCoroutine("UIOFF");
            }
            if (Set == false && clear == false)
            {
                Set = true;
                ui.SetActive(true);
                UION();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Set == true)
            {
                StartCoroutine("UIOFF");
                
            }

        }
    }


    private void Update()
    {
        if (Set)
        {
            ui.transform.localScale = Vector3.Lerp(ui.transform.localScale, scaleValue, 10 * Time.deltaTime);
           ui.transform.localPosition = Vector3.Lerp(ui.transform.localPosition, offsetIngame, 10 * Time.deltaTime);
        }
    }

    void UION()
    {
        offsetIngame = offset;
        ui.transform.parent =gameObject.transform;
        scaleValue = new Vector3(1, 1, 1);
        positionValue = new Vector3(0, 2, 0);
        
    }

    IEnumerator UIOFF()
    {
        offsetIngame.y = offset.y - 1f;
        scaleValue = new Vector3(0, 0, 0);
        positionValue = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1f);
        Set = false;
        ui.SetActive(false);
        ui.transform.parent = null;
    }

    // 1. 콜라이더위치를 오브젝트로정하게
    // 2. UI띄우는위치를 오브젝트로정하게
}
