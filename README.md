# _Pierre's Treats_

#### By: _**David Gamble**_

#### _Epicodus project to demonstate many to many relationship with login and authentication using Identity._

## Technologies Used

* _C#_
* _.NET 6_
* _ASP.NET Core MVC 6_
* _Entity Framework Core_
* _MySql_
* _MS Tests_

## Description

_This is a web application that that allows a user to create roles for users and allows users to create accounts and log in.  Users can view Pierre's Treats and Flavors as well as their relationships to each other.  The admin can create, edit, delete, and join Treats and Flavors._

## Setup/Installation Requirements

* _Clone the repository to your desktop from: https://github.com/DavidDGamble/PierresTreats.Solution.git_
* _Create appsettings.json file in PierresTreats folder_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[database_name];uid=[USERNAME];pwd=[PASSWORD];"
  }
}
```
* _run dotnet commands below in PierresTreats_
```
dotnet restore
```
```
dotnet ef database update
```
```
dotnet watch run
```
* _From the Home Page click the Create or manage account link and register an admin and a user_
* _Enter https://localhost:5001/role in the address bar and use the Create a Role link to create and "admin" and a "user"_
* _Use the Update link to add your admin to the admin role and your user to the suer role_
* _Navigate back to the Home Page and log in_
* _The admin will have access to create, edit, delete, and join while all other users have view authorization_
* _If in the roles branch, the user had access to place and view orders. WIP_

## Known Bugs

* _No known issues_
* _roles branch WIP_

## License

_Copyright (c) 2022 David Gamble_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
