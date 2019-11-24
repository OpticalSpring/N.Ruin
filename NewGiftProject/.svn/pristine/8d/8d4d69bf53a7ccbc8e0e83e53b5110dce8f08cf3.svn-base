using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnningSoundSet : MonoBehaviour
{
    public GameObject player;
    SoundManager sound;
    public float dis;
    public int backsound;
    public int a;
   public float f1, f2;
    public float rf1, rf2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound.SoundPlay(5, 4);
        sound.SoundVolumeSet(5, 4, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dis = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        if (dis < a)
        {
            f1 = 1;
            f2 = 0;
        }
        else if(dis < a+5)
        {
            f1 = 0.2f;
            f2 = 0f;
        }
        else
        {
            f1 = 0.0f;
            f2 = 1f;
        }
        if (dis < 20)
        {
            rf1 = Mathf.Lerp(rf1, f1, Time.deltaTime);
            rf2 = Mathf.Lerp(rf2, f2, Time.deltaTime);
            sound.SoundVolumeSet(5, 4, rf1);
            sound.SoundVolumeSet(1, backsound, rf2);
        }
    }
}
