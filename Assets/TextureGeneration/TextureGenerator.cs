using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.PCG
{

    public class TextureGenerator : MonoBehaviour {

        public int size = 128;

	    void Start ()
        {
            Texture2D tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
            tex.filterMode = FilterMode.Point;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    //Color c = Color.blue;

                    //if (x + y > 30)
                    //    c = Color.red;
                    //if (x - y < 60)
                    //    c = Color.green;

                    float value = 0;
                    for (int oct = 1; oct < 10; oct++)
                    {
                        value += (1f/((float)oct+1f)) * Mathf.PerlinNoise(x*oct/(float)size, y*oct / (float)size);
                    }

                    Color c = new Color(value, value, value, 1);

                    tex.SetPixel(x, y, c);
                }
            }

            tex.Apply();

            GetComponent<MeshRenderer>().material.mainTexture = tex;

	    }

	
	   
    }

}

