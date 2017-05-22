package mis132_hw2;

public abstract class Account {
	protected String accountID;
	protected double balance;
	protected int time;

	public abstract double calculateBalance();

	public String getAccountID() {
		return accountID;
	}

	public void deposit(double amount) {
		this.balance = amount + this.calculateBalance();
		this.time = Test.time;
	}

	public boolean withdraw(double amount) {
		if (this.calculateBalance() >= amount) {
			this.balance = this.calculateBalance() - amount;
			this.time = Test.time;
			return true;
		} else
			return false;
	}

	public boolean transfer(double amount, Account a) {
		if (Test.findBank(this.accountID).equals(Test.findBank(a.accountID))) {
			if (this.calculateBalance() >= amount + Test.commission) {
				this.withdraw(amount + Test.commission);
				a.deposit(amount);
				return true;
			} else
				return false;
		} else {
			if (this.calculateBalance() >= amount + Test.commission) {
				this.withdraw(amount + (Test.pConstant * amount));
				a.deposit(amount);
				return true;
			} else
				return false;

		}
	}

	public double balance() {
		return this.calculateBalance();
	}

}
