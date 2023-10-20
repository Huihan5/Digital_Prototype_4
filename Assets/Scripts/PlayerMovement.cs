using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float leftBoundary = -10f;
    public float rightBoundary = 10f;
    public float bottomBoundary = -5f;
    public float upBoundary = 5f;

    public int moveSpeed = 3;

    SpriteRenderer myRend;

    public AudioSource mySource;
    public AudioClip walkingSound;

    public bool horizontalPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (transform.position.x >= leftBoundary && transform.position.x <= rightBoundary)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = true;

                WalkingSound();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = false;

                WalkingSound();
            }
        }

        if (!horizontalPlatform)
        {
            if (transform.position.y >= bottomBoundary && transform.position.y <= upBoundary)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                    //myRend.flipY = false;

                    WalkingSound();
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                    //myRend.flipY = true;

                    WalkingSound();
                }
            }
        }

        //Boundary
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, 0);

        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, 0);
        }

        if (transform.position.y < bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, bottomBoundary, 0);

        }
        else if (transform.position.y > upBoundary)
        {
            transform.position = new Vector3(transform.position.x, upBoundary, 0);
        }

    }

    void WalkingSound()
    {
        if (!mySource.isPlaying && walkingSound)
        {
            mySource.PlayOneShot(walkingSound);
        }
    }
}
