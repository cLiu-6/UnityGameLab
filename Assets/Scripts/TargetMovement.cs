using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetMovement : MonoBehaviour
{
   private Vector2 v = Vector2.right;
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float speed;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] private AudioClip audio;

	[SerializeField] bool diff = false;
	
	public static Vector2 xy;
	private float delay=0.5f;
	private float timeElapsed;
    private Animator animator;
	
	void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
		InvokeRepeating("Scale", 1f, 1f);
    }
	void Update()
	{
      	transform.Translate(Time.deltaTime*v*speed);

        if(transform.position.x >= 5)
        {
            v = Vector2.left;
        }

        if(transform.position.x <= -5)
        {
            v = Vector2.right;
        }

 	}

	void FixedUpdate() 
	{
		// if (transform.position.x <= 5 && isFacingRight || transform.position.x >= -5 && !isFacingRight) {
		// 	Flip();

	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

	public void Pop()
	{
        animator.SetTrigger("pop");
		SoundManager.instance.PlaySound(audio);
	}

	public void OnPopAnimFinished()
	{
		//float animTime=GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

		Destroy(gameObject);

	}

	public void Scale()
	{
		if (diff)
		{
			xy = transform.localScale;
			xy.x += 2f;
			xy.y += 2f;
		}
		else
		{
			xy = transform.localScale;
			xy.x += 1f;
			xy.y += 1f;
		}
	
		transform.localScale = xy;

		if (xy.x > 12f)
		{
			Pop();
			//SoundManager.instance.PlaySound(audio);
			//OnPopAnimFinished();
			Invoke("Restart",delay);
		}
	}

	public void Restart() 
	{
		
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Score.ResetScore();
		
		
	}
}
