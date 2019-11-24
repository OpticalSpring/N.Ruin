using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    public GameObject[] movePoint;
    public float delayTime, movementSpeed;
    public bool state;
    public float realDelayTime;

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
                if(Vector3.Distance(gameObject.transform.position, movePoint[0].transform.position) < 0.1f)
                {
                    state = false;
                    realDelayTime = delayTime;
                }
                else
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[0].transform.position, movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (Vector3.Distance(gameObject.transform.position, movePoint[1].transform.position) < 0.1f)
                {
                    state = true;
                    realDelayTime = delayTime;
                }
                else
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[1].transform.position, movementSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            realDelayTime -= Time.deltaTime;
        }
    }
}
