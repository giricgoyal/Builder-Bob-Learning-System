/**
 * 
 */
package utilities;

import processing.core.PFont;
import processing.core.PImage;

/**
 * @author giric
 *
 */
public class Util {
	
	public static int frameRate = 60;
	public static int screenW = 1280;
	public static int screenH = 750;
	
	public static PFont font;
	public static int font_regular = 14;
	public static int font_small = 12;
	
	public static String path_font = "Helvetica-Bold-100.vlw";
	public static String path_economy = "economy.png";
	public static String path_population = "population.png";
	public static String path_highpop = "HighPop.png";
	public static String path_higheco = "HighEco.png";
	public static String path_mediumpop = "MediumPop.png";
	public static String path_mediumeco = "MediumEco.png";
	public static String path_lowpop = "LowPop.png";
	public static String path_loweco = "LowEco.png";
	public static String path_leeve = "Levees.png";
	public static String path_sandbag = "Sandbag.png";
	public static String path_dam = "Dam.png";
	public static String path_dam1Result = "Dam1.txt";
	public static String path_dam2Result = "Dam2.txt";
	public static String path_levee1Result = "Levee1.txt";
	public static String path_levee2Result = "Levee2.txt";
	public static String path_levee3Result = "Levee3.txt";
	public static String path_sandbag1Result = "Sandbag1.txt";
	public static String path_sandbag2Result = "Sandbag2.txt";
	public static String path_sandbag3Result = "Sandbag3.txt";
	public static String path_sandbag4Result = "Sandbag4.txt";
	
	
	public static PImage img_economy;
	public static PImage img_population;
	public static PImage img_loweco;
	public static PImage img_lowpop;
	public static PImage img_mediumeco;
	public static PImage img_mediumpop;
	public static PImage img_higheco;
	public static PImage img_highpop;
	public static PImage img_leeve;
	public static PImage img_sandbag;
	public static PImage img_dam;
	
	public static int NONE = 0;
	public static int ECONOMY = 1;
	public static int POPULATION = 2;
	public static int DAMS = 3;
	public static int LEEVE = 4;
	public static int SANDBAGS = 5;
	public static int RESULT = 6;
	public static int EMAIL = 7;
	
	public static int color_background = 0xee000000;
	public static int color_darkgray = 0xff333333;
	public static int color_button1 = 0xeedd3333;
	public static int color_button1light = 0xeea03333;
	public static int color_button2 = 0xee3333dd;
	public static int color_button2light = 0xee3333a3;
	public static int color_white = 0xeeffffff;
	public static int color_button1selected = 0xeeffffff;
	public static int color_black = 0xee000000;

}
