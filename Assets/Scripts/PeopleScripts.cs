using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleScripts : MonoBehaviour
{
    public Sprite people1;
    public Sprite people2;

    int mySpeed;
    public int moveSpeedSlow;
    public int moveSpeedFast;

    public float leftBoundary;

    SpriteRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();

        int size = Random.Range(0, 1);

        if(size == 1)
        {
            myRend.sprite = people1;
            mySpeed = moveSpeedFast;
        }
        else
        {
            myRend.sprite = people2;
            mySpeed = moveSpeedSlow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1, 0, 0)*mySpeed;

        if (transform.position.x <= leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
