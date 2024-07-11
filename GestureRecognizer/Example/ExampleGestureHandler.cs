using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GestureRecognizer;
using System.Linq;

public class ExampleGestureHandler : MonoBehaviour {

	public Text textResult;

	//public Transform referenceRoot;

	public List<GesturePatternDraw> references = new List<GesturePatternDraw>();
	//GesturePatternDraw[] references;
	ColorArea colorArea;
	void Start () {
		//Actualizarreferencias();
		colorArea = GetComponent<ColorArea>();
	}

	/*
	void Actualizarreferencias()
	{
		references.Clear();
		GesturePatternDraw[] gpd = referenceRoot.GetComponentsInChildren<GesturePatternDraw>();
		foreach (GesturePatternDraw g in gpd)
		{
			references.Add(g);
		}
		//references = referenceRoot.GetComponentsInChildren<GesturePatternDraw>();
	}
	*/

	void ShowAll(){
		for (int i = 0; i < references.Count; i++) {
			references [i].gameObject.SetActive (true);
		}
	}

	public void OnRecognize(RecognitionResult result){
		StopAllCoroutines ();
		//ShowAll ();
		if (result != RecognitionResult.Empty)
		{
			//textResult.text = "wena"; //result.gesture.id + "\n" + Mathf.RoundToInt (result.score.score * 100) + "%";
									  //StartCoroutine (Blink (result.gesture.id));
			if(GameManager.instance.BuscarEnLibreria(colorArea.colorArea, result.gesture))
			{
				colorArea.LoHizoBien();
			}
			else
			{
				colorArea.LoHizoMal();
			}
		}
		else
		{
			colorArea.LoHizoMal();
		}
	}



	IEnumerator Blink(string id){
		var draw = references.Where (e => e.pattern.id == id).FirstOrDefault ();
		if (draw != null) {
			colorArea.LoHizoBien();
			var seconds = new WaitForSeconds (0.1f);
			for (int i = 0; i <= 20; i++) {
				draw.gameObject.SetActive (i % 2 == 0);
				yield return seconds;
			}
			draw.gameObject.SetActive (true);
			Destroy(draw.gameObject.transform.parent.gameObject);
			

		}
		else
		{

			colorArea.LoHizoMal();
		}
		//.SetActive(false);
		//Actualizarreferencias();
	}

}
