using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public int nowSceneNumber;
    public int progressState;
    public GameObject[] playerStartPoint;
    public GameObject[] cameraStartPoint;
   


    // Start is called before the first frame update
    void Start()
    {
        progressState = PlayerPrefs.GetInt("ProgressState");
        PlayerPrefs.SetInt("SceneState", nowSceneNumber);
        GameObject.Find("Player").transform.position = playerStartPoint[progressState].transform.position;
        GameObject.Find("MainCam").transform.position = cameraStartPoint[progressState].transform.position;
    }

    public void Save(int state)
    {
        progressState = state;
        PlayerPrefs.SetInt("ProgressState", progressState);
    }

    public void ReLoadScene()
    {
        StartCoroutine("DelayReLoad");
    }

    public void NextScene()
    {
        StartCoroutine("DelayClear");
    }

    public void Exit()
    {
        StartCoroutine("DelayExit");
    }

    IEnumerator DelayReLoad()
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().FadeOut();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(nowSceneNumber);
    }

    IEnumerator DelayClear()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().AllSoundStop();
        GameObject.Find("GameManager").GetComponent<UIManager>().FadeOut();
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(nowSceneNumber + 1);
    }
    IEnumerator DelayExit()
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().FadeOut();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(0);
    }
}
