
// Эбулисов Эмиль 3ИСП-2 
#include<iostream>
using namespace std;

int main(){
int day, i=1;
    while(true){
    cout<<"Ввести номер дня: ";
    cin>>day;
        if(day > 0 && day <= 7){
        break;
        }
        else{
            cout<<i++<<" Нет такого дня недели!"<<endl;
        }
            }

switch(day){
    case 1: cout<<"Понедельник"<<endl; break;
    case 2: cout<<"Вторник"<<endl; break;
    case 3: cout<<"Среда"<<endl; break;
    case 4: cout<<"Четверг"<<endl; break;
    case 5: cout<<"Пятница"<<endl; break;
    case 6: cout<<"Суббота"<<endl; break;
    default: cout<<"Воскресенье"<<endl; 
        }
}