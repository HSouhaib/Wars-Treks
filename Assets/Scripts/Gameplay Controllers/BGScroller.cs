using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.05f;

    private float Y_Axis;

    private Material bgMateriel;

    private void Awake()
    {
        bgMateriel = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Y_Axis += speed * Time.deltaTime;
        bgMateriel.SetTextureOffset("_MainTex",new Vector2(0f,Y_Axis));
    }


}//class









