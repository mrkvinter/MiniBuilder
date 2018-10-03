using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationTextCounterController : MonoBehaviour
{

	private Text text;
	
	void Start ()
	{
		text = GetComponent<Text>();
		StartCoroutine(Counter());
	}
	
	IEnumerator Counter ()
	{
		for (var i = 3; i > 0; i--)
		{
			text.text = $"...{i}";
			yield return new WaitForSeconds(1);
		}

		text.text = "";
	}
}
