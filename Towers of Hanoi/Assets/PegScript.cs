using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{



    public void AddSegment(GameObject segment) {
        segments.Add(segment);
    }
    void OnMouseDown(){
        Debug.Log("clicked!!");

        if (Manager.instance.liftingSegment){
            Manager.instance.DropSegmentOnPeg(gameObject);

        }

        if (!Manager.instance.liftingSegment){
            Debug.Log("seg count ="+ segments.Count );
            if (segments.Count == 0) {
                //do nothing
            } else {
                Manager.instance.liftingSegment = true;
                GameObject topSegment = segments[segments.Count -1];
                (topSegment.GetComponent<SegmentScript>() as SegmentScript).Lift();
                Manager.instance.segmentBeingLifted = topSegment;
                segments.Remove(topSegment);
                Debug.Log(topSegment);

            }
        }

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
