﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light360 : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
