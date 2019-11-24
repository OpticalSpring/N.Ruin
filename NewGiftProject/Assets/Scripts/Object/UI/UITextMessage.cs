using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITextMessage : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2.2f, 0);
    Vector3 offsetIngame;
    public string textString;
    SpriteRenderer spriteRender;
    Text text;

    Vector2 uiScale;
    Vector3 canvasScale;
    Vector3 canvasScaleNow;
    float x_NOW;
    public float x_MAX;
    float y_NOW;
    public bool textOn;
    public GameObject mainObejct;
    Vector3 targetPos;
    float canvas_Y = 1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageSizeUpdate();
    }

    void ImageSizeUpdate()
    {

        targetPos = mainObejct.transform.position;
        targetPos += offsetIngame;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 10 * Time.deltaTime);

        uiScale = Vector2.Lerp(uiScale, new Vector2(x_NOW * 0.7f, 2 * 0.7f), 10 * Time.deltaTime);
        canvasScale = Vector3.Lerp(canvasScale, canvasScaleNow, 10 * Time.deltaTime);
        gameObject.transform.localScale = canvasScale;
        spriteRender.size = uiScale;
        transform.LookAt(Camera.main.transform);
    }
    public void TextOn()
    {
        StartCoroutine("UION");
    }

    void TextOff()
    {
        StartCoroutine("UIOFF");
    }


    IEnumerator UION()
    {
        textOn = true;
        offsetIngame = offset;
        //canvas_Y = mainObejct.transform.position.y+2.2f;
        canvasScaleNow = new Vector3(0.03f, 0.03f, 0.03f);
        //x_MAX = textString.Length;
        x_NOW = 0;

        while (x_NOW < x_MAX)
        {
            x_NOW += 1;
            //text.text = textString.Substring(0,(int) x_NOW);
            yield return new WaitForSeconds(0.3f / x_MAX);
        }
        text.text = textString;
        yield return new WaitForSeconds(3f);
        TextOff();
    }

    IEnumerator UIOFF()
    {

        //x_MAX = textString.Length;
        x_NOW = x_MAX;
        text.text = "";
        while (x_NOW > 0)
        {
            x_NOW -= 1;
            //text.text = textString.Substring(0, (int)x_NOW);
            yield return new WaitForSeconds(0.3f / x_MAX);
        }
        offsetIngame.y = offset.y - 1f;
        //canvas_Y = mainObejct.transform.position.y + 1;
        canvasScaleNow = new Vector3(0, 0, 0);
        textOn = false;
    }
}