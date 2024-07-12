using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TextMeshProMouseHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshPro;
    private Animator animator;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on this GameObject.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textMeshPro != null)
        {
            Debug.Log("Mouse entered: " + textMeshPro.name);
            animator.SetTrigger("Grande");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textMeshPro != null)
        {
            Debug.Log("Mouse exited: " + textMeshPro.name);
            animator.SetTrigger("Pequeño");
        }
    }
}
