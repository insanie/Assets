## overseer.ps1
The main PowerShell script of the application. It uses WMI library to access hardware data of the remote (or local!) PC.
### Input arguments are:
* **Computers** - an array of PC names you wish to scan. *If not provided, will use Computer Group from **conf** file!* Will be ignored completely along with Computer Group from **conf** file if **LocalScan** flag is set.
* **ConfPath** - a string with path to **conf** file. Will be set to .\ if not provided.
* **NoErrors** - a flag that will try to suppress warnings and errors, although not all of those can be suppressed properly. Use in case when you're sure the script will work properly but there's annoying messages about things like missing UID or something.
* **NoConnectionCheck** - a flag that disables connection check for PCs to be scanned. Ignored if **LocalScan** flag is set. *Use ONLY in case when you're sure given PCs are online or you'll get a rainbow of warnings and errors!*
* **ShowQueries** - a flag that will show you what exact SQL queries are being addressed to the database. Debug/maintenance usage.
* **LocalScan** - a flag that will force the script to scan only local PC. Equals to passing 'localhost' to **Computers**. *If set, will ignore both **Computers** and Computer Group from **conf** file!*
* **IncludeServers** - this flag enables the script to scan server OS. By default the script ignores PCs that have 'server' in their OS name.
* **ShowReport** - a flag that will provide output to console of the scanned data. *The script won't show you all the details by default since it will become a mess while scanning multiple PCs!* Also no need to set it up when **NoDatabaseEntry** is set.
* **NoDatabaseEntry** - a flag forbidding the script to upload data to the database.
### Usage examples:
#### Perform local scan of your personal PC (you don't need literally ANYTHING for that - only the script itself):
>.\overseer.ps1 -LocalScan -NoDatabaseEntry
#### Scan particular Computer Group, write the result to the database, and show the report as well. Oh! And we want servers to be there:
>.\overseer.ps1 -Computers "IT Department" -IncludeServers -ShowReport
#### No time to waste! This department is there online and I want to scan it FAST! I don't have 4 seconds for stupid connection check and errors:
>.\overseer.ps1 -Computers "Dodgy Department" -NoConnectionCheck -NoErrors
#### Ok, something went wrong with the database. I need to see if those queries are ok:
>.\overseer.ps1 -Computers "Problem Generating Department" -ShowQueries

## InstallBaseTables.ps1
The script to create all neccessary tables in the database before use.

## basebuild.sql
SQL script to be used in **InstallBaseTables.ps1**.

## DeleteBaseTables.ps1
Feel like something went wrong? Or simply want to reset your database and start again from scratch? Then use this script!
*Don't forget to run **InstallBaseTables.ps1** again after this one!*
