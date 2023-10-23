using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseScript : MonoBehaviour
{
    BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            myCollider.isTrigger = true;
        }
    }
}
