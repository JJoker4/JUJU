using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {

	private PlayerAttributes playerAttr;

	private Canvas canvas;
	private string[] fonts;
	private readonly int defaultFontSize = 40;
	private readonly Vector2 defaultUIelementAnchoredSize = new Vector2(220, 100);

	private Dictionary<string, GameObject> uiDict = new Dictionary<string, GameObject>();


	void Awake ()
	{
		fonts = Font.GetOSInstalledFontNames();
	}

	void Start () {
		playerAttr = GameObject.FindObjectOfType<PlayerAttributes>();
		addCanvasToGameObject();
		canvas = this.gameObject.GetComponent<Canvas>();
		configureCanvas(canvas);
		addCustomMenuSet(200,30,40);
		addTextGoElementToCanvas("DetectorText", "", new Vector2(0,-200));
	}


	void Update ()
	{
		GameObject.Find("Life").GetComponent<Text>().text = "Life: " + playerAttr.life;
		GameObject.Find("Energy").GetComponent<Text>().text = "Energy: " + playerAttr.energy;
		GameObject.Find("Oxygen").GetComponent<Text>().text = "Oxygen: " + playerAttr.oxygen;
	}


	private void addCanvasToGameObject ()
	{
		this.gameObject.AddComponent<Canvas>();
	}

	private void configureCanvas (Canvas canvas)
	{
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		this.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}

	private GameObject addTextGoElementToCanvas (string name, string value, Vector2 anchoredPosition)
	{
		GameObject go = new GameObject(name);
		go.transform.SetParent(this.gameObject.transform);
		go.AddComponent<Text>();

		Text targetText = go.GetComponent<Text>();
		targetText.font = Font.CreateDynamicFontFromOSFont(fonts[0], 10);
		targetText.fontSize = defaultFontSize;
		targetText.text = value;
		go.GetComponent<RectTransform>().sizeDelta = defaultUIelementAnchoredSize;
		go.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;


		uiDict.Add(name, go);
		return go;
	}

	private void moveElement(GameObject go, Vector3 r) {
		go.GetComponent<RectTransform>().position = r;
	}

	private void addCustomMenuSet(int width, int height, int distanceYfactor) {
		int distanceNextObjectMultiplier = 2;
		GameObject nameGo = addTextGoElementToCanvas("Life", "Life: " + playerAttr.life, new Vector2(-width,height));
		GameObject LifeGo = addTextGoElementToCanvas("Energy", "Energy: " + playerAttr.energy, new Vector2(-width,height + distanceYfactor));
		GameObject oxygenGo = addTextGoElementToCanvas("Oxygen", "Oxygen: " + playerAttr.oxygen,new Vector2(-width,height + (distanceNextObjectMultiplier * distanceYfactor)));
	}
}
