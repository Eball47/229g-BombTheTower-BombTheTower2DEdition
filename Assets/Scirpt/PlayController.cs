using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float speed ;
    public float jump ;

    private Rigidbody2D rb2D;
    
    public Transform shootPoint;

    public GameObject target;

    public Rigidbody2D bullet;

    
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 5);
            RaycastHit2D hit = Physics2D.GetRayIntersection( ray , Mathf.Infinity );
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log(" Hit point : " + hit.point);
                
                Vector2 projectileV = CalculateProjectile(shootPoint.position, hit.point, 1);
                
                Rigidbody2D spawnBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                
                spawnBullet.velocity = projectileV;
            }
        }
    }
    Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        Vector2 distance = targetPoint - origin;
        
        float velocityX = distance.x / time;
        
        float velocityY = distance.y / time + 0.5f * Mathf.Abs( Physics2D.gravity.y)*time  ;
        
        Vector2 projecttileVelocity = new Vector2(velocityX , velocityY);
        
        return projecttileVelocity;
    }
    
}
