# drafter
React NBA Drafting application built for the boys.

version 0.0.2. Init

Structure.

React with polling https://developer.okta.com/blog/2018/09/25/spring-webflux-websockets-react // possible move to server-sent-events
Front-End And Backend setup with JSON API

Methodology

I believe in the best possible configuration. When the website has made a change, it will use websockets to send the type of change made, player picked up etc. Then the appropiate components will be re-mounted. 

Design

screens USER
-- F/A player (with sorting)
-- Other Teams
-- Your Team
-- Timer/Draft State

screens PRESENTER
-- Last pick video
-- Last pick stats
-- Next team picking
-- F/A playerlist 
-- Timer/Draft State

screen admin page
-- Settings
-- Start stop timer
-- Upload new players CSV
-- Add and remove players based on master list
