param
    (
    [parameter(Position=0, Mandatory=$true)]
    [string]$Query
    )
$conf = Get-Content (".\conf")
$connection = New-Object System.Data.SqlClient.SqlConnection("Server=$($conf[0]); Database=$($conf[1]); Trusted_Connection=Yes; Integrated Security=SSPI;")
$connection.Open()
$command = $connection.CreateCommand()
$command.CommandText = $query
$command.CommandTimeout = 0
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter $command
$dataset = New-Object System.Data.DataSet
$adapter.Fill($dataset) | Out-Null
$connection.Close()
$dataset.Tables
