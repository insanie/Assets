# overseer - *the automated Windows PC inventorization tool*
## What does it do?
To put it simply - ***overseer*** helps you to keep hardware data about all PCs in your domain organized and relevant. It polls computers from a certain Computer Group in your domain and then stores retrieved data in an SQL Server database. You can then access this database via simple desktop app or use the database itself to create you own queries and reports.

## Who is it for?
***overseer*** can be of use for small/middle businesses running Active Directory and about hundreds of PCs. It is known to be challenging to keep track of all PCs being in use and their hardware state. Like, is it new? Will it support this new software we're about to use? Why is this user struggling with their PC, is it obsolete that much? And of course you would like to have some reports of any kind to plan upgrades of your hardware. This can be manageable when we talk about dozens of PCs you can simply try to remember or keep track in a spreadsheet and update it manually. When it crawls to a hundred of PCs the amount of work dedicated to gather and update the data is unbearable. There's some built-in Active Directory features to keep track of it, but it's a restricted amount of data and is mostly useless. Also you can try some opensource or even commercial products to do so, but they are client-based and require additional software installed on your PCs.

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
Copy files ***overseer.ps1*** and ***conf*** anywhere you find reasonable - they're the only ones needed to perform scan. Open Task Scheduler and create new task. Set up executing ***overseer.ps1*** with argument *-ConfPath "full_path_to_conf_file"*. Even tho the script will automatically search for conf file near itself if no such argument passed, script execution from the task is slightly different, so keep full path to ***conf***. Schedule any time you find pleasable for your case - try to find the time when all your PC should be online. Choose that special account you created as an account to run task as! *NOTE: read how to properly run a PowerShell script in a task to avoid many errors. It's a 5 min read but it will save you much more!*
### Final
That's it! ***overseer*** will now poll your PCs according to the schedule you set up!

## Usage
After your first successfull scan you're able to browse through scanned data with desktop app. Open it as an account with permissions at least **to read** the database. Once you opened it click on a button with no label to open settings and set up your SQL Server name and database name - just as you did in ***conf*** file! *Also you can manually edit **overseer desktop.exe.config*** to put those parameters in place. Save those settings and return to the main window of the app. Type the name of a specific PC in the upper text box and hit Enter. You will see either a list of dates with sufficient data regarding this PC or a message that there's no record about such PC. Double click on any record you want to see or choose it with up/down arrows on your keyboard and press Enter. The app will briefly show a progressbar displaying how the databased is being queried. After that it will open a separate window with scanned data about the PC. It is seperated into several categories and tab so you can easily make a conclusion about PC configuration and it's software state. Close this window and try again with a different PC and so on.

## Modification
You can rewrite some of ***overseer's*** mechanics by diving into **PowerShell** folder - there's a detailed description of algorithms and technologies used in the code! I tried to keep it simple while useful, so everybody can modify it for their needs.
