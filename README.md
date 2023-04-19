# drafter
React NBA Drafting application built for the boys.

version 0.1.0 C# razorpage edition

Structure.

React with polling https://developer.okta.com/blog/2018/09/25/spring-webflux-websockets-react // possible move to server-sent-events
Front-End And Backend setup with JSON API// perhaps spring boot and spring 5 with https://www.baeldung.com/spring-webflux

Methodology

I believe in the best possible configuration. When the website has made a change, it will use websockets to send the type of change made, player picked up etc. Then the appropiate components will be re-mounted. 

Design

screens USER
-- F/A player (with sorting)
-- Other Teams
-- Your Team
-- Timer/Draft State
-- Depth Charts
-- Projected stats using ESPN projections with our scoring system, last years stats also.
-- Next best pick, and next best at position.
-- fuck you button (if a player was picked that you wanted)
-- review pick thats been 1/5 stars
-- picks timeline

screens PRESENTER
-- Last pick video
-- Last pick stats
-- Next team picking
-- F/A playerlist
-- picks timeline
-- Timer/Draft State
-- End of draft summaries with videos
-- Summaries include best team, worst pick, best shooters, tallest team, etc etc.

screen admin page
-- Settings
-- Start stop timer
-- Upload new players CSV -- THIS WORKS ALREADY, BUT CAN RE-SEED IF I WANT
-- Add and remove players based on master list ## THIS CAN BE DONE VIA DB IF NEEDED
-- Export Final Draft