using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool Stop;
    public bool Stop2;
    PlayerFSM playerFSM;
    public Animator animator;
    public float[] movementSpeed =  new float[3];//지정 속도
    public float[] nowSpeed = new float[2];//현재 속도
    float[] nextSpeed = new float[2];//다음 속도
    public Vector3 turnPoint = Vector3.zero;
    bool concealmenting;
    public Vector3 oldPos;
    float randAni, randAni2;
    SoundManager soundManager;
    void Start()
    {
        playerFSM = GetComponent<PlayerFSM>();
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        oldPos = gameObject.transform.position;
        turnPoint = new Vector3(gameObject.transform.position.x + 100, 0, gameObject.transform.position.z - 0.05f);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameObject.transform.position.z != oldPos.z)
        {
            oldPos.x = gameObject.transform.position.x;
            oldPos.y = gameObject.transform.position.y;

            //gameObject.transform.position = oldPos;
        }
        if (playerFSM.playerState != PlayerFSM.PlayerState.Death && playerFSM.playerState != PlayerFSM.PlayerState.Climb && playerFSM.playerState != PlayerFSM.PlayerState.Drop)
        {
            Concealment();
            InputKey();
        }
        if (playerFSM.playerState != PlayerFSM.PlayerState.Death && playerFSM.playerState != PlayerFSM.PlayerState.Climb && playerFSM.playerState != PlayerFSM.PlayerState.Interaction)
        {
            Move();
        }
        

    }

    public void SetAniState(int num)
    {
        animator.SetInteger("AniState", num);
    }

    void InputKey()
    {
        
            playerFSM.playerState = PlayerFSM.PlayerState.Idle;
            nextSpeed[0] = 0;
            nextSpeed[1] = 0;
        
            if (Stop == true) return;
        
        if(concealmenting == true)
        {
            SetAniState(3);
        }
        else
        {
            SetAniState(0);
            playerFSM.concealmentState = false;
        }
        
        if (Input.anyKey)
        {
            //if ((Input.GetKey(KeyCode.LeftControl) &&Input.GetKey(KeyCode.LeftArrow))||(concealmenting == true && Input.GetKey(KeyCode.LeftArrow)))
            //{
            //    playerFSM.playerState = PlayerFSM.PlayerState.Move;
            //    turnPoint = new Vector3(gameObject.transform.position.x - 1, 0, gameObject.transform.position.z - 0.05f);
            //    nextSpeed[0] = -movementSpeed[2];
            //    nextSpeed[1] = 1;
            //    SetAniState(3);
            //    Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            //    playerFSM.concealmentState = true;
            //}
            //else if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightArrow)) || (concealmenting == true && Input.GetKey(KeyCode.RightArrow)))
            //{
            //    playerFSM.playerState = PlayerFSM.PlayerState.Move;
            //    turnPoint = new Vector3(gameObject.transform.position.x + 1, 0, gameObject.transform.position.z - 0.05f);
            //    nextSpeed[0] = movementSpeed[2];
            //    nextSpeed[1] = 1;
            //    SetAniState(3);
            //    Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            //    playerFSM.concealmentState = true;
            //}
            if(Input.GetKey(KeyCode.LeftControl) && playerFSM.sitfa == false)
            {
                playerFSM.playerState = PlayerFSM.PlayerState.Idle;
                SetAniState(3);
                playerFSM.concealmentState = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) && concealmenting == false)//좌측으로 뛰기 상태
            {
               
                    nextSpeed[0] = -movementSpeed[1];
                if(soundManager.chase == true)
                {
                    nextSpeed[1] = 5;
                }
                else
                {
                    nextSpeed[1] = 4;
                }
                
                playerFSM.playerState = PlayerFSM.PlayerState.Move;
                turnPoint = new Vector3(gameObject.transform.position.x - 1, 0, gameObject.transform.position.z - 0.05f);
                SetAniState(0);
                //Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift) && concealmenting == false)//우측으로 뛰기 상태
            {
               
                    nextSpeed[0] = movementSpeed[1];
                if (soundManager.chase == true)
                {
                    nextSpeed[1] = 5;
                }
                else
                {
                    nextSpeed[1] = 4;
                }

                playerFSM.playerState = PlayerFSM.PlayerState.Move;
                turnPoint = new Vector3(gameObject.transform.position.x + 1, 0, gameObject.transform.position.z - 0.05f);
                SetAniState(0);
                //Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && concealmenting == false)//좌측으로 걷기 상태
            {
                
                    nextSpeed[0] = -movementSpeed[0];
                    nextSpeed[1] = 1;
                
                playerFSM.playerState = PlayerFSM.PlayerState.Move;
                turnPoint = new Vector3(gameObject.transform.position.x - 1, 0, gameObject.transform.position.z - 0.05f);
                SetAniState(0);
                //Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && concealmenting == false)//우측으로 걷기 상태
            {
                
                    nextSpeed[0] = movementSpeed[0];
                    nextSpeed[1] = 1;
              
                playerFSM.playerState = PlayerFSM.PlayerState.Move;
                turnPoint = new Vector3(gameObject.transform.position.x + 1, 0, gameObject.transform.position.z- 0.05f);
                SetAniState(0);
                //Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);
            }

        }
        
            Turn(gameObject.transform.GetChild(0).gameObject, turnPoint);

    }

    void Move()
    {
        nowSpeed[0] = Mathf.Lerp(nowSpeed[0], nextSpeed[0], 50 * Time.deltaTime);
        if (Mathf.Abs(nowSpeed[0]) < 0.01f) nowSpeed[0] = 0;

        nowSpeed[1] = Mathf.Lerp(nowSpeed[1], nextSpeed[1], 5 * Time.deltaTime);
        if (nowSpeed[1] < 0.01f) nowSpeed[1] = 0;
        gameObject.transform.position += new Vector3(nowSpeed[0] * Time.deltaTime, 0, 0);
        animator.SetFloat("Movement", nowSpeed[1]);
        
        if (Stop2 == true) return;
        gameObject.transform.GetChild(0).localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).localPosition, Vector3.zero,Time.deltaTime);
    }
    

    public void Turn(GameObject obj, Vector3 target)
    {
        float dz = target.z - gameObject.transform.position.z;
        float dx = target.x - gameObject.transform.position.x;

        float rotateDegree = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg;

        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, rotateDegree, 0), 500 * Time.deltaTime);
    }

   

    void Concealment()
    {
        if (playerFSM.concealmentState == true)
        {
            RaycastHit hit;
            float maxDistance = 0.5f;
            bool isHit = Physics.SphereCast(gameObject.transform.GetChild(0).position + new Vector3(0, 0.5f, 0), 0.15f, Vector3.up, out hit, maxDistance);
            if (isHit)
            {
                playerFSM.concealmentState = true;
                concealmenting = true;
            }
            else
            {
                concealmenting = false;
            }
        }
    }

   

    public void Death()
    {
        playerFSM.playerState = PlayerFSM.PlayerState.Death;
        SetAniState(10);
        StartCoroutine("DelayReStart");
    }

    IEnumerator DelayReStart()
    {
        yield return new WaitForSeconds(0f);
        GameObject.Find("GameManager").GetComponent<SaveManager>().ReLoadScene();
    }

   public void PlayerMoveStart(Transform targetPos)
    {
        StartCoroutine(PlayerMove(targetPos));
    }
    IEnumerator PlayerMove(Transform targetPos)
    {
        SetAniState(0);
        while (Vector3.Distance(transform.position, targetPos.position) > 0.1)
        {
            animator.SetFloat("Movement", 1);
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, movementSpeed[0] * Time.deltaTime);
            Turn(gameObject.transform.GetChild(0).gameObject, targetPos.position);
            yield return new WaitForSeconds(0.01f);
        }
       Stop = false;
    }
}
