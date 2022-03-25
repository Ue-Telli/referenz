#include "Player.h"
#include<QKeyEvent>
#include<QGraphicsScene>
#include"enemy.h"
#include"gamemainmenu.h"



Player::Player()
{
    Level       =     1 ;
    LifePoints  =   100 ;
    Mana        =    10 ;
    Skill       =     0 ;
    damage      =    10 ;
    protection      = 0    ;
    money           = 0    ;
    InventarOn_Off  = false;
    v=0;

    QPixmap pix(":/new/Png/tile_0024.png");
    setPixmap(pix);
    setPos(50,50);
    setScale(1.9);
    setZValue(4);
}


// Tastenbefehle
void Player::keyPressEvent(QKeyEvent *event)
{

    QList<QGraphicsItem*>colliding_items= collidingItems();
    for (int i=0,n =colliding_items.size();i<n;i++)
    {
      if (typeid (*(colliding_items[i])) == typeid (Enemy)) // angriff des Gegners
        {
         LifePoints-= 10;
        }
      if (typeid (*(colliding_items[i])) == typeid (Resource)) // Collider zum erkennen vom Object Rescource
      {
          if (event->key()==Qt::Key_E)                   // wenn die taste F gedrückt ist
          {
            scene()->removeItem(colliding_items[i]);
            delete colliding_items[i];                   // löschen des erkannten Object
            addItem(1,"Holz");                          // einfungen von 1 holz ins inventar

          }
         // kollidieung erzeugen
          switch (event->key())
            {
             case Qt::Key_Right:if (pos().x()<colliding_items[i]->x())
                                                {setPos(pos().x()-10,pos().y());};break;

             case Qt::Key_Left:if (pos().x()>colliding_items[i]->x())
                                                {setPos(pos().x()+10,pos().y());};break;

             case Qt::Key_Up:if (pos().y()>colliding_items[i]->y())
                                                {setPos(pos().x(),pos().y()+10);};break;

             case Qt::Key_Down:if (pos().y()<colliding_items[i]->y())
                                                {setPos(pos().x(),pos().y()-10);};break;
            }
          }
        }

//Steuerung es Spielers
    if (event->key()==Qt::Key_Left || event->key() == Qt::Key_A)
    { 
        if(x()>50)               //wenn die x achse größer als 5
         {
         setPos(x()-10,y());  //soll sich die position um 10 pixel verändern
         }
    }
    else if (event->key()==Qt::Key_Right || event->key() == Qt::Key_D)
    {
        if(x()<860)             //wenn die x achse kleiner als 530
        {
            setPos(x()+10,y()); //soll sich die position um 10 pixel verändern
        }
    }
    else if (event->key()==Qt::Key_Down || event->key() == Qt::Key_S)
    {
        if(y()<630)             //wenn die y achse kleiner als 480
        {
         setPos(x(),y()+10);    //soll sich die position um 10 pixel verändern
        }
    }
    else if (event->key()==Qt::Key_Up || event->key() == Qt::Key_W)   //Nach oben bewegen
    {
        if(y()>-5)               //wenn die y achse größer als 0
        {
         setPos(x(),y()-10);    //soll sich die position um 10 pixel verändern
        }
    }

// Öffnen des Crafting Fensters
    if (event->key()==Qt::Key_C)
    {
        scene()->addItem(CraftingUI);
        scene()->addItem(CraftingUi_background);
        scene()->addItem(creatStick);
        scene()->addItem(creatSword);
        scene()->addItem(crafting_button);
        scene()->addItem(rect);
    }
    else if (InventarOn_Off==false)
    {
// Öffnen des inventars Fensters
        if (event->key()==Qt::Key_I)
        {
            InventroyUi = new Inventory();
            InventroyUi->setZValue(3);
            InventroyUi->setScale(2.5);
            InventroyUi->setTransformationMode(Qt::SmoothTransformation);

            scene()->addItem(InventroyUi);
            scene()->addItem(inventarSlot[0]);
            scene()->addItem(inventarSlot[1]);
            scene()->addItem(inventarSlot[2]);
            scene()->addItem(X_button);
            scene()->addItem(roundButton);
            InventarOn_Off=true;
       }
    }
//Schließen des Inventar und Crafting Fensters
    else if (event->key()==Qt::Key_Escape)
    {
    scene()->removeItem(InventroyUi);
    scene()->removeItem(inventarSlot[0]);
    scene()->removeItem(inventarSlot[1]);
    scene()->removeItem(CraftingUI);
    scene()->removeItem(CraftingUi_background);
    scene()->removeItem(creatStick);
    scene()->removeItem(crafting_button);
    InventarOn_Off = false;
    }
}

void Player::closeGuiButton()
{
    scene()->removeItem(InventroyUi);
    scene()->removeItem(inventarSlot[0]);
    scene()->removeItem(inventarSlot[1]);
    scene()->removeItem(inventarSlot[2]);
    scene()->removeItem(roundButton);
    scene()->removeItem(X_button);
    InventarOn_Off = false;
}

//Auswahl des Rezept zum Craften
void Player::creatReceptItem(int recept)
{
    if (recept==1)
    {
        rect->setPos(-creatStick->x()+470,-creatStick->y()+210);
    }
    else if (recept==2)
    {
     rect->setPos(-creatSword->pos().x()+470,-creatSword->pos().y()+310);
     newItem("Schwert");
    }

}



