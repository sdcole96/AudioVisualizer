﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {

	AudioSource mAudio;
	public static float[] samples = new float[512];
	public static float[] freqBand = new float[8];
	public static float[] bandBuffer = new float[8];
	float[] bufferDecrease = new float[8];

	float[] freqBandHighest = new float[8];
	public static float[] audioBand = new float[8];
	public static float[] audioBandBuffer = new float[8];

	// Use this for initialization
	void Start () 
	{
		mAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetSpectrumAudioSource();
		MakeFrequencyBands();
		BandBuffer();
		CreateAudioBands();
	}

	void GetSpectrumAudioSource()
	{
		mAudio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
	}

	void CreateAudioBands()
	{
		for(int i = 0; i < 8; i++)
		{
			if(freqBand[i] > freqBandHighest[i])
			{
				freqBandHighest[i] = freqBand[i];
			}
			audioBand[i] = (freqBand[i]/freqBandHighest[i]);
			audioBandBuffer[i] = (bandBuffer[i]/freqBandHighest[i]);
		}
	}
	
	void BandBuffer()
	{
		for(int g = 0; g< 8; ++g)
		{
			if( freqBand[g] > bandBuffer[g])
			{
				bandBuffer[g] = freqBand[g];
				bufferDecrease[g] = 0.005f;
			}
			if( freqBand[g] < bandBuffer[g])
			{
				bandBuffer[g] -= bufferDecrease[g];
				bufferDecrease[g] *= 1.2f;
			}
		}
	}

	void MakeFrequencyBands()
	{
		int count = 0;

		for(int i = 0;i<8; i++)
		{
			float average = 0;
			int sampleCount = (int)Mathf.Pow(2,i) * 2;

			if(i == 7)
			{
				sampleCount += 2;
			}
			for(int j = 0; j < sampleCount; j++)
			{
				average += samples[count] * (count + 1);
				count++;
			}

			average /= count;

			freqBand[i] = average * 10;
		}
	}
}
