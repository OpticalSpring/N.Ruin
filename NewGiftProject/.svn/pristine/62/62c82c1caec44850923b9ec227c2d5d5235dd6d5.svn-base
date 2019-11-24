using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCartSystem : MonoBehaviour
{
    public float movementSpeed;
    public float rotateSpeed;
    public GameObject[] movePoint;
    public int moveCount;
    bool vec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveCount)
        {
            case 0:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[0].transform.position, movementSpeed * Time.deltaTime);
                break;
            case 1:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[1].transform.position, movementSpeed * Time.deltaTime);
                break;
            case 2:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[2].transform.position, movementSpeed * Time.deltaTime);
                gameObject.transform.eulerAngles = Vector3.MoveTowards(gameObject.transform.eulerAngles, new Vector3(0, 90, 0), Time.deltaTime * rotateSpeed);
                break;
            case 3:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[3].transform.position, movementSpeed * Time.deltaTime);
                gameObject.transform.eulerAngles = Vector3.MoveTowards(gameObject.transform.eulerAngles, new Vector3(0, 90, 0), Time.deltaTime * rotateSpeed);
                break;
            case 4:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[4].transform.position, movementSpeed * Time.deltaTime);
                gameObject.transform.eulerAngles = Vector3.MoveTowards(gameObject.transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * rotateSpeed);
                break;
            case 5:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, movePoint[5].transform.position, movementSpeed * Time.deltaTime);
                gameObject.transform.eulerAngles = Vector3.MoveTowards(gameObject.transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * rotateSpeed);
                break;
        }

        if (Vector3.Distance(gameObject.transform.position, movePoint[moveCount].transform.position) < 0.5f)
        {
            moveCount++;

            if ((moveCount == 6))
            {
                moveCount = 0;
                gameObject.transform.position = movePoint[0].transform.position;
            }
        }
    }
}
