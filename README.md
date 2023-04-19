# SOTR-Fixer

This is a very simple program geared toward SRT files with a specfic guideline. It aims to go from this:

1
00:00:01.123 -> 00:00:02.456
Hello, my name is John, and welcome to my video.

To this:

1
00:00:01.123 -> 00:00:02.456
[00:00:01] John Doe [00:00:03] Hello, my name is John, and welcome to my video.


Notice how at the beginning of the subtitle, new elements were added as follows: "[start timestamp] speaker name [start timestamp]"

And of course, instead of doing that manually, it was done automatically by way of writing just one letter and a space, then working normally on the subtitle like so:

j Hello, my name is John, and welcome to my video. The program does all the replacing.


This WPF program will work as follows: One button to open an SRT file, a second button to transform it to the desired format and a third button to open the final file.

There will be another pane in which to set which letter goes with which name to perform the transformation.
