package mis132_hw1;

public class Family {

	private Person wife;
	private Person husband;
	public Person[] children = new Person[0];
	public int childCount = 0;

	public Family(Person w, Person h) {
		this.wife = w;
		this.husband = h;
	}

	public Person getWife() {
		return wife;
	}

	public Person getHusband() {
		return husband;
	}

	public void addPerson(Person p) {

		Person[] temp = new Person[this.children.length + 1];

		for (int i = 0; i < this.children.length; i++)
			temp[i] = this.children[i];

		temp[childCount++] = p;
		this.children = temp;

	}

}
