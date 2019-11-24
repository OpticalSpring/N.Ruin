using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public Button[] chapterButton;
    public Image backImage;
    public Sprite[] backSpr;
    public GameObject[] chapText;
    public GameObject[] button;
    public GameObject credit;
    public int stageNumber;
    private void Awake()
    {
        
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        Cursor.visible = true;
    }
    private void Start()
    {
        stageNumber = PlayerPrefs.GetInt("Stage");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SoundPlay(1, 0);
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.F1))
        //{
        //    PlayerPrefs.SetInt("EndCount", 0);
        //    PlayerPrefs.SetInt("Stage", 0);
        //    SceneManager.LoadSceneAsync(0);
        //}

        //if (Input.GetKey(KeyCode.F2))
        //{
        //    PlayerPrefs.SetInt("EndCount", 11);
        //    PlayerPrefs.SetInt("Stage", 2);
        //    SceneManager.LoadSceneAsync(0);
        //}
    }
    public GameObject[] setObject;

    public void SetButton_0()
    {
        NewGame();
    }
    public void SetButton_1()
    {
        Continue();
    }
    public void SetButton_2()
    {
        ChapterOepn();
    }
    public void SetButton_3()
    {
        CreditsOpen();
    }
    public void SetButton_4()
    {
        Exit();
    }
    void NewGame()
    {
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(1);
    }

    void Continue()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneState"));
    }

    void ChapterOepn()
    {
        setObject[0].SetActive(false);
        setObject[3].SetActive(true);
    }

    public void ChapterClose()
    {
        setObject[0].SetActive(true);
        setObject[3].SetActive(false);
    }

    void CreditsOpen()
    {
        setObject[0].SetActive(false);
        setObject[4].SetActive(true);
        credit.transform.localPosition = new Vector3(0, -5500, 0);
    }

   public void CreditsClose()
    {
        setObject[0].SetActive(true);
        setObject[4].SetActive(false);
    }

    void Exit()
    {
        Application.Quit();
    }

    public void ChapterSet_1()
    {
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(1);
        
    }
    public void ChapterSet_2()
    {
        if (stageNumber > 0)
        {
            PlayerPrefs.SetInt("ProgressState", 0);
            SceneManager.LoadSceneAsync(2);
        }
    }
    public void ChapterSet_3()
    {
        if (stageNumber > 1)
        {
            PlayerPrefs.SetInt("ProgressState", 0);
            SceneManager.LoadSceneAsync(4);
        }
    }
    public void ChapterSet_4()
    {
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(4);
    }
    public void ChapterSet_5()
    {
        PlayerPrefs.SetInt("ProgressState", 0);
        SceneManager.LoadSceneAsync(5);
    }
    public void ButtonOffMouse()
    {
        backImage.sprite = backSpr[0];
        for (int i = 0; i < 3; i++)
        {
            button[i].transform.localScale = new Vector3(1, 1, 1);
            chapText[i].GetComponent<Animator>().SetInteger("AniState", 0);
            chapText[i].SetActive(false);
        }
    }

    public void ButtonOnMouse1()
    {
        
        button[0].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        backImage.sprite = backSpr[1];
        chapText[0].SetActive(true);
        chapText[0].GetComponent<Animator>().SetInteger("AniState", 1);
    }
    public void ButtonOnMouse2()
    {
        if (stageNumber > 0)
        {
            button[1].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            backImage.sprite = backSpr[2];
            chapText[1].SetActive(true);
            chapText[1].GetComponent<Animator>().SetInteger("AniState", 2);
        }
    }
    public void ButtonOnMouse3()
    {
        if (stageNumber > 1)
        {
            button[2].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            backImage.sprite = backSpr[3];
            chapText[2].SetActive(true);
            chapText[2].GetComponent<Animator>().SetInteger("AniState", 3);
        }
    }
}
