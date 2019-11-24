using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    public Animator animator;
    public bool death;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(death == false)
        {
            gameObject.transform.position += new Vector3(0.7f * Time.deltaTime, 0, 0);
            animator.SetFloat("Movement", 1);
        }
    }

    public void SetAniState(int num)
    {
        animator.SetInteger("AniState", num);
    }

    public void Death()
    {
        death = true;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(8, 10);
        SetAniState(10);
    }
}
