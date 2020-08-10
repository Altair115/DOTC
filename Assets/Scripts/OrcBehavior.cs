using UnityEngine;
using System.Collections;

public class OrcBehavior : MonoBehaviour {

	//Health Varibles
	public int Health = 100;
	Collider Coll;

	//Hits Variables
	public int Damage = 50;

	//Anim Variables
	Animator anim;

	//NAV Varibles
	public Transform[] Waypoints;
	public Transform Current;
	public int Destination = 0;
	UnityEngine.AI.NavMeshAgent agent;
	public float speed;
	float RunSpeed = 3.0f;
	float WalkSpeed = 1.5f;
	public bool control = false;
	public bool RUN = false;

	

	void Awake () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.speed = WalkSpeed;
		anim = GetComponent <Animator> ();
		anim.SetBool ("IsWalking", true);


	}
	
	void Update () 
	{
		agent.SetDestination (Waypoints [Destination].position);
		Coll = GetComponent<Collider> ();
		Current = Waypoints [Destination];

		if (control == true) 
		{
			if(RUN == false)
			{
				agent.speed = WalkSpeed;
			}
			if(RUN == true)
			{
				agent.speed = RunSpeed;
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Core") 
		{
			agent.speed = 0.0f;
			anim.SetTrigger ("Attack");
			Destination ++;
			control = true;
		}
		if (other.gameObject.tag == "Extra") 
		{
			Destination ++;
		}
		if (other.gameObject.tag == "Exit") 
		{
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Magic") 
		{
			Damage = 50;
			Health -= Damage;
			anim.SetTrigger("GotHit");
			Destroy (other.gameObject);
			if (Health <= 30) {
				RUN = true;
				anim.SetBool("IsRunning",true);
				agent.speed = RunSpeed;
				anim.SetBool("IsWalking",false);
			}
			if (Health <= 0) 
			{
				RUN = false;
				Destroy(Coll);
				agent.speed = 0.0f;
				anim.SetTrigger("Die");
				Destroy (gameObject, 1.2f);
				Money.money += 100;
			}
		}
		if (other.gameObject.tag == "Lightning") 
		{
			Damage = 34;
			Health -= Damage;
			anim.SetTrigger("GotHit");
			Destroy (other.gameObject);
			if (Health <= 30) {
				RUN = true;
				anim.SetBool("IsRunning",true);
				agent.speed = RunSpeed;
				anim.SetBool("IsWalking",false);
			}
			if (Health <= 0) 
			{
				RUN = false;
				Destroy(Coll);
				agent.speed = 0.0f;
				anim.SetTrigger("Die");
				Destroy (gameObject, 1.2f);
				Money.money += 100;
			}

		}
		if (other.gameObject.tag == "Arrow") 
		{
			Damage = 15;
			Health -= Damage;
			anim.SetTrigger("GotHit");
			Destroy (other.gameObject);
			if (Health <= 30) {
				RUN = true;
				anim.SetBool("IsRunning",true);
				agent.speed = RunSpeed;
				anim.SetBool("IsWalking",false);
			}
			if (Health <= 0) 
			{
				RUN = false;
				Destroy(Coll);
				agent.speed = 0.0f;
				anim.SetTrigger("Die");
				Destroy (gameObject, 1.2f);
				Money.money += 100;
			}
		}
		if (other.gameObject.tag == "Bullet") 
		{
			Damage = 10;
			Health -= Damage;
			anim.SetTrigger("GotHit");
			Destroy (other.gameObject);
			if (Health <= 30) {
				RUN = true;
				anim.SetBool("IsRunning",true);
				agent.speed = RunSpeed;
				anim.SetBool("IsWalking",false);
			}
			if (Health <= 0) 
			{
				RUN = false;
				Destroy(Coll);
				agent.speed = 0.0f;
				anim.SetTrigger("Die");
				Destroy (gameObject, 1.2f);
				Money.money += 100;
			}
		}
	}


}
