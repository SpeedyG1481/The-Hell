using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text deathCount;

    void Update()
    {
        deathCount.text = GameManager.deathCounter.ToString();
        // distance.text = GameManager.playerPosition.x.ToString(); 
    }
}