using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{


    public bool IsValidMove(GameObject segment) {
        if (segments.Count == 0) return true;
        float segmentSize = segment.transform.localScale.x;
        GameObject topSegment = segments[segments.Count - 1];
        float topSegmentSize = topSegment.transform.localScale.x;
        return (segmentSize <= topSegmentSize);
    }




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

    public bool HasCompleteTower() {

        Debug.Log("checking complete tower!" + this+ "segmentCount " + segments.Count);
        if (segments.Count != Manager.instance.heightOfCompleteTower) return false;
        Debug.Log("a");
        var team = (segments[0].GetComponent<SegmentScript>() as SegmentScript).team;
        Debug.Log("tean" + team);
        foreach(GameObject segment in segments) {
            if ((segment.GetComponent<SegmentScript>() as SegmentScript).team != team) {
                return false;
            }
            Debug.Log("correct");

        }
         return true;


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
