/**
 * 
 */
package main;

import processing.core.PApplet;
import processing.core.PConstants;
import utilities.Util;

/**
 * @author giric
 *
 */
public class Buttons extends BasicControl {
	
	private boolean selected;
	private boolean showClicked;
	private boolean addStroke;
	private String name;
	private boolean elps;
	private int color;
	private int borderColor;
	private int selectedColor;
	
	public Buttons(PApplet parent, float x, float y, float width, float height) {
		super(parent, x, y, width, height);
		// TODO Auto-generated constructor stub
		
		elps=false;
		selected = false;
		addStroke = false;
		showClicked = false;
		name = "";
		color = 0;
		borderColor = Util.color_darkgray;
	}

	@Override
	public void draw() {
		// TODO Auto-generated method stub
		
		parent.pushStyle();
		if(showClicked) parent.fill(selected?selectedColor:color);
		else parent.fill(color);
		if(addStroke) {
			parent.stroke(borderColor);
			parent.strokeWeight(2);
		}
		else {
			parent.noStroke();
		}
		parent.rectMode(PConstants.CORNER);
		parent.ellipseMode(PConstants.CENTER);
		if(elps) parent.ellipse(myX, myY, myWidth, myHeight);
		else 
			parent.rect(myX, myY, myWidth, myHeight, 5);
		parent.textAlign(PConstants.CENTER,PConstants.CENTER);
		parent.fill(selected?color:Util.color_white);
		parent.textFont(Util.font);
		if(elps) {
			parent.textSize(Util.font_regular);
			parent.text(name, myX, myY);
		}
		else { 
			parent.textAlign(PConstants.CENTER, PConstants.CENTER);
			parent.textSize(Util.font_regular);
			parent.text(name, (myWidth)/2+myX, (myHeight)/2+myY);
		}
		parent.popStyle();
		
	}
	
	public boolean isClicked(float posX, float posY) {
		return ((posX >= myX && posX <= myX + myWidth) && (posY >= myY && posY <= myY + myHeight)) ? true : false;
	}
	
	public void setXY(float x, float y) {
		myX = x;
		myY = y;
	}
	
	public void setHW(float h, float w) {
		myHeight = h;
		myWidth = w;
	}
	
	public boolean isSelected(){
		return selected;
	}
	
	public void setElps(boolean val){
		this.elps = val;
	}

	public boolean checkIn(float posX,float posY){
		if (elps){
			float radius = myWidth/2;
			//System.out.println(posX + "," + posY + " : " + myX + "," + myY);
			float tempDist = PApplet.dist(posX, posY, myX, myY);
			//System.out.println(radius);
			//System.out.println(tempDist);
			return tempDist<=radius ? true : false;
		}
		return (myX<posX && posX<myX+myWidth && myY<posY && posY<myY+myHeight) ? true: false;
	}
	
	public void setSelected(boolean selected){
		this.selected = selected;
	}
	
	public void setName(String name){
		this.name=name;
	}
	
	public String getName() {
		return this.name;
	}
	
	public void setShowClick(){
		this.showClicked=true;
	}
	
	public void setColor(int color, int borderColor, int selectedColor) {
		this.color = color;
		this.borderColor = borderColor;
		this.selectedColor = selectedColor;
	}
	
	
	public void setButton(int color, int borderColor, int selectedColor, boolean elps, boolean stroke, String name) {
		setColor(color, borderColor, selectedColor);
		setElps(elps);
		setStroke(stroke);
		setName(name);
	}
	
	public void setStroke(boolean val){
		this.addStroke = val;
	}
	
}
