
void btn_init(){
 pinMode(btn,INPUT); 
}

void btn_reset(){
  if (digitalRead(btn)==LOW){
  delay(500);
  if (digitalRead(btn) == LOW){
   motor_init();
   bt_init();
  } 
 } 
}
