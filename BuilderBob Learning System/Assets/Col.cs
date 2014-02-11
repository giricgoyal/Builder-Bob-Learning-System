using UnityEngine;
using System.Collections;

public class Col : MonoBehaviour {
	public bool a = false;
	public bool coll = false;
    public int nb = 0;
    public bool overlook = false;
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
		if (collision.transform.tag == "Player") { 
			coll = true;
		}
        if (collision.transform.tag == "Delta")
        {
            overlook = true;
        }
        if (collision.transform.tag == "Narrow")
        {
            nb = 1;
        }
        if (collision.transform.tag == "Wide")
        {
            nb = 2;
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
		if(nb != 0 || 1== 1){
		    advise += "EVALUATION OF TOPOLOGICAL MEASURES :\n";
		    string interimAdvise = "";
		    if (highel) {
			    score += 10;
			    elScore += 10;
			    interimAdvise = "Dam is rightly placed between areas of high elevation.";
			    //interimAdvise = highel.ToString()+" high elevation";

 		    }
		    if (mediumel) {
			    if(highel){
				    score -= 3;
				    elScore -= 3;
                    interimAdvise = "Dam placed between areas of medium and high elevation making it effective but not optimal. Suggest dam relocation to area with higher elevation";
				    //interimAdvise = "Dam placed between areas of medium and high elevation, This dam is semi-effective since it doesnt have enough height to be able to control the flow of the water. It could cause flooding if not handled properly. A dam must be placed at a high elevation area in order for it to be effective since the natural elevation on the sides gives better control over flow of water in order to protect the lower lying areas better.";
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation";
			    }else{
				    score += 5;
				    elScore += 5;
                    interimAdvise = "Dam placed between areas of medium elevation making it less effective and more expensive compared to placement between areas of higher elevation.Suggest dam relocation to area with higher elevation";
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation";
			    }
		    }
		    if (lowel) {
			    if(highel && mediumel ){
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation"+lowel.ToString()+" low elevation";
                    interimAdvise = "Dam placed between areas of low medium and high elevations making partially effective and more expensive compared to other alternatives. Suggest relocation to area with higher elevation";
                    score -= 1;
                    elScore -= 1;
			    }else if(highel && !mediumel){
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation"+lowel.ToString()+" low elevation";
                    interimAdvise = "Dam placed between high and low elevation areas making it partially effective and more expensive compared to other alternatives. Suggest relocation to area with higher elevation";
                    score -= 5;
                    elScore -= 5;

			    }else if(!highel && mediumel){
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation"+lowel.ToString()+" low elevation";
                    interimAdvise = "Dam placed between areas of medium and low elevations making it barely effective and considerably expensive compared to better alternatives. Suggest relocation to area with higher elevation";
                    score -= 1;
                    elScore -= 1;
			    }else{
				    score += 0;
				    elScore += 0;
				    //interimAdvise = highel.ToString()+"high elevation" +mediumel.ToString()+" medium elevation"+lowel.ToString()+" low elevation";
                    interimAdvise = "Dam placed between low elevation areas making it least effective and most expensive compared to the alternatives.";
				    //advise += "You have placed the dam at a low elevation area, This dam is ineffective since it doesnt have any height to be able to control the flow of the water. It would cause flooding rather than preventing it. A dam must be placed at a high elevation area in order for it to be effective since the natural elevation on the sides gives better control over flow of water in order to protect the lower lying areas better.";
			    }
		    }
		    if (nb == 1) {
			    interimAdvise += "\n The " + name +" is placed at a narrow area which is the best place for a dam since the dam construction expenditure is reduced";
		    } else if(nb == 2) {
                interimAdvise += "\n The " + name + " is placed at a broad area. This is not adviseable since the dam construction expenditure is increased ";
		    }
		    advise += interimAdvise;
		    advise += "\nSCORE: "+elScore.ToString()+"\n";
		    advise += "\nEVALUATION OF ECONOMIC SECURITY :\n";
		    string interimEcoAdvise = "";
		    if (lowec) {
                interimEcoAdvise = "Dam rightly placed between areas of low economy reducing dam construction expenses.";
			    //interimEcoAdvise = "You have rightly placed the dam on a low economy area, this would let the dam be built easily without relocating the economic structures";
                score += 10;
                ecoScore += 10;
		    }
		    if (mediumec) {
			    if(lowec){
				    score -= 3;
				    ecoScore -= 3;
				    //interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy";
                    interimEcoAdvise = "Dam placed between areas of low to medium economy. Would require displacement and relocation of few economic structures, increasing overall expenses. Suggest dam relocation to areas of low economy";
				    //advise += "The dam is placed in a medium economy area. This would require displacement and relocation of a few economic structures for its construction. Suggest relocation of dam to an area of low economy ";
			    }else{
				    score += 5;
				    ecoScore += 5;
				    //interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy";
                    interimEcoAdvise = "Dam placed between areas of medium economy. Would require displacement and relocation of few economic structures, increasing overall expenses. Suggest dam relocation to areas of low economy";
                    //advise += "The dam is placed in a medium economy area. This would require displacement and relocation of a few economic structures for its construction. Suggest relocation of dam to an area of low economy ";
			    }
		    }
		    if (highec) {
			    if(lowec && mediumec){
				    interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy" + highec.ToString() + "High Economy";
                    score -= 1;
                    ecoScore -= 1;
                    interimEcoAdvise = "Dam placed between areas of low to high economy. Would require major displacement and relocation of economic structures, increasing overall expenses considerably. Suggest dam relocation to areas of low economy";
                    //advise += "The dam is placed in a high economy area. This would require displacement and relocation of many economic structures for its construction. Suggest relocation of dam to an area of low economy ";
			    } else if (lowec && !mediumec){
				    interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy" + highec.ToString() + "High Economy";
                    score -= 5;
                    ecoScore -= 5;
                    interimEcoAdvise = "Dam placed between areas of low to high economy. Would require major displacement and relocation of economic structures, increasing overall expenses considerably. Suggest dam relocation to areas of low economy "; 
                    //advise += "The dam is placed in a high economy area. This would require displacement and relocation of many economic structures for its construction. Suggest relocation of dam to an area of low economy ";
			    }else if (!lowec && mediumec){
                    score -= 1;
                    ecoScore -= 1;
                    interimEcoAdvise = "Dam placed between areas of medium to high economy.Would require major displacement and relocation of economic structures, increasing overall expenses considerably. Suggest dam relocation to areas of lower economy ";
				    //interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy" + highec.ToString() + "High Economy";

			    }else{
				
				    //interimEcoAdvise = lowec.ToString()+" Low Economy" + mediumec.ToString() + "Medium Economy" + highec.ToString() + "High Economy";
                    interimEcoAdvise = "Dam placed between areas of low economy. Would require drastic displacement and relocation of economic structures, increasing expenses and reducing feasibility. Suggest relocation of dam to areas of lower economy";
				    //advise += "The dam is placed in a high economy area. This would require displacement and relocation of many economic structures for its construction. Suggest relocation of dam to an area of low economy ";
			    }
		    }

		    advise += interimEcoAdvise;
		    advise += "\nSCORE: "+ecoScore.ToString()+"\n";
		
		    advise += "\nEVALUATION OF POPULATION SECURITY :\n";
		    interimEcoAdvise = "";
		    if (lowp) {
                interimEcoAdvise = "Dam has been rightly placed between areas of low population";
			    //interimEcoAdvise = "You have rightly placed the dam on a low Population area, this would let the dam be built easily without relocating the populace";
                score += 10;
                pScore += 10;
		    }
		    if (mediump) {
			    if(lowp){
				    score -= 3;
				    pScore -= 3;
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population";
                    interimEcoAdvise = "Dam placed between areas of low to medium population. Would require mild displacement and relocation of populace, increasing overall expenses. Suggest dam relocation to areas of low population";
				    //advise += "The levee is placed in a medium Population area, this levee would partly efficient for economic security. A levee would be better placed at an area with high Population, since the Population then can be protected from the destruction caused by floods";
			    }else{
				    score += 5;
				    pScore += 5;
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population";
                    interimEcoAdvise = "The dam is placed in a medium population area. This would require slight displacement and relocation of populace for its construction. Suggest relocation of dam to an area of low population";
				    //advise += "The levee is placed in a medium Population area, this levee would partly efficient for economic security. A levee would be better placed at an area with high Population, since the Population then can be protected from the destruction caused by floods";
			    }
		    }
		    if (highp) {
			    if(lowp && mediump){
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population" + highp.ToString() + "High Population";
                    interimEcoAdvise = "Dam placed between areas of low to high population. Would require major displacement and populace, increasing overall expenses considerably. Suggest dam relocation to areas of low population";
                    score -= 1;
                    pScore -= 1;
			    }else if (lowp && !mediump){
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population" + highp.ToString() + "High Population";
                    interimEcoAdvise = "Dam placed between areas of low to high population. Would require major displacement and relocation of populace, increasing overall expenses considerably. Suggest dam relocation to areas of low population";
                    score -= 5;
                    pScore -= 5;
			    }else if (!lowp && mediump){
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population" + highp.ToString() + "High Population";
                    interimEcoAdvise = "Dam placed between areas of medium to high population.Would require major displacement and relocation of populace, increasing overall expenses considerably. Suggest dam relocation to areas of lower population";
                    score -= 1;
                    pScore -= 1;
			    }else{
               
				    //interimEcoAdvise = lowp.ToString()+" Low Population" + mediump.ToString() + "Medium Population" + highp.ToString() + "High Population";
                    interimEcoAdvise = "Dam placed between areas of low population. Would require drastic displacement and relocation of populace, increasing expenses and reducing feasibility. Suggest relocation of dam to areas of lower population";
				    //advise += "You have placed the dam at a high Population area, this dam would be inefficient for economic security. Since the dam would cause the economic structures to be relocated";
			    }
		    }
            GameObject[] bestDams = GameObject.FindGameObjectsWithTag("BestDam");
		        foreach (GameObject bestDam in bestDams) {
			    scoringScript ss = new scoringScript();
			    resultClass result = ss.findScore(gameObject,bestDam);
			    if(result.getFinalDistance()<res.getFinalDistance()){
				    res = result;
			}
		    }
		    advise += interimEcoAdvise;
		    advise += "\nSCORE: "+pScore.ToString()+"\n";
		    if (res.getHillFlag() == "uphill") {
			    advise += "\nNote: You could place this dam more up the river\n";
		    } else {
			    advise += "\nNote: You could place this dam more down the river\n";
		    }
        }else{
            advise += "Note: You have not placed the dam on the river\n";
        }
		advise += "\nTOTAL SCORE: "+score.ToString()+"\n";
		


        System.IO.File.WriteAllText(@"C:\Users\Public\Documents\Unity Projects\Water\runnables\assistiveDisplay\data\" + name + ".txt",advise);

	}
}
