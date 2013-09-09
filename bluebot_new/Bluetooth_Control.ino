
byte control, lastControl;
bool forward, backward, lights, left, right, lastLights;
int speedR, speedL;
int output = 1;

/* INITIALIZE BLUETOOTH COM */
void bt_init(){
  
  bt.print("AT+NAME BLUEBOT");
  
  while(! bt.available()) { 
    ledLight(output); output = 1-output; delay(250); 
  }
  ledLight(1);
}

void bt_command(){
   if(bt.available())
    control = bt.read();
  if(control != lastControl)
  {
    setFlagsBasedOnControl();
   
    setMotorSpeeds();
    leftDrive(speedL);
    rightDrive(speedR);
    
    lastControl = control;
    lastLights = lights;
  }
}

void setFlagsBasedOnControl()
{
  forward = (control & 0x10) != 0;
  backward = (control & 0x20) != 0;
  lights = control & 0x80;
  left = (control & 0x04) != 0;
  right = (control & 0x08) != 0;
}

void setMotorSpeeds()
{
  int turnMag = 10;
  if(forward)
  {
    speedL = speedLimit-10;
    speedR = speedLimit;

  }
  else if(backward)
  {
    speedL = -speedLimit+11;
    speedR = -speedLimit;

  }
  else
  {
    speedL = 0;
    speedR = 0;
    turnMag = 18;

  }
  
  if(left)
  {
    speedL -= turnMag * 2;
    speedR += turnMag * 2; 

  }
  else if(right)
  {
    speedL += turnMag * 2;
    speedR -= turnMag * 2; 

  }
}

