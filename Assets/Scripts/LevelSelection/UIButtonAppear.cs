using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class UIButtonAppear : MonoBehaviour
{
    public float duration = 0.6f;
    public float startScale = 0.7f;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private CanvasGroup canvasGroup;
    private Vector3 targetScale;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        targetScale = transform.localScale;

        // Estado inicial
        transform.localScale = targetScale * startScale;
        canvasGroup.alpha = 0f;

        // Iniciar aparición
        StartCoroutine(AnimateIn());
    }

    IEnumerator AnimateIn()
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            float t = curve.Evaluate(timer / duration);

            transform.localScale = Vector3.Lerp(targetScale * startScale, targetScale, t);
            canvasGroup.alpha = Mathf.Lerp(0, 1, t);

            yield return null;
        }

        transform.localScale = targetScale;
        canvasGroup.alpha = 1f;
    }
}
