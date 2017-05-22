package mis132_hw1;

public class Person {

	public Person[] children = new Person[0];
	private String name;
	private int gender;
	private Person mother;
	private Person father;
	private Family family;
	private int childCount = 0;

	public Person(String n, int g, Person m, Person f) {
		this.name = n;
		this.gender = g;
		this.mother = m;
		this.father = f;
	}

	public Family married(Person spouse) {
		if (this.gender == 0) {
			this.family = new Family(spouse, this);
			return spouse.family = new Family(spouse, this);
		} else
			spouse.family = new Family(this, spouse);
		return this.family = new Family(this, spouse);

	}

	public Person born(String n, int g, Person f) {
		this.addPerson(new Person(n, g, this, f));
		f.addPerson(new Person(n, g, this, f));
		this.family.addPerson(new Person(n, g, this, f));
		f.family.addPerson(new Person(n, g, this, f));
		return new Person(n, g, this, f);
	}

	public Person getMotherInLaw() {
		if (this.family != null)
			if (this.gender == 0)
				return this.family.getWife().mother;
			else
				return this.family.getHusband().mother;
		else
			return null;

	}

	public Person[] allChildren() {
		return this.children;
	}

	public Person[] allSisters() {
		Person[] a = this.tumKardesler();
		Person[] sisters = new Person[10];
		for (int i = 0; i < a.length; i++)
			if (a[i] != null && a[i].name != this.name)
				if (a[i].gender == 1)
					sisters[i] = a[i];
		return sisters;

	}

	public Person[] allBrothers() {
		Person[] a = this.tumKardesler();
		Person[] brothers = new Person[10];
		for (int i = 0; i < a.length; i++)
			if (a[i] != null && a[i].name != this.name)
				if (a[i].gender == 0)
					brothers[i] = a[i];
		return brothers;

	}

	public Person[] tumKardesler() {
		Person[] tumKardesler = new Person[10];
		for (int i = 0; i < this.father.childCount; i++)
			if (this.name != this.father.children[i].name)
				tumKardesler[i] = this.father.children[i];
		return tumKardesler;
	}

	public Person[] grandParents() {
		Person gparents[] = new Person[4];
		gparents[0] = this.father.father;
		gparents[1] = this.father.mother;
		gparents[2] = this.mother.father;
		gparents[3] = this.mother.mother;
		return gparents;

	}

	public Person[] allAncestors() {
		Person[] ancestors = new Person[20];
		int k = 0;
		Person x = this.father;
		Person y = this.mother;
		while (y != null) {
			if (k >= 2) {
				ancestors[k] = x.family.getWife();
				k++;
				ancestors[k] = y.family.getHusband();
				k++;
			}
			ancestors[k] = x;
			k++;
			ancestors[k] = y;
			k++;
			x = x.father;
			y = y.mother;

		}
		return ancestors;
	}

	public boolean areBrothers(Person par) {

		for (int i = 0; i < 10; i++) {
			if (this.allBrothers()[i].name.equals(par.name))
				return true;

		}
		return false;
	}

	public String getName() {
		return name;
	}

	public int getChildCount() {
		return childCount;
	}

	public Family getFamily() {
		return family;
	}

	public Person getMother() {
		return mother;
	}

	public Person getFather() {
		return father;
	}

	public void addPerson(Person p) {

		Person[] temp = new Person[this.children.length + 1];

		for (int i = 0; i < this.children.length; i++)
			temp[i] = this.children[i];

		temp[childCount++] = p;
		this.children = temp;

	}

}
