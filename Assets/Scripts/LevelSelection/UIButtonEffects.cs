using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverScale : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{
    public float hoverScale = 1.1f;
    public float scaleDuration = 0.15f;

    private Vector3 originalScale;
    private Coroutine scaleRoutine;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (scaleRoutine != null) StopCoroutine(scaleRoutine);
        scaleRoutine = StartCoroutine(ScaleTo(originalScale * hoverScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (scaleRoutine != null) StopCoroutine(scaleRoutine);
        scaleRoutine = StartCoroutine(ScaleTo(originalScale));
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float time = 0f;

        while (time < scaleDuration)
        {
            time += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, time / scaleDuration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
