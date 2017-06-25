using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

struct Windows {
	public int x;
	public int y;
}

public class OptionMenuController : MonoBehaviour {

	private int graphic;
	private int textures;
	private int sky;
	private int processing;
	private int shadow;
	private int antialiasing;
	private int anisotropic;
	private int windowMode;
	private int indexResolution;
	private bool syncrovertical;
	private List<Windows> resolution = null;

	public bool Syncrovertical
	{
		get
		{
			return syncrovertical;
		}

		set
		{
			syncrovertical = value;
		}
	}

	public int Graphic
	{
		get
		{
			return graphic;
		}

		set
		{
			graphic = value;
		}
	}

	public int Textures
	{
		get
		{
			return textures;
		}

		set
		{
			textures = value;
		}
	}

	public int Sky
	{
		get
		{
			return sky;
		}

		set
		{
			sky = value;
		}
	}

	public int Processing
	{
		get
		{
			return processing;
		}

		set
		{
			processing = value;
		}
	}

	public int Shadow
	{
		get
		{
			return shadow;
		}

		set
		{
			shadow = value;
		}
	}

	public int Antialiasing
	{
		get
		{
			return antialiasing;
		}

		set
		{
			antialiasing = value;
		}
	}

	public int WindowMode
	{
		get
		{
			return windowMode;
		}

		set
		{
			windowMode = value;
		}
	}

	public int IndexResolution
	{
		get
		{
			return indexResolution;
		}

		set
		{
			indexResolution = value;
		}
	}

	public int Anisotropic
	{
		get
		{
			return anisotropic;
		}

		set
		{
			anisotropic = value;
		}
	}

	// Use this for initialization
	void Start () {
		CreateResolution();
	}

	// Update is called once per frame
	void Update() {
	}

	private void CreateResolution()
	{
		resolution = new List<Windows>();
		Windows size1 = new Windows();
		size1.x = 640;
		size1.y = 480;
		resolution.Add(size1);
		Windows size2 = new Windows();
		size2.x = 720;
		size2.y = 480;
		resolution.Add(size2);
		Windows size3 = new Windows();
		size3.x = 720;
		size3.y = 576;
		resolution.Add(size3);
		Windows size4 = new Windows();
		size4.x = 800;
		size4.y = 600;
		resolution.Add(size4);
		Windows size5 = new Windows();
		size5.x = 1024;
		size5.y = 768;
		resolution.Add(size5);
		Windows size6 = new Windows();
		size6.x = 1280;
		size6.y = 720;
		resolution.Add(size6);
		Windows size7 = new Windows();
		size7.x = 1280;
		size7.y = 768;
		resolution.Add(size7);
		Windows size8 = new Windows();
		size8.x = 1280;
		size8.y = 800;
		resolution.Add(size8);
		Windows size9 = new Windows();
		size9.x = 1280;
		size9.y = 960;
		resolution.Add(size9);
		Windows size10 = new Windows();
		size10.x = 1280;
		size10.y = 1024;
		resolution.Add(size10);
		Windows size11 = new Windows();
		size11.x = 1360;
		size11.y = 768;
		resolution.Add(size11);
		Windows size12 = new Windows();
		size12.x = 1360;
		size12.y = 1024;
		resolution.Add(size12);
		Windows size13 = new Windows();
		size13.x = 1366;
		size13.y = 768;
		resolution.Add(size13);
		Windows size14 = new Windows();
		size14.x = 1440;
		size14.y = 900;
		resolution.Add(size14);
		Windows size15 = new Windows();
		size15.x = 1600;
		size15.y = 900;
		resolution.Add(size15);
		Windows size16 = new Windows();
		size16.x = 1680;
		size16.y = 1050;
		resolution.Add(size16);
		Windows size17 = new Windows();
		size17.x = 1920;
		size17.y = 1080;
		resolution.Add(size17);
		Windows size18 = new Windows();
		size18.x = 1920;
		size18.y = 1200;
		resolution.Add(size18);
	}

	public void Load() {
		//Load Configuration
	}

	public void Save () {
		Debug.Log("Sync = " + syncrovertical);
		Debug.Log("Graphic = " + graphic);
		Debug.Log("Shadow = " + shadow);
		Debug.Log("Textures = " + textures);
		Debug.Log("Processing = " + processing);
		Debug.Log("Sky = " + sky);
		Debug.Log("Antialisaing = " + x(antialiasing));
		Debug.Log("Anisotropic = " + x(anisotropic));
		Debug.Log("Resolution = " + resolution[indexResolution].x + "x" + resolution[indexResolution].y);
		Debug.Log("Mode Windows = " + (windowMode == 0 ? true : false));
		//Save Configuration
	}

	public int x (int nb) {
		if (nb == 0)
			return (0);
		int result = 1;
		for (int i = 0; i < nb; i++)
			result *= 2;
		return result;
	}


	public void Retour () {
		SceneManager.LoadScene("MainMenu");
	}

	public void Appliquer() {
		QualitySettings.shadowResolution = (ShadowResolution)shadow;
		QualitySettings.antiAliasing = x(antialiasing);
		Screen.SetResolution(resolution[indexResolution].x, resolution[indexResolution].y, windowMode == 0 ? true : false);
		//Application of options
		Save();
		Retour();
	}
}
