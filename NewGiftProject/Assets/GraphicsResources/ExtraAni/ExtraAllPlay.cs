using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAllPlay : MonoBehaviour
{
    public int aniState;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("AniState", aniState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
