using UnityEngine;
using System.Collections;
using System;

public class scoringScript : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 public void testScore()
	{
	print ("Scoring script running");
	
		GameObject bestDam1 = GameObject.Find("bestDam1");
		GameObject placedDam1 = GameObject.Find("placedDam1");
		GameObject bestDam2 = GameObject.Find("bestDam2");
		GameObject placedDam2 = GameObject.Find("placedDam2");	
		GameObject placedlevee1 = GameObject.Find("placedLevee1");
		GameObject placedlevee2 = GameObject.Find("placedLevee2");	
		GameObject placedlevee3 = GameObject.Find("placedLevee3");	
		GameObject bestLevee1 = GameObject.Find("bestLevee1");	
		GameObject bestLevee2 = GameObject.Find("bestLevee2");	
		GameObject bestLevee3 = GameObject.Find("bestLevee3");	
		GameObject placedSB1 = GameObject.Find("placedSB1");
		GameObject placedSB2 = GameObject.Find("placedSB2");
		GameObject placedSB3 = GameObject.Find("placedSB3");
		GameObject placedSB4 = GameObject.Find("placedSB4");
		GameObject bestSB1 = GameObject.Find("bestSB1");
		GameObject bestSB2 = GameObject.Find("bestSB2");
		GameObject bestSB3 = GameObject.Find("bestSB3");
		GameObject bestSB4 = GameObject.Find("bestSB4");
		
		
		
		
		findScore(placedDam1, bestDam1);
		
		
		
		
		
	}
	public resultClass findScore(GameObject placed,GameObject best)
	{
       // print(placed.transform.position.x.ToString() + " : " + best.transform.position.x.ToString());
		float totalDistance;
		string side;
	
		if(placed.transform.position.x > best.transform.position.x)
		{
			//right side
	
 totalDistance = findCheckPointsAndDistance(placed.transform.position.x,best.transform.position.x,placed.transform.position.y,best.transform.position.y,placed.transform.position.z,best.transform.position.z);//right,left
			side = "right";
		}
		else
		{
totalDistance = findCheckPointsAndDistance(best.transform.position.x,placed.transform.position.x,best.transform.position.y,placed.transform.position.y,best.transform.position.z,placed.transform.position.z);//right,left
	side = "left";
		}
		resultClass finalResult = new resultClass();
		finalResult.setSide(side);
		finalResult.setFinalDistance(totalDistance);
		if(side.Equals("left"))
		{finalResult.sethillFlag("downhill");}
		else if(side.Equals("right"))
		{finalResult.sethillFlag("uphill");}
		
		
		//print ("final result");
		//print (finalResult.getHillFlag());
		//print(finalResult.getFinalDistance());
		//print(finalResult.getSide());
		return finalResult;
		
		

		
	}
	public float findCheckPointsAndDistance(float right, float left,float rightY,float leftY,float rightZ,float leftZ)
	{	
		Vector3[] cpArray = new Vector3[4]; 
		
		int i = 0;
		float checkPointCount = 0;

		GameObject checkPoint1 = GameObject.Find("checkPoint1");
		GameObject checkPoint2 = GameObject.Find("checkPoint2");
		GameObject checkPoint3 = GameObject.Find("checkPoint3");
		GameObject checkPoint4 = GameObject.Find("checkPoint4");
		float cP1 = checkPoint1.transform.position.x;
		float cP2 = checkPoint2.transform.position.x;
		float cP3 = checkPoint3.transform.position.x;
		float cP4 = checkPoint4.transform.position.x;
		
		
		if((cP1>left)&&(cP1<right))
		{
			checkPointCount++;
			cpArray[i] =new Vector3(checkPoint1.transform.position.x,checkPoint1.transform.position.y,checkPoint1.transform.position.z);
			i++;
		}
		
			if((cP2>left)&&(cP2<right))
		{
			checkPointCount++;
			cpArray[i] = new Vector3(checkPoint2.transform.position.x,checkPoint2.transform.position.y,checkPoint2.transform.position.z);
			i++;
			//Vector3 CP1 = new Vector3(checkPoint1.transform.position.x,checkPoint1.transform.position.y,checkPoint1.transform.position.z);
			//Vector3 CP2 = new Vector3(checkPoint2.transform.position.x,checkPoint2.transform.position.y,checkPoint2.transform.position.z);
			//distance = distance + Vector3.Distance(CP1,CP2);
			
		}
		
			if((cP3>left)&&(cP3<right))
		{
			
			cpArray[i] = new Vector3(checkPoint3.transform.position.x,checkPoint3.transform.position.y,checkPoint3.transform.position.z);
			checkPointCount++;
			i++;

			
		}
			if((cP4>left)&&(cP4<right))
		{
			cpArray[i] = new Vector3(checkPoint4.transform.position.x,checkPoint4.transform.position.y,checkPoint4.transform.position.z);
			i++;
			checkPointCount++;
	
		}
		//print(checkPointCount);

        float totalDistance = 0f;
        float CPdistance = 0f;

        if (checkPointCount != 0)
        {
            CPdistance = findCPDistance(checkPointCount, cpArray);
            totalDistance = Vector3.Distance(new Vector3(left, leftY, leftZ), cpArray[0]) + Vector3.Distance(new Vector3(right, rightY, rightZ), cpArray[i - 1]) + CPdistance;
            //print(cpArray[0].ToString());
            //print(cpArray[i - 1].ToString());
		
        }
        else
        {
            totalDistance = Vector3.Distance(new Vector3(left, leftY, leftZ), new Vector3(right, rightY, rightZ));
        }
		//print(CPdistance);
		//print (totalDistance);
		return totalDistance;
		
		
		
		
		
	}
	public float findCPDistance(float checkPointCount, Vector3[] cpArray)
	{float distance = 0;
		if(checkPointCount == 0)
		{
			 distance = 0; 
		}
		else if(checkPointCount == 1)
		{
			 distance = Vector3.Distance(cpArray[0],cpArray[1]);
		}
		else if(checkPointCount == 2)
		{
			distance = Vector3.Distance(cpArray[0],cpArray[1])+ Vector3.Distance(cpArray[1],cpArray[2]);
		}
		else if(checkPointCount == 3)
		{
		distance = Vector3.Distance(cpArray[0],cpArray[1])+ Vector3.Distance(cpArray[1],cpArray[2]) + Vector3.Distance(cpArray[2],cpArray[3]);
		}
		return distance;
		
		
	}
	
}
