# DATA512 Project Plan: Reliability metrics for King County Metro bus service

## Introduction

Does it feel like buses are often late or never shows up because it left earlier than expected? King County Metro measures the on-time reliability of its buses, and it reported in its [2018 System Evaluation](https://kingcounty.gov/depts/transportation/metro/about/accountability-center/performance/route-performance.aspx) that some of its bus routes are unreliable and cites traffic congestion and high ridership as contributing factors. They use this on-time reliability measure to identify routes needing additional investment, based on how much time must be added to schedules to reach the system's goal. Sound Transit also publishes service quality metrics by route for its buses in its [2019 Service Implementation Plan](https://www.soundtransit.org/get-to-know-us/documents-reports/2019-service-implementation-plan-draft) as part of the planning process to determine if service changes are needed.

The King County Metro bus system's goal is for each route to have fewer than 20 percent of recorded late arrivals for all-day measures, or fewer than 35 percent for the weekday PM peak period. For Sound Transit, their [service standards and performance measures](https://www.soundtransit.org/get-to-know-us/documents-reports/2018-service-standards-performance-measures) quotes what seems to be a more stringent threshold of less than 15% of late bus trips overall.

Besides the difference in key performance indicator threshold, the most interesting difference is how the two agencies define what constitutes lateness. King County Metro considers a scheduled stop to be on-time if the bus arrived at its stop from 1.5 minutes before to 5.5 minutes after its scheduled time, and each of these stops are tallied into an on-time performance metric. On the other hand, Sound Transit primarily uses bus departure time as opposed to arrival time at a bus stop. Their performance standard requires a bus trip to depart no more than 3 minutes late from its start, no more than 5 minutes late from the route's midpoint and arrive no more than 7 minutes late at its terminus. At each of these three checkpoints the buses must never depart early. These data points are then aggregated to produce an overall performance measure.

Despite both being a commuter bus service and with some overlapping service areas, the on-time reliability metrics are markedly different between the two. Why is there such a large difference in performance target between the two, and why is there a different interpretation of what it means for a bus route to be considered on-time? Perhaps to determine the right criteria for timeliness we should consider what is important for transit riders using the bus service. Are those factors accounted for in the evaluation metric used? Raw data are facts; the human-centred aspect of this is how this data is interpreted and reported.

This project aims to augment King County Metro's system evaluation report with an alternative set of measures, such as using the evaluation criteria used by Sound Transit or another set of measures we define as useful from the transit riders' perspective:

* How much time should people expect to wait for a bus past its scheduled time?
* Which routes are most likely to depart its stops earlier than scheduled?
* What would the reliability measure of bus routes be, if we used different criteria to determine if it is on-time?

## Plan

Sound Transit manages an [open transit data](https://www.soundtransit.org/help-contacts/business-information/open-transit-data-otd) platform with publicly accessible data for the Puget Sound region, including for King County Metro, and it is available via the OneBusAway API. According to Sound Transit's Open Transit Data GitHub page, the platform offers both static data such as schedules, routes and fares as well as dynamic transit data such as real-time updates and predictive vehicle location information. This [terms of use](https://www.soundtransit.org/help-contacts/business-information/open-transit-data-otd/transit-data-terms-use) allow many uses of this data including their display and analysis.

My plan is to collect King County Metro's bus timetable and real-time data, and evaluate its on-time reliability according to their own performance indicator as well as some alternatives such as:

* What if we consider all early departures from a schedule stop to be not on-time? i.e. use Sound Transit's definition of being on-time: never depart early and up to 5 minutes past the scheduled time.
* What if we consider a bus trip to be unreliable if any of its stops were not on-time, and then require fewer than 20 percent of all scheduled bus trips to be reliable (counting reliable trips instead of counting individual stops)
* Should we separate peak hour stops into its own category for on-time reliability calculation with a higher late tolerance, or treat them all equally as Sound Transit does?

Afterwards, we'll explore how different interpretations what a reliably on-time bus system is affects the reported performance in the system scorecard. The system evaluation report provides data on route reliability in terms of percent of late stops split into different periods: all-day, weekday PM peak, Saturday and Sunday. We can compare how these scores by route changes when we redefine the bus timeliness criteria.

## Dependencies and unknowns

The OneBusAway mobile app can show when buses are early or late, delivered on a real-time basis. Specifically, I could see when a bus departed a stop early or late, and by how many minutes. Ideally, I would like to work with pre-processed historical bus arrival times, but it is yet unclear if this is easily accessible as a bulk data export or if I would need to make multiple requests to the OneBusAway API to obtain this data the entire period of interest.

## Human-centred design considerations

As a regular user of the bus transit system, I notice that buses often run later than their scheduled time. I have also experienced waiting for a bus at a bus top but the bus never showed up, which could be explained by the bus arriving earlier than scheduled and therefore I have missed the bus even though I was at the stop before the scheduled time. With a curiosity of the on-time reliability, I found a detailed system evaluation report that already analyses performance by route. However, I was surprised that the criteria for determining if a bus was on-time allowed for running up to 1.5 minutes early, so I think it would be an interesting exercise to see what the performance measures would be if this was not the case, and test other criteria more favourable to users of this transit system.

Human-centred design influence in this project takes the form of a closer examination of the system's performance evaluation. The performance measure currently used by King County Metro seems to adequately test outcomes against the planned bus schedule within a tolerance in either direction, but does it bias against the transit users' wishes to not miss their bus if they arrived to wait at their bus stop ahead of the schedule time only to find the bus departed early?

The published system evaluation report also separated the weekday PM stops into a separate category with a more permissive tolerance before considering a route to be late. Is this also a system-centric evaluation method that allows buses to be less timely during times of stress, or should we take a more user-centric and continue to hold the system to the same quality of service relative to what the transit user desires?

This work will test the on-time reliability measure's sensitivity to different definitions of lateness as well as different aggregations for reporting and if more work is needed to ensure the methodologies chosen is aligned with transit riders' expectations.