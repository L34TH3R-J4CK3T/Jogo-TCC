using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health_UI : MonoBehaviour {

    private int healthMaxCap = 10;
    public int healthStarting = 2;
    public int healthActual;
    private int healthMax;
    private int healthPerHeart = 1;

    public Image[] healthImages;
    public Sprite[] healthSprites;


	// Use this for initialization
	void Start () {
        healthActual = healthStarting * healthPerHeart;
        healthMax = healthMaxCap * healthPerHeart;
        UpdateMaxHealth();
        UpdateHealth();
	}

    //private void Update()
    //{
    //    UpdateMaxHealth();
    //    UpdateHealth();
    //}

    void UpdateMaxHealth()
    {
        for (int i = 0; i < healthMaxCap; i++)
        {
            if(healthStarting <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
    }

    void UpdateHealth()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if(healthActual >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - healthActual));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

}
