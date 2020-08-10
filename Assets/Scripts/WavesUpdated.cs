using UnityEngine;
using System.Collections;

public class WavesUpdated : MonoBehaviour {

	//Variables
	public Transform[] Waves;

	public int loop;
	public int Wavenumber = 0;
	public float SpawnWait;
	public float StartWait;
	public float WaveWait;



	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());	
	}
	

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(StartWait);
		while(true)
		{
			//How many enemy will spawn
			for (int i = 0; i < loop; i++) 
			{
				//which enemy will be spawned
				Instantiate (Waves [Wavenumber], transform.position, transform.rotation);
				yield return new WaitForSeconds(SpawnWait);
			}
			//how much time has to pas before starting a new wave
			yield return new WaitForSeconds (WaveWait);
			Wavenumber ++;
			WaveDisplay.Wave ++;
			loop += 5;
		}
	
	}
}
