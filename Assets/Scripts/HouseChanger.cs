using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseChanger : MonoBehaviour
{
	public Sprite[] HouseLevel;
	public string[] LevelsNames;
	public SpriteRenderer SpriteRenderer;
	public GameObject MessageLabel;
	public GameObject Blip;
	public GameObject Counter;
	public AudioClip AudioClip;
	public AudioSource AudioSource;
	
	public void StartChange ()
	{
		SpriteRenderer.sprite = HouseLevel[HouseChangerManager.Instance.CurrentState];
		if (HouseChangerManager.Instance.CoinsCount >= 3)
		{
			Counter.SetActive(true);
			HouseChangerManager.Instance.CurrentState++;
			StartCoroutine(HouseChange());
			MessageLabel.SetActive(true);
		}
	}

	public void StartNextLevel()
	{
		SceneManager.LoadScene(LevelsNames[HouseChangerManager.Instance.CurrentLevel]);
		HouseChangerManager.Instance.CurrentLevel++;
	}

	IEnumerator HouseChange()
	{
		yield return new WaitForSeconds(3);
		Blip.SetActive(true);
		yield return new WaitForSeconds(0.35f);
		AudioSource.PlayOneShot(AudioClip);
		SpriteRenderer.sprite = HouseLevel[HouseChangerManager.Instance.CurrentState];
		yield return new WaitForSeconds(0.35f);
		Blip.SetActive(false);
		HouseChangerManager.Instance.CoinsCount = 0;
	}
}