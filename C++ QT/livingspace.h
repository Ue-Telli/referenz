#ifndef LIVINGSPACE_H
#define LIVINGSPACE_H

#include<QGraphicsScene>
#include <QGraphicsRectItem>


class LivingSpace: public QGraphicsPixmapItem
{
private:
    int typ ;


public:
             LivingSpace                 (int type );
    QPixmap  getpixmap                   (  );

};

#endif // LIVINGSPACE_H
