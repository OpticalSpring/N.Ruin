using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing360 : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
