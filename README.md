# NijiLive
- What does this programm do:

Checks what YT channels out of a given list are currently streaming.

- Why does this exist:

Following a massive amount of YT channels that focus on live streaming can easily clutter up the subfeed with streaming VODs.
While some companies offer websites of their own to see wich of their talent is currently streaming, for talent of other companies aswell
as independant streamers there is no way to easily check wether they are streaming outside of manually looking up each channel.

- How does it work:

The App sends a HTTP-GET to each channel's livestream URL and analyses the returned HTML to find out wether it is currently live or not.
It does not use the YT-API due to there not being a way to check the livestream status of channels that aren't yours.

- How to use:

First either download the NijiLive.v1.0.rar (top right of this page under category "Releases") or build the programm yourself using the source code.
When you open the programm it will look like this:
![alt text](https://i.imgur.com/SovM1Aw.png)

If you downloaded the release version or already have a channel list you can click on Load List and select the list you want to load. It will then display all the
channels in that list like this:
![alt test](https://i.imgur.com/l2WYsJw.png)

The Filters on the side can be used to change what items are displayed in your list. Selecting none will display the full list.

Selecting one or more of the channels and clicking the "Remove Ch." button will delete them from the list.

Selecting one channel and clicking the "Edit Channel" button will open a window that lets you edit the channel information (more info on the Add/Edit Window below).

The "add to current list" option will make it so that if you load another list it won't replace the current one but instead add all non duplicate channels to the current list.

Clicking the "Check Live" button will send a HTTP-Get request for each channel in the list. Depending on your internet speed and amount of channels in the list this might
take a while (for reference i have 500kbs-1mb download and while testing the default list of around 100 channels it took about a minute). While sending requests the UI will look
like this:

![alt-text](https://i.imgur.com/yE1Sm3v.png)

After all requests are completed and the programm has checked what channels are live the UI will look like this:

![alt-text](https://i.imgur.com/BONCjZp.png)

Channels that are currently live will be on the top of the list. Double clicking on an entry will open the livestream link in your system's default browser (this also works
for channels that are not live). 

If you click on "Add Channel" or "Edit Channel" a window that looks like this will open:

![alt-text](https://i.imgur.com/ijucPxu.png)

Note that you cannot add a channel with a name or an URL that is already on the list.

IMPORTANT: Channel ULRs have to look like this: https://www.youtube.com/channel/UC_a1ZYZ8ZTXpjg9xUY9sj8w

eg. https://www.youtube.com/channel/ {ID} , do NOT add /live at the end as the programm automatically does that. 
Clicking on a channel in your YT subscription list should lead you to an URL like this anyway. 
If you have trouble finding the channel ID of a YT channel you can also use: https://commentpicker.com/youtube-channel-id.php

(Note: VirtualYoutuberWiki also links channels using their ID so you can copy it from there aswell.)

The Agency field checks if you entered something (if the streamer is independant just enter independant), Region is simply any 2 letters and there are no checks for the
Gen field.

You can double check if the channel was added correctly by double clicking the channel in the list, even if the channel isn't live the link will direct
you to their channel page.

- Dependencies (Json/.Net):

This programm uses Newtensoft.Json to serialize the lists and therefore needs the Newtensoft.Json.dll to run. This programm will only run on Windows
and requires .Net Framework 4.7.2 or newer.

Json File Structure looks like this:

![alt-text](https://i.imgur.com/Qq2BdGU.png)

- Misc (False Positives/Contact/Image Info):

Potentially might trigger a false positive on Windows Defender, during testing on a friend's PC it got flagged as "Trojan:Script/Wacatac.B!ml". I suspect this is
either due to the programm being able to make a rather large amount of web requests or it calling your system's default browser when you double click on a channel.
Anyway if you are worried about this being a trojan you can either read through the code and build it yourself (main reason why i made this open source), only use it
in a safe environment (eg. VM), scan it on sites like VirusTotal (https://www.virustotal.com/gui/) or simply pass on using it altogether. For reference this is the link
to the VirusTotal page when i uploaded the NijiLive v1.0.rar: 

https://www.virustotal.com/gui/file/1aea8bb5359b4ca8790747645d17b004486d796a850e6a894c705aab909aa755/detection
![alt-text](https://i.imgur.com/PEw0yqZ.png)

If you find any bug and don't want to use GitHub yourself you can contact me on Discord "really bad meme#7036".

All images used in this ReadMe are hosted on imgur.com
