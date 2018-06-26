using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public float moveSpeed = 2.0f;
	public float rotationSpeed = 100.0f;
	public float jumpHeight = 200.0f;
	public float fallLimit = -10.0f;
	public int gold = 0;
	public int health = 50;
	public bool allowShooting = true;
	public bool allowJumping = true;
	public AudioClip fallSound;
	public GameObject projectile;
	public Vector3 projectileOffset = new Vector3(0.0f, 0.25f, 0.0f);
	public Animator anim;
	
	private Vector3 initialPos;
	private AudioSource audioSource;
	private bool isGrounded = false;
	
	void Awake()
	{
		initialPos = transform.position;
		audioSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
	}
	
	void Start()
	{
		audioSource.loop = true;
        audioSource.Stop();
	}
	
	void Update()
	{
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		bool walking = z != 0.0f;
		
		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		PlayFootsteps(walking);
		Animate(walking);
		
		if (transform.position.y < fallLimit)
			Respawn();
		if (Input.GetKeyDown(KeyCode.Space))
			Jump();
		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
			Shoot();
	}
	
	void FixedUpdate()
	{
	}
	
	public void SetGrounded(bool grounded)
	{
		isGrounded = grounded;
	}
	
	void Jump()
	{
		if (!allowJumping)
			return;
		
		if (isGrounded) {
			isGrounded = false;
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
		}
	}
	
	void Shoot()
	{
		if (!allowShooting)
			return;
		
		GameObject p = Instantiate(projectile, transform.position + projectileOffset, transform.rotation);
		p.transform.localScale = this.transform.localScale;
		p.tag = "PlayerProjectile";
	}
	
	void Respawn()
	{
		audioSource.PlayOneShot(fallSound);
		transform.position = new Vector3(initialPos.x, 5.0f, initialPos.z);
	}
	
	void Animate(bool walking)
	{
		if (walking)
			anim.Play("shadow_walk");
		else
			anim.Play("shadow_idle");
			
	}
	
	void PlayFootsteps(bool play)
	{
		if (play && isGrounded) {
			if (!audioSource.isPlaying)
				audioSource.Play();
		}
		else
			audioSource.Stop();
	}
}
