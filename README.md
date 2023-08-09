# drafter
Angular C# MVC NBA Drafting application built for the boys.

version 0.7.0
We are refreshing automatically with new data.

Methodology
I believe in the best possible configuration. When the website has made a change, it will use websockets to send the type of change made, player picked up etc. Then the appropiate components will be re-mounted. 

I think I will probe to check for changes every 5 seconds as this is the easiest way to implement it for now. a 5 second refresh is fine for me at this point.

Next Features Priority
-- Deployment // Done
-- Interval Refresh // 5 seconds but can be improved.
-- Player Pictures // DONE
-- Triple Double etc addition
-- Pick Rater and f you button
-- Next best pick Algorithm
-- Phase 3

Design

screens USER
-- F/A player (with sorting) #Phase 1 complete
-- Other Teams 3 / 4 as it is searchable
-- Your Team, sortable list phase 4
-- Watch list #Phase 4 -- Watch list v2 adding notes and where what pick you think they should go (will highligh if still available). should also be selectable.
-- Timer/Draft State
-- Depth Charts #Phase 3 / 4
-- Projected stats using ESPN projections with our scoring system, last years stats also. Phase 2
-- Next best pick, and next best at position. 
-- fuck you button (if a player was picked that you wanted) Phase 2
-- review pick thats been 1/5 stars Phase 2
-- picks timeline
-- add the message service that appears when you select a row here (row selection > events) https://primeng.org/table#selection-events
-- forecasting 2023-2024 using with our scoring system
-- Have a system that predicts rookies and allows to see only rookies etc, or injured players that didn't play that year. (CHECK INJURY SITUATION. EX. Lonzo Ball is not listed)

screens PRESENTER Phase 3
-- Last pick video // not handled in carousel https://videogular.github.io/ngx-videogular/docs/ this will be a hidden full screen absolute position object. unhides on pick. hides and pauses after certain amount of minutes.
   we need to download the videos locally fml i wanna die, the server will serve them using the wwwroot.
-- Last pick stats
-- other random stats and current teams. 10 second cycle.
-- Next team picking
-- F/A playerlist
-- picks timeline
-- Timer/Draft State
-- End of draft summaries with videos
-- play sound on pick. draft sound. https://stackoverflow.com/questions/44883501/play-sound-in-angular-4
-- Summaries include best team, worst pick, best shooters, tallest team, etc etc. Phase 4

allow setting up of full application under one page infrastructure. Phase 5
-- team/draft create is removed from top menu
-- login and register is removed from top menu to be handled by angular
-- import CSV will seed the players rather than using the command line

Phase 6 AI Adam silver
-- use AI voice generator to create a voice that will announce the picks. 
-- we can leverage a speech to text with a custom AI voice. Or. We can record snips and piece them together to create the total pick announcement
-- P1 {With the {} pick, of the "Draft"}P2{the "team name " selects}P3{ "player" from}P4{the "NBA team"}
-- The wording can be modified for the above as fit

Phase 7, Android/IOS web app 
-- make everything mobile friendly

Phase 8 convert to native app
-- https://betterprogramming.pub/how-to-convert-your-angular-application-to-a-native-mobile-app-android-and-ios-c212b38976df
-- Make sure we are able to change the url string on load, so we can change the server ip where we need to. House to house etc.

PRESENTER IDEA ARCHETECTURE
-- It will be based on a carosel structure, hopefully css can control the animation to switch from slides to fades if need be. -- sorted
-- not sure about the video yet. But hopefully I can rip youtube videos locally. -- this can be an that triggers if pick was < 5 seconds ago. If window is open. play video?
-- we need to hide the values of the picked player if we want it to be a surprise, maybe a 30 second window before a new pick is revealed? depending on a setting.
   meaning we need to create a setting for the draft for this.

screen admin page
-- Settings
-- Start stop timer
-- Upload new players CSV -- THIS WORKS ALREADY, BUT CAN RE-SEED IF I WANT
-- Add and remove players based on master list ## THIS CAN BE DONE VIA DB IF NEEDED
-- Export Final Draft Phase 2

EXTRA FEATURES TO CONSIDER
-- compare players. use a checkbox and it will create a popup that will put all the players together (2 probably) then have red/green text.
-- Addition of rotowire news. see http://nbasense.com/nba-api/StatsProd/StatsCms/Rotowire/RotowirePlayer#request-example player ids are same as here https://www.nba.com/players


Improvements to make
- extract methods from API's to own apis and create services to handle object creation/manipulation. Controllers are doing too much. Phase 4
- Make everything async!!! Very important for these api calls. Remove wait synchronous calls that I had to add. Phase 4
- drafted players should be it's own table, so if we need to remove and reorder players. We can loop through the picked players from pick time and re assign using loop index. 
- change login url and controller routes # Phase 4
- have more than one draft Phase 5 if ever
- have more than one team per user 5 if ever
- remove admin team and user as it's a stupid implementation for it to make the seeder work Phase 5
- pull everything out into services where possible. Rather computing within repositories Phase 4/5
- Dashboard picks API has a very fat unneccessary response
- Pull out mat card when it was implemented in dashboard picks commit 6/7/2023
- Fix API slowness. No idea what's happening here atm.
- Handle draftplayerdashboard exception when drafting a player that's not avaliable.
- draftPlayer picking player does not reset time when done locally.
- Fix timer when it goes into negative
- interval refresh should only refresh if there's new data. I didn't manage to do this but it will help relieve the server if we can implment.
- tickTock() in the timer, we convert to seconds from milliseconds then back to seconds again. This is stupid.

IMPORTANT FIXES TO MAKE
- Pagination resets if I attempt to reload the player picker. So I have disabled it for now.
- You can currently steal other users picks, as well as you can redraft your own players and the picks will be deleted

IMPORTANT COMMANDS

ng build --output-hashing=none "this creates our angular application"

sqllocaldb start ProjectsV13 "Starts required sql server"

dotnet ef migrations add <nameofmigration> "Creates a new migration based on model changes"
dotnet ef database update "Updates database after migrations are made or the db/schema needs to be created."

dotnet run /destory "kills the DB entirely"
dotnet run /seed "imports the players from data/playersMaster"

Deployment

Install .nethosting core hosting bundle 
run app pool as physical windows USER
go to C:\Windows\System32\inetserv\Config and change applicationHost.config file. Make applicationPoolDefaults setProfileEnvironment="true"

follow https://app.pluralsight.com/course-player?clipId=911d1a47-1a19-4bee-90d7-050594ca2e74 as close as possible and look at event viewer logs whenever possible.

use the SQL string when publishing