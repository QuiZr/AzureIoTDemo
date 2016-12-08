#include <Arduino.h>
#include <ArduinoJson.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>

#define USE_SERIAL Serial

ESP8266WiFiMulti WiFiMulti;

void setup() {
  USE_SERIAL.begin(115200);

  WiFiMulti.addAP("SSID", "PASSWORD");
}

void loop() {
  // Wait for WiFi connection
  int wifi = WiFiMulti.run();
  printWiFiStatus(wifi);

  if (wifi == WL_CONNECTED) {
    HTTPClient http;
    USE_SERIAL.print("[HTTP] begin...\n");

    // Configure traged server, url and content type
    http.begin("http://IP:PORT/api/temperature");
    http.addHeader("Content-Type", "application/json", true, true);

    // Read data from sensor and create a JSON object
    StaticJsonBuffer<200> jsonBuffer;
    JsonObject& root = jsonBuffer.createObject();
    root["Place"] = "lodz";
    root["Value"] = double_with_n_digits((double)random(-10000, 10000) / (double)100, 2);

    // Create a string from JSON object
    char buffer[256];
    root.printTo(buffer, sizeof(buffer));

    // Start connection and send HTTP header
    int httpCode = http.POST(buffer);
    USE_SERIAL.print("[HTTP] POST...\n");

    // httpCode will be negative on error
    if (httpCode > 0) {
      // HTTP header has been send and Server response header has been handled
      USE_SERIAL.printf("[HTTP] POST... Code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK) {
        // Do something with reveived data, for now just print it to console.
        String payload = http.getString();
        USE_SERIAL.println(payload);
      }
    } else {
      USE_SERIAL.printf("[HTTP] POST... failed, error: %s\n", http.errorToString(httpCode).c_str());
    }

    USE_SERIAL.print("\n");
    http.end();
  }
  delay(10000);
}

void printWiFiStatus(int wifi) {
  switch (wifi) {
    case (WL_CONNECTED):
      USE_SERIAL.printf("[WiFi] Connected. Status code: WL_CONNECTED\n");
      break;
    case (WL_NO_SHIELD):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_NO_SHIELD\n");
      break;
    case (WL_IDLE_STATUS):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_IDLE_STATUS\n");
      break;
    case (WL_NO_SSID_AVAIL):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_NO_SSID_AVAIL\n");
      break;
    case (WL_SCAN_COMPLETED):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_SCAN_COMPLETED\n");
      break;
    case (WL_CONNECT_FAILED):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_CONNECT_FAILED\n");
      break;
    case (WL_CONNECTION_LOST):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_CONNECTION_LOST\n");
      break;
    case (WL_DISCONNECTED):
      USE_SERIAL.printf("[WiFi] Not connected. Status code: WL_DISCONNECTED\n");
      break;
  }
}

