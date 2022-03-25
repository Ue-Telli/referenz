#include "item.h"

Item::Item()
{
   itemValue=0; // aktuelle Item anzahl
   name="Leer"; // name des Items im Inventar

   // Darstellung der Inventars Slots
   Slot.load(":/new/Png/glassPanel.png");
   setPixmap(Slot);
   setScale(0.5);
   Item_Icon = new QGraphicsPixmapItem(this); // verknüpfen der icons mit den Slots

}


void Item::setItem(int value, QString Itemname) // einfügen neuer items
{
name =Itemname;
    if(Itemname=="Holz")    // wenn der name gleich dem eingefügtem namen ist
    {                       // erhöhe den aktuelle werd und zeige die Garfik diese Items im Slot an
        itemValue += value;
        icon.load(":/new/Png/holz-1.png");
        Item_Icon->setPixmap(icon);
        Item_Icon->setPos(this->pos().x()*1.05,pos().y()*1.05);//(Slot.width()*2.3,Slot.height()*2.3);
        Item_Icon->setScale(1);
        Item_Icon->setZValue(4);
        Item_Icon->setOpacity(1);

    }
    else if (Itemname=="Stein")
    {
        itemValue += value;
        icon.load(":/new/Png/stein.png");
        Item_Icon->setPixmap(icon);
    }
    else if (Itemname=="Schwert")
    {
    itemValue += value;
    icon.load(":/new/Png/swordBronze.png");
    Item_Icon->setPixmap(icon);
    }
    if (itemValue==0)
    {
        name="Leer";
        Item_Icon->setOpacity(0);
    }
}

void Item::deletItem(int value, QString Itemname) // entfernen von items
{
   if(name==Itemname && itemValue>0)
   {
    itemValue=-value;
    qDebug()<<itemValue;
   }
   else if(itemValue==0) //Wenn der item anzahl gleich null
   {
   name="Leer";          // namen wieder auf Leer setzen
   };
}

QString Item::getName()  // rückgabe des namen für ander klassen
{
    return name;
}


