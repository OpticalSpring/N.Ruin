using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Move,
        Death,
        Drop,
        Climb,
        Interaction

    }
    public PlayerState playerState;

    
    public bool concealmentState;
    public bool chaseState;
    public int terrain;
    public bool sitfa;

    private void Update()
    {
        if (concealmentState == true)
        {
            GetComponent<CapsuleCollider>().height = 0.8f;
            GetComponent<CapsuleCollider>().center = new Vector3(0, 0.6f, 0);
        }
        else
        {
            GetComponent<CapsuleCollider>().height = 1.8f;
            GetComponent<CapsuleCollider>().center = new Vector3(0, 0.9f, 0);
        }
    }
}
