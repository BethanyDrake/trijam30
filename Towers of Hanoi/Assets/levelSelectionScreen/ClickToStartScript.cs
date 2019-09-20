using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void BackToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Wombat");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Echidna");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Koala");
    }

     public void StartLevel4()
    {
        SceneManager.LoadScene("Wallaby");
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) {
        //     SceneManager.LoadScene("MainScene");
        // }
    }
}
