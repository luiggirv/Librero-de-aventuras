using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

	public Camera cam;
	private float maxWidth;
	private bool canControl;

	void Start () {
	
		if (cam == null) {
			cam = Camera.main;
		}
		canControl = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float hatWidth = GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x-hatWidth;
	}
	
	void FixedUpdate () {
		if (canControl) {
			//Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			//Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
			//float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			//targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
			//Vector3 targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,				 0.0f);
			if (Input.touchCount > 0)
            {
				Touch touch = Input.GetTouch(0);
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				touchPosition.z = 0;
				Vector3 direction = (touchPosition - transform.position);
				GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * (10f);
				if (touch.phase == TouchPhase.Ended)
                {
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				}
			}
			//GetComponent<Rigidbody2D>().MovePosition(targetPosition);
		}
	}

	public void toggledControl (bool toggle) {
		canControl = toggle;
	}
}
