package mis132_hw4;

import java.util.ArrayList;

import javax.swing.JFrame;

public class Control {
	GuiFrame frame;
	String[] displayInfo=new String[10]; 
	public Control() {
		
		GuiFrame frame = new GuiFrame(this);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setSize(1200, 500);
		frame.setVisible(true);
	}
	
}
