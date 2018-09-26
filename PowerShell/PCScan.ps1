param
	(
	[parameter(Position=0)]
	[string[]]$Computers,
	[string]$ConfPath,
	[switch]$NoErrors,
	[switch]$NoConnectionCheck,
	[switch]$ShowQueries,
	[switch]$LocalScan,
	[switch]$IncludeServers,
	[switch]$ShowReport,
	[switch]$NoDatabaseEntry
	)

# declaring function for processing sql queries
function SQLQuery
	{
	param
		(
    	[parameter(Position=0)]
    	[string[]]$commandlist
		)
	$connection = New-Object System.Data.SqlClient.SqlConnection("Server=$($conf[0]); Database=$($conf[1]); Trusted_Connection=Yes; Integrated Security=SSPI;")
	$connection.Open()
	foreach ($line in $commandlist)
	    {
    	$command = $connection.CreateCommand()
		if ($ShowQueries) {$line}
    	$command.CommandText = $line
    	$command.CommandTimeout = 0
    	$adapter = New-Object System.Data.SqlClient.SqlDataAdapter $command
    	$dataset = New-Object System.Data.DataSet
    	$adapter.Fill($dataset) | Out-Null
		$dataset.Tables
    	}
	$connection.Close()
	}

# adding option to disable error spam in console
if ($NoErrors) {$ErrorActionPreference = "SilentlyContinue"}

# opening configuration file
if ($ConfPath.length -eq 0) {$conf = Get-Content (".\conf")}
else {$conf = Get-Content ($ConfPath + "\conf")}

# defining global session for this particular run
if (-not ($NoDatabaseEntry))
	{
	$session_global = (SQLQuery "SELECT TOP 1 session_global FROM dbo.log ORDER BY session_global DESC;").session_global
	if ($session_global -ne [System.DBNull]::Value) {$session_global ++}
	else {$session_global = 1}
	}

# putting localhost or conf group to computers list array if empty
if ($Computers.count -eq 0)
	{
	if ($LocalScan)
		{
		$Computers = $env:COMPUTERNAME
		Write-Host ("`nNo computer name defined, will assume localhost ",$env:COMPUTERNAME) -Separator "" -ForegroundColor Yellow
		}
	else {$Computers = (Get-ADGroupMember $conf[2]).name}
	}

# adding counter to build progressbar
$count = 0

