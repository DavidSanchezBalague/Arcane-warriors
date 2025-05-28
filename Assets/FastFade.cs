using System.Collections;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class FastFade : SceneTransition
{
    public CanvasGroup fade;

    public override IEnumerator AnimateTransitionIn()
    {
        fade.gameObject.SetActive(true); // 🔥 Asegúrate de que el objeto esté activo
        fade.alpha = 0f;
        var tweener = fade.DOFade(1f, 0.25f);
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimateTransitionOut()
    {
        var tweener = fade.DOFade(0f, 0.25f);
        yield return tweener.WaitForCompletion();
        fade.gameObject.SetActive(false); // Opcional: ocultarlo después
    }
}

