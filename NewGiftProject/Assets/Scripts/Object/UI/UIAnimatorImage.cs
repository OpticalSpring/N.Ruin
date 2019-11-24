using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimatorImage : MonoBehaviour
{
    Animator ani;
    Image image;
    SpriteRenderer sprRen;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        image = gameObject.GetComponent<Image>();
        sprRen = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprRen.sprite;
    }
}
