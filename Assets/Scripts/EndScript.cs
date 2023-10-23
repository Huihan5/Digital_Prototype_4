using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    FadeChanger myChanger;

    public float countDown = 3;
    public GameObject info;

    // Start is called before the first frame update
    void Start()
    {
        myChanger = GameObject.Find("LevelChanger").GetComponent<FadeChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0)
        {
            countDown = 0;
            info.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            myChanger.FadeTo(0);
        }
    }
}
