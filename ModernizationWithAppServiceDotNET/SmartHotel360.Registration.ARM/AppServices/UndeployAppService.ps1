Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] [Parameter(Mandatory=$true)] $WebAppName,
    [string] [Parameter(Mandatory=$true)] $AppServicePlanName,
    [string] [Parameter(Mandatory=$true)] $SqlServerName,
    [string] [Parameter(Mandatory=$true)] $AppInsightsName
)

# Sample values
#$ResourceGroupName = 'Dojo-Booking-Dev'
#$WebAppName = 'dojo-bookings-app-dev'
#$AppServicePlanName = 'dojo-bookings-plan-sv2mlcp36rlry'
#$SqlServerName = 'dojo-bookings-server-sv2mlcp36rlry'
#$AppInsightsName = 'dojo-bookings-app-dev'

# Below commands don't raise error if the resource doesn't exist, so no need to check for existence.

Write-Host 'Deleting web app:' $WebAppName
Remove-AzWebApp -ResourceGroupName $ResourceGroupName -Name $WebAppName -Force

Write-Host 'Deleting app service plan:' $AppServicePlanName
Remove-AzAppServicePlan -ResourceGroupName $ResourceGroupName -Name $AppServicePlanName -Force

Write-Host 'Deleting app insights:' $AppInsightsName
Remove-AzApplicationInsights -ResourceGroupName $ResourceGroupName -Name $AppInsightsName

$sqlserver = (Get-AzSqlServer | Where-Object{$_.ServerName -eq $SqlServerName})

if($sqlserver -ne $null)
{
    Write-Host 'Deleting sql server:' $SqlServerName
    Remove-AzSqlServer -ResourceGroupName $ResourceGroupName -ServerName $SqlServerName -Force
}