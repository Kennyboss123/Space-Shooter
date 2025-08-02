using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBackground : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeColor()
    {
        StartCoroutine(KillPlayerColor());
    }
    IEnumerator KillPlayerColor()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(1);

        spriteRenderer.color = ConvertToHex("#575454");
    }

    public Color ConvertToHex(string hex)
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hex, out newColor))
        {
            return newColor;
        };
        return Color.white;
    }
}
