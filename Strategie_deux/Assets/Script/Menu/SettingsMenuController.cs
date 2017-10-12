using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour {

	public Toggle fullScreenToggle;
	public Toggle vSyncToggle;
	public Toggle HDRToggle;
	public Dropdown resolutionDropdown;
	public Dropdown graphicDropdown;
	public Dropdown textureDropdown;
	public Dropdown shadowDropdown;
	public Dropdown aaDropdown;
	public Dropdown anisotropicDropdown;

	public Dropdown postProcessingDropdown;
	public Dropdown methodAntiAliasingDropdown;
	public Dropdown bufferDropdown;

	public bool general;
	private Resolution[] resolutions = null;
	private GameSettings Settings;
	private ManagerScene managerScene;

	// Use this for initialization
	void Start() {
		CreateResolution();
		managerScene = (ManagerScene)FindObjectOfType(typeof(ManagerScene));
		if (managerScene != null)
		{
			Settings = managerScene.Settings;
			LoadUI();
		}
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
            if ((resolution.height != Previous.height) || (resolution.width != Previous.width))
                resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
			Previous = resolution;
		}
	}

	public void LoadUI() {	
		general = true;
		vSyncToggle.isOn = Settings.vSync;
        HDRToggle.isOn = Settings.HDR;
        resolutionDropdown.value = Settings.resolutionIndex;
        fullScreenToggle.isOn = Settings.fullScreen;
        textureDropdown.value = Settings.texturesQuality;
		shadowDropdown.value = Settings.shadowQuality;
		postProcessingDropdown.value = Settings.postProcessing;
		bufferDropdown.value = Settings.buffer;
		methodAntiAliasingDropdown.value = Settings.methodAntiAliasing;
		anisotropicDropdown.value = Settings.anisotropic;
		aaDropdown.value = Settings.antiAliasing;
		graphicDropdown.value = Settings.graphicQuality;
        resolutionDropdown.RefreshShownValue();
		general = false;
	}

	public void Return () {
		managerScene.UnLoadScene("SettingsMenu");
	}

	public void SaveSettings() {
		Settings.SaveSettings("Settings.xml");
	}

	public void Apply () {
		Settings.Apply();
		Settings.SaveSettings("Settings.xml");
		Return();
	}

	public void UpdateAA(int postProcessing) {
		if (postProcessing > 0 && methodAntiAliasingDropdown.options.Count == 2)
		{
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("TAA"));
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("FXAA"));
			methodAntiAliasingDropdown.options.Add(new Dropdown.OptionData("SSAA"));
		}
		else if (postProcessing == 0 && methodAntiAliasingDropdown.options.Count == 5)
			methodAntiAliasingDropdown.options.RemoveRange(2, 3);
		methodAntiAliasingDropdown.RefreshShownValue();
	}

	public void ModeCustom() {
		if (general == false)
			graphicDropdown.value = 4;
	}

	public void SetFullScreen(bool enable) {
		Settings.fullScreen = enable;
	}

	public void SetVSync(bool enable) {
		Settings.vSync = enable;
		ModeCustom();
	}

	public void SetHDR(bool enable) {
		Settings.HDR = enable;
		ModeCustom();
	}

	public void SetResolution(int index) {
		Settings.resolutionIndex = index;
	}

	public void SetGraphicQuality(int graphic) {
        Settings.graphicQuality = graphic;
        if (graphic >= 4)
            return;

        general = true;
		textureDropdown.value = graphic;
		shadowDropdown.value = graphic;
		aaDropdown.value = graphic;
		postProcessingDropdown.value = graphic;
		anisotropicDropdown.value = graphic;
		vSyncToggle.isOn = graphic > 1;
		HDRToggle.isOn = graphic > 2;
		general = false;
	}

	public void SetTextureQuality(int texture) {
		Settings.texturesQuality = texture;
		ModeCustom();
	}

	public void SetShadowQuality(int shadow) {
		Settings.shadowQuality = shadow;
		ModeCustom();
	}

	public void SetAA(int aa) {
		Settings.antiAliasing = aa;
		ModeCustom();
	}

	public void SetPostProcessing(int postProcessing) {
		Settings.postProcessing = postProcessing;
		UpdateAA(postProcessing);
		ModeCustom();
	}

	public void SetMethodAntiAliasing(int methodAntiAliasing) {
		Settings.methodAntiAliasing = methodAntiAliasing;
		ModeCustom();
	}

	public void SetBuffer(int buffer) {
		Settings.buffer = buffer;
		ModeCustom();
	}

	public void SetAnisotropic(int anisotropic) {
		Settings.anisotropic = anisotropic;
		ModeCustom();
	}
    public void DebugLog()
    {
        Debug.Log("SettingsMenu");
        Debug.Log("general = " + general);
        Debug.Log("vSyncToggle.isOn = " + vSyncToggle.isOn);
        Debug.Log("HDRToggle.isOn = " + HDRToggle.isOn);
        Debug.Log("resolutionDropdown.value = " + resolutionDropdown.value);
        Debug.Log("fullScreenToggle.isOn = " + fullScreenToggle.isOn);
        Debug.Log("textureDropdown.value = " + textureDropdown.value);
        Debug.Log("shadowDropdown.value = " + shadowDropdown.value);
        Debug.Log("postProcessingDropdown.value = " + postProcessingDropdown.value);
        Debug.Log("bufferDropdown.value = " + bufferDropdown.value);
        Debug.Log("methodAntiAliasingDropdown.value " + methodAntiAliasingDropdown.value);
        Debug.Log("anisotropicDropdown.value = " + anisotropicDropdown.value);
        Debug.Log("aaDropdown.value = " + aaDropdown.value);
        Debug.Log("graphicDropdown.value = " + graphicDropdown.value);
        foreach(Resolution res in resolutions)
            Debug.Log("resolution (" + res.ToString() + ")");
    }
}
