using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSoundManager : MonoBehaviour
{
    int oldValue;
    public void SoundPlay(int i, int j)
    {
        gameObject.transform.GetChild(i).GetChild(j).gameObject.GetComponent<AudioSource>().Play();
    }

    public void RandomPlay(int i, int x, int y)
    {
        int j;
        while (true)
        {
            j = Random.Range(x, y + 1);
            if(oldValue != j)
            {
                break;
            }
        }
        oldValue = j;
        SoundPlay(i, j);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Sound");
        StartCoroutine("Sound2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Sound()
    {
        while (true)
        {
            RandomPlay(0, 0, 10);
            yield return new WaitForSeconds(Random.Range(2,6));
        }
    }

    IEnumerator Sound2()
    {
        while (true)
        {
            RandomPlay(0, 11, 15);
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    }
}
