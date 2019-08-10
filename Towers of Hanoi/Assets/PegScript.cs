using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{


    void OnMouseDown(){
        Debug.Log("clicked!!");
        GameObject topSegment = segments[segments.Count -1];
        (topSegment.GetComponent<SegmentScript>() as SegmentScript).Lift();
        Debug.Log(topSegment);
    }
    public List<GameObject> segments = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
}
