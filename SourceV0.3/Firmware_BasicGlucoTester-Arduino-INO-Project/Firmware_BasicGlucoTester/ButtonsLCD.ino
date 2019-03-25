void IF()
{//Loop Infinito de la Interaz Física
  GetButtonsStateIF();
  ExecuteActionsIF();
}


void ExecuteActionsIF()
{
  if(ONOFFButton)
  {
    lcd.clear();
    lcd.print("ON OFF");
    ONOFFButton = false;
  }
  
  if(TestButton)
  {
    test = TakeSample();
    absorb = log10(cal/test);
    RefreshLCD();
    TestButton = false;
  }
  
  if(CalButton)
  {
    cal = TakeSample();
    RefreshLCD();
    CalButton = false;
  }
}

void GetButtonsStateIF()
{
  if(!ONOFFButton)
  {
    ONOFF = digitalRead(pinONOFFButton);//Read Actual Value
    if(ONOFF_ && !ONOFF)
    {//Last value es HIGH and Actual Value es LOW the is Falling Edge
      ONOFFButton = true;
    }
    ONOFF_ = ONOFF;
  }
  
  if(!TestButton)
  {
    Test = digitalRead(pinTestButton);
    if(Test_ && !Test)
    {//Last value es HIGH and Actual Value es LOW the is Falling Edge
      TestButton = true;
    }
    Test_ = Test;
  }
  
  if(!CalButton)
  {
    Cal = digitalRead(pinCalButton);
    if(Cal_ && !Cal)
    {//Last value es HIGH and Actual Value es LOW the is Falling Edge
      CalButton = true;
    }
    Cal_ = Cal;
  }
  
}

void RefreshLCD()
{
  lcd.clear();
  lcd.print("I0:");
  lcd.print(cal);
  lcd.print(" I1:");
  lcd.print(test);
  lcd.setCursor(0,1);
  lcd.print("Abs: ");
  lcd.print(absorb);
}

float TakeSample()
{
  int i = 0;
  float sample = 0;
  digitalWrite(pinIREnable, HIGH);//turn on IR Board
  lcd.clear();
  lcd.print("Sampling...");
  delay(10);
  for(i = 0; i<100;i++)
  {
   sample += analogRead(pinIRAnalog) * 0.0032258;
   lcd.setCursor(0,1);
   lcd.print(i);
   lcd.print("%");
   delay(DELAY_SAMPLES);//50ms delay 
  }
  digitalWrite(pinIREnable, LOW);//turn off IR Board
 return sample/100;
}

void DisplayPCBussyIF()
{
  lcd.clear();
  lcd.print("PC is Connected");
}

void DisplayWelcomeIF()
{
  lcd.clear();
  lcd.print("Glucometer by");
  lcd.setCursor(0,1);
  lcd.print("Haza & Ricky");
}

void DisplayIniPC()
{
  lcd.clear();
  lcd.print("Waiting 4 PC");
  lcd.setCursor(0,1);
  lcd.print("inicialization");  
}
