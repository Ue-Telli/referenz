#include "Resource.h"


Resource::Resource(QString Material): QObject (), QGraphicsPixmapItem ()
{
    materialName =Material;
}

QPixmap Resource::gettree()
{
  QPixmap Material;

  if(materialName=="Tree")
    {
    Material.load(":/new/img/img/mapTile_055.png");
    }
  if(materialName=="Stone")
    {
    Material.load(":/new/Png/stein.png");
    }
  if(materialName=="Kristal")
    {
    Material.load(":/new/Png/kristall.png");
    };
  return Material;
}


