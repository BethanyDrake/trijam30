using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WinChecker : MonoBehaviour
{
    public abstract bool CheckWinState(GameObject[] pegs);
}

public class Manager : MonoBehaviour {

    public static Manager instance;

    public int heightOfCompleteTower;
    public bool liftingSegment;
    public bool movingSegment;
    public GameObject segmentBeingLifted;
    // Start is called before the first frame update
    public GameObject winText;

    public GameObject[] pegs = new GameObject[3];
    public float travelDistanceRemaining;
    public float segmentMoveSpeed;
    public bool cheat;
    public Vector3 targetPosition;

    public Vector3 direction;

    public WinChecker winChecker;
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
        cheat = false;
    }

    void DropSegment() {
        if ((targetPeg.GetComponent<PegScript>() as PegScript).IsValidMove(segmentBeingLifted)) {
            (segmentBeingLifted.GetComponent<Rigidbody>() as Rigidbody).isKinematic = false;

            (targetPeg.GetComponent<PegScript>() as PegScript).AddSegment(segmentBeingLifted);

            liftingSegment = false;
            CheckWinState();
        } else {
            WarnInvalidMove();
        }

    }

    void EndGame() {
        Debug.Log("you have won!");
        winText.SetActive(true);
        KongregateAPIBehaviour.LogPuzzleComplete();
    }

    void CheckWinState() {
        bool hasWon = winChecker.CheckWinState(pegs);
        if (cheat || hasWon) EndGame();
        // Debug.Log("checking win state!");
        // if (cheat) EndGame();
        // int numCompleteTowers = 0;
        // foreach(GameObject peg in pegs) {
        //     if ((peg.GetComponent<PegScript>() as PegScript).HasCompleteTower()) {
        //         numCompleteTowers +=1;
        //     }
        // }
        // Debug.Log(numCompleteTowers);
        //  if (numCompleteTowers == 2) {
        //     EndGame();
        // }
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