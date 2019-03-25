void InfiniteLoopPC()
{
  InicializaPC();
  while(1)
  {
    Get_InstruccionPC();
    digitalWrite(pinIREnable, HIGH);//turn on IR Board
    analogValue = analogRead(pinIRAnalog);
      if(breakPC)
      {
       breakPC = false;
       DisplayWelcomeIF();
       break;            //Exit InfiniteLoopPC() and go to void loop()
      }
  }
}



int Get_InstruccionPC()
{
 if(Serial.available())
 {
   switch(Serial.read())
   {
     case 'S'://Close. Entra a bucle de inicializar
              Salir();
     break;
     
     case 'b'://Obten el valor analógico del ADC0
              //Just send the fu&%$&g string and i will manage everything in C#
              Serial.println(analogValue);
     break;
   }
 }
}

void Salir()
{
  PC = false;
  DisplayWelcomeIF();
  InicializaPC(); //Loop en inicializa esperando nueva inicializacion
}

//Inicializamos la comunicacion serial
//Debe mandar una secuencia de caracteres tal que cumplan con el criterio "square"
void InicializaPC()
{
  int caracter[6];
  int i = 0;
  int actualChar = 0;
  caracter[0] = 's';
  caracter[1] = 'q';
  caracter[2] = 'u';
  caracter[3] = 'a';
  caracter[4] = 'r';
  caracter[5] = 'e';
  digitalWrite(pinIREnable, LOW);//turn off IR Board
  DisplayIniPC();
  time = millis();
  while(1)
  {//Mientras no se inicialice no sale del ciclo
     if(Serial.available())
    {
        actualChar = Serial.read();
        if(actualChar == caracter[i])
        {
          if(i == 5)
          {//Si es la ultima iteracion
            Serial.write('a');//escribimos caracter de confirmacion
            PC = true;        //PC is connected and inicialized
            DisplayPCBussyIF();
            break; //Salimos del while
          }
          i++;
        }
        else
        {//Si no es el caracter esperado
          //Verifica si es el caracter inmediato anterior
          if(actualChar == caracter[i - 1])
          {//Como es el caracter esperado, entonces no actualiza i
            ;
          }
          else
          {//Comienza desde 0 porque no es ni madres de lo que se esperaba
            i = 0; 
          }
        }
        
      }
      time_ = millis();
      if( (time_ - time) > PCTimeOut)
      {
        breakPC = true;
        break; //breakWhile
      }
  }
  //Termina While
}
