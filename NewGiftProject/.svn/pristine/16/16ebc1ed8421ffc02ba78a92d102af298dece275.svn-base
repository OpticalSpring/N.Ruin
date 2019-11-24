using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    CameraMove cameraMove;
    GameObject[] checkPos = new GameObject[3];
    float[] disPos = new float[2];
    Vector3 nextPos;
    
    public float degree, cameraDistance;
    private void Start()
    {
        cameraMove = GameObject.Find("MainCam").GetComponent<CameraMove>();
        for (int i = 0; i < 3; i++)
        {
            checkPos[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("PlayerAni"))
        {
            Vector3 colVector = col.transform.position;
            colVector.z = 0;
            Vector3 check0Vector = checkPos[0].transform.position;
            check0Vector.z = 0;
            Vector3 check1Vector = checkPos[1].transform.position;
            check1Vector.z = 0;
                
            disPos[0] = Vector3.Distance(colVector, check0Vector);
            disPos[1] = Vector3.Distance(check0Vector, check1Vector);
            nextPos.x = checkPos[0].transform.position.x + (checkPos[1].transform.position.x - checkPos[0].transform.position.x) * (disPos[0]) / disPos[1];
            nextPos.y = checkPos[0].transform.position.y + (checkPos[1].transform.position.y - checkPos[0].transform.position.y) * (disPos[0]) / disPos[1];
            nextPos.z = checkPos[0].transform.position.z + (checkPos[1].transform.position.z - checkPos[0].transform.position.z) * (disPos[0]) / disPos[1];

            cameraMove.newPos = nextPos;
            cameraMove.cameraDistance = cameraDistance;
            cameraMove.target = checkPos[2].transform.position;
            cameraMove.trigger = gameObject.transform.position;
            cameraMove.degree = degree;
        }
    }

   
}
