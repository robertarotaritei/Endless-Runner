using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public float gravityScaleFactor = 20f;
    public abstract void Start();
    public abstract void FixedUpdate();

    public void FadeToWhite()
    {
		SpriteRenderer rend;
		rend = GetComponent<SpriteRenderer>();

		IEnumerator FadeOut()
		{
			for (float i = 0f; i <= 1f; i += 0.35f)
			{
				Color c = rend.material.color;

				c.r = i;
				c.g = i;
				c.b = i;

				rend.material.color = c;

				yield return new WaitForSeconds(0.0001f);
			}
		}
		StartCoroutine(FadeOut());
	}
}
