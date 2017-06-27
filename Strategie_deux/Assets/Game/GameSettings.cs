using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("GameSettings")]
public class GameSettings
{

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
	public int buffer;
	public int postProcessing;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {
	}

	/// <summary>
	/// Apply Function
	/// </summary>
	public void Apply() {
		QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
		QualitySettings.antiAliasing = (antiAliasing == 0 ? 0 : (int)Mathf.Pow(2, antiAliasing));
		QualitySettings.masterTextureLimit = texturesQuality;
		QualitySettings.vSyncCount = vSync == true ? 1 : 0;
		QualitySettings.asyncUploadBufferSize = (buffer == 0 ? 0 : (int)Mathf.Pow(4, buffer));
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		Texture.SetGlobalAnisotropicFilteringLimits((int)Mathf.Pow(2, anisotropic), 9);

		ApplyScreen();
		if (Camera.main != null)
			ApplycCamera();
	}

	public void ApplycCamera () {
		if (methodAntiAliasing == 1)
			Camera.main.allowMSAA = true;
		Camera.main.allowHDR = HDR;
	}

	private void ApplyScreen() {
		Resolution[] resolutions = Screen.resolutions;
		Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, fullScreen);
	}

	/// <summary>
	/// Save Function
	/// </summary>
	/// <param name="Settings.xml"></param>
	public void SaveSettings(string file) {
		XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
		FileStream stream = new FileStream(file, FileMode.Create);
		serializer.Serialize(stream, this);
		stream.Close();
	}

	/// <summary>
	/// Load Function
	/// </summary>
	/// <param name="Settings.xml"></param>
	/// <returns></returns>
	public static GameSettings LoadSettings(string file) {
		GameSettings settings;

		if (File.Exists(file))
			settings = LoadSettingsFromXml(file);
		else
			settings = new GameSettings();
		return settings;
			
	}

	private static GameSettings LoadSettingsFromXml(string file) {
		XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
		FileStream stream = new FileStream(file, FileMode.Open);
		GameSettings settings = serializer.Deserialize(stream) as GameSettings;
		stream.Close();
		return settings;
	}

	/// <summary>
	/// DEBUG Function
	/// </summary>
	public void DebugLog() {
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
		Debug.Log("Buffer = " + buffer);
		Debug.Log("PostProcessing = " + postProcessing);
	}
}