using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombinableBubbleBubble : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject target;
    public float moveSpeed = 2;
    public float stopMoveDistanceFromTarget = 0.1f;

    public System.Action<Vector2> OnCombine;
    
    private LineRenderer lineRenderer;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lineRenderer.enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        lineRenderer.SetPosition(1, Input.mousePosition - rectTransform.anchoredPosition3D - new Vector3(Screen.width, Screen.height) * 0.5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (var item in eventData.hovered)
        {
            if(item == target)
            {
                CombineThoughtBubble(item);
                return;
            }
        }
        lineRenderer.enabled = false;
    }

    void CombineThoughtBubble(GameObject bubble)
    {
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        RectTransform targetTransform = target.GetComponent<RectTransform>();

        while(Vector2.Distance(rectTransform.position, target.transform.position) > stopMoveDistanceFromTarget)
        {
            rectTransform.position += (target.transform.position - rectTransform.position) * moveSpeed * Time.deltaTime;
            lineRenderer.SetPosition(1, targetTransform.anchoredPosition - rectTransform.anchoredPosition);
            yield return null;
        }

        OnCombine?.Invoke(transform.position);

        target.SetActive(false);
        gameObject.SetActive(false);
    }
}
