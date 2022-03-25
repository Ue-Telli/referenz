#include "inventory.h"
#include<QtDebug>

Inventory::Inventory()
{
//+++ Inventar Fenster+++//
Inventar.load(":/new/Png/panel_brown.png");
setPixmap(Inventar);
setPos(200,200);
setZValue(1);
QPixmap x_grey(":/new/Png/iconCross_brown.png");
QPixmap x_brown(":/new/Png/iconCross_brown.png");

roundButton = new QGraphicsPixmapItem();
QPixmap pix(":/new/img/img/buttonRound_blue.png");
roundButton->setPixmap(pix);
roundButton->setPos(pos().x()*2.13,pos().y()*0.92);
roundButton->setZValue(4);

X_button= new Buttons("",Qt::white,x_grey,x_brown);
X_button->setPos(pix.width()*12.4,pix.height()*5.1);

for (int i=0;i<3;i++)
{
  inventarSlot[i]= new Item();
  inventarSlot[i]->setZValue(3);
}

inventarSlot[0]->setPos(pos().x()*1.15,pos().y()*1.1);
inventarSlot[1]->setPos(pos().x()*1.50,pos().y()*1.1);
inventarSlot[2]->setPos(pos().x()*1.85,pos().y()*1.1);
}

//++++Einfügen von Gegenstanden ins inventar++++//
void Inventory::addItem(int Items, QString Itemname)
{
  if(inventarSlot[0]->getName()=="Leer"|| inventarSlot[0]->getName()==Itemname)
          {
              inventarSlot[0]->setItem(Items,Itemname);
                  qDebug()<<"inventar 1 wird gefüllt mit Holz";
          }
  else if (inventarSlot[1]->getName()=="Leer"||inventarSlot[1]->getName()==Itemname)
          {
             inventarSlot[1]->setItem(Items,Itemname);
             qDebug()<<"inventar 2 wird gefüllt mit"<<Itemname;
          }
  else if(inventarSlot[2]->getName()=="Leer"||inventarSlot[2]->getName()==Itemname)
          {
            inventarSlot[2]->setItem(Items,Itemname);
            qDebug()<<"inventar3 befuellt";
  }
}
//+++ Crafting von neuen Objekten++//
void Inventory::newItem(QString Itemname)
{
    if(Itemname=="Schwert")
    {
        for (int i=1;i<3;i++)
        {
            if(inventarSlot[0]->getName()=="Holz"&& inventarSlot[i]->getName()=="Stein")
            {
               inventarSlot[0]->deletItem(1,"Holz");inventarSlot[i]->deletItem(1,"Stein");
               addItem(1,"Schwert");
            }
            else if (inventarSlot[i]->getName()=="Holz"&& inventarSlot[0]->getName()=="Stein")
            {
                inventarSlot[0]->deletItem(1,"Holz");inventarSlot[i]->deletItem(1,"Stein");
                addItem(1,"Schwert");
            }
        }
    }
}




