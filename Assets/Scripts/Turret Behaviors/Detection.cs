using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {
	//Variables
	public Collider[] Targets;
	static public Collider EnemyOne;
	public Transform Projectiles;
	public float Radius = 12;
	public float time = 0;
	public float FireRate;

	void Update () 
	{	
		//seperating layers so not everything is seen by the overlap sphere
		int layerMask = 1 << 8;
		Targets = Physics.OverlapSphere (transform.position, Radius, layerMask);

		//foreach object in the overlap sphere look at the first One
		foreach (Collider Colls in Targets) 
		{
			Vector3 Rpos = Targets [0].transform.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (Rpos);
			transform.rotation = rotation;
			//change name when in range of turret
			Colls.name = "In Range";

			time = time + 1 * Time.deltaTime;

			//Spawning Projectiles
			if(time >= FireRate)
			{
				Instantiate(Projectiles, transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);
				time =0;
			}
			EnemyOne = Targets [0]; 
		}



		
	}
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, Radius);
		foreach (Collider Colls in Targets)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, Colls.transform.position);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(Colls.transform.position, 0.5f);
		}
	}
}
