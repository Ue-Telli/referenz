#-------------------------------------------------
#
# Project created by QtCreator 2019-05-06T11:03:27
#
#-------------------------------------------------

include(:\img\Font)

QT       += core gui \
            multimedia

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = LivingSpace
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

CONFIG += c++11

SOURCES += \
        main.cpp \
    gamemainmenu.cpp \
    livingspace.cpp \
    player.cpp \
    buttons.cpp \
    inventory.cpp \
    item.cpp \
    craftig.cpp \
    enemy.cpp \
    Resource.cpp

HEADERS += \
    gamemainmenu.h \
    livingspace.h \
    player.h \
    buttons.h \
    inventory.h \
    item.h \
    craftig.h \
    enemy.h \
    Resource.h

FORMS +=

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

RESOURCES += \
    png.qrc
