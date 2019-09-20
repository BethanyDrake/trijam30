using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoalaWinChecker : WinChecker
{

  public void Start(){}
  public void Update(){}
  public override bool CheckWinState(GameObject[] pegs)
  {

    PegScript lastPeg = (pegs[2].GetComponent<PegScript>() as PegScript);
    return lastPeg.HasCompleteTower();
  }

}
