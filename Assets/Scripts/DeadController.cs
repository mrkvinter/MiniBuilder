using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadController : MonoBehaviour
{

	public Transform VirtualCamera;
	public CinemachineBrain CinemachineBrain;
	public AudioClip DeathAudio;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
			StartCoroutine(StartReload());
	}

	private IEnumerator StartReload()
	{
		CinemachineBrain.enabled = false;
		StartCoroutine(Shake());
		audioSource.PlayOneShot(DeathAudio);
		yield return new WaitForSeconds(0.7f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	private IEnumerator Shake()
	{
		var t = 0.0f;
		var pos = VirtualCamera.position;
		while (t < 0.7f)
		{
			VirtualCamera.position = new Vector3(pos.x + Random.Range(-0.25f, 0.25f),
				pos.y + Random.Range(-0.25f, 0.25f), pos.z);
			t += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
	}
}
