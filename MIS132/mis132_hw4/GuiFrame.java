package mis132_hw4;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.*;
import javax.swing.event.AncestorListener;

public class GuiFrame extends JFrame {
	//!!!!!!hw4 add ons!!!!!!!!!!!
	Control controller;
	String[]displayInfo=new String[10];
	private JTextArea updateTextP3;
	private JTextArea updateTextP4;
	private JTextField searchBox;
	private JButton search;
	private JTextArea searchLabel;
	private JButton display;
	private JButton update;
	//!!!!!!!!
	int pageNumber = 1;
	ArrayList person = new ArrayList<>();
	private JButton next;
	private JButton back;
	private JButton cancel;
	private JButton finish;
	private JPanel buttons;
	private JPanel mainPanel;
	private JPanel info;
	private JTextArea infoText;
	private JTextField name;
	private JTextField lastName;
	private JLabel labelName;
	private JLabel labelLName;
	private JLabel labelGender;
	private JRadioButton male;
	private JRadioButton female;
	private ButtonGroup gender;
	private JLabel labelMarried;
	private JCheckBox married;
	private JLabel labelMilitary;
	private JCheckBox military;
	private JLabel labelDepartments;
	private JList department;
	private String[] departments = { "", "Human Resource", "IT","Sales Management", "Logistic" };
	private JLabel labelType;
	private JPanel[] typePanel;
	private JLabel contractDuration;
	private JTextField cDText;
	private JLabel wage;
	private JTextField wText;
	private JLabel weeklyWorkingHours;
	private JTextField wHText;
	private JComboBox type;
	private String[] types = { "", "Regular", "Contracted" };
	private JLabel labelLanguage;
	private JList language;
	private String[] languages = { "English", "French", "German", "Russian","Italian", "Arabic" };
	private JLabel labelSkill;
	private JLabel labelOtherSkill;
	private JList skill;
	private String[] skills = { "Java", "C#", "CSS", "HTML", "Javascript","Photoshop", "MS Office" };
	private JTextField textSkill;
	private JTextArea finishText;

	GuiFrame(Control a) {
		super("Welcome Page");
		BorderLayout layout=new BorderLayout(10, 10);
		layout.setHgap(25);
		this.setLayout(layout);
		
		Controller ctrl = new Controller();
		Controller2 ctrl2 = new Controller2();
		
		//!!!!!!!!hw4 add ons
	
		this.controller=a;
		updateTextP3=new JTextArea();
		updateTextP4=new JTextArea();
		updateTextP3.setEditable(false);
		updateTextP4.setEditable(false);
		searchBox=new JTextField(15);
		search=new JButton("Search");
		searchLabel=new JTextArea();
		display=new JButton("Display");
		update=new JButton("Update");
		display.addActionListener(ctrl);
		update.addActionListener(ctrl);
		search.addActionListener(ctrl);
		//!!!!!!!!
		

		// buttons
		next = new JButton("Next");
		back = new JButton("Back");
		cancel = new JButton("Cancel");
		finish = new JButton("Finish");
		JPanel buttons = new JPanel();
		buttons.add(cancel);
		buttons.add(back);
		buttons.add(next);
		buttons.add(finish);
		next.addActionListener(ctrl);
		back.addActionListener(ctrl);
		finish.addActionListener(ctrl);
		cancel.addActionListener(ctrl);

		// main Panel
		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new FlowLayout(50));
		labelName = new JLabel("Name:");
		name = new JTextField(15);
		labelLName = new JLabel("Last Name:");
		lastName = new JTextField(15);

		labelGender = new JLabel("Gender:");
		male = new JRadioButton("Male", false);
		female = new JRadioButton("Female", false);
		gender = new ButtonGroup();
		gender.add(male);
		gender.add(female);
		male.addActionListener(ctrl2);
		female.addActionListener(ctrl2);

		labelMarried = new JLabel("Marital Status:");
		married = new JCheckBox("Married", false);
		labelMilitary = new JLabel("Military Status:");
		military = new JCheckBox("Completed", false);

		labelDepartments = new JLabel("Department:");
		department = new JList(departments);
		department.setSelectionMode(0);

		labelType = new JLabel("Types:");
		type = new JComboBox(types);
		typePanel = new JPanel[2];
		for (int i = 0; i < typePanel.length; i++) {// create arry of panels
			typePanel[i] = new JPanel();
			typePanel[i].setLayout(new FlowLayout(50));
			add(typePanel[i]);
			typePanel[i].setVisible(false);
		}
		contractDuration = new JLabel("Contract Duration: ");
		cDText = new JTextField(15);
		wage = new JLabel("Wage: ");
		wText = new JTextField(15);
		weeklyWorkingHours = new JLabel("Weekly Working Hours: ");
		wHText = new JTextField(15);
		typePanel[0].add(weeklyWorkingHours);
		typePanel[0].add(wHText);
		typePanel[1].add(contractDuration);
		typePanel[1].add(cDText);
		typePanel[1].add(wage);
		typePanel[1].add(wText);

