#include "Materials.h"



void Materials::keyPressEvent(QKeyEvent *event)
{
  if(event->key()==Qt::Key_Space)
  {
     setTree(1);

  }
}

