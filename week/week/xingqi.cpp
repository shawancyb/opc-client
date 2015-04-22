#include<stdio.h>
#include<process.h>
int main()
{
	int dayNum;
	char * days[7];
	days[0] = "Sunday";
	days[1] = "Monday";
	days[2] = "Tuesday";
	days[3] = "Wednesday";
	days[4] = "Thursday";
	days[5] = "Friday";
	days[6] = "Saturday";
printf("Enter a number from 1 to 7: ");
scanf("%d",&dayNum);
if (dayNum >= 1 && dayNum <= 7)
	{printf("That day is %s\n",days[dayNum - 1]);}
else
	{printf("You didn't enter a good number.\n");}
	system("pause"); 
	return 0;
}


