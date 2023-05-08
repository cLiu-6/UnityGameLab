using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractorBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed=1f;

    Rigidbody2D rigidB;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight())
        {
            rigidB.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigidB.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x>Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

    }
}
