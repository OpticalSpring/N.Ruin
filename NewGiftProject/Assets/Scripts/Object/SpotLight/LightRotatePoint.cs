using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotatePoint : MonoBehaviour
{
    public GameObject[] movePoint;
    public float delayTime, movementSpeed;
    public bool state;
    public int stateNumber;
    public float realDelayTime;
    public GameObject lookAtTarget;

    // Update is called once per frame
    void Update()
    {
        if (realDelayTime < 0)
        {

            if (Vector3.Distance(lookAtTarget.transform.position, movePoint[stateNumber].transform.position) < 0.1f)
            {
                if (state == true && stateNumber == 0)
                {
                    state = false;
                    stateNumber++;
                }
                else if (state == false && stateNumber >= movePoint.Length-1)
                {
                    state = true;
                    stateNumber--;
                }
                else if (state == true)
                {
                    stateNumber--;
                }
                else if (state == false)
                {
                    stateNumber++;
                }
                if (Vector3.Distance(lookAtTarget.transform.position, Camera.main.gameObject.transform.position) < 15)
                {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 12);
                }
                realDelayTime = delayTime;
            }
            else
                {
                    lookAtTarget.transform.position = Vector3.Slerp(lookAtTarget.transform.position, movePoint[stateNumber].transform.position, movementSpeed * Time.deltaTime);
                }
            
            gameObject.transform.LookAt(lookAtTarget.transform.position);
        }
        else
        {
            realDelayTime -= Time.deltaTime;
        }
    }
}
