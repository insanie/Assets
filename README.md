# overseer - *the automated Windows PC inventorization tool*
## What does it do?
To put it simply - ***overseer*** helps you to keep hardware data about all PCs in your domain organized and relevant. It polls computers from a certain Computer Group in your domain and then stores retrieved data in an SQL Server database. You can then access this database via simple desktop app or use the database itself to create you own queries and reports.

## How does it work?
### PowerShell script
PowerShell script operates on a Windows machine via Task Scheduler collecting data about available PCs. The script has several arguments and a configuration file. The arguments provide options to operate outside the Task Scheduler routine and scan PCs whenever you want, scan a single PC, or scan localhost PC. Also you can suppress error messages, show SQL queries, disable connection check, etc. The configuration file stores simple data like database the script should address and a Computer Group in your domain you wish to scan. Additional information about PowerSheel script you can find in a corresponding readme.
### SQL Server database
SQL Server database stores all the data in a pretty comprehensive set of tables. While you can familiarize yourself with its structure, you will find it straightforward and easy to use for your own queries, reports, or projects built over it.
### C# desktop app
Desktop app is a simple Windows Forms app that allows you to search through scanned PCs and their scan dates and inspect a specific one scanned data as a table inside the same app. It also has its configuration file that keeps settings for accessing the database (but not credentials!).

## Deployment
As ***overseer*** has no packages or installable features, it simply reqires to download scripts and desktop app. After a couple of manipulations you'll be ready to go for your first scan in no time!
### Requirements
1. Active Directory - ***overseer*** works **ONLY** with domain based on Windows as it requires special credentials that will fit all the PCs (and database permissions as well!). *A client-based solution would eradicate such dependencies but we're here for clientlessness, right?*
2. SQL Server - you can try to use any other SQL solution, but be ready to tinker SQL queries in sources and face credentials issue. You can also try SQL Server Express keeping in mind space limitations. *A year of 3 times per week polls of ~2500 PCs resulted in almost 1 GB database.*
3. PowerShell 4.0+ on all PCs - that means Windows 8 and above. Most of properly updated Windows 7 machines will work just fine. Windows XP ships with **NO** PowerShell, so be aware.
4. A machine to run PowerSheel script on - the same requirements as above.
### Create new account
Create a new account in AD that has **administrator rights** for all the PCs. You can simply put it into Domain Admins group but that's a **BAD** idea! Better create a new policy that adds this account to local Administrators group on your PCs. This account will be needed **ONLY** to run the script and then access future database, so no actual person will use it!
### Create new database
Create a new database in your SQL Server. Give the newly created account full access to the database. You can give any other groups or accounts permissions to the database in case they would need to access it.
### Edit configuration file
Open ***conf*** file with any text editor. You will find three lines there:
1. Your SQL Server machine name
2. Your database name
3. A Computer Group you wish to scan - *it is set to Domain Computers by default*
Edit those lines accordingly to your setup.
### Create tables in database
Execute script ***InstallBaseTables.ps1*** to create tables in the database. *NOTE: you have to run the script as an account with full access to the database. You can use the newly created account for that.*
### Choose machine to run the main script on
You need to find a computer that will perform scans. It doesn't have to be a server or some kind of dedicated machine. The performance impact from running the script is close to zero.
### Setup script run schedule
Copy files ***overseer.ps1*** and ***conf*** anywhere you find reasonable - they're the only ones needed to perform scan. Open Task Scheduler and create new task. Set up executing ***overseer.ps1*** with argument *-ConfPath "full_path_to_conf_file"*. Even tho the script with automatically search for conf file near itself if no such argument passed, script execution from the task is slightly different, so keep full path to ***conf***. Schedule any time you find pleasable for your case - try to find the time when all your PC should be online. Choose that special account you created as an account to run task as! *NOTE: read how to properly run a PowerShell script in a task to avoid many errors. It's a 5 min read but it will save you much more!*
### Final
That's it! ***overseer*** will now poll your PCs according to the schedule you set up!
OPTIONAL
## Usage
