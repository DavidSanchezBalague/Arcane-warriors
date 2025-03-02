using System.Collections;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class CrossFade : SceneTransition
{
    public CanvasGroup crossFade;

    public override IEnumerator AnimateTransitionIn()
    {
        var tweener = crossFade.DOFade(1f, 0.5f); // De 0 a 1 en 0.5 segundos
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimateTransitionOut()
    {
        var tweener = crossFade.DOFade(0f, 0.5f); // De 1 a 0 en 0.5 segundos
        yield return tweener.WaitForCompletion();
    }

}
