#include <gamemainmenu.h>
#include <livingspace.h>
#include <QApplication>

GameMainMenu* menu;
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    menu= new GameMainMenu();
    menu->display();
    menu->show();
    return a.exec();
}
