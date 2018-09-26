$conf = Get-Content (".\conf")
$connection = New-Object System.Data.SqlClient.SqlConnection("Server=$($conf[0]); Database=$($conf[1]); Trusted_Connection=Yes; Integrated Security=SSPI;")
$connection.Open()
$command = $connection.CreateCommand()
$command.CommandText = "EXEC sp_MSforeachtable 'DROP TABLE ?'"
$command.CommandTimeout = 0
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter $command
$dataset = New-Object System.Data.DataSet
$adapter.Fill($dataset) | Out-Null
if ($dataset.Tables[0] -ne $null) {$table = $dataset.Tables[0]}
elseif ($table.Rows.Count -eq 0) {$table = New-Object System.Collections.ArrayList}
$table
$connection.Close()
