using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WombatWinChecker : WinChecker {
    // Start is called before the first frame update

    public override bool CheckWinState (GameObject[] pegs) {

        PegScript lastPeg = (pegs[2].GetComponent<PegScript> () as PegScript);
        return lastPeg.HasCompleteTower ();
    }
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}