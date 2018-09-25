using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paramCube : MonoBehaviour {

	public int band;
	public float startScale, scaleMultiplier;
	public bool useBuffer;
	Material m;

	// Use this for initialization
	void Start () 
	{
		m = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(useBuffer)
		{
		transform.localScale = new Vector3(transform.localScale.x ,(AudioPeer.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
		float value = AudioPeer.audioBandBuffer[band];
		Color color = new Color(value,value,value);
		m.SetColor("_EmissionColor", color);
		}
		else
		{
		transform.localScale = new Vector3(transform.localScale.x ,(AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
		float value = AudioPeer.audioBandBuffer[band];
		Color color = new Color(value,value,value);
		m.SetColor("_EmissionColor", color);
		}		
	}
}
