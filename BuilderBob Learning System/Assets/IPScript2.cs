using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.IO;

class intVector2 {
	public int x;
	public int y;
	
	public intVector2(int x, int y) {
		this.x = x;
		this.y = y;
	}
}

class NodesClass {
	private Vector2 lastPos;
	private string name;
	private Vector2 pos;
	private int count;
	
	public NodesClass() {
		count = 0;
		pos = new Vector2 (0, 0);
	}
	
	public void setName(string name) {
		this.name = name;
	}
	
	public string getName() {
		return name;
	}
	
	public void addToPos(int i, int j) {
		lastPos.x = i;
		lastPos.y = j;
		pos.x += pos.x + i;
		pos.y += pos.y + j;
		count += 1;
	}
}



public class IPScript2 : MonoBehaviour {

	public GameObject plane;
	public CtrlStruct[] csarray;
	public int _CaptureCounter = 0;
	public WebCamTexture webcamTexture;
	public string savePath = "/Users/praveenmody/snaps";
	public List<CtrlStruct> pixels = new List<CtrlStruct>();
	//public string url = "http://upload.wikimedia.org/wikipedia/commons/d/de/Color-Green.JPG";
	private Texture2D texture;
	private Texture2D textureNew;
	//Texture2D wwwTex;
	public TextAsset imageTextAsset;
	
	public Vector2 damPos1 = new Vector2(0,0);
	public Vector2 damPos2 = new Vector2(0,0);
	public Vector2 sandbagPos1 = new Vector2 (0, 0);
	public Vector2 sandbagPos2 = new Vector2(0,0);
	public Vector2 sandbagPos3 = new Vector2(0,0);
	public Vector2 sandbagPos4 = new Vector2(0,0);
	public Vector2 leevePos1 = new Vector2(0,0);
	public Vector2 leevePos2 = new Vector2(0,0);
	public Vector2 leevePos3 = new Vector2(0,0);
	
	private int countDam1 = 0;
	private int countDam2 = 0;
	private int countLeeve1 = 0;
	private int countLeeve2 = 0;
	private int countLeeve3 = 0;
	private int countSandbag1 = 0;
	private int countSandbag2 = 0;
	private int countSandbag3 = 0;
	private int countSandbag4 = 0;
	
	private GameObject[] blue;
	private GameObject[] green;
	private GameObject[] red;
	
	private int counter = 0;
	
	private Color blue1 = new Color (0, 0, 0.5f, 1);
	private Color blue2 = new Color (0, 0, 0.8f, 1);
	private List<Color> blues = new List<Color>();
	
	private Color Green1 = new Color(0, 0.3f, 0, 1);
	private Color Green2 = new Color(0, 0.6f, 0, 1);
	private Color Green3 = new Color(0, 0.9f, 0, 1);
	private List<Color> greens = new List<Color>();
	
	private Color Red1 = new Color(0.2f, 0, 0, 1);
	private Color Red2 = new Color(0.4f, 0, 0, 1);
	private Color Red3 = new Color(0.6f, 0, 0, 1);
	private Color Red4 = new Color(0.8f, 0, 0, 1);
	private List<Color> reds = new List<Color>();
	
	private int textureWidth, textureHeight;
	private float ratioX, ratioY;
	private int startI, startJ;
    private int time = 30;
    private float timer = 0f;
    private bool startTimer = false;
    private float waterTimer = 24f;
	
	// Giric's additions >>>>>>>>>>>>.
	private List<NodesClass> nodeList = new List<NodesClass>();
	
	public GameObject damObj1;
    public GameObject damObj2;
	public GameObject leeveObj1;
    public GameObject leeveObj2;
    public GameObject leeveObj3;
	public GameObject sandbagObj1;
    public GameObject sandbagObj2;
    public GameObject sandbagObj3;
    public GameObject sandbagObj4;


