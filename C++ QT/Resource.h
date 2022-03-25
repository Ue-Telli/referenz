#ifndef RESOURCE_H
#define RESOURCE_H
#include <QGraphicsPixmapItem>
#include<QObject>

class Resource:public QObject, public QGraphicsPixmapItem
{
private: QString materialName;
public:
        Resource    (QString Material);
        QString getMeterial;
        QPixmap gettree ();
};

#endif // NEUKLASSE_H
