using UnityEngine;
using System.Collections;

public class LeveeCol : MonoBehaviour {
	public bool a = false;
	public int collisionRegion = 0;
	public bool lowel = false;
	public bool mediumel = false;
	public bool highel = false;
	public bool lowec = false;
	public bool mediumec = false;
	public bool highec = false;
	public bool lowp = false;
	public bool mediump = false;
	public bool highp = false;
	public int score = 0; 
	public string advise ;
	public bool pp;
	public resultClass res;

	// Use this for initialization
	void Start () {
		advise = "";
		res = new resultClass ();
		res.setFinalDistance(99999999f);
	}
	
	// Update is called once per frame
	void Update () {
		if (pp) {
			generateAdvise();
			pp=false;
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "LeveeCollDown") { 
			collisionRegion = 1;
		} else if (collision.gameObject.tag == "LeveeCollUp") {
			collisionRegion = 2;
        }
        else if (collision.gameObject.tag == "LeveeCollRight")
        {
			collisionRegion = 3;
        }
        else if (collision.gameObject.tag == "LeveeCollLeft")
        {
			collisionRegion = 4;
		}
		if (collision.transform.tag == "LowElevationArea") { 
			lowel = true;
		}
		if (collision.transform.tag == "HighElevationArea") { 
			highel = true;
		}
		if (collision.transform.tag == "MediumElevationArea") { 
			mediumel = true;
		}
		if (collision.transform.tag == "LowEcoArea") { 
			lowec = true;
		}
		if (collision.transform.tag == "MediumEcoArea") { 
			mediumec = true;
		}
		if (collision.transform.tag == "HighEcoArea") { 
			highec = true;
		}
		if (collision.transform.tag == "LowPopArea") { 
			lowp = true;
		}
		if (collision.transform.tag == "HighPopArea") { 
			highp = true;
		}
		if (collision.transform.tag == "MediumPopArea") { 
			mediump = true;
		}
	}
	public void generateAdvise(){
		advise = "";
		int score = 0;
		int elScore = 0; 
		int ecoScore = 0; 
		int pScore = 0; 

		advise += "EVALUATION OF TOPOLOGICAL MEASURES :\n";
		string interimAdvise = "";
		if (highel) {
			score += 0;
			elScore += 0;
			interimAdvise = "You have placed the levee at a high elevation area but it needs to be placed at a low lying area in order for it to be effective ";
		}else if (mediumel) {
			score += 0;
			elScore += 5;
			interimAdvise = "You have placed the levee at a medium elevation area but it needs to be placed at a low lying area in order for it to be effective ";
		}else if (lowel) {
			print ("inside");
			score += 10;
			elScore += 10;
			interimAdvise = "You have rightly placed the levee at a low elevation area ";
		}
		advise += interimAdvise;
		advise += "\nSCORE: "+elScore.ToString()+"\n";
		advise += "\nEVALUATION OF ECONOMIC SECURITY :\n";

		interimAdvise = "";
		if (highec) {
			score += 10;
			ecoScore += 10;
			interimAdvise = "You have rightly placed the levee at a high economy area, this levee would be very efficient for economic security. Since the economy now can be protected from the destruction caused by floods";
		}else if (mediumec) {
			score += 5;
			ecoScore += 5;
			interimAdvise = "You have placed the levee in a medium economy area, this levee would be partly efficient for economic security. A levee would be better placed at an area with high economy, since the economy then can be protected from the destruction caused by floods";
		}else if (lowec) {
			interimAdvise = "You have placed the levee low economy area, this levee would be inefficient for economic security. A levee would be better placed at an area with high economy, since the economy then can be protected from the destruction caused by floods";
		}
		advise+=interimAdvise;
		advise += "\nSCORE: "+ecoScore.ToString()+"\n";

		advise += "\nEVALUATION OF POPULATION SECURITY :\n";

		if (highp) {
			score += 10;
			pScore += 10;
			interimAdvise = "You have rightly placed the levee at a high population area, this levee would very efficient. Since more number of lives can be protected the levee now";
		}else if (mediump) {
			score += 5;
			pScore += 10;

			interimAdvise = "You have placed the levee at a medium population area, this levee would be partly efficient. A levee would be better placed at an area with high population, since more number of lives can be protected the levee then";
		}else if (lowp) {
			interimAdvise = "You have placed the levee at a low population area, this levee would be inefficient. A levee would be better placed at an area with high population, since more number of lives can be protected the levee then";
		}
		advise += interimAdvise;
		advise += "\nSCORE: "+pScore.ToString()+"\n";
        GameObject[] BestLevees = GameObject.FindGameObjectsWithTag("BestLevee");
        foreach (GameObject BestLevee in BestLevees)
        {
            scoringScript ss = new scoringScript();
            resultClass result = ss.findScore(gameObject, BestLevee);
            if (result.getFinalDistance() < res.getFinalDistance())
            {
                res = result;
            }
        }
		if (res.getHillFlag() == "uphill") {
			advise += "\nNote: You could place this levee more up the river\n";
		} else {
			advise += "\nNote: You could place this levee more down the river\n";
		}
		advise += "\nTOTAL SCORE: "+score.ToString()+"\n";
		
		print (advise);
        System.IO.File.WriteAllText(@"C:\Users\Public\Documents\Unity Projects\Water\runnables\assistiveDisplay\data\" + name + ".txt",advise);

	}
}
