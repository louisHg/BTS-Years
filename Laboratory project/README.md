# Laboratory project
Goal : Access and inventory management of a laboratory containing hazardous products.
![header image](https://raw.github.com/louisHg/BTS-Years/main/Laboratory%20project/capture%20écran%20projet/labo%20pp.png)

## Mission

Here, my mission is to simulate an inventory management. 
That's why i used a microsystem (Raspberry) and an interface which takes the balance measurements and indicating the location of the products with the leds.


## Solution

I held like solutions to used a Raspberry Pi 3 like microsystem, a leds strips Néo-Pixel, a serial balance and an interface wxPython programmed on Raspberry.

![header image](https://raw.github.com/louisHg/BTS-Years/main/Laboratory%20project/capture%20écran%20projet/materials.png)

## Install

```bash
Install mysql.connector  to connected raspberry programme and the code : pip install mysql-connector-python
Install xampp or lamp on the terminal : sudo apt install mariadb-server php-mysql
Don't Forget to put an IP fixed address !!!
Install Python3 : sudo apt-get install python3-wxgtk4.0 python3-wxgtk-webview4.0 python3-wxgtk-media4.0
Install "rpi_ws281x" library :  sudo pip install rpi_ws281x
Install WxPython : "sudo pip3 install wxpython" or follow the link https://hoyoung2.blogspot.com/2019/01/install-wxpython-404-in-raspberry-pi.html
Selected the folder Serial to used the weigher
And Go to phpmyadmin.net to copy the database on "labo1.sql"
```
