using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researcher : MonoBehaviour
{
    public int aniState;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    public void MoveStart(Vector3 targetPos)
    {
        StartCoroutine(Move(targetPos));
    }
    // Update is called once per frame
    void Update()
    {
        SetAniState(aniState);
    }
    public void SetAniState(int num)
    {
        animator.SetInteger("AniState", num);
    }
    public void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }
    IEnumerator Move(Vector3 targetPos)
    {
        SetAniState(2);
        for (int i = 0; i < 20; i++)
        {
            Turn(gameObject.transform.GetChild(0).gameObject, targetPos);
            yield return new WaitForSeconds(0.01f);
        }
        while (Vector3.Distance(transform.position, targetPos) > 1)
        {
            animator.SetFloat("Movement", 1);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 4 * Time.deltaTime);
            Turn(gameObject.transform.GetChild(0).gameObject, targetPos);
            yield return new WaitForSeconds(0.01f);
        }
        aniState = 0;
    }
}
