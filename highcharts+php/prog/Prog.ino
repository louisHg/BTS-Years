#include <Dhcp.h>
#include <Dns.h>
#include <Ethernet.h>
#include <EthernetClient.h>
#include <EthernetServer.h>
#include <EthernetUdp.h>

#include <Adafruit_Sensor.h>
#include <DHT_U.h>
#include <DHT.h>
#include "SPI.h"

DHT dht1(6, DHT22);
DHT dht2(7, DHT22);
 
byte mac[] = { 0x90, 0xA2, 0xDA, 0x0E, 0xA5, 0x7E };
//byte ip[] = {192, 168, 1, 100}; //IP shield
IPAddress server(192,168,1,17); //IP pc
//byte subnet[] = {255, 255, 255, 0};
EthernetClient client;
 
void setup()
{
 Ethernet.begin(mac);
 delay(2000);
 Serial.begin(9600);
  
Serial.println("toto");

 dht1.begin();
 dht2.begin();
}
 
void loop()
{
    Serial.println(Ethernet.localIP());

 float t = dht1.readTemperature();
 float f = dht2.readTemperature();

if (client.connect(server,80))
{
 Serial.println("connexion ok");
 Serial.println("Envoi de requete ...");
 client.print("GET http://");
 client.print(server);
 client.print("/temperature/index.php");
 client.print("data=");
 client.print(f);
 client.print("&data2=");
 client.print(t);
 client.println(" HTTP/1.1");
 client.print( "Host:" );
 client.println( server );
 client.println( "Connection: close" );
 client.println();
 client.println();
 client.stop();
 Serial.print("donnee ecrite ");
 Serial.println(t);
 Serial.println(f);
}
else
{
 Serial.println("Probleme de conenxion");
}
if (client.connected())
{
 client.stop();
}
delay(3000);
 
}
