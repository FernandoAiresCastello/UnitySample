using UnityEngine;
using System.Collections.Generic;

public class Player : ExtendedMonoBehaviour
{
	public float moveSpeed = 2.0f;
	public float rotationSpeed = 100.0f;
	public float jumpHeight = 200.0f;
	public float fallLimit = -10.0f;
	public int gold = 0;
	public int health = 0;
	public int maxHealth = 0;
	public int aura = 0;
	public bool allowShooting = true;
	public bool allowJumping = true;
	public AudioClip fallSound;
	public GameObject projectile;
	public Animator anim;
	
	private Vector3 initialPos;
	private Quaternion initialRot;
	private AudioSource audioSource;
	private SpriteRenderer spriteRenderer;
	private Color originalColor;
	private bool isGrounded = false;
	private bool isLocked = false;
	
	void Awake()
	{
		initialPos = transform.position;
		initialRot = transform.rotation;
		audioSource = GetComponent<AudioSource>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		originalColor = spriteRenderer.color;
		anim = GetComponent<Animator>();
	}
	
	void Start()
	{
		audioSource.loop = true;
        audioSource.Stop();
	}
	
	void Update()
	{
		if (isLocked)
			return;
		
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		bool walking = z != 0.0f;
		
		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		PlayFootsteps(walking);
		Animate(walking);
		
		if (fallLimit != 0 && (transform.position.y < fallLimit))
			Respawn();
		if (Input.GetButtonDown("Jump"))
			Jump();
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3"))
			Shoot();
		
		//if (Input.GetKeyDown(KeyCode.F1))
			//transform.position = GameObject.Find("LastPlatformStart").GetComponent<Transform>().position;
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
		if (!allowShooting || projectile == null)
			return;
		
		GameObject p = Instantiate(projectile, transform.position + 
			projectile.GetComponent<PlayerProjectile>().offset, transform.rotation);
		p.transform.localScale = this.transform.localScale;
		p.tag = "PlayerProjectile";
	}
	
	void Respawn()
	{
		audioSource.PlayOneShot(fallSound);
		transform.position = initialPos;
		transform.rotation = initialRot;
		SetGrounded(true);
	}
	
	void Animate(bool walking)
	{
		if (walking)
			anim.Play("PlayerWalk");
		else
			anim.Play("PlayerIdle");
			
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
	
	public void Lock()
	{
		Lock(true);
	}

	public void Unlock()
	{
		Lock(false);
	}

	public void Lock(bool locked)
	{
		isLocked = locked;
	}
	
	public void Show()
	{
		Show(true);
	}

	public void Hide()
	{
		Show(false);
	}

	public void Show(bool show)
	{
		spriteRenderer.enabled = show;
	}
	
	public void Damage(int points)
	{
		health -= points;
		if (health < 0)
			health = 0;
		
		Flash(Color.red);
	}
	
	public void Flash(Color color)
	{
		spriteRenderer.color = color;
		Wait(0.2f, ()=> {
			spriteRenderer.color = originalColor;
		});		
	}
}
