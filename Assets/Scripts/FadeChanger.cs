using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeChanger : MonoBehaviour
{
    public Animator myAnimator;

    [SerializeField]
    public bool levelEnd;

    [SerializeField]
    public int nextLevel;
    //SceneManager.GetActiveScene().buildIndex +1
    [SerializeField]
    public int levelToLoad;
    [SerializeField]
    public float fadeCountDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    levelEnd = true;
        //}

        if (levelEnd)
        {
            FadeTo(nextLevel);
        }
    }

    public void LevelEnd()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadeTo(int levelIndex)
    {
        levelToLoad = levelIndex;
        myAnimator.SetTrigger("FadeOut");
    }

    public void GoToNext()
    {
        FadeTo(nextLevel);
    }
}
