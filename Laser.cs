using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Laser : MonoBehaviour {

	int CurrentOrb = 0;
	string OrbName;
	int OrbID = 1;
	private bool Clicked = false; 
	float timer; 
	 

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{

		timer += Time.deltaTime;

		if (this.onClick) {
				
			if (timer < 1) {

				if (Clicked == true) {

					Clicked = false; 

				} else if (CurrentOrb != 0) {
					string StartPoint = "Laser" + CurrentOrb;
					object Laser = GameObject.AddComponent<StartPoint>();
					LaserCreator (Laser);
					CurrentOrb = OrbID;
					OrbName = this.name;

				} 
				else {
					CurrentOrb = OrbID;
					OrbName = this.name;
				}
			}

				else {
					Clicked = !Clicked;

		}
		timer = 0; 
	}
}

		

	IEnumerator LaserCreator() {
		Ray connection = new Ray(transform.position, transform.forward);
		Laser.SetPosition = (Ray.origin);
		Laser.SetPosition = (CurrentOrb.transform.position); 
	}

}




