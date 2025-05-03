using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevels : MonoBehaviour
{
    public void JugarNivel(int nivel)
    {
        string escena = "";

        switch (nivel)
        {
            case 1: escena = "Game"; break;
            case 2: escena = "Game 2"; break;
            case 3: escena = "Game 3 Buena"; break;
        }

        if (!string.IsNullOrEmpty(escena))
        {
            LevelManager.Instance.LoadSceneWithImage(escena, "CrossFade", nivel - 1);
        }
    }
}