using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public GameObject[] movePoint;
    public float delayTime, movementSpeed;
    public bool state;
    public float realDelayTime;
    public GameObject lookAtTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (realDelayTime < 0)
        {
            if (state)
            {
                if (Vector3.Distance(lookAtTarget.transform.position, movePoint[0].transform.position) < 0.1f)
                {
                    state = false;
                    realDelayTime = delayTime;
                }
                else
                {
                    lookAtTarget.transform.position = Vector3.MoveTowards(lookAtTarget.transform.position, movePoint[0].transform.position, movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (Vector3.Distance(lookAtTarget.transform.position, movePoint[1].transform.position) < 0.1f)
                {
                    state = true;
                    realDelayTime = delayTime;
                }
                else
                {
                    lookAtTarget.transform.position = Vector3.MoveTowards(lookAtTarget.transform.position, movePoint[1].transform.position, movementSpeed * Time.deltaTime);
                }
            }
            gameObject.transform.LookAt(lookAtTarget.transform.position);
        }
        else
        {
            realDelayTime -= Time.deltaTime;
        }
    }
}
