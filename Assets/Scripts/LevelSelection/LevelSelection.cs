using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
   public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
