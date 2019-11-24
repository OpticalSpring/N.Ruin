using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    public GameObject[] waypoint;
    public int wayCount;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nePos = waypoint[wayCount].transform.position - gameObject.transform.position;
        Vector3 look = Vector3.Slerp(gameObject.transform.forward, nePos.normalized, Time.deltaTime );
        gameObject.transform.rotation = Quaternion.LookRotation(look, Vector3.up);
        gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Vector3.Distance(gameObject.transform.position, waypoint[wayCount].transform.position) < 0.5f)
        {
            wayCount++;
            if (waypoint.Length == wayCount)
            {
                wayCount = 0;
            }
        }
    }
}
