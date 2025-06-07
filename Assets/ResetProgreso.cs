using UnityEngine;

public class ResetProgreso : MonoBehaviour
{
    public void ReiniciarProgreso()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Progreso borrado!");
    }
}
