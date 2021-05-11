using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text deathCount, lastDistance;
    public int distanceText;
    

    void Start()
    {
        Load();

    }

    public void Load()
    {
        deathCount.text = PlayerPrefs.GetInt("deathCount").ToString();
        lastDistance.text = PlayerPrefs.GetInt("distance").ToString();
    }

    public void Save()
    {
        if (GameManager.deathDistance > PlayerPrefs.GetInt("distance"))
        {
            lastDistance.text = ((int)GameManager.deathDistance).ToString();
            PlayerPrefs.SetInt("distance", (int)GameManager.deathDistance);
        }
    }
}
