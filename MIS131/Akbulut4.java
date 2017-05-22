//Enes Emre Akbulut 2013502153

import java.util.Random;
public class Akbulut4 {
	public static void main(String[] args) {
		int customer=1,cost=0;
		int capacity[]={15,15,15,15,15,15};
	    int city[]={1,2,3,4,5,6};
		int price[]={55,45,45,35,75,65};
		int soldTicket[]={0,0,0,0,0,0};
		System.out.println("\n------FlywithUs Airlines Computer------");
		while(customer<11){
		System.out.println(customer+". Customer");
		Random randomInput=new Random();
	    int cityCode=randomInput.nextInt(6)+1;
	    int boughtSeat=randomInput.nextInt(5)+1;
	    if((capacity[cityCode-1]-boughtSeat)>0){
	    System.out.println("Destination city: "+city[cityCode-1]);
	    System.out.println("Number of bought seats: "+boughtSeat);
	    System.out.print("The seat numbers: ");
	    for(int i=1;i<=boughtSeat;i++){
	    	System.out.printf("%3d",((i-capacity[cityCode-1])+15));
		}
	    capacity[cityCode-1]-=boughtSeat;
		System.out.println("\nThe cost: "+boughtSeat*price[cityCode-1]+" TL\n");
		cost+=(boughtSeat*price[cityCode-1]);
		soldTicket[cityCode-1]+=boughtSeat;
		customer++;
		}else{
			System.out.println("Destination city: "+city[cityCode-1]);
		    System.out.println("Number of bought seats: "+boughtSeat);
			System.out.println("Error...Not enough capacity.\n");
			customer++;
		}}
		System.out.println("-------FINAL-------\nTotal number of tickets sold:");
		System.out.println("City         Tickets sold");
		System.out.println("----         ------------");
		for(int a=0;a<6;a++){System.out.println(city[a]+"\t----> \t "+soldTicket[a]);}
		System.out.println("Grand Total: "+cost+" TL");
		}
	}


