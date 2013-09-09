void motor_init(){
 leftDrive(0);
 rightDrive(0); 
}

/* CONTROLLING RIGHT MOTOR (M0) */
void leftDrive(int i){
  
  /* CHECKING POSITIVE INPUT */
  if ( i >= 0 ){
    if ( i > 127 ){
      i = 127;                //PREVENTING OVERFLOW
    }
    motorSerial.write(0x8A);  //SEND FORWARD COMMAND
    motorSerial.write(i);     //SEND SPEED LIMIT
  }
  
  /* CHECKING NEGATIVE INPUT */
  else if (i < 0){
    if ( i < -127 ){
      i = -127;               //PREVENTING OVERFLOW
    }
    i = i * (-1);             //CONVERTING SPEED LIMIT
    motorSerial.write(0x88);  //SEND BACKWARD COMMAND
    motorSerial.write(i);     //SEND SPEED LIMIT
  }
}

/*First Alternative
void rightDrive( short i )
{
  
  if (i < 0)
  {
    i = i * (-1)              //ABSOLUTE VALUE
    motorSerial.write(0x8A);  //SEND BACKWARD COMMAND
  }
  else
  {
    motorSerial.write(0x88);  //SEND FORWARD COMMAND
  }
  
  
  if ( i > 127 )
  {
    i = 127;                //PREVENTING OVERFLOW
  } // Probably dont need since integer must be -127 < i < 127 since short int
    // would need to prevent overflow before passing value to the function

  motorSerial.write(i);     //SEND SPEED LIMIT
  
}
*/


/*Second Alternative (Dont use this xD)
void rightDrive( short i )
{
  motorSerial.write( (i<0) ? 0x8A : 0x88);
  motorSerial.write( 0x88 + ( (i>>6) & (1<<1) )); //Alternative
  motorSerial.write( ( (i>>7)^i ) + (i>>7) );
}
*/


/* CONTROLLING LEFT MOTOR (M1) */
void rightDrive(int i){
  /* CHECKING POSITIVE INPUT */
  if ( i >= 0 ){
    if ( i > 127 ){
      i = 127;                //PREVENTING OVERFLOW  
    }
    motorSerial.write(0x8E);  //SEND FORWARD COMMAND
    motorSerial.write(i);     //SEND SPEED LIMIT
  }
  
  /* CHECKING NEGATIVE INPUT */
  else if (i < 0){
    if ( i < -127 ){
      i = -127;               //PREVENTING OVERFLOW  
    }
    i = i * (-1);             //CONVERTING SPEED LIMIT
    motorSerial.write(0x8C);  //SEND BACKWARD COMMAND
    motorSerial.write(i);     //SEND SPEED LIMIT
  }
}

/*First Alternative
void leftDrive( short i )
{

  if ( i < 0 )
  {
    i = i * (-1)
    motorSerial.write(0x8E);  //SEND BACKWARD COMMAND
  }
  else
  {
    motorSerial.write(0x8C);  //SEND FORWARD COMMAND
  }
  
  if ( i > 127 )
  {
    i = 127;                //PREVENTING OVERFLOW  
  } // Probably dont need since integer must be -127 < i < 127 since short int
    // would need to prevent overflow before passing value to the function
  
  motorSerial.write(i);     //SEND SPEED LIMIT
}
*/


/*Second Alternative (Dont use this xD)
void leftDrive( short i )
{
  motorSerial.write( (i<0) ? 0x8E : 0x8C);
  motorSerial.write( 0x8C + ( (i>>6) & (1<<1) )); //Alternative
  motorSerial.write( ( (i>>7)^i ) + (i>>7) );
}
*/

