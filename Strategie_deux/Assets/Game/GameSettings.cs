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

	// Update is called once per frame
	void Update() {

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
		Debug.Log("AntiAliasing = " + (antiAliasing == 0 ? 0 : (int)Mathf.Pow(2, antiAliasing)));
		Debug.Log("Resolution = " + resolutionIndex);
		Debug.Log("Mode AntiAliasing = " + methodAntiAliasing);
		Debug.Log("Anisotropic = " + (anisotropic == 0 ? 0 : (int)Mathf.Pow(2, anisotropic)));
		Debug.Log("PostProcessing = " + postProcessing);
		Debug.Log("Buffer = " + buffer);
	}

	public void Apply() {
		Resolution[] resolutions = Screen.resolutions;
		Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, fullScreen);
		QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
		QualitySettings.antiAliasing = (antiAliasing == 0 ? 0 : (int)Mathf.Pow(2, antiAliasing));
		QualitySettings.masterTextureLimit = texturesQuality;
		QualitySettings.vSyncCount = vSync == true ? 1 : 0;
		QualitySettings.asyncUploadBufferSize = (buffer == 0 ? 0 : (int)Mathf.Pow(4, buffer));
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		Texture.SetGlobalAnisotropicFilteringLimits((int)Mathf.Pow(2, anisotropic), 9);
		if (Camera.main != null)
			ApplycCamera();
	}

	public void ApplycCamera () {
		if (methodAntiAliasing == 1)
			Camera.main.allowMSAA = true;
		Camera.main.allowHDR = HDR;
	}
}