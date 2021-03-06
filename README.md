<!--Category:Powershell--> 
 <p align="right">
    <a href="https://www.powershellgallery.com/packages/ProductivityTools.SportsTracker/"><img src="Images/Header/Powershell_border_40px.png" /></a>
    <a href="http://productivitytools.tech/sports-tracker-cmdlet//"><img src="Images/Header/ProductivityTools_green_40px_2.png" /><a> 
    <a href="https://github.com/ProductivityTools-TrainingLog/ProductivityTools.SportsTracker.SDK"><img src="Images/Header/Github_border_40px.png" /></a>
</p>
<p align="center">
    <a href="http://productivitytools.tech/">
        <img src="Images/Header/LogoTitle_green_500px.png" />
    </a>
</p>

# Sports Tracker Cmdlet
 
PowerShell module which allows to manage trainings on the https://sports-tracker.com/ website.

<!--more-->
It exposes following commands
 ```powershell
Add-Training
Get-Trainings
```
Login and Password can be provided with [PowerShell Master Configuration](http://productivitytools.tech/powershell-master-configuration/) or parameter.

## Example
```powershell
Add-Training -TrainingType AlpineSkiing -Description "description" -Duration 20 -Date "2020.02.26" -Time "08:09" -Distance 69

Add-Training -TrainingType AlpineSkiing -Description "description" -Duration 20 -Date "2020.02.26" -Time "08:09" -Distance 69 -Login pawel@pawel.pl -Password "fdsa" -Verbose
```
 
 ![Cmdlet Example](Images/TrainingCmdlet.png)

 After adding training through module we can see it in the portal.
 <!--og-image-->
 ![Example](Images/TrainingAdded.png)
 .
