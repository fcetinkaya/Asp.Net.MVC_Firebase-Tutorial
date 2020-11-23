# Asp.net Mvc - Firebase Tutorial
> Asp.net MVC - Firebase Tutorial {CRUD - File Upload - Notification}

## Table of contents
* [General info](#general-info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Code Examples](#code-examples)

## General info
<h4>Firebase Authentication</h4>

1. Add Nugets for Owin Security and Firebase Authentication
2. Add Firebase Api Key for Configuration
3. Account Controller For Signup,Login and Logoff Methods
4. Add Models for Signup and Login
5. Add Owin Startup Authentication class and Method
6. Verify User from Firebase Authentication then signin user and add user info to Claim Identities


<h4>Firebase CRUD</h4>

1. Signin with Gmail Account

2. Create Project In Firebase 
3. Copy Secret Key for Authentication
4. Create Realtime Database and Copy database Path (Secret Key and Database Path use to Firebase Configuration in C#)
5. Create Asp.net MVC Project
6. Add Firesharp nugget and Add reference in project
7. Add Model and Controller
8. Firebase Configuration in Controller


<h4> Firebase Storage</h4>

1. Install Nuget for Firebase Storage and Auth
2. Post file to View
3. Firebase Storage Connection
4. File Upload to Bucket

## Screenshots
![Example screenshot](./product_list.jpg)
![Example screenshot](./product_AddImage.jpg)

## Technologies
* .NET Framework 4.6.1+
* .NET Standard 3.1, providing .NET Core support
* Install latest version of Visual Studio : https://www.visualstudio.com/downloads/
* ASP.NET MVC Pattern : https://dotnet.microsoft.com/apps/aspnet/mvc
* Firebase : https://firebase.google.com/

## Code Examples
Show examples of usage:
```
 if ('serviceWorker' in navigator) {
                navigator.serviceWorker.register('../firebase-messaging-sw.js')
                    .then(function (registration) {
                        console.log("Service Worker Registered");
                        messaging.useServiceWorker(registration);
                    });
            }

            const messaging = firebase.messaging();

            messaging.requestPermission()
                .then(function () {
                    console.log("granted");
                    if (isTokenSentToServer()) {
                        console.log("already granted");
                    } else {
                        getRegtoken();
                    }
                });
```

