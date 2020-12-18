Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName,
    [string] [Parameter(Mandatory=$true)] $StorageAccountName,
    [string] [Parameter(Mandatory=$true)] $TableName,
    [string] [Parameter(Mandatory=$true)] $Variables,
    [string] [Parameter(Mandatory=$true)] $VariableGroup
)

# Sample values
#$ResourceGroupName='Dojo-Booking-Dev'
#$StorageAccountName='dojosharedaccount'
#$TableName='dojosharedvariables'
#$Variables='armoutputdev,.AppServiceApplicationUrl,Path'
#$VariableGroup='111'

Install-Module AzTable -Scope CurrentUser

$rg = Get-AzResourceGroup -Name $ResourceGroupName;
$location = $rg.Location;

# Create the storage account.
$storageAccount = (Get-AzStorageAccount | Where-Object{$_.StorageAccountName -eq $StorageAccountName})

if($storageAccount -eq $null)
{
    Write-Host 'Creating storage account:',$StorageAccountName;
    $storageAccount = New-AzStorageAccount -ResourceGroupName $ResourceGroupName `
      -Name $StorageAccountName `
      -SkuName Standard_LRS `
      -Location $location `
      -Kind Storage
}

$ctx = $storageAccount.Context

# Create the shared table.
$storageTable = (Get-AzStorageTable –Context $ctx | Where-Object{$_.Name -eq $TableName})

if($storageTable -eq $null)
{
    Write-Host 'Creating storage table:',$TableName
    $storageTable = New-AzStorageTable –Name $TableName –Context $ctx
}

$cloudTable = $storageTable.CloudTable

# Get variable values.
$envs = (Get-ChildItem env:)

foreach ($var in $Variables.Split(","))
{
    $env = $envs | Where-Object{$_.Name -eq $var}

    if($env -ne $null)
    {
        # Add the variable to table.
        Write-Host 'Adding' $var 'to table storage.'#: $env.Value 
        try{
            Add-AzTableRow `
                -table $cloudTable `
                -partitionKey $VariableGroup `
                -rowKey ($var) -property @{"value"=$env.Value}
        }
        catch {
            # TODO: Update the record.
        }
    }
    else
    {
        Write-Host 'NOT FOUND' $var
    }
}