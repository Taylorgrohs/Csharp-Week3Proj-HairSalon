# _C# Hair Salon_

#### _C#, Nancy and Razor project for Epicodus, 02.26.2016_

#### By _**Taylor Grohs**_

## Description

_You can add Hair Stylists and with each stylist you can add clients that see them _

## Setup/Installation Requirements

* To view the project you must clone the files to your desktop and in your powershell run 'dnu restore' while in the project folder, after the restore is complete you then run 'dnx kestrel' and type localhost:5004 into your browser.

* Database used:
* CREATE DATABASE hairsalon;
* GO
* USE hairsalon;
* GO
* CREATE TABLE stylist(id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE client(id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
* GO

## Support and contact details

_Email me at taylorgrohs@gmail.com_


### License

*MIT*

Copyright (c) 2016 **_Epicodus_**
