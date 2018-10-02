using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health_UI : MonoBehaviour {

    public GameControl gameControl;


    
    public int startHearts; 
    private int curHealth;
    

    private int healthPerHeart = 1;
    [Header("Imagens")]
    [Tooltip("Coloque todas as imagens para não ocorrer glitches.")]
    public Image[] healthImages;
    public Sprite[] healthSprites;
    
  


	// Use this for initialization
	void Start () {
        
        
        UpdateMaxHealth();
        UpdateActualHealth();
	}

    private void Update()
    {   
       curHealth = gameControl.health;
       UpdateMaxHealth();
       UpdateActualHealth();
    }

    void UpdateMaxHealth()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if(startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
    }

    void UpdateActualHealth()
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
                if(curHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth ));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

}
