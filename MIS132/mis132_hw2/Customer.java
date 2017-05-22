package mis132_hw2;

public class Customer {
	private String name;
	private String customerID;

	public Customer(String n, String i) {
		this.name = n;
		this.customerID = i;
	}

	public String getCustomerID() {
		return customerID;
	}

	public String getName() {
		return name;
	}

}