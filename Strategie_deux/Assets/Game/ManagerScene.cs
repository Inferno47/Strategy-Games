using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	private List<Pair<Scene, string>> listScene;
	private GameSettings settings;
    private ANetworkManager networkManager;
	private string previousScene;

    public ANetworkManager NetworkManager
    {
        get
        {
            return networkManager;
        }

        set
        {
            if (networkManager != null)
                Destroy(networkManager.gameObject);
            networkManager = value;
        }
    }

    public GameSettings Settings
    {
        get
        {
            return settings;
        }
    }

    // Use this for initialization
    void Start () {
		if (GameObject.FindObjectsOfType(typeof(ManagerScene)).Length > 1)
			Destroy(this.gameObject);
		DontDestroyOnLoad(this);
		SceneManager.sceneLoaded += OnSceneLoaded;
        listScene = new List<Pair<Scene, string>> {new Pair<Scene, string>(SceneManager.GetActiveScene(), "MainMenu")};
	    settings = GameSettings.LoadSettings("Settings.xml");
		settings.Apply();
	}
	
	// Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// System for load and unload Scene
    /// </summary>
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (mode == LoadSceneMode.Single)
		{
			previousScene = listScene[0].Second;
            listScene.Clear();
			FindGameObjectByName(scene.GetRootGameObjects(), "Main Camera").SetActive(true);
			FindGameObjectByName(scene.GetRootGameObjects(), "EventSystem").SetActive(true);
			settings.ApplycCamera();
		}
        listScene.Add(new Pair<Scene, string>(scene, scene.name));
	}

	public void LoadScene(string name, LoadSceneMode mode) {
		if (mode == LoadSceneMode.Additive)
			DisableCanvas(listScene.Count - 1);
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
	    {
	        return;
	    }
	    else if (index == 0)
	    {
	        LoadScene(previousScene, LoadSceneMode.Single);
	        return;
	    }
	    SceneManager.UnloadSceneAsync(name);
        listScene.RemoveAt(index);
		if (index == 0)
			return;
		EnableCanvas(index - 1);
	}

	/// <summary>
	/// Warning: To start this function, all LoadScene() must be terminated
	/// </summary>
	private void LoadScenePrevious(int index) {
		for (int i = listScene.Count - 1; i > index; --i)
			UnloadSceneByIndex(i);
		EnableCanvas(index);
	}

	private void UnloadSceneByIndex(int index) {
		SceneManager.UnloadSceneAsync(listScene[index].Second);
        listScene.RemoveAt(index);
	}

	private int FindScene(string name) {
		for (int i = 0; i < listScene.Count; ++i)
			if (listScene[i].Second == name)
				return i;
		return -1;
	}

	private static GameObject FindGameObjectByName(IEnumerable<GameObject> listGameObjects, string name) {
	    return listGameObjects.FirstOrDefault(tmp => tmp.name == name);
	}

	public GameObject FindGameObjectByScene(string scene, string name)  {
		int indexScene = FindScene(scene);
		return indexScene == -1 ? null : FindGameObjectByName(listScene[indexScene].First.GetRootGameObjects(), name);
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
		if (index < 0 && index >= listScene.Count)
			return null;
		GameObject[] listGameObjects = listScene[index].First.GetRootGameObjects();
		return FindGameObjectByName(listGameObjects, "Canvas");
	}

    /// <summary>
    /// DEBUG Function
    /// </summary>
    public void DebugLog()
    {
        foreach (Pair<Scene, string> scene in listScene)
            Debug.Log("Scene Name : " + scene.Second);
        if (settings != null)
            settings.DebugLog();
        /*if (networkManager != null)
            networkManager.DebuLog();*/
        Debug.Log(previousScene);
    }
}
