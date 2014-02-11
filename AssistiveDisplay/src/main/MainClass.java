/**
 * 
 */
package main;

import java.util.ArrayList;
import java.util.Properties;

import processing.core.*;
import processing.net.*;
import processing.core.PApplet;
import utilities.Util;

import javax.mail.*;
import javax.mail.internet.*;
import javax.activation.*;
import javax.mail.util.*;

import java.io.*;

/**
 * @author giric
 *
 */
public class MainClass extends PApplet {
	
	private Buttons button_damInfo;
	private Buttons button_leveeInfo;
	private Buttons button_sandbagInfo;
	private Buttons button_population;
	private Buttons button_economy;
	private Buttons button_showResult;
	private Buttons button_sendMail;
	private Buttons button_send;
	private Buttons button_cancel;
	
	private ArrayList<Buttons> buttons;
	
	private PImage img;
	
	private int selectedImage = 0;
	
	private String completeResult = "Dams:\n";
	private int totalScore = 0;
	private String emailID = "Enter your Email";
	

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println("premain");
		PApplet.main(new String[] { "main.MainClass" });
		System.out.println("postmain");
	}
	
	public void setupGUI() {
		
		buttons = new ArrayList<Buttons>();
		
		button_damInfo = new Buttons(this, 15, 50, 100, 30);
		button_damInfo.setButton(Util.color_button1, Util.color_button1light, Util.color_button1selected, false, false, "Dam");
		button_damInfo.setShowClick();
		buttons.add(button_damInfo);
		
		button_leveeInfo = new Buttons(this, 15, 85, 100, 30);
		button_leveeInfo.setButton(Util.color_button1, Util.color_button1light, Util.color_button1selected, false, false, "Levee");
		button_leveeInfo.setShowClick();
		buttons.add(button_leveeInfo);
		
		button_sandbagInfo = new Buttons(this, 15, 120, 100, 30);
		button_sandbagInfo.setButton(Util.color_button1, Util.color_button1light, Util.color_button1selected, false, false, "Sandbags");
		button_sandbagInfo.setShowClick();
		buttons.add(button_sandbagInfo);
		
		button_economy = new Buttons(this, 15, 220, 100, 30);
		button_economy.setButton(Util.color_button2, Util.color_button2light, Util.color_button1selected, false, false, "Economy");
		button_economy.setShowClick();
		buttons.add(button_economy);
		
		button_population = new Buttons(this, 15, 255, 100, 30);
		button_population.setButton(Util.color_button2, Util.color_button2light, Util.color_button1selected, false, false, "Population");
		button_population.setShowClick();
		buttons.add(button_population);
		
		button_showResult = new Buttons(this, 15, 615, 100, 30);
		button_showResult.setButton(Util.color_black, Util.color_black, Util.color_white, false, false, "Show Result");
		button_showResult.setShowClick();
		buttons.add(button_showResult);
		
		button_sendMail = new Buttons(this, 15, 650, 100, 30);
		button_sendMail.setButton(Util.color_black, Util.color_black, Util.color_white, false, false, "Email Result");
		button_sendMail.setShowClick();
		buttons.add(button_sendMail);
		
		button_send = new Buttons(this, Util.screenH/2 + 130 - 103, 350, 100,  30);
		button_send.setButton(Util.color_black, Util.color_black, Util.color_white, false, false, "Send");
		button_send.setShowClick();
		buttons.add(button_send);
		
		button_cancel = new Buttons(this, Util.screenH/2 + 133, 350, 100,  30);
		button_cancel.setButton(Util.color_black, Util.color_black, Util.color_white, false, false, "Cancel");
		button_cancel.setShowClick();
		buttons.add(button_cancel);
		
	}

	public void setup() {
		frameRate(Util.frameRate);
		
		Util.screenW = displayWidth - 350;
		Util.screenH = displayHeight;
		
		
		size((int)Util.screenW, (int)Util.screenH);
		background(Util.color_background);

		Util.font = loadFont(sketchPath + "/data/" + Util.path_font);
		
		setupGUI();
		
		Util.img_economy = loadImage(sketchPath + "/data/" + Util.path_economy);
		Util.img_population = loadImage(sketchPath + "/data/" + Util.path_population);
		Util.img_loweco = loadImage(sketchPath + "/data/" + Util.path_loweco);
		Util.img_lowpop = loadImage(sketchPath + "/data/" + Util.path_lowpop);
		Util.img_mediumeco = loadImage(sketchPath + "/data/" + Util.path_mediumeco);
		Util.img_mediumpop = loadImage(sketchPath + "/data/" + Util.path_mediumpop);
		Util.img_higheco = loadImage(sketchPath + "/data/" + Util.path_higheco);
		Util.img_highpop = loadImage(sketchPath + "/data/" + Util.path_highpop);
		Util.img_leeve = loadImage(sketchPath + "/data/" + Util.path_leeve);
		Util.img_sandbag = loadImage(sketchPath + "/data/" + Util.path_sandbag);
		Util.img_dam = loadImage(sketchPath + "/data/" + Util.path_dam);
		
		drawOnce();
	}
	
	public void draw() {
		if (selectedImage == Util.EMAIL) {
			drawOnce();
		}
	}
	
	public void drawOnce() {
		pushStyle();
		noStroke();
		fill(Util.color_darkgray);
		rect(5, 5, 120, Util.screenH-10, 2);
		
		fill(Util.color_white);
		textAlign(PConstants.CENTER, PConstants.TOP);
		textSize(Util.font_regular);
		text("Information", 65, 25);
		
		text("View\nDistribution", 65, 170);
		
		stroke(Util.color_white);
		line(15, 310, 115, 310);
		noStroke();
		
		textSize(Util.font_small);
		text("Version v1.0", 65, Util.screenH - 80);
		
		
		popStyle();

		
		pushStyle();
		fill(Util.color_darkgray);
		rect(130, 5, Util.screenH - 5, Util.screenH - 5);
		popStyle();
		
		if (selectedImage >= Util.ECONOMY && selectedImage <= Util.SANDBAGS) {
			if (selectedImage == Util.ECONOMY) {
				img = Util.img_economy;
			}
			else if (selectedImage == Util.POPULATION) {
				img = Util.img_population;
			}
			else if (selectedImage == Util.LEEVE) {
				img = Util.img_leeve;
			}
			else if (selectedImage == Util.SANDBAGS) {
				img = Util.img_sandbag;
			}
			else if (selectedImage == Util.DAMS) {
				img = Util.img_dam;
			}
			image(img, 140, 15, Util.screenH - 25, Util.screenH - 70);
			drawLegend();
		}
		else if (selectedImage == Util.RESULT) {
			showResult();
		}
		else if (selectedImage == Util.EMAIL) {
			showEmail();
		}
		
		
		for (Buttons b: buttons){
			if (b.getName().compareToIgnoreCase("Email Result") == 0) {
				if (selectedImage == Util.RESULT || selectedImage == Util.EMAIL) {
					b.draw();
				}
			}
			else if (b.getName().compareToIgnoreCase("Send") == 0 || b.getName().compareToIgnoreCase("Cancel") == 0) {
				if (selectedImage == Util.EMAIL) {
					b.draw();
				}
			}
			else {
				b.draw();
			}
		}
		
	}
	
	public void sendMail() {
		// Recipient's email ID needs to be mentioned.
		String to = emailID;

		// Sender's email ID needs to be mentioned
		String from = "web@gmail.com";
	
		// Assuming you are sending email from localhost
		String host = "localhost";
	
		// Get system properties
		Properties properties = System.getProperties();
	
		// Setup mail server
		properties.setProperty("mail.smtp.host", host);
	
		// Get the default Session object.
		Session session = Session.getDefaultInstance(properties);
	
		try{
			// Create a default MimeMessage object.
			MimeMessage message = new MimeMessage(session);
	
			// Set From: header field of the header.
			message.setFrom(new InternetAddress(from));
	
			// Set To: header field of the header.
			message.addRecipient(Message.RecipientType.TO,
	                          new InternetAddress(to));
	
			// Set Subject: header field
			message.setSubject("This is the Subject Line!");
	
			// Now set the actual message
			message.setText("This is actual message");
	
			// Send message
			Transport.send(message);
			System.out.println("Sent message successfully....");
		}catch (MessagingException mex) {
			mex.printStackTrace();
		}
	}
	
	public void showEmail() {
		pushStyle();
		fill(Util.color_darkgray);
		rect(130, 5, Util.screenH - 5, Util.screenH - 5);
		
		fill(Util.color_white);
		rect(200, 300, 650, 30);
		
		fill(Util.color_black);
		textAlign(PConstants.LEFT, PConstants.CENTER);
		textSize(Util.font_regular);
		text(emailID+(frameCount/10 % 2 == 0 ? "_" : ""), 210, 315);
		popStyle();
	}
	
	public void showResult() {
		pushStyle();
		fill(Util.color_darkgray);
		rect(130, 5, Util.screenH - 5, Util.screenH - 5);
		
		fill(Util.color_white);
		textSize(Util.font_regular+1);
		textAlign(PConstants.CENTER, PConstants.CENTER);
		text("How Did you Perform?", 130 + (Util.screenH - 5)/2, 20);
		stroke(Util.color_white);
		line(440, 35, 610, 35);
		noStroke();
		
		completeResult = "Dams:\n";
		totalScore = 0;
		String path = sketchPath + "/data/";
		
		try {
			String dataText = "";
			BufferedReader file = new BufferedReader(new FileReader(path + Util.path_dam1Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_dam2Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			
			completeResult += "\nLevees:\n";
			
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_levee1Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_levee2Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_levee3Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			
			completeResult += "\nSandbags:\n";
			
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_sandbag1Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_sandbag2Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_sandbag3Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			dataText = "";
			file = new BufferedReader(new FileReader(path + Util.path_sandbag4Result));
			while((dataText = file.readLine()) != null) {
				//int score = Integer.valueOf(dataText.split("\t")[0].trim()).intValue();
				String advice = dataText;
				
				//String advice = dataText.split("\t")[0].trim();
				//completeResult += "(Score: " + String.valueOf(score) +") - ";
				completeResult += advice + "\n";
				//totalScore += score;
			}
			
			//completeResult += "\n\nTotal Score: " + String.valueOf(totalScore);
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		textSize(Util.font_small - 3);
		textAlign(PConstants.LEFT, PConstants.TOP);
		text(completeResult, 150, 70, Util.screenH - 20, Util.screenH - 80);
		popStyle();
		
		
	}
	
	public void drawLegend() {
		pushStyle();
		
		if (selectedImage == Util.ECONOMY) {
			image(Util.img_higheco, 15, 370, 40, 40);
			image(Util.img_mediumeco, 15, 420, 40, 40);
			image(Util.img_loweco, 15, 470, 40, 40);
			fill(Util.color_white);
			textSize(Util.font_regular);
			textAlign(PConstants.CENTER, PConstants.CENTER);
			text("Legend (density)", 65, 350);
			textAlign(PConstants.LEFT, PConstants.CENTER);
			text("High", 60, 390);
			text("Medium", 60, 440);
			text("Low", 60, 490);
		}
		else if (selectedImage == Util.POPULATION) {
			image(Util.img_highpop, 15, 370, 40, 40);
			image(Util.img_mediumpop, 15, 420, 40, 40);
			image(Util.img_lowpop, 15, 470, 40, 40);
			fill(Util.color_white);
			textSize(Util.font_regular);
			textAlign(PConstants.CENTER, PConstants.CENTER);
			text("Legend (density)", 65, 350);
			textAlign(PConstants.LEFT, PConstants.CENTER);
			text("High", 60, 390);
			text("Medium", 60, 440);
			text("Low", 60, 490);
		}
		
		popStyle();
	}
	
	

	public void keyReleased() {
		if (key != CODED) {
			if (emailID.compareToIgnoreCase("Enter your Email") == 0) {
				emailID = "";
			}
			switch(key) {
			    case BACKSPACE:
			      emailID = emailID.substring(0,max(0,emailID.length()-1));
			      break;
			    case TAB:
			    	//emailID += "    ";
			      break;
			    case ENTER:
			    case RETURN:
			      // comment out the following two lines to disable line-breaks
			    	//emailID += "\n";
			      break;
			    case ESC:
			    case DELETE:
			      break;
			    default:
			    	emailID += key;
		    }
		}
	}
	
	
	public void mouseClicked() {
		
	}
	
	public void mousePressed() {
		for (Buttons b: buttons) {
			if (b.isClicked(mouseX, mouseY)) {
				System.out.println(b.getName() + " pressed");
				for (Buttons b2 : buttons) {
					if (b2 != b) {
						b2.setSelected(false);
					}
				}
				b.setSelected(true);
			}
		}
		
		if (button_economy.isClicked(mouseX, mouseY)) {
			selectedImage = Util.ECONOMY;
		}
		else if (button_population.isClicked(mouseX, mouseY)) {
			selectedImage = Util.POPULATION;
		}
		else if (button_leveeInfo.isClicked(mouseX, mouseY)) {
			selectedImage = Util.LEEVE;
		}
		else if(button_sandbagInfo.isClicked(mouseX,  mouseY)) {
			selectedImage = Util.SANDBAGS;
		}
		else if(button_damInfo.isClicked(mouseX, mouseY)) {
			selectedImage = Util.DAMS;
		}
		else if(button_showResult.isClicked(mouseX, mouseY)) {
			selectedImage = Util.RESULT;
		}
		if (selectedImage == Util.RESULT || selectedImage == Util.EMAIL) {
			if (button_sendMail.isClicked(mouseX,  mouseY)) {
				selectedImage = Util.EMAIL;
			}
			else if (button_cancel.isClicked(mouseX,  mouseY)) {
				selectedImage = Util.RESULT;
				button_showResult.setSelected(true);
			}
			else if (button_send.isClicked(mouseX,  mouseY)) {
				sendMail();
				selectedImage = Util.RESULT;
				button_showResult.setSelected(true);
			}
		}
		drawOnce();
	}
	
	public void mouseReleased() {
		
	}
	
	public void mouseDragged() {
		
	}
}
