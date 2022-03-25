#ifndef PLAYER_H
#define PLAYER_H
#include <QGraphicsPixmapItem>
#include "Resource.h"
#include "inventory.h"
#include "craftig.h"


class Player:public QObject,public Craftig,public Inventory
{
private:
       Inventory* InventroyUi    ;
             bool InventarOn_Off ;
              int v              ;
              int Level          ;
              int EXP            ;
              int LifePoints     ;
              int Mana           ;
              int Skill          ;
              int damage         ;
              int protection     ;
              int money          ;

public:
                Player  ();
        void    closeGuiButton();
        void    creatReceptItem(int recept);
        void    whyYouPunchMe(int damage);
private:
        void    keyPressEvent(QKeyEvent* event);


};

#endif // PLAYER_H
