using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {
	public static LineDrawer Instance;
	public string note1;
	public string note2;
	public int num1;
	public int num2;
	public int numInput;
	public Color[] colors;
	public GameObject[] lasers;
	public GameObject laser;
//	public float timer;
	void Awake(){
//		timer = 0;
		note1 = note2 = "empty";
		Instance = this;
	}
//	void Update(){
//		timer += Time.deltaTime;
//	}
	public void SetNumberIndex(int n){
		n = n - 1;
		if (num1 == 0) {
			num1 = n;
		} else if (num1 == n) {
			num1 = 0;

		} else if (num1 != n && num2 == 0) {
			num2 = n;
			int x = num1 - num2;
			numInput = Mathf.Abs (x);

			num1 = num2;
			num2 = 0;
		}

//		if (num1 != 0 && num2 != 0) {
//			int x = num1 - num2;
//			numInput = Mathf.Abs (x);
//
//			num1 = num2;
//			num2 = 0;
//		}

	}

	public void SelectNote (string name){
		if (note1 == "empty") {
			note1 = name;
//			timer = 0;
		} else if (note1 == name) {

			GameObject.Find (note1).transform.transform.FindChild ("Particle System").gameObject.SetActive (false);
			note1 = "empty";
//			timer = 0;
		} else if (note1 != name && note2 == "empty") {

			GameObject.Find (note1).transform.transform.FindChild ("Particle System").gameObject.SetActive (false);
			note2 = name;
//			timer = 0;
		}

		if (note1 != "empty" && note2 != "empty") {


			Invoke ("GenerateLaser", 0.02f);

		}


	}// SelectNote (string name) ends
	void GenerateLaser(){
		GameObject g = Instantiate (lasers[numInput], GameObject.Find (note1).transform.position, Quaternion.identity) as GameObject;
//		if (timer > 0.2f)
//			g.GetComponent<DrawLine>().speed = 2 ;
		g.GetComponent<DrawLine> ().origin = GameObject.Find (note1).transform;
		g.GetComponent<DrawLine> ().destination = GameObject.Find (note2).transform;

		g.GetComponent<LineRenderer> ().material.color = colors [numInput];
//			g.GetComponent<LineRenderer> ().endColor = colors [numInput];

		GameObject.Find (note1).transform.transform.FindChild ("Particle System").gameObject.SetActive(false);
		GameObject.Find (note2).transform.transform.FindChild ("Particle System").gameObject.SetActive(false);
		note1 = note2;
		note2 = "empty";

		GameObject.Find (note1).transform.transform.FindChild ("Particle System").gameObject.SetActive(true);
	}

}

		
