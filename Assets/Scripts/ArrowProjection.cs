using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjection : MonoBehaviour
{   
    [SerializeField] int speed; 
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        TargetMovement balloon = collision.GetComponent<TargetMovement>();
        if (collision.CompareTag("Balloon")) 
        {
            if (balloon != null) 
            {
                balloon.Pop();
                Score.AddPoints();
            }
            Destroy(gameObject);
        }
        
    }

}
