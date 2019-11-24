using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextSet : MonoBehaviour
{
    public string textString;
    public bool set;
    public float textMax;
    public GameObject textObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (set ==false && textObject.GetComponent<UITextMessage>().textOn == false)
            {
                textObject.GetComponent<UITextMessage>().textString = textString;
                textObject.GetComponent<UITextMessage>().x_MAX = textMax;
                textObject.GetComponent<UITextMessage>().TextOn();
               
                set = true;
            }
        }
    }
}
