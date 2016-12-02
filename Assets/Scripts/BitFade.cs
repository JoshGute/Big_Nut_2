using UnityEngine;
using System.Collections;

public class BitFade : MonoBehaviour
{
    private tk2dSprite tSprite;
    private Renderer rRenderer;
    private float fScale = 0;


    void Start ()
    {
        if (GetComponent<tk2dSprite>())
        {
            tSprite = GetComponent<tk2dSprite>();
            rRenderer = null;
        }

        else if (GetComponentInChildren<tk2dSprite>())
        {
            tSprite = GetComponentInChildren<tk2dSprite>();
            rRenderer = null;
        }

        else
        {
            tSprite = null;
            rRenderer = GetComponent<Renderer>();
        }
	}
	
	void Update ()
    {
        if (tSprite != null)
        {
            tSprite.color = Color.Lerp(Color.white, Color.clear, fScale += 0.003f);
            if (tSprite.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }

        else if (rRenderer != null)
        {
            rRenderer.material.color = Color.Lerp(Color.white, Color.clear, fScale += 0.003f);
            if (rRenderer.material.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }
	}
}
