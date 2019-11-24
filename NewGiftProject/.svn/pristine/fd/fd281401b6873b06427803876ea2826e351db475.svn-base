using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc : MonoBehaviour
{
    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine("I1");

    }

    // Update is called once per frame
    void Update()
    {
        if (end == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                end = true;
                StartCoroutine("I2");
            }
        }
    }

    IEnumerator I1()
    {
        yield return new WaitForSeconds(100);
        for (int k = 100; k > 0; --k)
        {
            gameObject.GetComponent<AudioSource>().volume = (float)k / 100;

            yield return new WaitForSeconds(0.01f);
        }
        PlayerPrefs.SetInt("SceneState", 0);
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(0);
        Destroy(gameObject);
    }
    IEnumerator I2()
    {
        for (int k = 100; k > 0; --k)
        {
            gameObject.GetComponent<AudioSource>().volume = (float)k / 100;

            yield return new WaitForSeconds(0.01f);
        }
        PlayerPrefs.SetInt("SceneState", 0);
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(0);
        Destroy(gameObject);
    }

}
