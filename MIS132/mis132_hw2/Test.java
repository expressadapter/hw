package mis132_hw2;

import java.util.ArrayList;

public class Test {
	public static int time = 0;
	public static double commission = 20;
	public static double pConstant = 0.02;
	static ArrayList<Bank> bList = new ArrayList<Bank>();

	public static void main(String[] args) {

		ArrayList<Customer> BankCustomers = new ArrayList<Customer>();

		Bank GarantiBankasi = new Bank("gb");
		Bank Akbank = new Bank("ab");

		bList.add(GarantiBankasi);
		bList.add(Akbank);

		Customer Ali = new Customer("Ali", "" + (BankCustomers.size() + 1));
		BankCustomers.add(Ali);
		Customer Ayse = new Customer("Ayse", "" + (BankCustomers.size() + 1));
		BankCustomers.add(Ayse);
		Customer Ahmet = new Customer("Ahmet", "" + (BankCustomers.size() + 1));
		BankCustomers.add(Ahmet);

		GarantiBankasi.aList.add(new Time(GarantiBankasi, Ali, 200));
		GarantiBankasi.aList.add(new Saving(GarantiBankasi, Ayse, 100, 3));
		Akbank.aList.add(new Time(Akbank, Ahmet, 500));

		seeBalance("gb-1-1-1");
		seeBalance("gb-2-0-2");
		seeBalance("ab-3-1-1");
		click(10);
		deposit("gb-2-0-2", 60);
		click(5);
		seeBalance("ab-3-1-1");
		seeBalance("gb-2-0-2");
		transfer("gb-2-0-2", "ab-3-1-1", 60);
		withdraw("gb-1-1-1", 20);
		withdraw("ab-3-1-1", 20);
		click(4);
		seeBalance("gb-1-1-1");
		seeBalance("gb-2-0-2");
		seeBalance("ab-3-1-1");
		totalBalance(GarantiBankasi);
		totalBalance(Akbank);
	}

	public static void click() {
		time += 1;
	}

	public static void click(int par) {
		time += par;
	}

	public static void deposit(String id, double amount) {
		findBank(id).findAccount(id).deposit(amount);
	}

	public static void withdraw(String id, double amount) {
		findBank(id).findAccount(id).withdraw(amount);
	}

	public static void transfer(String sender, String receiver, double amount) {
		findBank(sender).findAccount(sender).transfer(amount,
				findBank(receiver).findAccount(receiver));
	}

	public static Bank findBank(String s) {
		for (int i = 0; i < bList.size(); i++)
			if (bList.get(i).getBankCode().equals(s.substring(0, 2)))
				return bList.get(i);
		return null;

	}

	public static void seeBalance(String s) {
		accountOwner(s);
		System.out.println(" Account's Balance: "
				+ findBank(s).findAccount(s).balance() + " Time= " + time);
	}

	public static void totalBalance(Bank a) {
		System.out.println("Bank's Total Balance: " + a.balance() + " Time= "
				+ time);
	}

	public static void accountOwner(String id) {
		for (int i = 0; i < findBank(id).aList.size(); i++)
			if (findBank(id).aList.get(i) == findBank(id).findAccount(id))
				System.out.print(findBank(id).cList.get(i).getName() + "'s");
	}
}