	// Use this for initialization
	IEnumerator Start () {
        
		print ("start");
		blues.Add (blue1);
		blues.Add (blue2);
		greens.Add (Green1);
		greens.Add (Green2);
		greens.Add (Green3);
		reds.Add (Red1);
		reds.Add (Red2);
		reds.Add (Red3);
		reds.Add (Red4);
		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture();
		if (devices.Length > 0) {
			webcamTexture.deviceName = devices[0].name;
			print (webcamTexture.deviceName);
			
			
			if(webcamTexture != null)
			{ 
				webcamTexture.Play();
				print ("waiting0");
				yield return new WaitForSeconds(time);
				print ("waiting");
				plane.GetComponent<MeshRenderer>().enabled = true;
				print ("waiting1");
				yield return new WaitForSeconds(1);
				print ("waiting2");
				TakeSnapshot();
				plane.GetComponent<MeshRenderer>().enabled = false;
				print ("waiting3");
			}
			print(webcamTexture.isPlaying);
			
		}


		print ("setting vars");
        textureWidth = 400;
		textureHeight = 400;
		texture = new Texture2D(640, 480);
		textureNew = new Texture2D (textureWidth, textureHeight);
		
		
		ratioX = 5;//2000 / texture.width;
		ratioY = 5;//2000 / texture.height;
		startI = 0;
		startJ = 56;
		
		
		//texture.Apply();
		//textureNew.Apply ();
		texture.LoadImage(imageTextAsset.bytes);
		texture.Apply ();
		print ("readng image");
		
		for (int i=0; i<=400; i=i+6){
			for (int j=56;j<=400;j=j+6){
               // Color pixel = texture.GetPixel(i, j);
                Color pixel = webcamTexture.GetPixel(i, j);
                if ((pixel.r < 0.7f * pixel.b) && (pixel.g < 0.7f * pixel.b))
				{
					Color Blue = new Color(0,0,1,1);	
					//mapImage("Blue",Blue,i,j);
					textureNew.SetPixel(i,j,Blue);
					textureNew.Apply();
					
				}
                else if ((pixel.g < 0.5f * pixel.r) && (pixel.b < 0.5f * pixel.r))
				{
					Color Red = new Color(1,0,0,1);	
					//mapImage("Red",Red,i,j);
					textureNew.SetPixel(i,j,Red);
					textureNew.Apply();
					
				}
                else if ((pixel.r < 0.75f * pixel.g) && (pixel.b < 0.75f * pixel.g))
				{
					Color Green = new Color(0,1,0,1);	
					//mapImage("Green",Green,i,j);
					textureNew.SetPixel(i,j,Green);
					textureNew.Apply();
					
					
				}
				else
				{
					textureNew.SetPixel(i,j,new Color(1,1,1,1));
					textureNew.Apply();
					//texture.SetPixel(i,j,new Color(0,0,0));
					//texture.Apply();
					//Other colors
				}
			}
		}

		print ("saving file");
		
		saveTextureToFile (textureNew, "testing1");
		print ("groupify");
		groupify ();
		print ("getting pos");
		getPositions ();
		//findNodes (texture);
		print(pixels.Count);
        if (countDam1 != 0)
        {
            damObj1.transform.position = new Vector3((damPos1.x + 0) * 5, 0, (damPos1.y - 20) * 5);
        }
        if (countDam2 != 0)
        {
            damObj2.transform.position = new Vector3((damPos2.x + 0) * 5, 0, (damPos2.y - 20) * 5);
        }
        else if (countDam2 == 0)
        {
            damObj2.transform.position = new Vector3((damPos1.x + 0) * 5, 0, (damPos1.y - 20) * 5);
        }
        if (countLeeve1 != 0)
        {
            leeveObj1.transform.position = new Vector3((leevePos1.x + 0) * 5, 0, (leevePos1.y - 20) * 5);
        }
        if (countLeeve2 != 0)
        {
            leeveObj2.transform.position = new Vector3((leevePos2.x + 0) * 5, 0, (leevePos2.y - 20) * 5);
        }
        if (countLeeve3 != 0)
        {
            leeveObj3.transform.position = new Vector3((leevePos3.x + 0) * 5, 0, (leevePos3.y - 20) * 5);
        }
        if (countSandbag1 != 0)
        {
            sandbagObj1.transform.position = new Vector3((sandbagPos1.x + 0) * 5, 0, (sandbagPos1.y - 20) * 5);
        }
        if (countSandbag2 != 0)
        {
            sandbagObj2.transform.position = new Vector3((sandbagPos2.x + 0) * 5, 0, (sandbagPos2.y - 20) * 5);
        }
        if (countSandbag3 != 0)
        {
            sandbagObj3.transform.position = new Vector3((sandbagPos3.x + 0) * 5, 0, (sandbagPos3.y - 20) * 5);
        }
        if (countSandbag4 != 0)
        {
            sandbagObj4.transform.position = new Vector3((sandbagPos4.x + 0) * 5, 0, (sandbagPos4.y - 20) * 5);
        }
		
		WaterRises.start = true;
        startTimer = true;
        GameObject[] dams = GameObject.FindGameObjectsWithTag("Finish");
        GameObject[] levees = GameObject.FindGameObjectsWithTag("levee");
        GameObject[] sbags = GameObject.FindGameObjectsWithTag("sandbag");
        foreach (GameObject gb in dams)
        {
            gb.GetComponent<Col>().pp = true;
        }
        foreach (GameObject gb in levees)
        {
            gb.GetComponent<LeveeCol>().pp = true;
        }
        foreach (GameObject gb in sbags)
        {
            gb.GetComponent<SandColl>().pp = true;
        }
	}
	
