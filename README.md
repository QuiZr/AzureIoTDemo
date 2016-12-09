# AzureIoTDemo
Simple ASP.NET Core app that collects data from ESP8266 or other IoT devices  
Link: http://azureiotdemonet.azurewebsites.net/

Available requests:

Type | Path | Data
--- | --- | ---
GET | /api/temperature | All temperature reads
GET | /api/temperature/{id} | Temperature read with selected id
POST | /api/temperature | Uploads a new temperature read. Place and value string needed in request body 
DELETE | /api/temperature/{id} | Deletes selected read

## Troubleshooting
* If Bower downloads wrong wersion of boostrap: http://stackoverflow.com/questions/37584520/bootstrap-3-3-6-jquery-2-2-4-version-exception/38460014#38460014  
* If you're at step 8 of Azure deployment and you can't see "Apply this migration on publish" checkbox this probably means that you have something wrong in project.json.
* If your app crashes at start make sure that you've newest version of .NET Core tools: https://www.microsoft.com/net/download/core#/current

## Azure deployment tutorial:
1. First create new web app  
![](http://i.imgur.com/zArzn8f.png)
2. Download publising profile  
![](http://i.imgur.com/7MZBJWR.png)
3. Create new SQL database instance  
![](http://i.imgur.com/cinW6Ke.png)
4. Copy connection string  
![](http://i.imgur.com/m8njM3z.png)
5. Remember to edit that string with proper user name and password  
6. Right click on your solution and click Publish  
![](http://i.imgur.com/kDUYCCp.png)
7. Import your publishing proflie that you've downloaded in step 2  
![](http://i.imgur.com/HktQsjJ.png)
8. Check both of those checkboxes and paste that edited connection string (step 4/5)
![](http://i.imgur.com/snGD3TZ.png)
9. Pray
10. Now you can edit AzureIoTDemo.ino with SSID, password and IP of your published app and flash it to your IoT device
10. ???
11. Profit.