		type.addActionListener(ctrl2);

		labelLanguage = new JLabel("Languages:");
		language = new JList(languages);
		language.setSelectionMode(ListSelectionModel.MULTIPLE_INTERVAL_SELECTION);
		labelSkill = new JLabel("Skills:");
		skill = new JList(skills);
		textSkill = new JTextField(15);
		labelOtherSkill = new JLabel("Other Skill:");

		finishText = new JTextArea(200, 200);
		
		mainPanel.add(updateTextP3);
		mainPanel.add(updateTextP4);
		mainPanel.add(searchBox);
		mainPanel.add(search);
		mainPanel.add(searchLabel);
		mainPanel.add(display);
		mainPanel.add(update);
		mainPanel.add(labelName);
		mainPanel.add(name);
		mainPanel.add(labelLName);
		mainPanel.add(lastName);
		mainPanel.add(labelGender);
		mainPanel.add(male);
		mainPanel.add(female);
		mainPanel.add(labelMarried);
		mainPanel.add(married);
		mainPanel.add(labelMilitary);
		mainPanel.add(military);
		mainPanel.add(labelDepartments);
		mainPanel.add(department);
		mainPanel.add(labelType);
		mainPanel.add(type);
		mainPanel.add(typePanel[0]);
		mainPanel.add(typePanel[1]);
		mainPanel.add(labelLanguage);
		mainPanel.add(language);
		mainPanel.add(labelSkill);
		mainPanel.add(skill);
		mainPanel.add(labelOtherSkill);
		mainPanel.add(textSkill);
		mainPanel.add(finishText);

		// info Panel
		JPanel info = new JPanel();
		infoText = new JTextArea(" Welcome to Employee Information GUI ", 0,
				100);
		infoText.setEditable(false);
		info.add(infoText);
		
