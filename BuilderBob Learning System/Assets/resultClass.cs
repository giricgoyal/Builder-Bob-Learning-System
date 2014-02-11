using UnityEngine;
using System.Collections;

public class resultClass {
	
	public string tangibleSide;
	public string hillFlag;
	public float finalDistance;
public  void setSide(string tangibleSide1)
	{
		tangibleSide = tangibleSide1;
		
	}
	public string getSide()
	{
		return tangibleSide;
		
	}
	
public void sethillFlag(string hillFlag1)
	{
		hillFlag = hillFlag1;
		
	}
	public string getHillFlag()
	{
		return hillFlag;
		
	}
	public  void setFinalDistance(float finalDistance1)
	{
		finalDistance = finalDistance1;
		
	}
	public  float getFinalDistance()
	{
		return finalDistance;
		
	}
		
}

