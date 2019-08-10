using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager instance;
    public bool lifting;
    // Start is called before the first frame update
    void Start()
    {
        Manager.instance = this;
        lifting = false;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
