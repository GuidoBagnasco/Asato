using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

    public static bool Over = false;


	protected override void OnAwake () {
        Over = false;
	}


    public void GameOver () {
        Over = true;
        (HUD.Instance as HUD).Show();
#if UNITY_STANDALONE
        (InputManager.Instance as InputManager).ShowPointer (true);
#endif
    }
}
