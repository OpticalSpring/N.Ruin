using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float movementSpeed, rotateSpeed, degree;
    public float cameraDistance;
    [HideInInspector]
    public Vector3 newPos,newPos2, target, trigger;
    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        newPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Move();
            Turn(gameObject, target);
        }
        else
        {
            Move2();
            Turn(gameObject, target);
        }
    }

    void Move()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos, movementSpeed * Time.deltaTime);
        gameObject.transform.GetChild(0).localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).localPosition, new Vector3(0, 0, -cameraDistance), movementSpeed * Time.deltaTime);
    }

    void Move2()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newPos2, movementSpeed * Time.deltaTime);
        gameObject.transform.GetChild(0).localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).localPosition, new Vector3(0, 0, -cameraDistance), movementSpeed * Time.deltaTime);
    }

    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - trigger.z;
        float dx = target.x - trigger.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(degree, rotateDegree, 0), rotateSpeed * Time.deltaTime);
    }
    

    
    
}
