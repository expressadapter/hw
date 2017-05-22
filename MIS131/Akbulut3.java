//Enes Emre Akbulut 2013502153

import java.util.Scanner;
public class Akbulut3{
	public static void main(String[] args){
        Scanner ask=new Scanner(System.in);
		char type = 0,opt = 0,again=' '; int tday,i=1,tearn=0,fsum=0;
        
		//Interface
		while(again!='X'){ 
		type=askType(i);
		opt=askOpt(i);
		tday=rentDays();
	    fsum=result(type,opt,tday,i);  
	    System.out.print("\r\t-For new customer type Y, to terminate progress type X:");
	    again=ask.next().toUpperCase().charAt(0);
	    tearn=tearn+fsum;
	    i++;
		}
		System.out.println("\r\n\t*MISCAR company\n\t---------------------------\n\tTotal profit:"+tearn+" TL\n\r\tTotal number of rents:"+(i-1));
	}
	 //Methods
	 public static char askType(int i){
		char type;
		Scanner ask=new Scanner(System.in);
		if (i>1){System.out.print("\r\t-Please type car type:");}else
			{System.out.print("\r\r\r\t-Welcome to MISCAR cost calculator.This program will help you to calculate cost of rent a car.\r\tIf you ready please start with choosing car type.\r\r\tEconomy   ---> Daily Charge 60 TL\r\tMidsize   ---> Daily Charge 75 TL\r\tFull size ---> Daily Charge 125 TL\r\r\t-Please type selected car type:");}
		type=ask.next().toUpperCase().charAt(0);
		while(type!='E'&&type!='M'&&type!='F'){System.out.print("\r\t-Error...Please type a valid car type:");
		type=ask.next().toUpperCase().charAt(0);}
		return type;
	}
	public static char askOpt(int i){
		char opt;
		Scanner ask=new Scanner(System.in);
		if (i>1){System.out.print("\r\t-Please choose extras:");}else
		{System.out.print("\r\t-Optionally, you can add supplemental liability insurance (SLI) or/and GPS navigation to your order.\r\r\tGPS navigation  ---> Daily Charge 12 TL\r\tSLI\t\t---> Daily Charge 25 TL\r\r\t-To add SLI or\\and GPS to your order please type its name in shortname(GPS or SLI),if you want select both type both.\r\tIf you don't want anyone please type neither: ");}
		opt=ask.nextLine().toUpperCase().charAt(0);
		while(opt!='S'&&opt!='G'&&opt!='N'&&opt!='B'){System.out.print("\r\t-Error...Please choose a valid choice:");
		opt=ask.next().toUpperCase().charAt(0);}	
		return opt;}
	public static int rentDays(){
		Scanner ask=new Scanner(System.in);
		int dpick,mpick,ypick,dret,mret,yret,tday;
		System.out.print("\r\t-Please enter your pick-up date with space between numbers.(Ex:17.11.2014 --->17 11 2014):");
	    dpick=ask.nextInt(); mpick=ask.nextInt(); ypick=ask.nextInt();
		System.out.print("\r\t-Please enter your return date with space between numbers.(Ex:18.11.2014 --->18 11 2014):");
		dret=ask.nextInt(); mret=ask.nextInt(); yret=ask.nextInt();
		while(dpick>30||dpick<=0||mpick>12||mpick<=0||dret>30||dret<=0||mret>12||mret<=0||yret==0||ypick==0||yret<ypick||(((dret<dpick)||(mret<mpick))&&(ypick==yret))){
			System.out.print("\r\t-Error...Please retype your pick-up date with space between numbers.(Ex:17.11.2014 --->17 11 2014):");
	        dpick=ask.nextInt(); mpick=ask.nextInt(); ypick=ask.nextInt();
	        System.out.print("\r\t-Please retype your return date with space between numbers.(Ex:18.11.2014 --->18 11 2014):");
		    dret=ask.nextInt(); mret=ask.nextInt(); yret=ask.nextInt();}
		tday=dayCalculate(dpick,mpick,ypick,dret,mret,yret);
	return tday;
	}
	public static int dayCalculate(int dpick,int mpick,int ypick,int dret,int mret,int yret){
		int day,month,year,tday;
		day=dret-dpick;
		month=mret-mpick;
		year=yret-ypick;
		if(day<0) {day+=30;month--;}
		if(month<0){month+=12;year--;}
		tday=day+(month*30)+(year*360);
		return tday;
	} 
	public static int result(char type,char opt,int tday,int i){
		int bsum=0,esum=0,fsum,cday;
		cday=(tday/7)*5+(tday%7);
		//Basic Rate
		System.out.println("\r\t\t\t\t\tTOTAL COST\r\t----------------------------------------------------------------------------------------");
		System.out.print("\t*"+i+". customer");
		switch(type){
		case 'E': bsum=cday*60;System.out.print(" you have selected economy class car (60TL/day)");break;
		case 'M': bsum=cday*75;System.out.print(" you have selected midsize class car (75TL/day)");break;
		case 'F': bsum=cday*125;System.out.print(" you have selected full size class car (125TL/day)");break;
		}
		//Extra
		switch(opt){		
		case 'G':esum=tday*12;System.out.print(" with GPS (12TL/day)");break;
		case 'S':esum=tday*25;System.out.print(" with SLI (25TL/day)");break;
		case 'B':esum=tday*37;System.out.print(" with GPS and SLI (37TL/day)");break;
		case 'N':esum=tday*0;System.out.print("");break;
		}
		//Total Cost
		fsum=bsum+esum;
        System.out.println(" for "+tday+" days.");
		System.out.println("\r\t\tBasic Cost  ----> "+"+"+bsum+" TL");
		System.out.println("\t\tExtra Costs ----> "+"+"+esum+" TL");
		System.out.println("\t--------------------------------------");
		System.out.println("\t\tTotal Cost  ---->  "+ fsum+" TL");
		return fsum;
	}
}
	
	

