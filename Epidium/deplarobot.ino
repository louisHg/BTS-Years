#define VITESSED 5                    //Pin 5 = Vitesse du moteur droit (pwm)
#define DIRECTIOND 4                  //Pin 4 = Direction du moteur droit
#define VITESSEG 9                    //Pin 9 = Vitesse du moteur gauche (pwm)
#define DIRECTIONG 8                  //Pin 8 = Direction du moteur gauche
#define JOYSTICK1 0                   //Pin A0 = Axe x joystick
#define JOYSTICK2 1                   //Pin A1 = Axe y joystick

long temps = 0;


void setup() {
  pinMode(VITESSED,OUTPUT);
  pinMode(DIRECTIOND,OUTPUT); 
  pinMode(VITESSEG,OUTPUT);
  pinMode(DIRECTIONG,OUTPUT); 
  digitalWrite(VITESSED,LOW);
  digitalWrite(VITESSEG,LOW);
  Serial.begin(9600);                                                                                     //Debit de communication arduino( a voir )                                                                               
}

void loop() {
 
ControleJoystick();

}


void ControleJoystick(){                                                                                  //Fonction de lecture du joystick

  int valJoystickVitesse,valJoystickDirection;
  unsigned char vitesse;
 
  valJoystickVitesse = analogRead(JOYSTICK1);
  valJoystickDirection = analogRead(JOYSTICK2); 
   
  if((valJoystickVitesse < 495) && (503 < valJoystickDirection < 507)) {                                  //RECUL
      vitesse = map(valJoystickVitesse,501,0,0,255);
      Bouge (vitesse,1,1); 
      }
      else {
          if ((valJoystickVitesse > 505) && (503 < valJoystickDirection < 507)){                          //AVANCE
              vitesse = map(valJoystickVitesse,501,1024,0,255);     
              Bouge(vitesse,0,0);
              }
              else {
                  if(( valJoystickDirection < 500 ) && (498 < valJoystickVitesse < 502)) {                //TOURNE A GAUCHE
                      vitesse = map(valJoystickDirection,501,0,0,255);     
                      Bouge(vitesse,0,1);
                      }
                      else {
                          if(( valJoystickDirection > 510 ) && (498 < valJoystickVitesse < 502)) {        //TOURNE A GAUCHE
                              vitesse = map(valJoystickDirection,501,0,0,255);     
                              Bouge(vitesse,1,0);
                              }
                              else {
                                  Stop();
                                  }                               
                      }
               }
        }
           
  if(millis()-temps>2000){                                                                                //AFFICHAGE DES VARIABLES
      Serial.print ("Val joystick vitesse : ");
      Serial.println (valJoystickVitesse);
      Serial.print ("Val joystick direction : ");
      Serial.println (valJoystickDirection);
      Serial.print ("Vitesse : ");
      Serial.println (vitesse);
      temps = millis();
      }
}

void Bouge (unsigned char vitesse, bool DirMoteurG, bool DirMotorD){                                    //FONCTION QUI ACTIVE LES MOTEURS
   analogWrite(VITESSED,vitesse);
   analogWrite(VITESSEG,vitesse);
   digitalWrite(DIRECTIOND,DirMoteurG);
   digitalWrite(DIRECTIONG,DirMotorD);
 
}

void Stop (){                                                                                           //FONCTION QUI ARRETE LES MOTEURS
    analogWrite(VITESSED,LOW);             
    analogWrite(VITESSEG,LOW);
}
