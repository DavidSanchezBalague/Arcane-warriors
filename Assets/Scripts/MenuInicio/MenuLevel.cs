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
            case 2: escena = "Game 2FINAL"; break;
            case 3: escena = "Game 3FINAL"; break;
            case 4: escena = "Game 4FINAL"; break;
            case 5: escena = "Game 5FINAL"; break;
            case 6: escena = "Game 6FINAL"; break;
        }

        if (!string.IsNullOrEmpty(escena))
        {
            LevelManager.Instance.LoadSceneWithImage(escena, "CrossFade", nivel - 1);
        }
    }
}