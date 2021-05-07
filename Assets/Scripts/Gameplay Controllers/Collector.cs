using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagMnager.PROJECTILE_TAG))
            collision.gameObject.SetActive(false);

        if (collision.CompareTag(TagMnager.METEOR_TAG) || collision.CompareTag(TagMnager.COLLECTABLE_TAG))
            Destroy(collision.gameObject);
    }
}
