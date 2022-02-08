<h1 align="center">Noroff Assignment 2</h1>

<br>
<p align="center">
	<img src="https://wpguru.co.uk/wp-content/uploads/2020/04/dotnet-logo.png" width="200">
</p>
<br>

[![standard-readme compliant](https://img.shields.io/badge/standard--readme-OK-green.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)
<img alt="Version" src="https://img.shields.io/badge/version-0.1-blue.svg?cacheSeconds=2592000" />

<div href="#" target="_blank">
	<img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
</div>

Noroff assignment number 3. REST API written in C#, using the ASP.NET Core Framework and Entity Framework Core. Written by Konstantinos Pascal.

## Table of Contents

-  [Install](#install)
-  [Usage](#usage)
-  [Maintainers](#maintainers)
-  [Contributing](#contributing)
-  [License](#license)

## Install

Clone the repository using:

```
git clone https://github.com/konstapascal/MovieStoreWebApi.git
```

## Usage

Open the **Chinook_SqlServer_AutoIncrementPKs.sql** file with **SQL Server Management Studio** and execute the script. This will create your **Chinook** database and its tables.

Go to the **ChinookReader/DataAccess/ConnectionHelper.cs** file and change **builder.DataSource** to your own server name. This can be found from within **SSMS** by:

1. Right clicking on your server inside the **Object Explorer**
2. Click on **Properties**, last option
3. Copy the value of the **Name** field

You may now run the **Program.cs** file to see the ouput of the different operations. Changes are also reflected inside the actual database.

## Maintainers

[@konstapascal](https://github.com/konstapascal)

## Contributing

PRs accepted.

## License

MIT © 2022 Konstantinos Pascal
