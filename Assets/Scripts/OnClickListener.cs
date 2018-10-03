using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour
{

	public KeyCode KeyCodeListen;
	public UnityEvent OnClick;
	public AudioClip Bleep;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCodeListen))
		{
			audioSource?.PlayOneShot(Bleep);
			OnClick.Invoke();
		}	
	}
}
