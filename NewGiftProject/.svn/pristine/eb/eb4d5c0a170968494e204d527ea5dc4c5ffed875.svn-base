using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : MonoBehaviour
{
    GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        gameObject.transform.LookAt(player.transform.position + new Vector3(0,1,0));
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1f)
        {
            player.GetComponent<PlayerControl>().Death();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerControl>().Death();
            Destroy(gameObject);
        }
    }

}
