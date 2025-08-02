using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TappingMechanism : MonoBehaviour
{
    public AudioSource tappingSFX;

    private void OnEnable()
    {

    }
    void Update()
    {
        CheckObjectHit();
    }

    private void CheckObjectHit()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit.collider != null)
            {
                Ball ballTapped = hit.collider.gameObject.GetComponent<Ball>();

                tappingSFX.Play();

                ballTapped.UseSpecialSkills();

                SpawnVFX(ballTapped);

                ballTapped.DestroyBall();
                
                return;
              
            }
        }    
    }

    public void SpawnVFX(Ball _ball)
    {
        ParticleSystem vfx = Instantiate(_ball.explosionVFX, _ball.transform.position, Quaternion.identity);

        vfx.Play();
        Destroy(vfx, 0.5f);
    }
}
