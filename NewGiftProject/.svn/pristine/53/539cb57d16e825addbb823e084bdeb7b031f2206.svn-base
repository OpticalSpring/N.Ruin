using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniEvent : MonoBehaviour
{
    PlayerFSM playerFSM;
    SoundManager soundManager;

    private void Start()
    {
         playerFSM= gameObject.transform.parent.gameObject.GetComponent<PlayerFSM>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    
    public void SoundWalk()
    {
        switch (playerFSM.terrain)
        {
            case 0:
                soundManager.SoundPlay(2, Random.Range(0, 3));
                break;
            case 1:
                soundManager.SoundPlay(2, Random.Range(8, 11));
                break;
            case 2:
                soundManager.SoundPlay(2, Random.Range(16, 19));
                break;
        }
    }

    public void SoundRun()
    {
        switch (playerFSM.terrain)
        {
            case 0:
                soundManager.SoundPlay(2, Random.Range(4, 7));
                break;
            case 1:
                soundManager.SoundPlay(2, Random.Range(12, 15));
                break;
            case 2:
                soundManager.SoundPlay(2, Random.Range(20, 23));
                break;
        }
    }
    

    public void ClimbEnd()
    {
        gameObject.transform.parent.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Idle;
        gameObject.GetComponent<Animator>().SetInteger("AniState", 0);
        gameObject.transform.parent.position = gameObject.transform.position;
        gameObject.transform.localPosition = Vector3.zero;
    }
}
