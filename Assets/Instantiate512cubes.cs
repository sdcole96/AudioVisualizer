using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512cubes : MonoBehaviour {

	public GameObject sampleCubePrefab;
	GameObject[] sampleCube = new GameObject[512];
	public float maxScale;
	public float j = 0;
	public float max;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i <512; i++)
		{
			GameObject instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab);
			instanceSampleCube.transform.position = this.transform.position;
			instanceSampleCube.transform.parent = this.transform;
			instanceSampleCube.name = "SampleCube" + i;
			float circle = -.703125f;
			this.transform.position += new Vector3(0f, i/5.0f,0f);
			//this.transform.rotation = Quaternion.Euler(0f,0f,1f);
			sampleCube[i] = instanceSampleCube;
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		j++;
		for(int i = 0; i < 512; i++)
		{
			if(sampleCube != null)
			{
				if(i>0)
				{
				float value = AudioPeer.samples[i] * maxScale;
				if(value < max)
					{
					sampleCube[i].transform.localScale = new Vector3(value+2,value + 2,value +2);
					}
				}
				sampleCube[i].transform.localRotation = Quaternion.Euler(0f,0f,j);


			}
		}
		
	}
	
}
