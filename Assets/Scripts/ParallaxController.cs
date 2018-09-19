using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

    public Transform Camera;
	public float VerticalStronghtParallax;
	public float HorizontalStronghtParallax;

	private Vector3 beginPositionCamera;
	private Vector3 beginPosition;
    
	void Start ()
	{
		beginPositionCamera = Camera.position;
		beginPosition = transform.position;
	}

	private void FixedUpdate()
	{
		var shift = (Camera.position - beginPositionCamera);
		var transformPosition = beginPosition + shift;
		transform.position = new Vector3(beginPosition.x + transformPosition.x * HorizontalStronghtParallax, 
			beginPosition.y + transformPosition.y * VerticalStronghtParallax, transform.position.z);
		
	}
}