	bool isColorEqual(Color a, Color b) {
		if (a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a)
			return true;
		return false;
	}
	
	void getPositions() {
		
		for (int i=startI; i<textureNew.width; i+=6) {
			for (int j=startJ; j<textureNew.height; j+=6) {
				Color newColor = textureNew.GetPixel(i,j);
				
				newColor.r = Mathf.Round(newColor.r*10)/10;
				newColor.g = Mathf.Round (newColor.g*10)/10;
				newColor.b = Mathf.Round(newColor.b*10)/10;
				
				if (newColor.Equals (blue1)) {
					damPos1.x += i;
					damPos1.y += j;
					countDam1++;
					//print ("check" + blue1.ToString() + " : " + newColor.ToString());
				}
				else if (newColor.Equals (blue2)) {
					damPos2.x += i;
					damPos2.y += j;
					countDam2++;
					
				}
				else if (newColor.Equals (Green1)) {
					leevePos1.x += i;
					leevePos1.y += j;
					countLeeve1++;
					
				}
				else if (newColor.Equals (Green2)) {
					leevePos2.x += i;
					leevePos2.y += j;
					countLeeve2++;
					
				}
				else if (newColor.Equals (Green3)) {
					leevePos3.x += i;
					leevePos3.y += j;
					countLeeve3++;
					
				}
				else if (newColor.Equals (Red1)) {
					sandbagPos1.x += i;
					sandbagPos1.y += j;
					countSandbag1++;
					
				}
				else if (newColor.Equals (Red2)) {
					sandbagPos2.x += i;
					sandbagPos2.y += j;
					countSandbag2++;
					
				}
				else if (newColor.Equals (Red3)) {
					sandbagPos3.x += i;
					sandbagPos3.y += j;
					countSandbag3++;
					
				}
				else if (newColor.Equals (Red4)) {
					sandbagPos4.x += i;
					sandbagPos4.y += j;
					countSandbag4++;
					
				}
			}
		}
		
		print ("blue1" + countDam1);
		print ("blue2" + countDam2);
		print ("leeve1" + countLeeve1);
		print ("leeve2" + countLeeve2);
		print ("leeve3" + countLeeve3);
		print ("sb1" + countSandbag1);
		print ("sb2" + countSandbag2);
		print ("sb3" + countSandbag3);
		print ("sb4" + countSandbag4);
		damPos1.x = damPos1.x/countDam1;
		damPos1.y = damPos1.y/countDam1;
		damPos2.x = damPos2.x/countDam2;
		damPos2.y = damPos2.y/countDam2;
		leevePos1.x = leevePos1.x / countLeeve1;
		leevePos1.y = leevePos1.y / countLeeve1;
		leevePos2.x = leevePos2.x / countLeeve2;
		leevePos2.y = leevePos2.y / countLeeve2;
		leevePos3.x = leevePos3.x / countLeeve3;
		leevePos3.y = leevePos3.y / countLeeve3;
		sandbagPos1.x = sandbagPos1.x / countSandbag1;
		sandbagPos1.y = sandbagPos1.y / countSandbag1;
		sandbagPos2.x = sandbagPos2.x / countSandbag2;
		sandbagPos2.y = sandbagPos2.y / countSandbag2;
		sandbagPos3.x = sandbagPos3.x / countSandbag3;
		sandbagPos3.y = sandbagPos3.y / countSandbag3;
		sandbagPos4.x = sandbagPos4.x / countSandbag4;
		sandbagPos4.y = sandbagPos4.y / countSandbag4;
		
	}
	
