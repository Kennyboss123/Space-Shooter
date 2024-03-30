using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLaser : MonoBehaviour
{
    float moveSpeed = 4f;
    private void Update()
    {
        gameObject.transform.Translate(new Vector2(0, 4f) * moveSpeed * Time.deltaTime, Space.Self);
    }
}
