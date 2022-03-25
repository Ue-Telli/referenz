#ifndef MATERIALS_H
#define MATERIALS_H
#include "livingspace.h"
#include <QKeyEvent>

class Materials:public LivingSpace
{

public:
    void keyPressEvent(QKeyEvent* event);
};

#endif // MATERIALS_H
