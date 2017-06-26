﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenuController : MonoBehaviour {

	public Toggle fullScreenToggle;
	public Toggle vSyncToggle;
	public Toggle HDRToggle;
	public Dropdown resolutionDropdown;
	public Dropdown graphicDropdown;
	public Dropdown textureDropdown;
	public Dropdown skyDropdown;
	public Dropdown shadowDropdown;
	public Dropdown aaDropdown;
	public Dropdown anisotropicDropdown;

	public Dropdown postProcessingDropdown;
	public Dropdown methodAntiAliasingDropdown;
	public Dropdown bufferDropdown;

	public bool general;
	private Resolution[] resolutions = null;
	GameSettings Settings;

	// Use this for initialization
	void Start() {
		CreateResolution();
		if (File.Exists("Settings.xml"))
			LoadSettings();
		else
			Settings = new GameSettings();
	}

	// Update is called once per frame
	void Update() {
	 }

	private void CreateResolution()
	{
		Resolution Previous = new Resolution();
		resolutions = Screen.resolutions;

		foreach (Resolution resolution in resolutions)
		{
			if ((resolution.height != Previous.height) && (resolution.width != Previous.width))
				resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
			Previous = resolution;
		}
	}

	public void LoadSettings() {
		XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
		FileStream stream = new FileStream("Settings.xml", FileMode.Open);
		Settings = serializer.Deserialize(stream) as GameSettings;
		stream.Close();
		
		LoadUI();
		
		
	}

	public void LoadUI() {	
		general = true;
		fullScreenToggle.isOn = Settings.fullScreen;
		vSyncToggle.isOn = Settings.vSync;
		HDRToggle.isOn = Settings.HDR;
		resolutionDropdown.value = Settings.resolutionIndex;
		textureDropdown.value = Settings.texturesQuality;
		skyDropdown.value = Settings.skyQuality;
		shadowDropdown.value = Settings.shadowQuality;
		postProcessingDropdown.value = Settings.postProcessing;
		bufferDropdown.value = Settings.buffer;
		methodAntiAliasingDropdown.value = Settings.methodAntiAliasing;
		anisotropicDropdown.value = Settings.anisotropic;
		aaDropdown.value = Settings.antiAliasing;
		graphicDropdown.value = Settings.graphicQuality;
		resolutionDropdown.RefreshShownValue();
		
	}


	public void SaveSettings () {
		XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
		FileStream stream = new FileStream("Settings.xml", FileMode.Create);
		serializer.Serialize(stream, Settings);
		stream.Close();
	}

	public void Retour () {
		SceneManager.LoadScene("MainMenu");
	}

	public void Appliquer() {
		Screen.SetResolution(resolutions[Settings.resolutionIndex].width, resolutions[Settings.resolutionIndex].height, Settings.fullScreen);
		QualitySettings.shadowResolution = (ShadowResolution)Settings.shadowQuality;
		QualitySettings.antiAliasing = (Settings.antiAliasing == 0 ? 0 : (int)Mathf.Pow(2, Settings.antiAliasing));
		QualitySettings.masterTextureLimit = Settings.texturesQuality;
		QualitySettings.vSyncCount = Settings.vSync == true ? 1 : 0;
		QualitySettings.asyncUploadBufferSize = (Settings.buffer == 0 ? 0 : (int)Mathf.Pow(4, Settings.buffer));
		Camera.current.allowHDR = Settings.HDR;
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		Texture.SetGlobalAnisotropicFilteringLimits(Settings.anisotropic , 9);
		if (Settings.methodAntiAliasing == 1)
			Camera.current.allowMSAA = true;
		SaveSettings();
		Retour();
		//Application of options 11/12
	}

	public void UpdateAA(int postProcessing) {
		if (postProcessing > 0 && methodAntiAliasingDropdown.options.Count == 2)
		{
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("TAA"));
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("FXAA"));
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("SSAA"));
		}
		else if (postProcessing == 0 && methodAntiAliasingDropdown.options.Count == 5)
		{
			methodAntiAliasingDropdown.options.RemoveRange(2, 3);
			methodAntiAliasingDropdown.RefreshShownValue();
		}
	}

	public void ModeCustom()
	{
		if (general == false)
			graphicDropdown.value = 4;
	}

	public void SetFullScreen(bool enable)
	{
		Settings.fullScreen = enable;
	}

	public void SetVSync(bool enable)
	{
		Settings.vSync = enable;
		ModeCustom();

	}

	public void SetHDR(bool enable)
	{
		Settings.HDR = enable;
		ModeCustom();
	}

	public void SetResolution(int index) {
		Settings.resolutionIndex = index;
	}

	public void SetGraphicQuality(int graphic) {
		Settings.graphicQuality = graphic;
		if (graphic < 4)
		{
			general = true;
			textureDropdown.value = graphic;
			skyDropdown.value = graphic;
			shadowDropdown.value = graphic;
			aaDropdown.value = graphic;
			postProcessingDropdown.value = graphic;
			anisotropicDropdown.value = graphic;
			if (graphic > 1)
				vSyncToggle.isOn = true;
			else
				vSyncToggle.isOn = false;
			if (graphic > 2)
				HDRToggle.isOn = true;
			else
				HDRToggle.isOn = false;
			general = false;
		}
	}

	public void SetTextureQuality(int texture) {
		Settings.texturesQuality = texture;
		ModeCustom();

	}

	public void SetSkyQuality(int sky) {
		Settings.skyQuality = sky;
		ModeCustom();
	}

	public void SetShadowQuality(int shadow) {
		Settings.shadowQuality = shadow;
		ModeCustom();
	}

	public void SetAA(int aa)
	{
		Settings.antiAliasing = aa;
		ModeCustom();
	}

	public void SetPostProcessing(int postProcessing) {
		Settings.postProcessing = postProcessing;
		UpdateAA(postProcessing);
		ModeCustom();
	}

	public void SetMethodAntiAliasing(int methodAntiAliasing)
	{
		Settings.methodAntiAliasing = methodAntiAliasing;
		ModeCustom();
	}
	public void SetBuffer(int buffer)
	{
		Settings.buffer = buffer;
		ModeCustom();
	}

	public void SetAnisotropic(int anisotropic) {
		Settings.anisotropic = anisotropic;
		ModeCustom();
	}
}
