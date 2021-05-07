using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    private Vector3 healthBarScale;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private GameObject destroyEffect;

    private DropCollectable dropCollectable;

    private void Awake()
    {
        dropCollectable = GetComponent<DropCollectable>();
    }


    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;

        health -= damageAmount;

        if (health <= 0f)
        {
            health = 0f;

            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            if (gameObject.CompareTag(TagMnager.ENEMY_TAG))
            {
                GamePlayControllerUI.instance.SetInfoUI(2);
                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }
            else if (gameObject.CompareTag(TagMnager.METEOR_TAG))
                GamePlayControllerUI.instance.SetInfoUI(3);

            
            SoundController.instance.PlayDestroySound();

            dropCollectable.CheckToSpawnCollectable();

            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundController.instance.PlayDamageSound();

        }
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }


} //class















