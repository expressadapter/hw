package mis132_hw2;

import java.lang.Math;

public class Saving extends Account {
	private static double interestRate = 0.12;
	private int term;

	public Saving(Bank bc, Customer c, double b, int t) {
		super.balance = b;
		super.time = Test.time;
		this.term = t;
		super.accountID = bc.getBankCode() + "-" + c.getCustomerID() + "-0-"
				+ (bc.aList.size() + 1);
		bc.cList.add(c);
	}

	public double calculateBalance() {
		double val = this.balance
				* Math.pow((1 + this.term * interestRate / 12),
						((Test.time - this.time) / this.term));
		val = Math.round(val);
		return val;
	}

}