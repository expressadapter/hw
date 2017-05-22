package mis132_hw2;

import java.lang.Math;

public class Time extends Account {
	private static double interestRate = 0.05;

	public Time(Bank bc, Customer c, double b) {
		super.balance = b;
		super.time = Test.time;
		super.accountID = bc.getBankCode() + "-" + c.getCustomerID() + "-1-"
				+ (bc.aList.size() + 1);
		bc.cList.add(c);
	}

	public double calculateBalance() {
		double val = this.balance
				* Math.pow((1 + interestRate / 12), Test.time - this.time);
		val = Math.round(val);
		return val;
	}

}
