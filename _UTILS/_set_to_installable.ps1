# Path to the settings.ini file
$filePath = "VampirioCode\settings.ini"

# Read the file and convert the JSON into a PowerShell object
$config = Get-Content -Path $filePath -Raw | ConvertFrom-Json

# Check the current state of "portable"
Write-Host "The current value of 'portable' is: $($config.portable)"

# Or, if you want to force it to a specific value:
$config.portable = $false

# Convert the object back to JSON and save the file
$config | ConvertTo-Json -Depth 10 | Set-Content -Path $filePath

# Verify the new state
Write-Host "The new value of 'portable' is: $($config.portable)"
