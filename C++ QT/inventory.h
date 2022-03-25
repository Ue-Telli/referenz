#ifndef INVENTORY_H
#define INVENTORY_H
#include <QVector>
#include <QGraphicsPixmapItem>
#include "item.h"
#include "buttons.h"



class Inventory:public Item
{
public:
        int      i       ;
        bool     gefuellt;
        Item*    inventarSlot[3];
        QPixmap  Inventar;
        Buttons* X_button;
        QGraphicsPixmapItem* roundButton;

public:
             Inventory                           () ;
        void addItem    (int Items,QString Itemname);
        void newItem    (QString Itemname)          ;

};

#endif // INVENTORY_H
