//Enes Emre Akbulut 2013502153

import java.util.Scanner;
public class Akbulut2{
	public static void main (String[] args){
		int elife, i, sa=0;
	    float d,value;
		char method;
		Scanner ask=new Scanner(System.in);
		System.out.println("\n\n\t\t-----Depreciation Calculator-----");
		System.out.print("\n\t-Hello user, please select your calculation method.Straight-line(S),Double-declining(D),Sum of the years' digit(Y)\n\tTo terminate progress type X:");
		method=ask.nextLine().charAt(0);
		while(method!='X'){
			while(method!='S'&& method!='Y'&& method!='D'&& method!='X'){
				System.out.print("\t-Error...Please select a valid calculation method.To terminate progress type X:");
				method=ask.nextLine().charAt(0);
			}
			if(method=='X')break;
			if(sa>0){System.out.print("\t-Please select your calculation method.To terminate progress type X:");
			method=ask.next().charAt(0);}
			while(method!='S'&& method!='Y'&& method!='D'&& method!='X'){
				System.out.print("\t-Error...Please select a valid calculation method.To terminate progress type X:");
				method=ask.next().charAt(0);}
			if(method=='X')break;
			System.out.print("\t-Please type current value of item:");
			value=ask.nextInt();
			System.out.print("\t-Please type economic life of item:");
			elife=ask.nextInt();
			sa++;
			
			switch(method){
		    
			case 'S':d=value/elife; i=0;
					do{ 
						i++; value=value-d; 
				        System.out.printf("\t%d. year's depreciation is %2.1f . The remaining value of item is %2.1f\n" ,i,d,value);
				        }while(i<elife); break;
			
		    case 'D':i=1;while(i<=elife){
		    	d=(value*2)/10;
				value=value-d;
				 System.out.printf("\t%d. year's depreciation is %2.1f . The remaining value of item is %2.1f\n" ,i,d,value);
				i++;
			} break;
			
		    case 'Y':i=0; int dnom=0,l;float nvalue=value; 
		    for(i=0; i<=elife; i++){dnom=dnom+i;}
			for(i=elife;i>0;i--){
				d=(i*value)/dnom;
				l=(elife-i)+1;
				nvalue=nvalue-d;
				System.out.printf("\t%d. year's depreciation is %2.1f . The remaining value of item is %2.1f\n",l,d,nvalue );
			 }break;
			}
		
		}
		ask.close();
		System.out.println("\t-"+"The progress is terminated,Good Bye...");
	}
}