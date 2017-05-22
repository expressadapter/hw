//Enes Emre Akbulut 2013502153

import java.util.Scanner;
import java.util.Random;
public class Akbulut5 {
	public static void main(String[] args) {
		Scanner input=new Scanner(System.in);
		Scanner input2=new Scanner(System.in);
		int customer=1,cost=0,k,g=0,a=0,totalTicket=0;
	    int boughtSeatAmount[]=new int[10];
		int price[]={55,45,45,35,75,65};
		int soldTicket[][]=new int[6][16];
		int[] cityCodeA=new int[11];
		int[][] seatNumber;
		seatNumber=new int[6][15];
		String passenger[];
		passenger=new String[10];
		System.out.println("\n------FlywithUs Airlines Computer------");
		
		while(customer<11){
		System.out.println(customer+". Customer");
		Random randomInput=new Random();
	    int cityCode=randomInput.nextInt(6)+1;
	    int boughtSeat=randomInput.nextInt(5)+1;
	    int length=0;
	    for(int i=0;i<15;i++){if(soldTicket[cityCode-1][i]!=0){length++;}}
	    
	    if(boughtSeat<(15-length)){
	    System.out.println("Destination city: "+cityCode);
	    System.out.println("Number of bought seats: "+boughtSeat);
	    boughtSeatAmount[customer-1]=boughtSeat;
	    System.out.print("Unreserved Seats: ");
	    for(int e=0;e<15;e++){
			if(seatNumber[cityCode-1][e]==0){System.out.print((e+1)+"  ");}
		}
	    System.out.print("\nPlease select seat numbers: ");
	    for(int i=0;i<boughtSeat;i++){
	    	k=input.nextInt();
	    	seatNumber[cityCode-1][k-1]=1;
	    	soldTicket[cityCode-1][i+length]=k;
	    	cityCodeA[customer-1]=cityCode;
	    	
	    }
	    System.out.println("Please enter passenger name: ");
    	passenger[customer-1]=input2.nextLine();
	    System.out.println("\nThe cost: "+boughtSeat*price[cityCode-1]+" TL\n");
		cost+=(boughtSeat*price[cityCode-1]);
		customer++;
		}else{
			System.out.println("Destination city: "+(cityCode-1));
		    System.out.println("Number of bought seats: "+boughtSeat);
			System.out.println("Error...Not enough capacity.\n");
			customer++;
		}}
		System.out.println("-------FINAL-------\n");
		System.out.println("City         Tickets sold");
		System.out.print("----         ------------\n");
		for(int i=0;i<6;i++){
			int length=0;
		    for(int h=0;h<15;h++){if(soldTicket[i][h]!=0){length++;}}
			System.out.println("  "+(i+1)+"   ----->   "+length);
			totalTicket+=length;
			for(int f=0;f<11;f++){
				if(cityCodeA[f]==i+1){
					a=g;
					g+=boughtSeatAmount[f];
					System.out.print("*"+passenger[f]+" ----> Seat numbers: ");
					while(a<g){ 
						System.out.printf("%d ",soldTicket[i][a]);
						a++;
					}
					
					System.out.print("\n");
				}
			}
			a=0;g=0;
		}
		System.out.println("\nTotal number of sold tickets: "+totalTicket);
		System.out.println("Grand Total: "+cost+" TL");
		
	}
}
		

	
		
		



