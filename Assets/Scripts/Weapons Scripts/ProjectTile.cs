using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    public float minDamage = 10f;
    public float maxDamage = 30f;

    private float projectileDamage;


    [SerializeField]
    private AudioClip spawnSound;


    [SerializeField]
    private GameObject boomEffect;

    [SerializeField]
    private AudioClip destroySound;


    private void Start()
    {
        projectileDamage = (int)Random.Range(minDamage, maxDamage); 
    }

    private void OnEnable()
    {
        if (spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
    }


    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagMnager.PLAYER_TAG))
        {
            // Deal Damage for the Player
            collision.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
            gameObject.SetActive(false);

        }

        if (collision.CompareTag(TagMnager.ENEMY_TAG) || 
            collision.CompareTag(TagMnager.METEOR_TAG))
        {
            //Deal Damage for Enemies 
            collision.GetComponent<EnemyHealth>().TakeDamage(projectileDamage, 0f);
            gameObject.SetActive(false);
            

        }

        if (!collision.CompareTag(TagMnager.UNTAGGED_TAG) && 
            collision.CompareTag(TagMnager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}//class










