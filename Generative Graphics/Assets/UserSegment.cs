using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// NOTE: Some code below adapted from NuiTrack tutorial code at https://download.3divi.com/Nuitrack/doc/UnitySegment_page.html
public class UserSegment: MonoBehaviour {

	// Use this for initialization
	[SerializeField]
    Color32[] colorsList;
     
    Rect imageRect;
     
    [SerializeField]
    Image segmentOut;
     
    Texture2D segmentTexture;
    Sprite segmentSprite;
    byte[] outSegment;
     
    int cols = 0;
    int rows = 0;
	void Start () {
		NuitrackManager.DepthSensor.SetMirror(true);

		NuitrackManager.onUserTrackerUpdate += ColorizeUser;

		nuitrack.OutputMode mode = NuitrackManager.DepthSensor.GetOutputMode();
		cols = mode.XRes;
		rows = mode.YRes;

		imageRect = new Rect(0, 0, cols, rows);
		segmentTexture = new Texture2D(cols, rows, TextureFormat.ARGB32, false);
		outSegment = new byte[cols * rows * 4];
		segmentOut.type = Image.Type.Simple;
		segmentOut.preserveAspect = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		NuitrackManager.onUserTrackerUpdate -= ColorizeUser;
	}
	void ColorizeUser(nuitrack.UserFrame frame)
	{
		
		for (int i = 0; i < (cols * rows); i++)
		{
			Color32 currentColor = colorsList[frame[i]];
		
			int ptr = i * 4;
			outSegment[ptr] = currentColor.a;
			outSegment[ptr + 1] = currentColor.r;
			outSegment[ptr + 2] = currentColor.g;
			outSegment[ptr + 3] = currentColor.b;
		}

		segmentTexture.LoadRawTextureData(outSegment);
		segmentTexture.Apply();
		segmentSprite = Sprite.Create(segmentTexture, imageRect, Vector3.one * 0.5f, 100f, 0, SpriteMeshType.FullRect);
		segmentOut.sprite = segmentSprite;

	}
	
	private void OnGUI()
	{
		GUI.color = Color.red;
		GUI.skin.label.fontSize = 50;
	}
}