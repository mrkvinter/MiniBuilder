using Engine.DataContainers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var coinsData = other.GetComponent<CoinsCountDataContainer>();
        if (coinsData != null)
        {
            HouseChangerManager.Instance.CoinsCount = coinsData.CoinsCount;
            SceneManager.LoadScene("House");
        }
    }
}