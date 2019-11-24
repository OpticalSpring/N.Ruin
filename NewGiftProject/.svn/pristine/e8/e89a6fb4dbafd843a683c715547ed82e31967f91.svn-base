using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image fadeSpr;
    public float i;
    public float j;
    public Image debuffImage;
    public Sprite[] dspr;
    public GameObject[] bgChange;
    DebuffManager debuff;
    public GameObject record;
    // Start is called before the first frame update
    void Start()
    {
        fadeSpr.color = new Vector4(0, 0, 0, 1.2f);
        debuff = GetComponent<DebuffManager>();
        FadeIn();
        StartCoroutine("FlashRecord");
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 0)
        {
             fadeSpr.color = Vector4.MoveTowards(fadeSpr.color, new Vector4(0, 0, 0, i), Time.deltaTime * 0.3f);

        }
        else
        {
            fadeSpr.color = Vector4.MoveTowards(fadeSpr.color, new Vector4(0, 0, 0, i), Time.deltaTime * 1f);
        }
        debuffImage.fillAmount = debuff.debuffValue/100;
        if (debuff.debuffValue < 50)
        {
            debuffImage.sprite = dspr[1];
            bgChange[0].SetActive(false);
            bgChange[1].SetActive(true);
        }
        else
        {
            debuffImage.sprite = dspr[0];
            bgChange[0].SetActive(true);
            bgChange[1].SetActive(false);
        }
    }

    public void FadeIn()
    {
        i = 0;
    }

    public void FadeOut()
    {
        i = 1;
    }

   
    IEnumerator FlashRecord()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            record.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            record.SetActive(false);
        }
    }
}