		this.add(info, BorderLayout.NORTH);
		this.add(mainPanel, BorderLayout.CENTER);
		this.add(buttons, BorderLayout.SOUTH);
		
		
		back.setVisible(false);
		labelName.setVisible(false);
		name.setVisible(false);
		labelLName.setVisible(false);
		lastName.setVisible(false);
		labelGender.setVisible(false);
		male.setVisible(false);
		female.setVisible(false);
		labelMarried.setVisible(false);
		married.setVisible(false);
		labelMilitary.setVisible(false);
		military.setVisible(false);
		labelDepartments.setVisible(false);
		department.setVisible(false);
		labelType.setVisible(false);
		type.setVisible(false);
		labelLanguage.setVisible(false);
		language.setVisible(false);
		labelSkill.setVisible(false);
		skill.setVisible(false);
		labelOtherSkill.setVisible(false);
		textSkill.setVisible(false);
		finishText.setVisible(false);
		updateTextP3.setVisible(false);
		updateTextP4.setVisible(false);
		display.setVisible(false);
		update.setVisible(false);
		searchLabel.setVisible(false);
	}

	private class Controller implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			JButton temp = (JButton) e.getSource();
			try {
				if (temp == next) {
					pageNumber++;

				} else if (temp == back) {
					pageNumber--;

				} else if (temp == cancel) {
					pageNumber = 1;
					searchLabel.setVisible(false);
					searchLabel.setText("");
					searchBox.setText("");
					display.setVisible(false);
					update.setVisible(false);
					name.setText("");
					lastName.setText("");
					gender.clearSelection();
					military.setSelected(false);
					married.setSelected(false);
					person.clear();
					department.clearSelection();
					type.setSelectedItem(null);
					language.clearSelection();
					skill.clearSelection();
					textSkill.setText("");
					cDText.setText("");
					wText.setText("");
					wHText.setText("");
					displayInfo=new String[10];
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(false);
				} else if (temp == finish) {
					pageNumber = 5;
					updateRecord(searchBox.getText());
					record();
				} else if(temp == display ){
					setInfo();
					pageNumber=5;
				} else if(temp== update){
					setInfo();
					updateTextP3.setText("Before update department:"+displayInfo[6]+"\nType: "+displayInfo[7]);
					updateTextP4.setText("Before update languages:"+displayInfo[8]+"\nSkills: "+displayInfo[9]);
					updateTextP3.setVisible(true);
					updateTextP4.setVisible(true);
					pageNumber=2;
				} else if(temp== search){
					search(searchBox.getText());
				}
				switch (pageNumber) {
				case 1:
					setTitle("Welcome Page");
					searchBox.setVisible(true);
					search.setVisible(true);
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(false);
					next.setVisible(true);
					infoText.setText(" Welcome to Employee Information GUI ");
					infoText.setVisible(true);
					back.setVisible(false);
					labelName.setVisible(false);
					name.setVisible(false);
					labelLName.setVisible(false);
					lastName.setVisible(false);
					labelGender.setVisible(false);
					male.setVisible(false);
					female.setVisible(false);
					labelMarried.setVisible(false);
					married.setVisible(false);
					labelMilitary.setVisible(false);
					military.setVisible(false);
					labelDepartments.setVisible(false);
					department.setVisible(false);
					labelType.setVisible(false);
					type.setVisible(false);
					labelLanguage.setVisible(false);
					language.setVisible(false);
					labelSkill.setVisible(false);
					labelOtherSkill.setVisible(false);
					skill.setVisible(false);
					textSkill.setVisible(false);
					finishText.setVisible(false);
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(false);
					break;
				case 2:
					setTitle("Second Page");
					infoText.setText(" Please type employee's name, surname and select employee's gender ,marital status and military status ");
					searchLabel.setVisible(false);
					searchBox.setVisible(false);
					search.setVisible(false);
					update.setVisible(false);
					display.setVisible(false);
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(false);
					back.setVisible(true);
					labelName.setVisible(true);
					name.setVisible(true);
					labelLName.setVisible(true);
					lastName.setVisible(true);
					labelGender.setVisible(true);
					male.setVisible(true);
					female.setVisible(true);
					labelMarried.setVisible(true);
					married.setVisible(true);
					labelDepartments.setVisible(false);
					department.setVisible(false);
					labelType.setVisible(false);
					type.setVisible(false);
					labelLanguage.setVisible(false);
					language.setVisible(false);
					labelSkill.setVisible(false);
					labelOtherSkill.setVisible(false);
					skill.setVisible(false);
					textSkill.setVisible(false);
					finishText.setVisible(false);
					typePanel[0].setVisible(false);
					typePanel[1].setVisible(false);
					break;

				case 3:
					setTitle("Third Page");
					infoText.setText(" Please select employee's department and type ");
					labelName.setVisible(false);
					name.setVisible(false);
					labelLName.setVisible(false);
					lastName.setVisible(false);
					labelGender.setVisible(false);
					male.setVisible(false);
					female.setVisible(false);
					labelMarried.setVisible(false);
					married.setVisible(false);
					labelMilitary.setVisible(false);
					military.setVisible(false);
					labelDepartments.setVisible(true);
					department.setVisible(true);
					labelType.setVisible(true);
					type.setVisible(true);
					labelLanguage.setVisible(false);
					language.setVisible(false);
					labelSkill.setVisible(false);
					labelOtherSkill.setVisible(false);
					skill.setVisible(false);
					textSkill.setVisible(false);
					updateTextP3.setVisible(true);
					updateTextP4.setVisible(false);
					break;
				case 4:
					setTitle("Forth Page");
					infoText.setText(" Please select employee's languages and skills ");
					labelName.setVisible(false);
					name.setVisible(false);
					labelLName.setVisible(false);
					lastName.setVisible(false);
					labelGender.setVisible(false);
					male.setVisible(false);
					female.setVisible(false);
					labelMarried.setVisible(false);
					married.setVisible(false);
					labelMilitary.setVisible(false);
					military.setVisible(false);
					labelDepartments.setVisible(false);
					department.setVisible(false);
					labelType.setVisible(false);
					type.setVisible(false);
					labelLanguage.setVisible(true);
					language.setVisible(true);
					labelSkill.setVisible(true);
					skill.setVisible(true);
					labelOtherSkill.setVisible(true);
					textSkill.setVisible(true);
					next.setVisible(true);
					finishText.setVisible(false);
					typePanel[0].setVisible(false);
					typePanel[1].setVisible(false);
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(true);
					break;
				case 5:
					setTitle("Fifth Page");
					updateTextP3.setVisible(false);
					updateTextP4.setVisible(false);
					searchLabel.setVisible(false);
					back.setVisible(true);
					infoText.setText("Employee Information\n !!!!!CAUTION:    If you haven't press finish button yet, please press finish button to record or update the employee\n"
							+ "\tIf you in display mode, do nothing");
					
				
					
					finishText.setText("\nName: " 
							+ displayInfo[1]+ "\nLast Name: " 
							+ displayInfo[2] + "\nGender: "
							+ displayInfo[3] + "\nMarital Status: "
							+ displayInfo[4] + "\nMilitary Status: "
							+ displayInfo[5] + "\nDepartment: "
							+ displayInfo[6] + "\nType: "
							+ displayInfo[7] + "\nLanguages: "
							+ displayInfo[8]+ "\nSkills: "
							+ displayInfo[9]
							+ textSkill.getText() + "\n");
					
					labelName.setVisible(false);
					name.setVisible(false);
					labelLName.setVisible(false);
					lastName.setVisible(false);
					labelGender.setVisible(false);
					male.setVisible(false);
					female.setVisible(false);
					labelMarried.setVisible(false);
					married.setVisible(false);
					labelMilitary.setVisible(false);
					military.setVisible(false);
					labelDepartments.setVisible(false);
					department.setVisible(false);
					labelType.setVisible(false);
					type.setVisible(false);
					labelLanguage.setVisible(false);
					language.setVisible(false);
					labelSkill.setVisible(false);
					skill.setVisible(false);
					next.setVisible(false);
					labelOtherSkill.setVisible(false);
					textSkill.setVisible(false);
					finishText.setVisible(true);
					break;

				}
			} catch (Exception error) {
				error.printStackTrace();
			}
		}

		private String printList(java.util.List<String> a) {
			String s = "";
			if (a.size() == 0)
				s = "None";
			for (int i = 0; i < a.size(); i++)
				if (i == a.size() - 1)
					s += a.get(i);
				else
					s += a.get(i) + ", ";
			return s;
		}
		private void setInfo() throws Exception{
			displayInfo=dbConnection.display(searchBox.getText());
			name.setText(displayInfo[1]);
			lastName.setText(displayInfo[2]);
			if(displayInfo[3].equals("Male"))
				male.setSelected(true);
			else
				female.setSelected(true);
			if(displayInfo[4].equals("Married"))
				married.setSelected(true);
			if(displayInfo[5].equals("Completed"))
				military.setSelected(true);
		}
		private void record() throws Exception{
			displayInfo[1]=name.getText();
			displayInfo[2]=lastName.getText();
			if (male.isSelected()) {
				displayInfo[3]="Male";
			} else {
				if (female.isSelected())
					displayInfo[3]="Female";
				else
					displayInfo[3]="Don't have information";
			}
			if (married.isSelected()) {
				displayInfo[4]="Married";
			} else {
				displayInfo[4]="Unmarried";
			}
			if (male.isSelected()) {
				if (military.isSelected())
					displayInfo[5]="Completed";
				else
					displayInfo[5]="Not completed";
			} else {
				if (female.isSelected())
					displayInfo[5]="None";
				else
					displayInfo[5]="Don't have information";
			}
			displayInfo[6]=(String) department.getSelectedValue();
			displayInfo[8]=printList(language.getSelectedValuesList());
			displayInfo[9]=printList(skill.getSelectedValuesList()) + ", "+ textSkill.getText();
			
			dbConnection.record(displayInfo);
		}
		private void updateRecord(String s) throws Exception{
			displayInfo[1]=name.getText();
			displayInfo[2]=lastName.getText();
			if (male.isSelected()) {
				displayInfo[3]="Male";
			} else {
				if (female.isSelected())
					displayInfo[3]="Female";
				else
					displayInfo[3]="Don't have information";
			}
			if (married.isSelected()) {
				displayInfo[4]="Married";
			} else {
				displayInfo[4]="Unmarried";
			}
			if (male.isSelected()) {
				if (military.isSelected())
					displayInfo[5]="Completed";
				else
					displayInfo[5]="Not completed";
			} else {
				if (female.isSelected())
					displayInfo[5]="None";
				else
					displayInfo[5]="Don't have information";
			}
			displayInfo[6]=(String) department.getSelectedValue();
			displayInfo[8]=printList(language.getSelectedValuesList());
			displayInfo[9]=printList(skill.getSelectedValuesList()) + ", "+ textSkill.getText();
			dbConnection.update(displayInfo,searchBox.getText());
		}
		private void search(String s) throws Exception{
			Boolean a=dbConnection.search(s);
			
			if(a=false){
				
				searchLabel.setText("Employee is not found, for new record please press next");
				searchLabel.setVisible(true);
				display.setVisible(false);
				update.setVisible(false);
			}
			else if(a=true){
				searchLabel.setText("Emloyee is exist, please select your action");
				searchLabel.setVisible(true);
				display.setVisible(true);
				update.setVisible(true);
			}
		}

	}

	private class Controller2 implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			if (male.isSelected()) {
				labelMilitary.setVisible(true);
				military.setVisible(true);
			} else {
				labelMilitary.setVisible(false);
				military.setVisible(false);
			}
			int a = type.getSelectedIndex();
			switch (a) {
			case 1:
				typePanel[0].setVisible(true);
				typePanel[1].setVisible(false);
				labelMilitary.setVisible(false);
				military.setVisible(false);
				break;
			case 2:
				typePanel[1].setVisible(true);
				typePanel[0].setVisible(false);
				labelMilitary.setVisible(false);
				military.setVisible(false);
				break;
			}
		}

	}

	
}
 