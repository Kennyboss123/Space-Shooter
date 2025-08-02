using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsAutoScrolling : MonoBehaviour
{
    [SerializeField] public ScrollRect scrollRect;
    public float scrollSpeed = 0.1f;
    public bool hasBeenScrolled;

    private void OnEnable()
    {
        scrollRect.verticalNormalizedPosition = 1f;
        hasBeenScrolled = false;
    }
    private void Update()
    {
        CheckScroll();
    }

    void CheckScroll()
    {
        bool mouseClick = Input.GetMouseButtonDown(0);
        if (!hasBeenScrolled && scrollRect.verticalNormalizedPosition > 0)
        {
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;
        }

        if(mouseClick) 
        {
            scrollRect.verticalNormalizedPosition = 1f;
            hasBeenScrolled = true;
        }
    }
}
