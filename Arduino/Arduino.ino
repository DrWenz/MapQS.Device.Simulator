#include <Wire.h>

int PWM1 = 7; 
int PWM2 = 6;
int PWM3 = 5;
int PWM4 = 4;
int PWM5 = 3;
int PWM6 = 2;
int PWM7 = 9;
int PWM8 = 8;

int Out1 = 22;
int Out2 = 24;
int Out3 = 26;
int Out4 = 28;

String SerialData ="";

void setup() {
  Wire.begin(4);
  Wire.onReceive(receiveEvent);
  Serial.begin(9600);
  
  pinMode(PWM1, OUTPUT);
  pinMode(PWM2, OUTPUT);
  pinMode(PWM3, OUTPUT);
  pinMode(PWM4, OUTPUT);
  pinMode(PWM5, OUTPUT);
  pinMode(PWM6, OUTPUT);
  pinMode(PWM7, OUTPUT);
  pinMode(PWM8, OUTPUT);

  analogWrite(PWM1,60);
  analogWrite(PWM2,80);
  analogWrite(PWM3,100);
  analogWrite(PWM4,120);
  analogWrite(PWM5,140);
  analogWrite(PWM6,160);
  analogWrite(PWM7,50);
  analogWrite(PWM8,60);

  pinMode(Out1,OUTPUT);
  digitalWrite(Out1,0);
  pinMode(Out2,OUTPUT);
  digitalWrite(Out2,0);
  pinMode(Out3,OUTPUT);
  digitalWrite(Out3,0);
  pinMode(Out4,OUTPUT);
  digitalWrite(Out4,0);

  Serial.println("");
  Serial.println("---------------");
  Serial.println("MapQS-Simulator");
  Serial.println("---------------");
}

void loop() {

  if (Serial.available() > 0) {
    SerialData = Serial.readStringUntil('\n');
    DoCmd();
  }

}

void DoCmd() {
    
    Serial.print("Received: ");
    Serial.println(SerialData);

    if (SerialData.length() == 4) {
      
      if (SerialData.substring(0,1) == "d") {
        SetDigi();
        return;
      }
      Serial.println("Can't decode Digi-command!");
      return;
    }

    if (SerialData.length() == 6) {
      
      if (SerialData.substring(0,1) == "a") {
        SetPwm();
        return;
      }
      
      Serial.println("Can't decode Analog-command!");
      return;
    }

    Serial.println("Incorrect commmand!");
}

void SetPwm () {

  if (SerialData.substring(1,2) == "1") {
    analogWrite(PWM1,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "2") {
    analogWrite(PWM2,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "3") {
    analogWrite(PWM3,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "4") {
    analogWrite(PWM4,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "5") {
    analogWrite(PWM5,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "6") {
    analogWrite(PWM6,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "7") {
    analogWrite(PWM7,SerialData.substring(3).toInt());
  }
  if (SerialData.substring(1,2) == "8") {
    analogWrite(PWM8,SerialData.substring(3).toInt());
  }

  return;
}

void SetDigi () {

  if (SerialData.substring(1,2) == "1") {
    if (SerialData.substring(3).toInt() == 1) {
      digitalWrite(Out1,1);
    }
    else {
      digitalWrite(Out1,0);
    }
  }

  if (SerialData.substring(1,2) == "2") {
    if (SerialData.substring(3).toInt() == 1) {
      digitalWrite(Out2,1);
    }
    else {
      digitalWrite(Out2,0);
    }
  }

  if (SerialData.substring(1,2) == "3") {
    if (SerialData.substring(3).toInt() == 1) {
      digitalWrite(Out3,1);
    }
    else {
      digitalWrite(Out3,0);
    }
  }

  if (SerialData.substring(1,2) == "4") {
    if (SerialData.substring(3).toInt() == 1) {
      digitalWrite(Out4,1);
    }
    else {
      digitalWrite(Out4,0);
    }
  }
  
}

void receiveEvent(int howMany)
{
  while(Wire.available()) // loop through all but the last
  {
    byte c = Wire.read(); // receive byte as a character
    if(c == 0x01) {
      byte c1 = Wire.read();
      byte c2 = Wire.read();
      byte c3 = Wire.read();
      byte c4 = Wire.read();
      byte c5 = Wire.read();
      byte c6 = Wire.read();

      analogWrite(PWM1, (int)c1);
      analogWrite(PWM2, (int)c2);
      analogWrite(PWM3, (int)c3);
      analogWrite(PWM4, (int)c4);
      analogWrite(PWM5, (int)c5);
      analogWrite(PWM6, (int)c6);
      
      Serial.print("C1:");
      Serial.print(c1);
      Serial.print(" ");
      
      Serial.print("C2:");
      Serial.print(c2);
      Serial.print(" ");
      
      Serial.print("C3:");
      Serial.print(c3);
      Serial.print(" ");
      
      Serial.print("C4:");
      Serial.print(c4);
      Serial.print(" ");
      
      Serial.print("C5:");
      Serial.print(c5);
      Serial.print(" ");
    
      Serial.print("C6:");
      Serial.print(c6);
      Serial.print(" ");
    }

    if(c == 0x04) {
      Serial.println("");
    }
  }
} 
