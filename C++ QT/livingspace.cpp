#include "livingspace.h"


LivingSpace::LivingSpace(int type)
{
   typ=type;
}


int LivingSpace::getNr()
{
    return nr;
}

QPixmap LivingSpace::getpixmap()
{
    QPixmap pix;
    switch(typ)
    {
    case 1:pix.load(":/new/Png/mapppppppp.png");break; //Wasserfeld
    case 2:pix.load(":/new/Png/HaupM.png");break; //Kante links
    case 3:pix.load(":/new/Png/Haus2.png");
          setPos(100,100);break;//grasFeld
    }
    return pix;

 }


