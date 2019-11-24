using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCreate : MonoBehaviour
{
    public GameObject fogObject;
    [Range(0, 1)]
    public float fogValue;
    public int fogCount;
    public float fogDistance;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fogCount; i++)
        {
            GameObject temp = Instantiate(fogObject);
            
            float alpha = fogValue - fogValue * (i / (float)fogCount);
            temp.GetComponent<MeshRenderer>().material.SetFloat("_FogAlpha", alpha);
            Vector3 newPos = gameObject.transform.position;
            newPos.z -= fogDistance * (i / (float)fogCount);
            temp.transform.position = newPos;
            temp.transform.parent = gameObject.transform;
        }
    }
    
}