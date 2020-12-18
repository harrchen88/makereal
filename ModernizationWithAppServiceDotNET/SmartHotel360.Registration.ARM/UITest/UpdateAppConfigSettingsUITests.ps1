param([Parameter(Mandatory=$True)] [string]$configPath,
          [Parameter(Mandatory=$true)]  [string]$webPortalUrl)
    
    Write-Output "Loading config file from $configPath"
    $xml = [xml](Get-Content $configPath)

    ForEach($add in $xml.configuration.appSettings.add)
    {
	    Write-Output "Processing AppSetting key $($add.key)"

	    if($add.key -eq "WebAppPortalUrl")
	    {
		    Write-Output "Found matching variable for key: $($add.key)"
		    Write-Output "Replacing value $($add.value)  with $webPortalUrl"
            
		    $add.value = $webPortalUrl
	    }
    }

    $xml.Save($configPath)