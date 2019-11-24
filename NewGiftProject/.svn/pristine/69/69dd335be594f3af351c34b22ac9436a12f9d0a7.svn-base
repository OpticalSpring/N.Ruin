using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpotLight : MonoBehaviour
{
    public enum LightColor
    {
        Red,
        Yellow,
        Green
    }

    public LightColor lightColor;
    Camera cam;
    GameObject player;
    public float aimTime;
    public GameObject bullet;
    public bool ammo;
    DebuffManager debuffManager;
    public bool nauto;
    // Start is called before the first frame update
    void Awake()
    {
        debuffManager = GameObject.Find("GameManager").GetComponent<DebuffManager>();
        switch (lightColor)
        {
            case LightColor.Red:
                GetComponent<Light>().color = Color.red;
                break;
            case LightColor.Yellow:
                GetComponent<Light>().color = Color.yellow;
                break;
            case LightColor.Green:
                GetComponent<Light>().color = Color.green;
                break;
        }
        cam = GetComponent<Camera>();
        if(nauto == false)
        cam.fieldOfView = GetComponent<Light>().spotAngle / 1.5f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FireCheck();
    }

    void FireCheck()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(player.transform.position + new Vector3(0,0.8f,0));
        if (viewPos.z > 0 && viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1)
        {
            RaycastHit hit;
            float maxDistance = 1000f;
            if (player.GetComponent<PlayerFSM>().concealmentState == true)
            {
                gameObject.transform.GetChild(0).LookAt(player.transform.position + new Vector3(0, 0.0f, 0));
            }
            else
            {
                gameObject.transform.GetChild(0).LookAt(player.transform.position + new Vector3(0, 0.8f, 0));
            }
            bool isHit = Physics.Raycast(gameObject.transform.GetChild(0).position, gameObject.transform.GetChild(0).forward, out hit, maxDistance);
            Debug.DrawRay(gameObject.transform.GetChild(0).position, gameObject.transform.GetChild(0).forward * maxDistance, Color.red);
            if (isHit)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (aimTime < 0)
                    {
                        switch (lightColor)
                        {
                            case LightColor.Red:
                                Fire();
                                break;
                            case LightColor.Yellow:
                                if (hit.collider.gameObject.GetComponent<PlayerFSM>().playerState != PlayerFSM.PlayerState.Idle)
                                    Fire();
                                break;
                            case LightColor.Green:
                                if (hit.collider.gameObject.GetComponent<PlayerFSM>().playerState != PlayerFSM.PlayerState.Move)
                                    Fire();
                                break;
                        }
                    }
                    else
                    {
                        aimTime -= Time.deltaTime;
                    }
                }
                else
                {
                    aimTime = 0.0f;
                }
            }

        }
    }

    void Fire()
    {
        //if (ammo == false)
        //{
        //    ammo = true;
        //    GameObject Temp = Instantiate(bullet);
        //    Temp.transform.position = gameObject.transform.position;
        //}
        debuffManager.debuffValue -= 100;
    }
}
