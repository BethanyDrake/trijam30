using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchidnaWinChecker : WinChecker
{

    public override bool CheckWinState(GameObject[] pegs) {
        // Debug.Log("checking win state!");

        int numCompleteTowers = 0;
        foreach(GameObject peg in pegs) {
            if ((peg.GetComponent<PegScript>() as PegScript).HasCompleteTower()) {
                numCompleteTowers +=1;
            }
        }
        Debug.Log(numCompleteTowers);
         if (numCompleteTowers == 2) {
            return true;
        }
        return false;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