# main loop starts
foreach ($PC in $Computers)
	{
	$count ++
	Write-Host ("`nPC #", $count, " out of ", $Computers.length, " is being scanned...") -Separator ""

	# check if os is a server os
	if (-not ($IncludeServers))
		{
		if ((Get-ADComputer $PC -Properties OperatingSystem).OperatingSystem -like "*server*")
			{
			Write-Host ($PC, " is a ") -NoNewline -Separator ""
			Write-Host ("server") -NoNewline -ForegroundColor Yellow
			Write-Host (", use IncludeServers switch to allow server scan.")
			continue
			}
		}

	# definign current time and date
	$scantime = Get-Date -Format "yyyy-MM-dd HH:mm:ss"

	# connectivity check if pc is not localhost
	if (($PC -ne $env:COMPUTERNAME) -and (-not $NoConnectionCheck))
		{
		Write-Host ("Checking connection to ",$PC,", please wait...") -Separator ""
		if (Test-Connection $PC -Count 1 -ErrorAction SilentlyContinue)
			{
			Write-Host ($PC," is ") -Separator "" -NoNewline
			Write-Host ("online") -NoNewline -ForegroundColor Green
			Write-Host (", verifying priviledges...")
			if (Test-Connection -Source $PC -ComputerName localhost -Count 1 -ErrorAction SilentlyContinue)
				{
				Write-Host ("You ") -NoNewline
				Write-Host ("have") -NoNewline -ForegroundColor Green
				Write-Host (" sufficient priviledges, proceeding to scan...")
				}
			else
				{
				Write-Host ("You ") -NoNewline
				Write-Host ("don't have") -NoNewline -ForegroundColor Red
				Write-Host (" sufficient priviledges, stopping operations.")
				if (-not ($NoDatabaseEntry))
					{
					$session_local = (SQLQuery "SELECT TOP 1 session_local FROM dbo.log WHERE hostname='$PC' ORDER BY session_local DESC;").session_local
					if ($session_local -ne [System.DBNull]::Value) {$session_local ++}
					else {$session_local = 1}
					# adding log entry for failed scan		
					SQLQuery "INSERT INTO dbo.log VALUES ('$PC', CAST (N'$scantime' AS datetime), 0, $session_local, $session_global)"
					}
				continue
				}
			}
		else
			{
			Write-Host ($PC," is ") -Separator "" -NoNewline
			Write-Host ("offline") -NoNewline -ForegroundColor Red
			Write-Host (", stopping operations.")
			if (-not ($NoDatabaseEntry))
				{
				$session_local = (SQLQuery "SELECT TOP 1 session_local FROM dbo.log WHERE hostname='$PC' ORDER BY session_local DESC;").session_local
				if ($session_local -ne [System.DBNull]::Value) {$session_local ++}
				else {$session_local = 1}
				# adding log entry for failed scan		
				SQLQuery "INSERT INTO dbo.log VALUES ('$PC', CAST (N'$scantime' AS datetime), 0, $session_local, $session_global)"
				}
			continue
			}
		}

	# filling USR array
	$count = 0
	$tmp = Get-WmiObject -Class Win32_ComputerSystem -ComputerName $PC
	if (Get-ADUser ($tmp.UserName -replace '.*\\','') -ErrorAction 'SilentlyContinue')
		{
		$usr_primary = New-Object PSObject
		$usr_primary | Add-Member NoteProperty "fullname" (Get-ADUser ($tmp.UserName -replace '.*\\','')).Name
		$usr_primary | Add-Member NoteProperty "place" $count
		$usr_primary | Add-Member NoteProperty "account" (Get-ADUser ($tmp.UserName -replace '.*\\','')).SAMAccountName
		$usr_primary | Add-Member NoteProperty "company" (Get-ADUser ($tmp.UserName -replace '.*\\','') -Properties Company).Company
		$usr_primary | Add-Member NoteProperty "department" (Get-ADUser ($tmp.UserName -replace '.*\\','') -Properties Department).Department
		$usr_primary | Add-Member NoteProperty "job" (Get-ADUser ($tmp.UserName -replace '.*\\','') -Properties Description).Description
		}
	else {Write-Host ("Cannot find SID ", ($tmp.UserName -replace '.*\\',''), " that will be skipped.") -ForegroundColor Red}
	$filt = "NOT SID = 'S-1-5-18' AND NOT SID = 'S-1-5-19' AND NOT SID = 'S-1-5-20'"
	$usrSQL = @()
	foreach ($tmp in (Get-WmiObject -Class Win32_UserProfile -Filter $filt -ComputerName $PC | Where-Object {($_.LastUseTime -ne $null) -and (([System.Management.ManagementDateTimeConverter]::ToDateTime($_.LastUseTime)) -gt (Get-Date).AddDays(-90))} | Sort-Object LastUseTime -Descending))
		{
		if (Get-ADUser $tmp.SID -ErrorAction 'SilentlyContinue')
			{
			$count ++
			$obj = New-Object PSObject
			$obj | Add-Member NoteProperty "fullname" (Get-ADUser $tmp.SID).Name
	    	$time = [System.Management.ManagementDateTimeConverter]::ToDateTime($tmp.LastUseTime)
	    	$obj | Add-Member NoteProperty "logontime" $time
			$obj | Add-Member NoteProperty "place" $count
	    	$obj | Add-Member NoteProperty "account" (Get-ADUser $tmp.SID).SAMAccountName
	    	$obj | Add-Member NoteProperty "company" (Get-ADUser $tmp.SID -Properties Company).Company
	    	$obj | Add-Member NoteProperty "department" (Get-ADUser $tmp.SID -Properties Department).Department
	    	$obj | Add-Member NoteProperty "job" (Get-ADUser $tmp.SID -Properties Description).Description
			$usrSQL += $obj
			}
		else {Write-Host ("Cannot find SID ", $tmp.SID, " that will be skipped.") -ForegroundColor Red}
		}

	# filling OS array
	$osSQL = New-Object PSObject
	$tmp = Get-WmiObject -Class win32_operatingsystem -ComputerName $PC
	$osSQL | Add-Member NoteProperty "system" $tmp.Caption
	$osSQL | Add-Member NoteProperty "arch" $tmp.OSArchitecture
	$osSQL | Add-Member NoteProperty "build" $tmp.BuildNumber
	# fix for XP's MUILanguages property missing
	if ($osSQL.system -like "*windows xp*") {$osSQL | Add-Member NoteProperty "lang" $tmp.OSLanguage}
	else {$osSQL | Add-Member NoteProperty "lang" ($tmp.MUILanguages -replace ('[\{\}]',''))}

	# filling CPU array
	$cpuSQL = @()
	foreach ($tmp in (Get-WmiObject -class win32_processor -ComputerName $PC))
		{
		$obj = New-Object PSObject	
		$obj | Add-Member NoteProperty "model" $tmp.Name
		$obj | Add-Member NoteProperty "freq" $tmp.MaxClockSpeed
		$obj | Add-Member NoteProperty "cores" $tmp.NumberOfCores
	    $obj | Add-Member NoteProperty "threads" $tmp.NumberOfLogicalProcessors
		$obj | Add-Member NoteProperty "socket" $tmp.SocketDesignation
		# fix for XP's OSArchitecture property missing
		if ($osSQL.system -like "*windows xp*") {$osSQL.arch = $tmp.AddressWidth}
		$cpuSQL += $obj
		}

	# filling MOBO array
	$moboSQL = New-Object PSObject
	$tmp = Get-WmiObject -class win32_baseboard -ComputerName $PC
	$moboSQL | Add-Member NoteProperty "vendor" $tmp.Manufacturer
	$moboSQL | Add-Member NoteProperty "model" $tmp.Product
	$moboSQL | Add-Member NoteProperty "rev" $tmp.Version

	# filling BIOS array
	$biosSQL = New-Object PSObject
	$tmp = Get-WmiObject -class win32_bios -ComputerName $PC
	$biosSQL | Add-Member NoteProperty "vendor" $tmp.Manufacturer
	$biosSQL | Add-Member NoteProperty "name" $tmp.Name
	$biosSQL | Add-Member NoteProperty "ver" $tmp.Version

	# filling DRV array
	$drvSQL = @()
	foreach ($tmp in (Get-WmiObject -class win32_diskdrive -ComputerName $PC | where-object {($_.InterfaceType -eq "IDE") -or ($_.InterfaceType -eq "USB") -or ($_.Model -like "*Raid*")}))
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "model" $tmp.Model
		$obj | Add-Member NoteProperty "size" ($tmp.Size/1000000000)
		$drvSQL += $obj
		}

	# filling VOL array
	$volSQL = @()
	foreach ($tmp in (Get-WmiObject -class win32_logicaldisk -ComputerName $PC | where-object {($_.drivetype -eq 3) -and ($_.DeviceID -ne $null)}))
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "letter" $tmp.DeviceID
		$obj | Add-Member NoteProperty "filesys" $tmp.FileSystem
		$obj | Add-Member NoteProperty "size" ($tmp.Size/1000000000)
		$obj | Add-Member NoteProperty "used" (($tmp.Size-$tmp.FreeSpace)/1000000000)
		$obj | Add-Member NoteProperty "free" ($tmp.FreeSpace/1000000000)
		$volSQL += $obj
		}

	# filling RAM arrays, first one is for common single-entity info, second is for dimms
	$ramSQL1 = New-Object PSObject
	$ramSQL2 = @()
	$ram = Get-WmiObject -class win32_physicalmemoryarray -ComputerName $PC
	$dimms = Get-WmiObject -class win32_physicalmemory -ComputerName $PC
	if ($dimms -is [array]) {$ramSQL1 | Add-Member NoteProperty "occslots" $dimms.Length}
	else {$ramSQL1 | Add-Member NoteProperty "occslots" 1}
	$ramSQL1 | Add-Member NoteProperty "totalslots" (($ram.MemoryDevices | Measure-Object -sum).Sum)
	$ramSQL1 | Add-Member NoteProperty "total" ((($dimms.capacity | Measure-Object -sum).Sum)/1073741824)
	if ($ram.MaxCapacity -ne 0) {$ramSQL1 | Add-Member NoteProperty "max" ((($ram.MaxCapacity | Measure-Object -sum).Sum)/1048576)}
	else {$ramSQL1 | Add-Member NoteProperty "max" 0}
	foreach ($tmp in $dimms)
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "slot" $tmp.DeviceLocator
		if ($tmp.Speed) {$obj | Add-Member NoteProperty "freq" $tmp.Speed}
		else {$obj | Add-Member NoteProperty "freq" 0}
		$obj | Add-Member NoteProperty "size" ($tmp.Capacity/1073741824)
		$obj | Add-Member NoteProperty "vendor" $tmp.Manufacturer
		$obj | Add-Member NoteProperty "model" $tmp.PartNumber
		$ramSQL2 += $obj
		}

	# filling NET array
	$netSQL = @()
	$lans = Get-WmiObject -Class win32_networkadapter -ComputerName $PC | where PhysicalAdapter -eq "True"
	$nets = Get-WmiObject -Class win32_networkadapterconfiguration -ComputerName $PC | Where-Object {$_.Description -in $lans.Name}
	foreach ($tmp in $lans)
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "model" $tmp.Name
		$obj | Add-Member NoteProperty "conname" $tmp.NetConnectionID
		if ($tmp.MACAddress -ne $null) {$obj | Add-Member NoteProperty "mac" $tmp.MACAddress}
		else {$obj | Add-Member NoteProperty "mac" "Not set"}
		if ($tmp.NetEnabled -eq "True")
			{
			$obj | Add-Member NoteProperty "ena" 1
			if (($nets | Where-Object {$_.description -eq $tmp.name}).DHCPEnabled[0] -eq "True") {$obj | Add-Member NoteProperty "dhcp" 1}
			else {$obj | Add-Member NoteProperty "dhcp" 0}
			$obj | Add-Member NoteProperty "ip" ($nets | Where-Object {$_.description -eq $tmp.name}).ipaddress[0]
			$obj | Add-Member NoteProperty "mask" ($nets | Where-Object {$_.description -eq $tmp.name}).ipsubnet[0]
			if ((($nets | Where-Object {$_.description -eq $tmp.name}).DefaultIPGateway) -ne $null) {$obj | Add-Member NoteProperty "gate" ($nets | Where-Object {$_.description -eq $tmp.name}).DefaultIPGateway[0]}
			else {$obj | Add-Member NoteProperty "gate" "Not set"}

			if ((($nets | Where-Object {$_.description -eq $tmp.name}).DNSServerSearchOrder) -ne $null) {$obj | Add-Member NoteProperty "dns" (($nets | Where-Object {$_.description -eq $tmp.name}).DNSServerSearchOrder -join ", ")}
			else {$obj | Add-Member NoteProperty "dns" "Not set"}
			}
		else
			{
			$obj | Add-Member NoteProperty "ena" 0
			$obj | Add-Member NoteProperty "dhcp" 0
			$obj | Add-Member NoteProperty "ip" "Adapter disabled"
			$obj | Add-Member NoteProperty "mask" "Adapter disabled"
			$obj | Add-Member NoteProperty "gate" "Adapter disabled"
			$obj | Add-Member NoteProperty "dns" "Adapter disabled"
			}
		$netSQL += $obj
		}

	# filling GPU array
	$gpuSQL = @()
	foreach ($tmp in (Get-WmiObject -Class win32_videocontroller -ComputerName $PC))
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "model" $tmp.Name
		$obj | Add-Member NoteProperty "driver" $tmp.DriverVersion
		$gpuSQL += $obj
		}

	# filling MON array
	$monSQL = @()
	foreach ($tmp in (Get-WmiObject -Class WmiMonitorID -Namespace root\wmi -ComputerName $PC))
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "vendor" (($tmp.ManufacturerName -ne '0' | foreach {[char]$_}) -join "")
		$obj | Add-Member NoteProperty "model" (($tmp.UserFriendlyName -ne '0' | foreach {[char]$_}) -join "")
		$obj | Add-Member NoteProperty "sn" (($tmp.SerialNumberID -ne '0' | foreach {[char]$_}) -join "")
		$monSQL += $obj
		}

	# filling PRN array
	$prnSQL = @()
	foreach ($tmp in (Get-WmiObject -Class win32_printer -ComputerName $PC))
		{
		$obj = New-Object PSObject
		$obj | Add-Member NoteProperty "name" $tmp.Name
		if ($tmp.Default -eq "True") {$obj | Add-Member NoteProperty "def" 1}
		else {$obj | Add-Member NoteProperty "def" 0}
		if ($tmp.Shared -eq "True") {$obj | Add-Member NoteProperty "shared" 1}
		else {$obj | Add-Member NoteProperty "shared" 0}
		$obj | Add-Member NoteProperty "port" $tmp.PortName
		$prnSQL += $obj
		}

	# filling SOFT array
	$softSQL = @()
	$RegistryLocation = 'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\','SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\'
	if ($PC -ne $env:COMPUTERNAME)
	    {
	    Set-Service -Name RemoteRegistry -Computer $PC -StartupType Manual
	    Get-Service -Name RemoteRegistry -ComputerName $PC | Start-Service
	    }
	$socket = New-Object Net.Sockets.TcpClient($PC,445)
	if ($socket.Connected)
	    {
	    $RegBase = [Microsoft.Win32.RegistryKey]::OpenRemoteBaseKey([Microsoft.Win32.RegistryHive]::LocalMachine,$PC)
	    $RegistryLocation | ForEach-Object `
       		{
       		$CurrentReg = $_
       		if ($RegBase)
	            {
           		$CurrentRegKey = $RegBase.OpenSubKey($CurrentReg)
           		if ($CurrentRegKey)
	                {
               		$CurrentRegKey.GetSubKeyNames() | ForEach-Object `
	                    {
                   		if (($RegBase.OpenSubKey("$CurrentReg$_")).GetValue('DisplayName'))
	                        {
                       		$obj = New-Object PSObject
                       		$obj | Add-Member NoteProperty "name" ((($RegBase.OpenSubKey("$CurrentReg$_")).GetValue("DisplayName")) -replace '''','''''')
                       		$obj | Add-Member NoteProperty "ver" (($RegBase.OpenSubKey("$CurrentReg$_")).GetValue("DisplayVersion"))
                       		$obj | Add-Member NoteProperty "path" (($RegBase.OpenSubKey("$CurrentReg$_")).GetValue("InstallLocation"))
                       		$softSQL += $obj
                       		}
                   		$socket.Close()
                   		}
               		}
           		}
       		}
   		}
	if ($PC -ne $env:COMPUTERNAME) {Set-Service -Name RemoteRegistry -Computer $PC -StartupType Disabled}

	# writing to database all the info
	if (-not ($NoDatabaseEntry))
		{
		# getting new local session for current PC
		$session_local = (SQLQuery "SELECT TOP 1 session_local FROM dbo.log WHERE hostname='$PC' ORDER BY session_local DESC;").session_local
		if ($session_local -ne [System.DBNull]::Value) {$session_local ++}
		else {$session_local = 1}

		# filling MAIN table entry and getting given id
		SQLQuery "INSERT INTO dbo.main VALUES ('$PC', $session_local, $session_global, CAST (N'$scantime' AS datetime), N'$($osSQL.system)', N'$($osSQL.arch)', $($osSQL.build), '$($osSQL.lang)', '$($moboSQL.vendor)', '$($moboSQL.model)', '$($moboSQL.rev)', '$($biosSQL.vendor)', '$($biosSQL.name)', '$($biosSQL.ver)', $($ramSQL1.totalslots), $($ramSQL1.occslots), $($ramSQL1.total), $($ramSQL1.max));"
		$id_parent = (SQLQuery "SELECT id FROM dbo.main WHERE hostname='$PC' AND session_local = $session_local;").id

		# starting building a list of queries for all secondary tables entries
		$querylist = @()
		$querylist += "INSERT INTO dbo.usr (id_parent, fullname, place, account, company, department, job) VALUES ($id_parent, N'$($usr_primary.fullname)', $($usr_primary.place), '$($usr_primary.account)', N'$($usr_primary.company)', N'$($usr_primary.department)', N'$($usr_primary.job)');"
		foreach ($tmp in $usrSQL)
			{
			$querylist += "INSERT INTO dbo.usr VALUES ($id_parent, N'$($tmp.fullname)', $($tmp.place), CAST (N'$($tmp.logontime)' AS datetime), '$($tmp.account)', N'$($tmp.company)', N'$($tmp.department)', N'$($tmp.job)');"
			}
		foreach ($tmp in $cpuSQL)
			{
			$querylist += "INSERT INTO dbo.cpu VALUES ($id_parent, N'$($tmp.model)', $($tmp.freq), $($tmp.cores), $($tmp.threads), '$($tmp.socket)');"
			}
		foreach ($tmp in $drvSQL)
			{
			$querylist += "INSERT INTO dbo.drv VALUES ($id_parent, '$($tmp.model)', $($tmp.size));"
			}
		foreach ($tmp in $volSQL)
			{
			$querylist += "INSERT INTO dbo.vol VALUES ($id_parent, '$($tmp.letter)', '$($tmp.filesys)', $($tmp.size), $($tmp.used), $($tmp.free));"
			}
		foreach ($tmp in $ramSQL2)
			{
			$querylist += "INSERT INTO dbo.ram VALUES ($id_parent, '$($tmp.slot)', $($tmp.freq), $($tmp.size), '$($tmp.vendor)', '$($tmp.model)');"
			}
		foreach ($tmp in $netSQL)
			{
			$querylist += "INSERT INTO dbo.net VALUES ($id_parent, N'$($tmp.model)', N'$($tmp.conname)', '$($tmp.mac)', $($tmp.ena), $($tmp.dhcp), '$($tmp.ip)', '$($tmp.mask)', '$($tmp.gate)', '$($tmp.dns)');"
			}
		foreach ($tmp in $gpuSQL)
			{
			$querylist += "INSERT INTO dbo.gpu VALUES ($id_parent, N'$($tmp.model)', '$($tmp.driver)');"
			}
		foreach ($tmp in $monSQL)
			{
			$querylist += "INSERT INTO dbo.mon VALUES ($id_parent, '$($tmp.vendor)', '$($tmp.model)', '$($tmp.sn)');"
			}
		foreach ($tmp in $prnSQL)
			{
			$querylist += "INSERT INTO dbo.prn VALUES ($id_parent, N'$($tmp.name)', $($tmp.def), $($tmp.shared), N'$($tmp.port)');"
			}
		foreach ($tmp in $softSQL)
			{
			$querylist += "INSERT INTO dbo.soft VALUES ($id_parent, N'$($tmp.name)', N'$($tmp.ver)', N'$($tmp.path)');"
			}

		# adding successfull scan log entry
		$querylist += "INSERT INTO dbo.log VALUES ('$PC', CAST (N'$scantime' AS datetime), 1, $session_local, $session_global);"

		# executing list of queries
		SQLQuery $querylist
		Write-Host ("Scanning ", $PC," is complete, database entries are written.") -Separator "" -ForegroundColor Yellow
		}

	# showing graphical report
	if ($ShowReport -or $NoDatabaseEntry)
		{
		# USR block
		Write-Host "`nCurrent User" -NoNewLine
		Write-Host " ---`n" -ForegroundColor DarkGray
		Write-Host ($usr_primary.fullname) -NoNewLine -ForegroundColor Gray
		Write-Host (" | No logon time | ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($usr_primary.account) -NoNewLine -ForegroundColor Gray
		Write-Host (" | ", $usr_primary.job, " | ") -Separator "" -NoNewLine -ForegroundColor DarkGray
		Write-Host ($usr_primary.department) -NoNewLine -ForegroundColor Gray
		Write-Host (" | ", $usr_primary.company, "`n") -Separator "" -ForegroundColor DarkGray
		Write-Host "Last Users" -NoNewLine
		Write-Host " -----`n" -ForegroundColor DarkGray
		foreach ($tmp in $usrSQL)
			{
			Write-Host ($tmp.fullname) -NoNewLine -ForegroundColor Gray
			Write-Host (" | ", $tmp.logontime, " | ") -Separator "" -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.account) -NoNewLine -ForegroundColor Gray
			Write-Host (" | ", $tmp.job, " | ") -Separator "" -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.department) -NoNewLine -ForegroundColor Gray
			Write-Host (" | ", $tmp.company) -Separator "" -ForegroundColor DarkGray
			}
		Write-Host

		# OS block
		Write-Host "Operating System`n"
		Write-Host ("System`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($osSQL.system) -ForegroundColor Gray
		Write-Host ("Architecture`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($osSQL.arch) -ForegroundColor Gray
		Write-Host ("Build`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($osSQL.build) -ForegroundColor Gray
		Write-Host ("Language`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($osSQL.lang, "`n") -Separator "" -ForegroundColor Gray

		# CPU block
		Write-Host "CPU" -NoNewLine
		Write-Host " ------------`n" -ForegroundColor DarkGray
		foreach ($tmp in $cpuSQL)
			{
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model) -ForegroundColor Gray
			Write-Host ("Frequency`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.freq, " MHz") -Separator "" -ForegroundColor Gray
			Write-Host ("Cores/Threads`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.cores, "/" ,$tmp.threads) -Separator "" -ForegroundColor Gray
			Write-Host ("Socket`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.socket, "`n") -Separator "" -ForegroundColor Gray
			}

		# MOBO block
		Write-Host "Motherboard" -NoNewLine
		Write-Host " ----`n" -ForegroundColor DarkGray
		Write-Host ("Vendor`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($moboSQL.vendor) -ForegroundColor Gray
		Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($moboSQL.model) -ForegroundColor Gray
		Write-Host ("Revision`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($moboSQL.rev, "`n") -Separator "" -ForegroundColor Gray

		# BIOS block
		Write-Host "BIOS" -NoNewLine
		Write-Host " ----------`n" -ForegroundColor DarkGray
		Write-Host ("Vendor`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($biosSQL.vendor) -ForegroundColor Gray
		Write-Host ("Name`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($biosSQL.name) -ForegroundColor Gray
		Write-Host ("Version`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($biosSQL.ver, "`n") -Separator "" -ForegroundColor Gray

		# HDD block
		Write-Host "Drives" -NoNewLine
		Write-Host " ---------`n" -ForegroundColor DarkGray
		foreach ($tmp in $drvSQL)
			{
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model) -ForegroundColor Gray
			Write-Host ("Size`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ([math]::round($tmp.size,1)," GB`n") -Separator "" -ForegroundColor Gray
			}
		
		# VOL block
		Write-Host "Partitions" -NoNewLine
		Write-Host " -----`n" -ForegroundColor DarkGray
		foreach ($tmp in $volSQL)
			{
			Write-Host ("Drive`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.letter) -ForegroundColor Gray
			Write-Host ("Filesystem`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.filesys) -ForegroundColor Gray
			Write-Host ("Size`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ([math]::round($tmp.size,1), " GB") -Separator "" -ForegroundColor Gray
			Write-Host ("Used/Free`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ([math]::round($tmp.used,1), " GB ") -Separator "" -NoNewLine -ForegroundColor Gray
			$perc = [math]::round((($tmp.used/$tmp.size)*100),0)
			Write-Host ($perc, "% ") -NoNewLine -Separator "" -ForegroundColor DarkGray
			for ($i = 1; $i -le 20; $i++)
				{
				if ($i -le ([math]::round(($perc/5),0))) {Write-Host (" ") -NoNewLine -BackgroundColor White}
				else {Write-Host (" ") -NoNewLine -BackgroundColor DarkGray}
				}
			Write-Host (" ",(100-$perc), "% ") -NoNewLine -Separator "" -ForegroundColor DarkGray
			Write-Host ([math]::round($tmp.free,1), " GB`n") -Separator "" -ForegroundColor Gray
			}
		
		# RAM block
		Write-Host "RAM" -NoNewLine
		Write-Host " ------------`n" -ForegroundColor DarkGray
		Write-Host ("Slots occupied`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($ramSQL1.occslots, " of ",$ramSQL1.totalslots) -Separator "" -ForegroundColor Gray
		Write-Host ("Total RAM`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($ramSQL1.total, " GB") -Separator "" -ForegroundColor Gray
		Write-Host ("Max RAM`t`t| ") -NoNewLine -ForegroundColor DarkGray
		Write-Host ($ramSQL1.max, " GB`n") -Separator "" -ForegroundColor Gray
		foreach ($tmp in $ramSQL2)
			{
			Write-Host ("Slot`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.slot) -ForegroundColor Gray
			Write-Host ("Frequency`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.freq, " MHz") -Separator "" -ForegroundColor Gray
			Write-Host ("Size`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.size, " GB") -Separator "" -ForegroundColor Gray
			Write-Host ("Vendor`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.vendor) -ForegroundColor Gray
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model, "`n") -Separator "" -ForegroundColor Gray
			}

		# LAN block
		Write-Host "Networking"-NoNewLine
		Write-Host " -----`n" -ForegroundColor DarkGray
		foreach ($tmp in $netSQL)
			{
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model) -ForegroundColor Gray
			Write-Host ("Connection name`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.conname) -ForegroundColor Gray
			Write-Host ("MAC address`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.mac) -ForegroundColor Gray
			Write-Host ("Adapter enabled`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.ena) -ForegroundColor Gray
			Write-Host ("DHCP enabled`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.dhcp) -ForegroundColor Gray
			Write-Host ("IP address`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.ip) -ForegroundColor Gray
			Write-Host ("Netmask`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.mask) -ForegroundColor Gray
			Write-Host ("Gateway`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.gate) -ForegroundColor Gray
			Write-Host ("DNS servers`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.dns, "`n") -Separator "" -ForegroundColor Gray
			}

		# GPU block
		Write-Host "GPU" -NoNewLine
		Write-Host " ------------`n" -ForegroundColor DarkGray
		foreach ($tmp in $gpuSQL)
			{
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model) -ForegroundColor Gray
			Write-Host ("Driver`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.driver,"`n") -Separator "" -ForegroundColor Gray
			}

		# MON block
		Write-Host "Monitors" -NoNewLine
		Write-Host " -------`n" -ForegroundColor DarkGray
		foreach ($tmp in $monSQL)
			{
			Write-Host ("Vendor`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.vendor) -ForegroundColor Gray
			Write-Host ("Model`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.model) -ForegroundColor Gray
			Write-Host ("Serial number`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.sn,"`n") -Separator "" -ForegroundColor Gray
			}
		
		# PRN block
		Write-Host "Printers" -NoNewLine
		Write-Host " -------`n" -ForegroundColor DarkGray
		foreach ($tmp in $prnSQL)
			{
			Write-Host ("Name`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.name) -ForegroundColor Gray
			Write-Host ("Default`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.def)-ForegroundColor Gray
			Write-Host ("Shared`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.shared) -ForegroundColor Gray	
			Write-Host ("Port`t`t| ") -NoNewLine -ForegroundColor DarkGray
			Write-Host ($tmp.port,"`n") -Separator "" -ForegroundColor Gray	
			}

		# SOFT block
		Write-Host "Software" -NoNewLine
		Write-Host " -------`n" -ForegroundColor DarkGray -NoNewLine
		$softSQL | Sort-Object Name | Format-Table
		Write-Host ("---`nTotal:", $softSQL.length, "`n")
		}

	# end of main loop
	}
