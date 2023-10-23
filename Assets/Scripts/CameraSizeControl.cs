using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScript : MonoBehaviour
{
    public Camera myCam;

    public float camMinSize = 2f;
    public float camMaxSize = 8f;

    public float camShowingMin = 3.5f;
    public float camShowingMax = 4.5f;

    public float showingTime = 3f;
    public float currentTime = 0f;
    public float loadingTime = 2f;

    public bool loading = false;

    public GameObject opaqueShade;
    public GameObject shade;

    public AudioSource mySource;
    public AudioClip wateringSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Changing Camera Size
        if (Input.GetKey(KeyCode.Q))
        {
            myCam.orthographicSize = myCam.orthographicSize + 1 * Time.deltaTime;

            if (myCam.orthographicSize > camMaxSize)
            {
                myCam.orthographicSize = camMaxSize;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            myCam.orthographicSize = myCam.orthographicSize - 1 * Time.deltaTime;

            if (myCam.orthographicSize < camMinSize)
            {
                myCam.orthographicSize = camMinSize;
            }
        }

        if (camShowingMin < myCam.orthographicSize && myCam.orthographicSize < camShowingMax)
        {
            opaqueShade.SetActive(true);
            currentTime += Time.deltaTime;

            WateringSound();
        }
        else
        {
            opaqueShade.SetActive(false);
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        //Showing object
        if (currentTime >= showingTime)
        {
            opaqueShade.SetActive(false);
            shade.SetActive(true);
            loading = true;
        }

        //Loading to the next scene
        if (loading)
        {
            loadingTime -= Time.deltaTime;
        }

        if (loadingTime <= 0)
        {
            SceneManager.LoadScene(1);
        }

    }

    void WateringSound()
    {
        if (!mySource.isPlaying && wateringSound)
        {
            mySource.PlayOneShot(wateringSound);
        }
    }
}
