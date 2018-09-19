using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour
{

	public KeyCode KeyCodeListen;
	public UnityEvent OnClick;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCodeListen))
		{
			OnClick.Invoke();
		}	
	}
}
