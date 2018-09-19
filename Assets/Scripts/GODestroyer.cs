using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GODestroyer : MonoBehaviour
{

	public float TimeLife;

	private void Start()
	{
		StartCoroutine(Destroy());
	}

	private IEnumerator Destroy()
	{
		yield return new WaitForSeconds(TimeLife);
		Destroy(gameObject);
	}
}
