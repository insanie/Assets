--
-- creating MAIN table that contains all single-entity params (like OS or motherboard)
CREATE TABLE dbo.main (id int IDENTITY(1,1) PRIMARY KEY, hostname nvarchar(64), session_local int, session_global int, scantime datetime, os_system nvarchar(64), os_arch nvarchar(32), os_build int, os_lang nvarchar(8), mobo_vendor nvarchar(64), mobo_model nvarchar(32), mobo_rev nvarchar(32), bios_vendor nvarchar(64), bios_name nvarchar(64), bios_ver nvarchar(32), ram_totalslots tinyint, ram_occslots tinyint, ram_total real, ram_max real);
--
-- creating USR table with last logged in users for last three months
CREATE TABLE dbo.usr (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, fullname nvarchar(64), place tinyint, logontime datetime, account nvarchar(32), company nvarchar(128), department nvarchar(128), job nvarchar(128));
--
-- creating CPU table with all installed cpu's and their specs
CREATE TABLE dbo.cpu (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, model nvarchar(64), freq smallint, cores tinyint, threads tinyint, socket nvarchar(24));
--
-- creating DRV table with all kind of drives even not mounted to the system
CREATE TABLE dbo.drv (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, model nvarchar(64), size real);
--
-- creating VOL table with all Windows-supported filesystems even not mounted
CREATE TABLE dbo.vol (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, letter nvarchar(4), filesys nvarchar(8), size real, used real, free real);
--
-- creating RAM table with installed memory modules and their specs
CREATE TABLE dbo.ram (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, slot nvarchar(32), freq smallint, size real, vendor nvarchar(32), model nvarchar(32));
--
-- creating NET table containing all network adapters even not active
CREATE TABLE dbo.net (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, model nvarchar(64), conname nvarchar(64), mac nvarchar(24), ena bit, dhcp bit, ip nvarchar(16), mask nvarchar(16), gate nvarchar(16), dns nvarchar(64));
--
-- creating GPU table with all grapics cards installed
CREATE TABLE dbo.gpu (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, model nvarchar(128), driver nvarchar(32));
--
-- creating MON table with all plugged monitors
CREATE TABLE dbo.mon (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, vendor nvarchar(32), model nvarchar(32), sn nvarchar(32));
--
-- creating PRN table with installed printers
CREATE TABLE dbo.prn (id int IDENTITY(1,1) PRIMARY KEY, id_parent int, name nvarchar(64), def bit, shared bit, port nvarchar(64));
--
-- creating SOFT table that contains all installed software
CREATE TABLE dbo.soft (id bigint IDENTITY(1,1) PRIMARY KEY, id_parent int, name nvarchar(128), ver nvarchar(32), path nvarchar(256));
--
-- creating LOG table containing scan status for each pc
CREATE TABLE dbo.log (id int IDENTITY(1,1) PRIMARY KEY, hostname nvarchar(64), scantime datetime, stat bit, session_local int, session_global int);
--
-- creating CHANGES table that contains all changes between configurations among two closest local sessions
CREATE TABLE dbo.changes (id int IDENTITY(1,1) PRIMARY KEY, hostname nvarchar(64), id_current int, id_last int, col nvarchar(32), val_new nvarchar(128), val_old nvarchar(128));