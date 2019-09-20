using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongregateAPIBehaviour : MonoBehaviour {
  private static KongregateAPIBehaviour instance;

  public void Start() {
    if(instance == null) {
    	instance = this;
    } else if(instance != this) {
    	Destroy(gameObject);
      return;
    }

    Object.DontDestroyOnLoad(gameObject);
    gameObject.name = "KongregateAPI";

    Application.ExternalEval(
      @"if(typeof(kongregateUnitySupport) != 'undefined'){
        kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');
      };"
    );

    LogLoadComplete();
  }

  public void OnKongregateAPILoaded(string userInfoString) {
    OnKongregateUserInfo(userInfoString);
  }

  public void OnKongregateUserInfo(string userInfoString) {
    var info = userInfoString.Split('|');
    var userId = System.Convert.ToInt32(info[0]);
    var username = info[1];
    var gameAuthToken = info[2];
    Debug.Log("Kongregate User Info: " + username + ", userId: " + userId);
  }

  public void LogLoadComplete() {
      Application.ExternalCall("kongregate.stats.submit", "Loaded", 1);
  }
   public static void LogPuzzleComplete() {
      Application.ExternalCall("kongregate.stats.submit", "PuzzleCompleted", 1);
  }
}