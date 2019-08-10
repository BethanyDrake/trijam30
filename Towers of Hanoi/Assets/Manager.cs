using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager instance;
    public bool liftingSegment;
    public bool movingSegment;
    public GameObject segmentBeingLifted;
    // Start is called before the first frame update

    public float travelDistanceRemaining;
    public float segmentMoveSpeed;

    public Vector3 targetPosition;

    public Vector3 direction;

    public GameObject targetPeg;
    public void DropSegmentOnPeg (GameObject peg) {
        Debug.Log(peg);
        targetPeg = peg;
        movingSegment = true;
        targetPosition = new Vector3 (peg.transform.position.x,
            segmentBeingLifted.transform.position.y,
            peg.transform.position.z);

        float distance = Vector3.Distance(targetPosition, segmentBeingLifted.transform.position);
        Debug.Log("distance: " + distance);
        //travelTimeRemaining = distance / segmentMoveSpeed;
       // Debug.Log("time: " + travelTimeRemaining);
        direction = targetPosition - segmentBeingLifted.transform.position;

        travelDistanceRemaining = distance;


    }
    void Start () {
        Manager.instance = this;
        liftingSegment = false;
        movingSegment = false;

    }

    void DropSegment() {
        if ((targetPeg.GetComponent<PegScript>() as PegScript).IsValidMove(segmentBeingLifted)) {
            (segmentBeingLifted.GetComponent<Rigidbody>() as Rigidbody).isKinematic = false;

            (targetPeg.GetComponent<PegScript>() as PegScript).AddSegment(segmentBeingLifted);

            liftingSegment = false;
        } else {
            WarnInvalidMove();
        }

    }

    void WarnInvalidMove() {
        Debug.Log("invalid move");
    }


    // Update is called once per frame
    void Update () {
        if (movingSegment) {

            segmentBeingLifted.transform.position += (direction * Time.deltaTime * segmentMoveSpeed);
            //distanceTravelled += (direction * Time.deltaTime * segmentMoveSpeed).magnitude;
            travelDistanceRemaining -= (direction * Time.deltaTime * segmentMoveSpeed).magnitude;
            if (travelDistanceRemaining <= 0) {
                segmentBeingLifted.transform.position = targetPosition;
                movingSegment = false;
                DropSegment();
            }
        }

    }
}