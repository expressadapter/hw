package mis132_hw4;

import java.sql.*;

public class dbConnection {
	private static Connection conn;
	private static Statement stmt;
	private static String[] array1 = new String[10];

	public static String[] display(String s) throws Exception {
		try {
			conn = DriverManager.getConnection("jdbc:odbc:GuiDB");
			stmt = conn.createStatement();
			ResultSet result = stmt.executeQuery("select name, lastname,gender,marital,military,department,type,language,skill from Employee where ID like '"
							+ s + "'");
			while (result.next()) {
				for (int i = 1; i < 10; i++)
					array1[i] = result.getString(i);
			}
		} catch (Exception e) {
			System.out.println(e);
		}
		return array1;
	}

	public static void record(String[] s) throws Exception {
		try {
			conn = DriverManager.getConnection("jdbc:odbc:GuiDB");
			stmt = conn.createStatement();
			stmt.executeUpdate("insert into employee (name,lastName,gender,marital,military,department,type,language,skill) values('"+s[1]+"','"+s[2]+"','"+s[3]+"','"+s[4]+"','"+s[5]+"','"+s[6]+"','"+s[7]+"','"+s[8]+"','"+s[9]+"')");
		} catch (Exception e) {
			System.out.println(e);
		}
	}
	public static boolean search(String s) throws Exception {
			String a="";
			conn = DriverManager.getConnection("jdbc:odbc:GuiDB");
			stmt = conn.createStatement();
			ResultSet result = stmt.executeQuery("select * from Employee where ID like '"
					+ s + "'");
			while (result.next()) {
				a=result.getString(1);
					
			}
			if(a.equals(null)){
				
				return true;}
			else 
				return false;	
		
	}
	public static void update(String[] s,String n) throws Exception {
		try {
			conn = DriverManager.getConnection("jdbc:odbc:GuiDB");
			stmt = conn.createStatement();
			stmt.executeUpdate("insert into employee (name,lastName,gender,marital,military,department,type,language,skill) values('"+s[1]+"','"+s[2]+"','"+s[3]+"','"+s[4]+"','"+s[5]+"','"+s[6]+"','"+s[7]+"','"+s[8]+"','"+s[9]+"') where ID like '"
					+ n + "'");
		} catch (Exception e) {
			System.out.println(e);
		}
	}
	
}
