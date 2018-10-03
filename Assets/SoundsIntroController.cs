using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsIntroController : MonoBehaviour
{

	public AudioClip Beep;
	public AudioClip Music;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayBeep()
	{
		audioSource.PlayOneShot(Beep);
	}

	public void PlayMusic()
	{
		audioSource.PlayOneShot(Music);
	}
}
