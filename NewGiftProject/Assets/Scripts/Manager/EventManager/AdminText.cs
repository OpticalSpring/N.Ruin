using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminText : MonoBehaviour
{
    public GameObject adminText;
    public Text adminTextObject;
    public Vector3 UIScale;
    // Start is called before the first frame update
    void Start()
    {
        adminTextObject = adminText.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       // adminText.transform.localScale = Vector3.Lerp(adminText.transform.localScale, UIScale, 10 * Time.deltaTime);
    }

    public void TextUpdate(string str)
    {
        adminTextObject.text = str;
        StartCoroutine(TextOn());
    }

    IEnumerator TextOn()
    {
        adminText.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(3f);
        adminText.transform.localScale = new Vector3(0, 0, 0);
    }
}
