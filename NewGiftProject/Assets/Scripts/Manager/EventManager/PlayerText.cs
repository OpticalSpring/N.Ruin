using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerText : MonoBehaviour
{
    public GameObject playerText;
    public Text playerTextObject;
    Vector4[] UIScale = new Vector4[2];
    public GameObject player;
    Camera cam;
    public Vector3 selPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerText = player.transform.GetChild(1).GetChild(0).gameObject;
        playerTextObject = playerText.transform.GetChild(0).gameObject.GetComponent<Text>();
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = cam.WorldToScreenPoint(player.transform.position) + selPos;
        newPos.z = 0;
        playerText.transform.position = newPos;
        //playerText.transform.localScale = Vector3.Lerp(playerText.transform.localScale, UIScale, 10 * Time.deltaTime);
        playerText.GetComponent<Image>().color = Vector4.Lerp(playerText.GetComponent<Image>().color, UIScale[0], Time.deltaTime * 4);
        playerText.transform.GetChild(0).GetComponent<Text>().color = Vector4.Lerp(playerText.transform.GetChild(0).GetComponent<Text>().color, UIScale[1], Time.deltaTime * 4);
    }

    public void TextUpdate(string str)
    {
        playerTextObject.text = str;
        StartCoroutine(TextOn());
    }

    IEnumerator TextOn()
    {
        UIScale[0] = new Vector4(1, 1, 1, 1);
        UIScale[1] = new Vector4(0.4705883f, 0.6784314f, 0.7960785f, 1);
        yield return new WaitForSeconds(3f);
        UIScale[0] = new Vector4(1, 1, 1, 0);
        UIScale[1] = new Vector4(0.4705883f, 0.6784314f, 0.7960785f, 0);
    }
}
