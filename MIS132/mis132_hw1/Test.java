package mis132_hw1;

import java.util.Arrays;

public class Test {

	public static void main(String[] args) {

		// 1.gen
		Person peter = new Person("peter", 0, null, null);
		Person melissa = new Person("melissa", 1, null, null);
		Person sid = new Person("sid", 0, null, null);
		Person wanda = new Person("wanda", 1, null, null);
		Person hank = new Person("hank", 0, null, null);
		Person marry = new Person("marry", 1, null, null);

		// 2.gen
		peter.married(melissa);
		Person emily = melissa.born("emily", 1, peter);
		Person marissa = melissa.born("marissa", 1, peter);
		Person tom = melissa.born("tom", 0, peter);
		Person george = melissa.born("george", 0, peter);

		wanda.married(sid);
		Person jeremy = wanda.born("jeremy", 0, sid);
		Person jerry = wanda.born("jerry", 0, sid);

		marry.married(hank);
		Person mark = marry.born("mark", 0, hank);
		Person lisa = marry.born("lisa", 1, hank);

		// 3.gen
		emily.married(jeremy);
		Person sidjr = emily.born("sid jr.", 0, jeremy);

		jerry.married(lisa);
		Person thomas = lisa.born("thomas", 0, jerry);
		Person jenny = lisa.born("jenny", 1, jerry);

		mark.married(marissa);

		// 4.gen
		Person ryan = new Person("ryan", 0, null, null);

		jenny.married(ryan);
		Person alice = jenny.born("alice", 1, ryan);

	}

	public static boolean displayArray(Person[] a) {
		for (int i = 0; i < a.length; i++) {
			if (a[i] != null)
				System.out.println(a[i].getName());
		}
		return false;
	}

}
