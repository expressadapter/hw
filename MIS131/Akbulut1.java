//Enes Emre Akbulut 2013502153

import java.util.Scanner;
public class Akbulut1{
    public static void main(String[] args){
    	int pick,ret,esum=0,mpick,ypick,yret,mret,dret,month,year,dpick,day,tday=0,bsum=0,fsum=0,psum=0,prom;
		char type,opt;
		Scanner ask=new Scanner(System.in);
		
		//Interface
		System.out.print("\r\r\r\t-Welcome to MISCAR cost calculator.This program will help you to calculate cost of rent a car.\r\tIf you ready please start with choosing car type.\r\r\tEconomy   ---> Daily Charge 60 TL\r\tMidsize   ---> Daily Charge 75 TL\r\tFull size ---> Daily Charge 110 TL\r\r\tPlease type selected car type:");
		type=ask.nextLine().charAt(0);
        System.out.print("\r\t-Optionally, you can add supplemental liability insurance (SLI) or/and GPS navigation to your order.\r\r\tGPS navigation  ---> Daily Charge 15 TL\r\tSLI\t\t---> Daily Charge 25 TL\r\r\tTo add SLI or\\and GPS to your order please type its name in shortname(GPS or SLI),if you want select both type both.\r\tIf you don't want anyone please type neither: ");
		opt=ask.nextLine().charAt(0);
		System.out.print("\r\t-Please enter your pick-up date without typing dots between numbers.(Ex:17.11.2014 --->17112014):");
	    pick=ask.nextInt();
		System.out.print("\r\t-Please enter your return date without typing dots between numbers.(Ex:18.11.2014 --->18112014):");
		ret=ask.nextInt();
		System.out.print("\r\t-You can enter your promotion code. If you don't have,please type 0:");
		prom=ask.nextInt();
		ask.close();
		
		//Day Calculation
		ypick=pick%10000;
	    mpick=(((pick-ypick)/10000)%100);
		dpick=((((pick-ypick)/10000)-mpick)/100);
		yret=ret%10000;
	    mret=(((ret-yret)/10000)%100);
		dret=((((ret-yret)/10000)-mret)/100);
		day=dret-dpick;
		month=mret-mpick;
		year=yret-ypick;
		if(day<0){
			do{
				day+=30;
				month--;
			 }while(day>=0);}
		if(day>=30){
			do{
				day-=30;
				month++;}while(day<30);}
		if(month<0){
			do{
				year-=1;
				month+=12;
			}while(month>=0);}
		if(month>=12){
			do{
				month-=12;
				year++;}while(month<12);
			}
		tday=day+month*30+year*360;
		
		//Basic Rate
		if(type=='e'|| type=='E')bsum=tday*60;
		if(type=='m'|| type=='M')bsum=tday*75;
		if(type=='f'|| type=='F')bsum=tday*110;
		
		//Extra
		if(opt=='g'|| opt=='G')esum=tday*15;
		if(opt=='s'|| opt=='S')esum=tday*25;
		if(opt=='b'|| opt=='B')esum=tday*40;
		if(opt=='n'|| opt=='N')esum=tday*0;
		
		//Promotion code
		if(prom==1)psum=(bsum*12)/100;
		if(prom==2)psum=(bsum*20)/100;
		
		//Total Cost
		fsum=bsum+esum-psum;
		
		//Final
		System.out.println("\r\t\t\t\t\tTOTAL COST\r\t----------------------------------------------------------------------------------------");
		if(type=='e'|| type=='E')System.out.print("\t*You have selected economy class car (60TL/day)");
        if(type=='m'|| type=='M')System.out.print("\t*You have selected midsize class car (75TL/day)");
		if(type=='f'|| type=='F')System.out.print("\t*You have selected full size class car (110TL/day)");
		if(opt=='g'|| opt=='G')System.out.print(" with GPS (15TL/day)");
		if(opt=='s'|| opt=='S')System.out.print(" with SLI (25TL/day)");
		if(opt=='b'|| opt=='B')System.out.print(" with GPS and SLI (40TL/day)");
		if(opt=='n'|| opt=='N')System.out.print("");
		System.out.println(" for "+tday+" days.");
		if(prom==1)System.out.println("\t%12 discount has been calculated based on basic cost.");
		if(prom==2)System.out.println("\t%20 discount has been calculated based on basic cost.");
		System.out.println("\r\t\tBasic Cost  ----> "+"+"+bsum+"TL");
		System.out.println("\t\tExtra Costs ----> "+"+"+esum+"TL");
		System.out.println("\t+\tPromo Code  ----> "+"-"+psum+"TL");
		System.out.println("\t--------------------------------------");
		System.out.println("\t\tTotal Cost  ---->  "+ fsum+"TL");
		}
	}
	
		
	
