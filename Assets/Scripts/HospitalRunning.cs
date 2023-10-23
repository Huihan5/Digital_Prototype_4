using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HospitalRunning : MonoBehaviour
{
    public GameObject conversationBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //public Sprite figureImage;

    public bool Line1;
    public bool Line2;
    public bool Line3;
    public bool Line4;
    public bool Line5;

    public bool conversation;
    public bool running;
    [SerializeField]
    public bool readingLetter;

    public GameObject people;

    public float peopleLoadingTime;
    public float peopleNowTime;

    public GameObject gateEntering;
    //public GameObject letter;

    public AudioSource mySource;
    //public AudioClip ambience;

    public Transform myCamPos;
    private CameraShake myCameraShake;

    public Transform nurseSpot;

    public bool shouting;
    public bool alreadyShout1 = true;

    FadeChanger myChanger;

    // Start is called before the first frame update
    void Start()
    {
        myCameraShake = GetComponent<CameraShake>();
        myChanger = GameObject.Find("LevelChanger").GetComponent<FadeChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation)
        {
            transform.position = nurseSpot.position + new Vector3(2, 0, 0);

            if (Line1)
            {
                nameText.text = "Nurse";
                dialogueText.text = "Are you ready for the surgery? Your wife has already been in the room.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line1 = false;
                }
            }
            else if (Line2)
            {
                nameText.text = "Me";
                dialogueText.text = "Would this surgery really change everything? It's really making me feel unassured...";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line2 = false;
                }
            }
            else if (Line3)
            {
                nameText.text = "Nurese";
                dialogueText.text = "Are you hesitating? Relax. It is a simple process. After the surgery, you would become a better human. Like everybody else.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line3 = false;
                }
            }
            else if (Line4)
            {
                nameText.text = "Me";
                dialogueText.text = "No. No, it won't! I have to leave this place. Right now.";

                shouting = true;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Line4 = false;
                }
            }
            else if (Line5)
            {
                nameText.text = "Nurse";
                dialogueText.text = "Wait! What are you going?";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    running = true;
                    conversationBox.SetActive(false);
                    Line5 = false;
                    conversation = false;
                }
            }
        }

        if (shouting && alreadyShout1)
        {
            myCameraShake.Shake(0.1f);
            alreadyShout1 = false;
        }

        if (running)
        {
            myCamPos.position = transform.position + new Vector3(0,2,-10);

            peopleNowTime -= Time.deltaTime;

            if(peopleNowTime <= 0)
            {
                peopleNowTime = peopleLoadingTime;
                Instantiate(people,transform.position + new Vector3(5, 0, 0), Quaternion.identity);
            }

        }

        if (readingLetter)
        {
            myChanger.GoToNext();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Line5)
        {
            if (collision.gameObject.name == "Nurse")
            {
                conversationBox.SetActive(true);
                conversation = true;
            }
        }

        if (collision.gameObject.name == "EndPoint")
        {
            running = false;
            readingLetter = true;
        }

        //if (collision.gameObject.name == "Surgery")
        //{

        //}
    }

}
