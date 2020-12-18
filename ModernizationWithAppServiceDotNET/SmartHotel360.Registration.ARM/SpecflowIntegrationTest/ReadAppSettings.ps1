    param([Parameter(Mandatory=$True)] [string]$config)
    $configPath = "$config"

    Write-Output "Loading config file from $configPath"
    $xml = [xml](Get-Content $configPath)

    ForEach($add in $xml.configuration.appSettings.add)
    {
	    Write-Output "AppSetting $($add.key): $($add.value)"
    }