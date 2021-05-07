using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth = 100f;

    private float playerHealth;

    [SerializeField]
    private GameObject playerExplosionFX;

    [SerializeField]
    private GameObject playerDamageFX;

    private Collectable collectable;

    private Slider playerHealthSlider;

    private void Awake()
    {
        playerHealthSlider = GameObject.FindWithTag(TagMnager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();

        playerHealth = playerMaxHealth;

        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;

    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
        playerHealthSlider.value = playerHealth;

        if (playerHealth <= 0f)
        {
            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
            SoundController.instance.PlayDestroySound();

            GameOverControllerUi.instance.OpenGameOverPanel();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
            SoundController.instance.PlayDamageSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagMnager.COLLECTABLE_TAG))
        {
            collectable = collision.GetComponent<Collectable>();

            if(collectable.type == CollectableType.Health)
            {
                playerHealth += collectable.healthValue;
                playerHealthSlider.value = playerHealth;

                //Debug.Log("PLAYER HEALTH INCREASED BY :" + playerHealth);

                if (playerHealth > playerMaxHealth)
                    playerHealth = playerMaxHealth;
              
                     Destroy(collision.gameObject);
            }
        }

        if(collision.CompareTag(TagMnager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));

           //Debug.Log("PLAYER HEALTH DECREASED BY: " + playerHealth);   
          
            Destroy(collision.gameObject); 
        }
    }

} //class
    