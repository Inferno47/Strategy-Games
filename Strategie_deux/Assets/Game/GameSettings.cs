using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("GameSettings")]
public class GameSettings {

	public bool vSync;
	public bool fullScreen;
	public bool HDR;

	public int graphicQuality;
	public int texturesQuality;
	public int skyQuality;
	public int shadowQuality;
	public int antiAliasing;
	public int resolutionIndex;
	public int anisotropic;
	public int methodAntiAliasing;
	public int postProcessing;
	public int buffer;

	// Use this for initialization
	void Start () {
	}
	
	public void DebugLog()
	{
		Debug.Log("GameSettings");
		Debug.Log("Sync = " + vSync);
		Debug.Log("HDR = " + HDR);
		Debug.Log("FullScreen = " + fullScreen);
		Debug.Log("Graphic = " + graphicQuality);
		Debug.Log("Shadow = " + shadowQuality);
		Debug.Log("Textures = " + texturesQuality);
		Debug.Log("Sky = " + shadowQuality);
		Debug.Log("AntiAliasing = " + (antiAliasing == 0 ? 0 : (int)Mathf.Pow(2, antiAliasing)));
		Debug.Log("Resolution = " + resolutionIndex);
		Debug.Log("Mode AntiAliasing = " + methodAntiAliasing);
		Debug.Log("Anisotropic = " + (anisotropic == 0 ? 0 : (int)Mathf.Pow(2, anisotropic)));
		Debug.Log("PostProcessing = " + postProcessing);
		Debug.Log("Buffer = " + buffer);
	}
	// Update is called once per frame
	void Update () {
		
	}
}