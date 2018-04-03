using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float moveSpeed, min, max;

	private float padding = 1;
	// Use this for initialization
	void Start () {
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMax = Camera.main.ViewportToWorldPoint(new Vector3(0,0, zDistance));
		Vector3 rightMax = Camera.main.ViewportToWorldPoint(new Vector3(1,0, zDistance));

		min = leftMax.x + padding;
		max = rightMax.x - padding;
		

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position += new Vector3 (moveSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += new Vector3 (-moveSpeed * Time.deltaTime, 0, 0);
		}
		//restricting movement
		float xPosition = transform.position.x;
		float limitX = Mathf.Clamp(xPosition, min, max); 
		this.transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
			
	
	}
}
