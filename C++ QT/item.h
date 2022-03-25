#ifndef ITEM_H
#define ITEM_H
#include<QString>
#include<QDebug>
#include<QGraphicsPixmapItem>
#include <QGraphicsTextItem>

class Item: public QGraphicsPixmapItem
{
public:
    QGraphicsPixmapItem* Item_Icon  ;
    QGraphicsTextItem* ItemText;

private:
        int         itemValue       ;
        int         Typ             ;
        int         Wood            ;
        int         Stone           ;
        bool        full            ;
        QString     name, definiton ;
        QPixmap     Slot            ;
        QPixmap     icon            ;

public:
               Item                       (   );
       int     getTyp                     (   );
       bool    isFilled                   (   );
       void    setItem      (int value,QString Itemname);
       void    deletItem    (int value, QString name);
       int     getItemValue               (   );
       QString getName                    (   );

};

#endif // ITEM_H
