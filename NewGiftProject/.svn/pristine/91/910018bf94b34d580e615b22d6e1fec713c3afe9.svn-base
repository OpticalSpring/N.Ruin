using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    public float debuffValue;
    public float debuffDistance;
    ShadowThresholdCustomEffect cameraSet;
    public bool aa;
    
    public float power;
    public Texture[] glitchTexture;
    public bool stop;
    public float heartF;
    // Start is called before the first frame update
    void Start()
    {
        heartF = 3;
        cameraSet = GameObject.Find("MainCam").transform.GetChild(0).GetChild(0).GetComponent<ShadowThresholdCustomEffect>();
        debuffValue = 100;
        debuffDistance = 100;
        cameraSet.GlitchTextureChange(glitchTexture[0]);
        StartCoroutine("HeartBeat");
    }

    // Update is called once per frame
    void Update()
    {
        ValueDown();
    }

    public void ValueUp()
    {
        debuffValue = 100;
    }

    public void ValueDisUp()
    {
        debuffDistance += Time.deltaTime;
    }

    IEnumerator HeartBeat()
    {
        while (true)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(2, Random.Range(32,35));
            yield return new WaitForSeconds(heartF);
        }
    }

    void ValueDown()
    {
        if(debuffValue > 0 && stop == false)
        {
            debuffValue -= Time.deltaTime * power;
        }
        else if(debuffValue <= 0)
        {
            if(aa == false)
            {
                aa = true;
                GameObject.Find("Player").GetComponent<PlayerControl>().Death();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(7, 19);
            }
        }
        cameraSet.glitchuv = 1;

        if (debuffValue < 1 )
        {
            cameraSet.zero = true;
            cameraSet.GlitchflowSpeed = 100;
            cameraSet.glipower = 0.1f;
            cameraSet.GlitchTextureChange(glitchTexture[1]);
            heartF = 0.4f;
        }
        else if (debuffValue < 25 || debuffDistance < 2)
        {
            cameraSet.zero = true;
            cameraSet.GlitchflowSpeed = 50;
            cameraSet.glipower = 3;
            heartF = 0.6f;
        }
        else if (debuffValue < 50 || debuffDistance < 4)
        {
            cameraSet.zero = true;
            cameraSet.GlitchflowSpeed = 25;
            cameraSet.glipower = 6;
            heartF = 0.8f;
        }
        else if(debuffValue < 75 || debuffDistance < 6)
        {
            cameraSet.zero = true;
            cameraSet.GlitchflowSpeed = 10;
            cameraSet.glipower = 9;
            heartF = 1.2f;
        }
        else
        {
            cameraSet.zero = false;
            cameraSet.GlitchflowSpeed = 0;
            cameraSet.glipower = 1;
            heartF = 3f;
            cameraSet.GlitchTextureChange(glitchTexture[0]);
        }
    }
}
