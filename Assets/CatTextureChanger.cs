using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatTextureChanger : MonoBehaviour {
	private List<Material> allMaterials = new List<Material>();
	public GameObject collar;
	public Texture collarTexture;
	public Texture[] collarTextures = new Texture[0];
	public Texture[] catTextures = new Texture[0];

	void Start () {
		Transform catBody;
		foreach(Transform child in transform)
		{
			if(child.name == "Null")
			{
				catBody = child;
				Renderer[] allChildrenRenderers = catBody.GetComponentsInChildren<Renderer>();
				foreach(Renderer renderer in allChildrenRenderers)
				{
					allMaterials.Add(renderer.material);
				}
				break;
			}
		}
		SetCatTexture(catTextures[2]);
		SetCollarTexture(collarTextures[4]);
	}

	public void SetCatTexture (Texture newTexture) 
	{
		foreach(Material mat in allMaterials)
		{
			mat.mainTexture = newTexture;
		}
		SetCollarTexture(collarTexture);
	}
	public void SetCollarTexture(Texture newTexture)
	{
		collarTexture = newTexture;
		collar.GetComponent<Renderer>().material.mainTexture = newTexture;
	}
}
