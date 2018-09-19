using Engine.DataContainers;
using UnityEngine;
using UnityEngine.UI;

public class BlockCountUiSyncer : MonoBehaviour
{

    public BlockCountDataContainer BlockCountDataContainer;

    private Text text;
    private int prevValue = 0;
	void Start ()
	{
	    text = GetComponent<Text>();
	}
	
	void Update ()
	{
	    if (BlockCountDataContainer.Count != prevValue)
	    {
	        prevValue = BlockCountDataContainer.Count;
	        text.text = prevValue.ToString();
	    }
	}
}
