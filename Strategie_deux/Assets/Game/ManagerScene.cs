using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pair<T, U>
{
	public Pair()
	{
	}

	public Pair(T first, U second)
	{
		this.First = first;
		this.Second = second;
	}

	public T First { get; set; }
	public U Second { get; set; }
};

public class ManagerScene : MonoBehaviour
{
	private List<Pair<Scene, string>> ListScene;
	private GameSettings settings;
	private string previousScene;

	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectsOfType(typeof(ManagerScene)).Length > 1)
			Destroy(this.gameObject);
		DontDestroyOnLoad(this);
		SceneManager.sceneLoaded += OnSceneLoaded;
		ListScene = new List<Pair<Scene, string>>();
		ListScene.Add(new Pair<Scene, string>(SceneManager.GetActiveScene(), "MainMenu"));
		settings = GameSettings.LoadSettings("Settings.xml");
		settings.Apply();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public GameSettings GetSettings() {
		return settings;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (mode == LoadSceneMode.Single)
		{
			previousScene = ListScene[0].Second;
			ListScene.Clear();
			FindGameObjectByName(scene.GetRootGameObjects(), "Main Camera").SetActive(true);
			FindGameObjectByName(scene.GetRootGameObjects(), "EventSystem").SetActive(true);
			settings.ApplycCamera();
		}
		ListScene.Add(new Pair<Scene, string>(scene, scene.name));
		Debug.Log(scene.name);
	}

	public void LoadScene(string name, LoadSceneMode mode) {
		if (mode == LoadSceneMode.Additive)
			DisableCanvas(ListScene.Count - 1);
		if (name == "MainMenu")
			mode = LoadSceneMode.Single; 
		if (FindScene(name) != -1)
			LoadScenePrevious(FindScene(name));
		else
			SceneManager.LoadScene(name, mode);
	}

	public void UnLoadScene(string name) {
		int index = FindScene(name);
		if (index == -1)
			return;
		if (index == 0)
		{
			LoadScene(previousScene, LoadSceneMode.Single);
			return;
		}
		SceneManager.UnloadSceneAsync(name);
		ListScene.RemoveAt(index);
		if (index == 0)
			return;
		EnableCanvas(index - 1);
	}

	/// <summary>
	/// Warning: To start this function, all LoadScene() must be terminated
	/// </summary>
	private void LoadScenePrevious(int index) {
		for (int i = ListScene.Count - 1; i > index; i--)
			UnloadSceneByIndex(i);
		EnableCanvas(index);
	}

	private void UnloadSceneByIndex(int index) {
		SceneManager.UnloadSceneAsync(ListScene[index].Second);
		ListScene.RemoveAt(index);
	}

	private int FindScene(string name)
	{
		for (int i = 0; i < ListScene.Count; i++)
			if (ListScene[i].Second == name)
				return i;
		return -1;
	}

	private GameObject FindGameObjectByName(GameObject[] listGameObjects, string name) {
		for (int i = 0; i < listGameObjects.Length; i++)
			if (listGameObjects[i].name == name)
				return listGameObjects[i];
		return null;
	}

	public GameObject FindGameObjectByScene(string scene, string name)  {
		int indexScene = FindScene(scene);
		if (indexScene == -1)
			return null;
		return FindGameObjectByName(ListScene[indexScene].First.GetRootGameObjects(), name);
	}

	private void EnableCanvas(int index) {
		GameObject canvas = GetCanvas(index);
		
		if (canvas != null)
			canvas.SetActive(true);
	}

	private void DisableCanvas(int index) {
		GameObject canvas = GetCanvas(index);
		if (canvas != null)
			canvas.SetActive(false);
	}

	private GameObject GetCanvas(int index) {
		if (index < 0 && index >= ListScene.Count)
			return null;
		GameObject[] listGameObjects = ListScene[index].First.GetRootGameObjects();
		return FindGameObjectByName(listGameObjects, "Canvas");
	}
}
