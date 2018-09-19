using System.Collections;
using System.Collections.Generic;
using Engine.DataContainers;
using UnityEngine;

public class CoinPickUpController : MonoBehaviour
{
	public GameObject Effect;
	public AudioClip CoinPuckUpSound;
	
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var coinCounter = other.GetComponent<CoinsCountDataContainer>();
		if (coinCounter != null)
		{
			audioSource.PlayOneShot(CoinPuckUpSound);
			coinCounter.CoinsCount++;
			Destroy(gameObject);
			Instantiate(Effect, transform.position, transform.rotation);
		}
	}
}