	void changeNeighbors(Texture2D textureNew, List<intVector2> newList, Color color, Color newColor) {
		for (int i=0; i<newList.Count; i++) {
			//foreach (intVector2 node in newList) {
			intVector2 node = newList [i];
			// eight neighbors check
			intVector2 n1 = new intVector2 (node.x - 6, node.y - 6);
			intVector2 n2 = new intVector2 (node.x, node.y - 6);
			intVector2 n3 = new intVector2 (node.x + 6, node.y - 6);
			intVector2 n4 = new intVector2 (node.x - 6, node.y);
			intVector2 n5 = new intVector2 (node.x + 6, node.y);
			intVector2 n6 = new intVector2 (node.x - 6, node.y + 6);
			intVector2 n7 = new intVector2 (node.x, node.y + 6);
			intVector2 n8 = new intVector2 (node.x + 6, node.y + 6);
			
			if (textureNew.GetPixel (n1.x, n1.y).Equals (color)) {
				
				if (!newList.Contains (n1))
					newList.Add (n1);
			}
			if (textureNew.GetPixel (n2.x, n2.y).Equals (color)) {
				
				if (!newList.Contains (n2))
					newList.Add (n2);
			}
			if (textureNew.GetPixel (n3.x, n3.y).Equals (color)) {
				
				if (!newList.Contains (n3))
					newList.Add (n3);
			}
			if (textureNew.GetPixel (n4.x, n4.y).Equals (color)) {
				
				if (!newList.Contains (n4))
					newList.Add (n4);
			}
			if (textureNew.GetPixel (n5.x, n5.y).Equals (color)) {
				
				if (!newList.Contains (n5))
					newList.Add (n5);
			}
			if (textureNew.GetPixel (n6.x, n6.y).Equals (color)) {
				
				if (!newList.Contains (n6))
					newList.Add (n6);
			}
			if (textureNew.GetPixel (n7.x, n7.y).Equals (color)) {
				
				if (!newList.Contains (n7))
					newList.Add (n7);
			}
			if (textureNew.GetPixel (n8.x, n8.y).Equals (color)) {
				
				if (!newList.Contains (n8))
					newList.Add (n8);
			}
			
			
			textureNew.SetPixel ((int)node.x, (int)node.y, newColor);
			textureNew.Apply ();
			
		}
	}
	
	void groupify() {
		int countB = 0;
		int countR = 0;
		int countG = 0;
		List<intVector2> newList = new List<intVector2> ();
		for (int i=startI; i<textureNew.width; i+=6) {
			for (int j=startJ; j<textureNew.height; j+=6) {
				if (textureNew.GetPixel(i,j).Equals(new Color(0,0,1,1))) {
					newList = new List<intVector2>();
					newList.Add (new intVector2(i,j));
					
					changeNeighbors(textureNew, newList, new Color(0,0,1,1), blues[countB]);	
					countB=countB+1;
				}
				if (textureNew.GetPixel(i,j).Equals(new Color(1,0,0,1))) {
					newList = new List<intVector2>();
					newList.Add (new intVector2(i,j));
					
					changeNeighbors(textureNew, newList, new Color(1,0,0,1), reds[countR]);	
					countR=countR+1;
				}
				
				if (textureNew.GetPixel(i,j).Equals(new Color(0,1,0,1))) {
					newList = new List<intVector2>();
					newList.Add (new intVector2(i,j));
					
					changeNeighbors(textureNew, newList, new Color(0,1,0,1), greens[countG]);	
					countG=countG+1;
				}
			}
		}
		saveTextureToFile (textureNew, "testing2");
	}
	
	void mapImage(string colorPixel,Color paintColor,int i,int j)
	{
		
		pixels.Add(new CtrlStruct { csposit = new Vector2(i,j), color = colorPixel });		
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3(20,500,20);
        cube.transform.position = new Vector3(ratioX * (i + 0), 250, ratioY * (j - 20));//48 is the upper clip,30 is the side shift
		cube.tag = colorPixel;
		cube.name = "cube" + colorPixel + counter;
		counter++;
		MeshRenderer gameObjectRenderer = cube.GetComponent<MeshRenderer>();
		Material newMaterial = new Material(Shader.Find("Transparent/Diffuse"));
		newMaterial.color = paintColor;
		gameObjectRenderer.material = newMaterial ;
	}
	
	// Update is called once per frame
	void TakeSnapshot()
	{
		print("Webcam");
		Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
		snap.SetPixels(webcamTexture.GetPixels());
		snap.Apply();
		
		File.WriteAllBytes(Application.dataPath + "/Snap.png", snap.EncodeToPNG());
		print(Application.dataPath);
		++_CaptureCounter;
	}
	
	// Giric's Additionss >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
	void saveTextureToFile(Texture2D texture, string name) {
		File.WriteAllBytes(Application.dataPath + "/" +name+ ".png", texture.EncodeToPNG());
	}
	
	void findNodes(Texture2D texture) {
		/*for (int i=0; i< texture.width; i++) {
			for (int j=0; j<texture.height; j++) {
				if (nodeList.Count = 0) {
					NodesClass temp = new NodesClass();
					temp.addToPos(i,j);
					nodeList.Add(new NodesClass());
				}
				else {
					foreach (NodesClass node in nodeList) {

					}
				}
			}
		}*/
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer)
        {
            timer = timer + Time.fixedDeltaTime;
            print(timer);
            if (timer >= waterTimer)
            {
                WaterRises.start = false;
                startTimer = false;
            }
        }
	}
}
