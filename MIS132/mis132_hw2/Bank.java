package mis132_hw2;

import java.util.ArrayList;

public class Bank {
	private String bankCode;
	ArrayList<Customer> cList = new ArrayList<Customer>();
	ArrayList<Account> aList = new ArrayList<Account>();

	public Bank(String c) {
		this.bankCode = c;
	}

	public String getBankCode() {
		return bankCode;
	}

	public ArrayList<Account> getaList() {
		return aList;
	}

	public Account findAccount(String s) {
		for (int i = 0; i < this.aList.size(); i++)
			if (this.aList.get(i).accountID.equals(s))
				return this.aList.get(i);
		return null;

	}

	public double balance() {
		double total = 0;
		for (Account t : aList)
			total += t.calculateBalance();
		return total;
	}

}
