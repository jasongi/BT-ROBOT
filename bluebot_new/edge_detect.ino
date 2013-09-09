
void IR_init(){
 pinMode(IRpin,INPUT); 
}

int proximity_check(void){
 static int value = 0;
 value = digitalRead(IRpin);
 if (digitalRead(IRpin) > distanceLimit) value = 1;
 else (value = 0);
 return value;
}

