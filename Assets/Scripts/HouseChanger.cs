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
	
	void Start ()
	{
		if (HouseChangerManager.Instance.CoinsCount >= 3)
		{
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
		SpriteRenderer.sprite = HouseLevel[HouseChangerManager.Instance.CurrentState + 1];
		yield return new WaitForSeconds(0.35f);
		Blip.SetActive(false);
		HouseChangerManager.Instance.CurrentState++;
		HouseChangerManager.Instance.CoinsCount = 0;
	}
}