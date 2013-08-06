#include <SoftwareSerial.h>
#include "IOconfig.h"

/* SETTING UP PARAMETERS */
int speedLimit=80;      //change the driving speed
int distanceLimit=150;  //change the IR trigger limit

void setup(){
  Serial.begin(9600);
  led_init();
  btn_init();
  motor_init();
  bt_init();
}

void loop(){
  /*
  if (proximity_check() )bt_command();
  else{
    leftDrive(0); rightDrive(0);
};
*/
 //btn_reset();
 bt_command();
}

