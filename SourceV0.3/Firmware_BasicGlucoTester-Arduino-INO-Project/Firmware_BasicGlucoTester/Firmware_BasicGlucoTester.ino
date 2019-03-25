/*
Hazael Fernando MOJICA GARCIA
Ricardo Guevara Zavala
Firmware para Arduino del Glucometro
Creation Date: 17/09/2013
Last Mod.Date: 06w/10/2013
V0.2
*/

// include the library code:
#include <LiquidCrystal.h>
#include <math.h>

//PINS DEFINITION
int pinIREnable = 22;    //Arduino PIN of "ON/OFF OUT" in "IR Board" Tarjeta IR
int pinIRAnalog = 0;     //Arduino PIN for ADC from "IR Board" Tarjeta IR

int pinLCD_RS = 34;      //LCD Pins
int pinLCD_Enable = 32;
int pinLCD_D4 = 30;
int pinLCD_D5 = 28;
int pinLCD_D6 = 26;
int pinLCD_D7 = 24;

//Push Buttons Pins
int pinONOFFButton = 36;  //On/Off Button
int pinCalButton = 38;    //Calibrate Button
int pinTestButton = 40;   // Test Button

//GLOBAL VARIABLES
boolean PC = false;                    //true if PC is conected and inicialized false if not
boolean Android = false;               //true if an Android Device is conected and inicialice the App.
int analogValue = 0;

//Private variables ButtonsLCD file
int DELAY_SAMPLES = 50;             //50ms of wait time between each sample measure (100 measures total)
boolean ONOFFButton = false;        //true in Falling edge (On/OFF Button has been pushed)
boolean TestButton = false;         //true in Falling edge (Test Button has been pushed)
boolean CalButton = false;          //true in Falling edge (Calibrate Button has been pushed)
float test = 0;
float cal = 0;
double absorb = 0;


boolean ONOFF = false;
boolean Test = false;
boolean Cal = false;
boolean ONOFF_ = false;
boolean Test_ = false;
boolean Cal_ = false;

//Private vaiables PC file
long PCTimeOut = 5000;      //5 seconds PC TimeOut
boolean breakPC = false;
unsigned long time = 0;
unsigned long time_ = 0;

// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(pinLCD_RS, pinLCD_Enable, pinLCD_D4, pinLCD_D5, pinLCD_D6, pinLCD_D7);

void setup()
{
  Serial.begin(115200);
  analogReference(EXTERNAL);
  // set up the LCD's number of columns and rows: 
  lcd.begin(16, 2);
  DisplayWelcomeIF();
  
  //pinMode's
  pinMode(pinIREnable, OUTPUT);
  pinMode(ONOFFButton, INPUT);
  pinMode(pinCalButton, INPUT);
  pinMode(pinTestButton, INPUT);
  
  //First State
  digitalWrite(pinIREnable, LOW);
}

void loop()
{
  //Priority 1. PC
  if(!PC)
  {//Pc is NOT connected && NOT inicialized
    if(Serial && Serial.available())
    {//Check if the computer is connected via USB B connector (creates Virtal Communication Port in PC)
      InfiniteLoopPC();
    }
  }
  
  //Priority 2. Android Device
  if(!Android)
  {
    
  }
  
  //Priority 3. ButtonsLCD. Interfaz Física
  IF();  
  
  
  
}
