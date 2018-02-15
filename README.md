# Simple-PSN-Registration-Bot
A automated tool to create accounts for playstation network

## GUI
<p align="center">
<img alt="..." src="https://i.imgur.com/BidCLWz.png" />
</p>

## Usage
All you need to do is compile the code using Visual Studio and run the project.

If you wish to use the automated account creating feature please update the string 'captchaApiKey' in the file 'Main.cs', this needs to be filled with a Captcha API Key from http://2captcha.com.

Otherwise you must provide a new captcha token for each account creation attempt.

To do this manually you first must install this tamper monkey script I created: https://greasyfork.org/en/scripts/38215-recaptcha

Next navigate to this address: https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account.action

Now all you need to do is complete the captcha and copy the token that shows up in the big textbox, then in the program click the create account button and a popup should show up asking for the token, just paste the token in to the box and continue.

## Updates
I will keep this bot updated as much as I can, I will be pushing a lot of updates to clean up the code.

## Issues
Please either create an issue on this git or contact me on discord: Sloth#4064
