
void led_init(){
 pinMode(LED, OUTPUT); 
}

/* CONTROLLING LED LIGHT */
void ledLight(boolean status){
 if (status){
  digitalWrite(LED, HIGH);          //TURN LED ON
 } 
 else ( digitalWrite(LED, LOW) );   //TURN LED OFF
}

