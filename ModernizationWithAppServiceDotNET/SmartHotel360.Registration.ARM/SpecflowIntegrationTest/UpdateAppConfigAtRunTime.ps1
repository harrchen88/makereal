param([Parameter(Mandatory=$True)] [string]$configPath,
          [Parameter(Mandatory=$true)]  [string]$authenticationMode,
          [Parameter(Mandatory=$true)]  [string]$sqlserver,
          [Parameter(Mandatory=$true)]  [string]$databaseName,
          [Parameter(Mandatory=$true)]  [string]$keyVaultUri,
		  [Parameter(Mandatory=$true)]  [string]$servicePrincipalClientId,
		  [Parameter(Mandatory=$true)]  [string]$servicePrincipalPassword)
    
    Write-Output "Loading config file from $configPath"
    $xml = [xml](Get-Content $configPath)

    ForEach($add in $xml.configuration.appSettings.add)
    {
	    Write-Output "Processing AppSetting key $($add.key)"

		if($add.key -eq "AuthenticationMode")
	    {
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $authenticationMode"
            
		    $add.value = $authenticationMode
	    }
	    elseif($add.key -eq "SqlServerName")
	    {
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $sqlserver"
            
		    $add.value = $sqlserver
	    }
        elseif($add.key -eq "DatabaseName")
        {
        
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $databaseName"
            $add.value = $databaseName
        }
        elseif($add.key -eq "KeyVaultUri")
        {
        
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $keyVaultUri"
            $add.value = $keyVaultUri
        }
		 elseif($add.key -eq "ServicePrincipalClientId")
        {
        
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $servicePrincipalClientId"
            $add.value = $servicePrincipalClientId
        }
		 elseif($add.key -eq "ServicePrincipalPassword")
        {
        
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $servicePrincipalPassword"
            $add.value = $servicePrincipalPassword
        }
    }

    $xml.Save($configPath)