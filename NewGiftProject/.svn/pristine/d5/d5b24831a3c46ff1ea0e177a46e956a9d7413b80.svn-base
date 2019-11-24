using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationSystem : MonoBehaviour
{
    public int movementType;
    public GameObject movementObject;
    public GameObject[] movePoint;
    public float movementSpeed;
    public bool usedOn;
    GameObject player;
    public Vector3 UIScale;
    public float aa;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    void UseCheck()
    {
       
            if (Input.GetKeyDown(KeyCode.Z) && Vector3.Distance(gameObject.transform.position, player.transform.position) < 1f)
            {
                if (usedOn == true)
                {
                  player.GetComponent<PlayerControl>().enabled = true;
                player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Idle;
                player.GetComponent<PlayerControl>().SetAniState(0);
                
                    usedOn = false;
                }
                else
                {
                player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Interaction;
                player.GetComponent<PlayerControl>().SetAniState(4);
               player.gameObject.GetComponent<PlayerControl>().enabled = false;
                    usedOn = true;
                }
            }
        
    }
    void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 600 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        aa = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (player.GetComponent<PlayerFSM>().playerState != PlayerFSM.PlayerState.Death)
        {
            UseCheck();
            if (usedOn == true)
            {
                KeyInput();
                Turn(player.transform.GetChild(0).gameObject, gameObject.transform.position);
            }
        }

        UIChange();
    }

    void KeyInput()
    {
        player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Idle;
        
            if (Input.GetKey(KeyCode.LeftArrow) && movementType == 0)
        {
            player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Move;
            movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, movePoint[0].transform.position, movementSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.RightArrow) && movementType == 0)
        {
            player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Move;
            movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, movePoint[1].transform.position, movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && movementType == 1)
        {
            player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Move;
            movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, movePoint[1].transform.position, movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && movementType == 1)
        {
            player.GetComponent<PlayerFSM>().playerState = PlayerFSM.PlayerState.Move;
            movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, movePoint[0].transform.position, movementSpeed * Time.deltaTime);
        }
    }
    void UIChange()
    {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1f)
            {
                UIScale = new Vector3(0.4f , 0.4f, 0.4f);
            }
            else
            {
                UIScale = new Vector3(0, 0, 0);
            }
        

        gameObject.transform.GetChild(0).GetChild(0).localScale = Vector3.Lerp(gameObject.transform.GetChild(0).GetChild(0).localScale, UIScale, 10 * Time.deltaTime);
        if(usedOn == true)
        {
            if (movementType == 0)
            {
                gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled =false;
                gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                gameObject.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>().enabled = false;
            }
            else
            {
                gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled = false;
                gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().enabled = false;
                gameObject.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            gameObject.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
