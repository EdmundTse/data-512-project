# DATA 512 Project

[DATA 512](https://wiki.communitydata.cc/Human_Centered_Data_Science_(Fall_2018)) is a course on Human Centred Data Science at the University of Washington.

Does it feel like buses are often late or never shows up because it left earlier than expected? For users of bus transit systems in Seattle, buses that cannot be relied upon to be on-time leads to anxiety about making tight connections and as a result might intead choose to commute by car or other means that are less efficient than public mass transit.

King County Metro does measure the on-time reliability of its buses, and makes their performance measurements publicly available within its [2018 System Evaluation](https://kingcounty.gov/depts/transportation/metro/about/accountability-center/performance/route-performance.aspx). Citing traffic congestion and high ridership as contributing factors to unreliability, these metrics were used to identify routes needing additional investment to reach the system's goal. Therefore, we should examine how these metrics were calculated to better understand if these resultant service changes do improve transit rider's experience.

## Data source

Sound Transit manages an [open transit data](https://www.soundtransit.org/help-contacts/business-information/open-transit-data-otd) platform with publicly accessible data for the Puget Sound region, including for King County Metro, and it is available via the OneBusAway API. According to Sound Transit's Open Transit Data GitHub page, the platform offers both static data such as schedules, routes and fares as well as dynamic transit data such as real-time updates and predictive vehicle location information. This [terms of use](https://www.soundtransit.org/help-contacts/business-information/open-transit-data-otd/transit-data-terms-use) allow many uses of this data including their display and analysis.

Two types of data are available in General Transit Feed Specification (GTFS) format via the [OneBusAway API](http://pugetsound.onebusaway.org/p/OneBusAwayApiService.action): static data that describes the bus routes, trips, stops and the timetable; and realtime data for vehicle locations and estimated bus arrival delays at each stop. Since GTFS realtime data is not publicly archived, I need to periodically query the API and save the results for later processing. GTFS static data is easily retrieved since they are delivered in a ZIP file, and changes less often than realtime data.

To collect realtime data, I deployed an [Azure Function](https://docs.microsoft.com/en-us/azure/azure-functions/) to query OneBusAway for King County Metro's realtime updates and save the response in protocol buffers format into [Azure Blob Storage](https://azure.microsoft.com/en-us/services/storage/blobs/). This function is scheduled to run every minute so that I could get the latest bus delay update. This is akin to opening the OneBusAway app and refreshing the feed every minute and looking at all of the bus delay updates for all stops in the service area.

## Project summary

The premise of this project is simply to test what happens to the system evaluation measures if we adjusted their definition. This is because bad measures that don't account for transit users' experience can be deceptive if a bus route were reported as being mostly on-time, but the definition of on-time doesn't match what transit riders would consider as on-time. Since these metrics also inform allocation of investments, it's important that the right metrics are used.

If we adjusted the evaluation criteria in the interest of riders of the transit system, we should expect the reported metrics to worsen. But by how much?

## How to run the code

The data processing and analysis code is provided as a Python 3 Jupyter notebook. Package requirements are listed in the `requirements.txt` file. Due to the file size of the raw protocol buffer API responses, these were not included in the repository, but this raw data after parsing was included as a compressed CSV file in the `data_raw` folder. The code checks that these processed files exist and avoid re-processing from raw files.

If you wish to collect OneBusAway data yourself, the Azure Function code that collects data from the OneBusAway API is included under `src/azure/snapbusrealtime-func`, and the resource group used for this project including Blob Storage resource were exported as a template under `src/azure/arm-template`.